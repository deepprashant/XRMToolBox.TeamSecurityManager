using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PKM.XRMToolBox.TeamSecurityManager.Model;
using System.IO;

namespace PKM.XRMToolBox.TeamSecurityManager.View
{
    public partial class UserSecurityReport : UserControl
    {
        private BindingSource bindingSourceRole = new BindingSource();
        private BindingSource bindingSourceTeam = new BindingSource();
        private BindingSource bindingSourceProfile = new BindingSource();
        DataTable roleReport;
        DataTable filteredRoleReport;
        DataTable teamReport;
        DataTable filteredTeamReport;
        DataTable profileReport;
        DataTable filteredProfileReport;

        public IUSMView ParentView { get; set; }
        public List<UserModel> Users { get; set; }
        public List<TeamModel> Teams { get; set; }
        public List<RoleModel> Roles { get; set; }
        public List<FieldSecurityModel> FieldSecurities { get; set; }        
        public List<UserTeamModel> UserTeam { get; set; }
        public List<TeamRoleModel> TeamRole { get; set; }
        public List<UserFieldSecurityModel> UserFieldSecurity { get; set; }
        public List<TeamFieldSecurityModel> TeamFieldSecurity { get; set; }

        public UserSecurityReport()
        {
            InitializeComponent();
            dataGridViewRole.DataSource = bindingSourceRole;
            dataGridViewTeam.DataSource = bindingSourceTeam;
            dataGridViewProfile.DataSource = bindingSourceProfile;
        }

        public void DisplayReport(IUSMView parentView, List<UserModel> users, List<TeamModel> teams, List<RoleModel> roles, List<FieldSecurityModel> fieldSeurity, List<UserRoleModel> userRoles
            , List<UserTeamModel> userTeams, List<TeamRoleModel> teamRoles, List<UserFieldSecurityModel> userFieldSecurity, List<TeamFieldSecurityModel> teamFieldSecurity)
        {
            ParentView = parentView;
            Users = users;
            Teams = teams;
            Roles = roles;
            FieldSecurities = fieldSeurity;
            UserTeam = userTeams;
            TeamRole = teamRoles;
            UserFieldSecurity = userFieldSecurity;
            TeamFieldSecurity = teamFieldSecurity;

            GenerateTeamRoleReport();
            GenerateTeamMemberReport();
            GenerateTeamProfileReport();
        }

        private void GenerateTeamRoleReport()
        {
            roleReport = new DataTable("Team Role Report");
            roleReport.Columns.Add("UniqueName");
            roleReport.Columns.Add("Name");
            roleReport.Columns.Add("Default Team");
            roleReport.Columns.Add("Team Type");
            roleReport.Columns.Add("Business Unit");
            foreach (string roleName in Roles.Select(a => a.FullName).Distinct())
            {
                roleReport.Columns.Add(roleName);
            }

            foreach (TeamModel team in Teams)
            {
                var currentTeamRoles = (from tr in TeamRole where tr.Team.CrmId == team.CrmId select tr.Role.FullName).ToList();
                DataRow row = roleReport.NewRow();
                row["UniqueName"] = string.Format("{0}-{1}", team.BUName, team.FullName);
                row["Name"] = team.FullName;
                row["Default Team"] = team.IsDefault;
                row["Team Type"] = team.TeamType;
                row["Business Unit"] = team.BUName;

                foreach (string roleName in currentTeamRoles)
                {
                    row[roleName] = "Yes";
                }

                roleReport.Rows.Add(row);               
            }
        }

        private void DisplayTeamRoleReport()
        {
            if (this.cbSelectedTeams.Checked)
            {
                List<TeamModel> selectedTeams = ParentView.GetCheckedTeams();
                if (selectedTeams.Count > 0)
                {
                    var teamUniqueNames = selectedTeams.Select(a => string.Format("{0}-{1}", a.BUName, a.FullName));
                    filteredRoleReport = (from row in roleReport.AsEnumerable()
                                          where teamUniqueNames.Contains(row.Field<string>("UniqueName"))
                                          select row).CopyToDataTable();
                }
                else
                {
                    filteredRoleReport = null;
                }
            }
            else
            {
                filteredRoleReport = roleReport.Select().CopyToDataTable();
            }

            if (this.cbNotNull.Checked && filteredRoleReport != null)
            {
                foreach (var column in filteredRoleReport.Columns.Cast<DataColumn>().ToArray())
                {
                    if (filteredRoleReport.AsEnumerable().All(dr => dr.IsNull(column)))
                        filteredRoleReport.Columns.Remove(column);
                }
            }

            bindingSourceRole.DataSource = filteredRoleReport;
        }

        private void GenerateTeamMemberReport()
        {
            teamReport = new DataTable("Team Members Report");
            teamReport.Columns.Add("UniqueName");
            teamReport.Columns.Add("Name");
            teamReport.Columns.Add("Default Team");
            teamReport.Columns.Add("Team Type");
            teamReport.Columns.Add("Business Unit");
            foreach (var user in Users)
            {
                teamReport.Columns.Add(string.Format("{0} ({1})", user.FullName, user.DomainName));
            }

            foreach (TeamModel team in Teams)
            {
                DataRow row = teamReport.NewRow();
                row["UniqueName"] = string.Format("{0}-{1}", team.BUName, team.FullName);
                row["Name"] = team.FullName;
                row["Default Team"] = team.IsDefault;
                row["Team Type"] = team.TeamType;
                row["Business Unit"] = team.BUName;
                foreach (var teamMembers in UserTeam.Where(a => a.Team.CrmId == team.CrmId))
                {
                    row[string.Format("{0} ({1})", teamMembers.User.FullName, teamMembers.User.DomainName)] = "Member";
                }

                teamReport.Rows.Add(row);
            }           
        }

        private void DisplayTeamMemberReport()
        {
            if (this.cbSelectedTeams.Checked)
            {
                List<TeamModel> selectedTeams = ParentView.GetCheckedTeams();
                if (selectedTeams.Count > 0)
                {
                    var teamUniqueNames = selectedTeams.Select(a => string.Format("{0}-{1}", a.BUName, a.FullName));
                    filteredTeamReport = (from row in teamReport.AsEnumerable()
                                          where teamUniqueNames.Contains(row.Field<string>("UniqueName"))
                                          select row).CopyToDataTable();
                }
                else
                {
                    filteredTeamReport = null;
                }
            }
            else
            {
                filteredTeamReport = teamReport.Select().CopyToDataTable();
            }

            if (this.cbNotNull.Checked && filteredTeamReport != null)
            {
                foreach (var column in filteredTeamReport.Columns.Cast<DataColumn>().ToArray())
                {
                    if (filteredTeamReport.AsEnumerable().All(dr => dr.IsNull(column)))
                        filteredTeamReport.Columns.Remove(column);
                }
            }

            bindingSourceTeam.DataSource = filteredTeamReport;
        }

        private void GenerateTeamProfileReport()
        {
            profileReport = new DataTable("Team Profile Report");
            profileReport.Columns.Add("UniqueName");
            profileReport.Columns.Add("Name");
            profileReport.Columns.Add("Default Team");
            profileReport.Columns.Add("Team Type");
            profileReport.Columns.Add("Business Unit");
            foreach (string profileName in FieldSecurities.Select(a => a.FullName).Distinct())
            {
                profileReport.Columns.Add(profileName);
            }

            foreach (TeamModel team in Teams)
            {
                var currentUserDirectProfiles = from tf in TeamFieldSecurity where tf.Team?.CrmId == team.CrmId select tf.FieldSecurity.FullName;               
                DataRow row = profileReport.NewRow();
                row["UniqueName"] = string.Format("{0}-{1}", team.BUName, team.FullName);
                row["Name"] = team.FullName;
                row["Default Team"] = team.IsDefault;
                row["Team Type"] = team.TeamType;
                row["Business Unit"] = team.BUName;
                foreach (string profileName in currentUserDirectProfiles)
                {
                    row[profileName] = "Yes";
                }

                profileReport.Rows.Add(row);
            }
        }

        private void DisplayTeamProfileReport()
        {
            if (this.cbSelectedTeams.Checked)
            {
                List<TeamModel> selectedTeams = ParentView.GetCheckedTeams();
                if (selectedTeams.Count > 0)
                {
                    var teamUniqueNames = selectedTeams.Select(a => string.Format("{0}-{1}", a.BUName, a.FullName));
                    filteredProfileReport = (from row in profileReport.AsEnumerable()
                                          where teamUniqueNames.Contains(row.Field<string>("UniqueName"))
                                          select row).CopyToDataTable();
                }
                else
                {
                    filteredProfileReport = null;
                }
            }
            else
            {
                filteredProfileReport = profileReport.Select().CopyToDataTable();
            }

            if (this.cbNotNull.Checked && filteredProfileReport != null)
            {
                foreach (var column in filteredProfileReport.Columns.Cast<DataColumn>().ToArray())
                {
                    if (filteredProfileReport.AsEnumerable().All(dr => dr.IsNull(column)))
                        filteredProfileReport.Columns.Remove(column);
                }
            }

            bindingSourceProfile.DataSource = filteredProfileReport;
        }

        private string DataTableToCSV(DataTable datatable, string fileName, char seperator = ',')
        {
            if (datatable == null)
            {
                return "No data available to generate report.";
            }

            try
            {
                StringBuilder sb = new StringBuilder();
                if (!File.Exists(fileName))
                {
                    for (int i = 0; i < datatable.Columns.Count; i++)
                    {
                        sb.Append(datatable.Columns[i]);
                        if (i < datatable.Columns.Count - 1)
                            sb.Append(seperator);
                    }
                    sb.AppendLine();
                }
                foreach (System.Data.DataRow dr in datatable.Rows)
                {
                    for (int i = 0; i < datatable.Columns.Count; i++)
                    {
                        sb.Append(dr[i].ToString().Replace(',', '-'));

                        if (i < datatable.Columns.Count - 1)
                            sb.Append(seperator);
                    }
                    sb.AppendLine();
                }
                if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                }

                File.AppendAllText(fileName, sb.ToString());

                return "Report Generated.";
            }
            catch (Exception ex)
            {
                return "Report Failed, Exception: " + ex.Message;
            }
        }

        private void tabReport_TabIndexChanged(object sender, EventArgs e)
        {
            var tab = (TabControl)sender;
            string aa = tab.SelectedTab.Name;
        }

        private void RefreshUI(string tabName)
        {
            DisplayTeamMemberReport();
            DisplayTeamProfileReport();
            DisplayTeamRoleReport();
        }

        private void tsbBack_Click(object sender, EventArgs e)
        {
            ParentView.HideDownloadControls();
        }

        private void tsbRunReport_Click(object sender, EventArgs e)
        {
            RefreshUI(this.tabReport.SelectedTab.Name);
        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            if (cbTeamRoles.Checked || cbTeamMembers.Checked || cbTeamProfiles.Checked)
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    StringBuilder message = new StringBuilder();
                    var response = string.Empty;
                    if (cbTeamRoles.Checked == true)
                    {
                        response = DataTableToCSV(filteredRoleReport, string.Format("{0}\\TeamRoles_{1}.csv", folderDlg.SelectedPath, DateTime.Now.ToFileTime()));
                        message.Append("Team Roles     : " + response);
                    }

                    if (cbTeamMembers.Checked == true)
                    {
                        message.Append(Environment.NewLine);
                        response = DataTableToCSV(filteredTeamReport, string.Format("{0}\\TeamMembers_{1}.csv", folderDlg.SelectedPath, DateTime.Now.ToFileTime()));
                        message.Append("Team Members   : " + response);
                    }

                    if (cbTeamProfiles.Checked == true)
                    {
                        message.Append(Environment.NewLine);
                        response = DataTableToCSV(filteredProfileReport, string.Format("{0}\\TeamProfiles_{1}.csv", folderDlg.SelectedPath, DateTime.Now.ToFileTime()));
                        message.Append("Team Profiles  : " + response);
                    }

                    MessageBox.Show(message.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select report(s) to download.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gbDownloadOptions.Focus();
            }
        }
    }
}
