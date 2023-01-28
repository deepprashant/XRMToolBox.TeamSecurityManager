using Microsoft.Xrm.Sdk;
using PKM.XRMToolBox.TeamSecurityManager.CustomEvent;
using PKM.XRMToolBox.TeamSecurityManager.Model;
using PKM.XRMToolBox.TeamSecurityManager.Presenter;
using PKM.XRMToolBox.TeamSecurityManager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace PKM.XRMToolBox.TeamSecurityManager.UserControls
{
    public partial class USMView : UserControl, IUSMView
    {
        //IOrganizationService _service;        
        IUSMPresenter presenter;
        private List<UserModel> users;
        private List<TeamModel> teams;
        private List<RoleModel> roles;
        private List<FieldSecurityModel> fieldSecurity;
        private List<BUModel> bus;
        private List<UserRoleModel> userRole;
        private List<UserTeamModel> userTeam;
        private List<TeamRoleModel> teamRole;

        private List<UserFieldSecurityModel> userFieldSecurity;
        private List<TeamFieldSecurityModel> teamFieldSecurity;


        private CustomListViewSorter userSorter;

        private BUModel currentBU;

        public IUSMPresenter Presenter
        {
            get
            {
                return presenter;
            }
            set
            {
                presenter = value;
            }
        }
        public List<UserModel> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                //DisplayUsers();
            }
        }
        public List<TeamModel> Teams
        {
            get
            {
                return teams;
            }
            set
            {
                teams = value;
                DisplayTeams();
            }
        }
        public List<RoleModel> Roles
        {
            get
            {
                return roles;
            }
            set
            {
                roles = value;
            }
        }

        public List<FieldSecurityModel> FieldSecurity
        {
            get
            {
                return fieldSecurity;
            }
            set
            {
                fieldSecurity = value;
            }
        }

        public List<UserRoleModel> UserRole
        {
            get
            {
                return userRole;
            }
            set
            {
                userRole = value;
            }
        }
        public List<UserTeamModel> UserTeam
        {
            get
            {
                return userTeam;
            }
            set
            {
                userTeam = value;
            }
        }
        public List<TeamRoleModel> TeamRole
        {
            get
            {
                return teamRole;
            }
            set
            {
                teamRole = value;
            }
        }
        public List<UserFieldSecurityModel> UserFieldSecurity
        {
            get
            {
                return userFieldSecurity;
            }
            set
            {
                userFieldSecurity = value;
            }
        }

        public List<TeamFieldSecurityModel> TeamFieldSecurity
        {
            get
            {
                return teamFieldSecurity;
            }
            set
            {
                teamFieldSecurity = value;
            }
        }

        public List<TeamModel> SelectedTeams { get; set; }
        public List<BUModel> BUs
        {
            get
            {
                return bus;
            }
            set
            {
                bus = value;
                DisplayBUs();
            }
        }
        public PluginControlBase TopParentControl { get; set; }

        public USMView()
        {
            InitializeComponent();
            HideDownloadControls();
            multiSelectRoles.HideBUColum();
            multiSelectFS.HideBUColum();

            multiSelectUsers.RecordUnAssigned += MultiSelectUsers_RecordUnAssigned;
            multiSelectUsers.RecordAssigned += MultiSelectUsers_RecordAssigned;
            multiSelectRoles.RecordUnAssigned += MultiSelectRoles_RecordUnAssigned;
            multiSelectRoles.RecordAssigned += MultiSelectRoles_RecordAssigned;
            multiSelectFS.RecordUnAssigned += MultiSelectFS_RecordUnAssigned;
            multiSelectFS.RecordAssigned += MultiSelectFS_RecordAssigned;

            userSorter = new CustomListViewSorter(this.listViewTeams, 4);
            //allRoleSorter = new CustomListViewSorter(this.listViewAllRoles, 3);
            //allFSSorter = new CustomListViewSorter(this.lvAllFSP, 3);
        }

        public void FetchCRMData()
        {
            presenter = new USMPresenter(this, TopParentControl.Service);
            presenter.FetchCRMData();
        }

        public void DisplayData()
        {
            presenter.DispayData();
        }

        public void ClearData()
        {
            presenter?.ClearData();
        }

        public void DisplayRoles(Guid buId)
        {
            multiSelectRoles.Available = Roles.Where(a => a.BUCrmId == buId).ToList<BaseModel>();
        }

        public void DisplayTeams()
        {
            // multiSelectTeams.Available = Teams.Where(a => !a.IsDefault).ToList<BaseModel>();
            listViewTeams.Items.Clear();
            if (Teams != null)
            {
                foreach (var d in Teams.OrderBy(a => a.FullName))
                {
                    ListViewItem item = new ListViewItem(d.FullName);
                    item.SubItems.Add(d.BUName);
                    item.SubItems.Add(d.CrmId.ToString());
                    item.SubItems.Add(d.BUCrmId.ToString());
                    listViewTeams.Items.Add(item);
                }
            }
            else
            {
                this.SelectedTeams = null;
                UpdateDataOnUI();
            }

            gbUsers.Text = string.Format("Teams: {0}", listViewTeams.Items != null ? listViewTeams.Items.Count.ToString() : "0"); ;
        }

        public void DisplayFieldSecurity()
        {
            multiSelectFS.Available = FieldSecurity.ToList<BaseModel>();
        }

        public void DisplayTeamRole(Guid buId)
        {
            multiSelectRoles.Assigned = TeamRole.Where(a => SelectedTeams.Contains(a.Team)).Select(b => b.Role).ToList<BaseModel>();
        }

        public void DisplayTeamFieldSecurity()
        {
            multiSelectFS.Assigned = TeamFieldSecurity.Where(a => SelectedTeams.Contains(a.Team)).Select(b => b.FieldSecurity).ToList<BaseModel>();
        }

        public void DisplayUsers()
        {
            if (Users != null)
            {
                multiSelectUsers.Available = Users.ToList<BaseModel>();
            }
            //listViewUsers.Items.Clear();
            //if (Users != null)
            //{
            //    foreach (var d in Teams.OrderBy(a => a.FullName))
            //    {
            //        ListViewItem item = new ListViewItem(d.FullName);
            //        item.SubItems.Add(d.BUName);
            //        item.SubItems.Add(d.CrmId.ToString());
            //        item.SubItems.Add(d.BUCrmId.ToString());
            //        listViewUsers.Items.Add(item);
            //    }
            //}
            //else
            //{
            //    this.SelectedUsers = null;
            //    UpdateDataOnUI();
            //}

            //gbUsers.Text = string.Format("Teams: {0}", listViewUsers.Items != null ? listViewUsers.Items.Count.ToString() : "0"); ;
        }

        public void DisplayTeamUser()
        {
            multiSelectUsers.Assigned = UserTeam.Where(a => SelectedTeams.Contains(a.Team)).Select(b => b.User).ToList<BaseModel>();
        }

        private void DisplayBUs()
        {
            comboBoxBU.Items.Clear();
            if (BUs != null && BUs.Count > 0)
            {
                comboBoxBU.Items.AddRange(BUs.OrderBy(a => a.FullName).ToArray());
                comboBoxBU.DisplayMember = "FullName";
            }
        }

        public void DisplayDownloadControls()
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = true;
            listViewTeams.CheckBoxes = true;
            this.userSecurityReport1.DisplayReport(this, Users, Teams, Roles, FieldSecurity, UserRole, UserTeam, TeamRole, UserFieldSecurity, TeamFieldSecurity);
        }

        public void HideDownloadControls()
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            listViewTeams.CheckBoxes = false;
        }

        public List<TeamModel> GetCheckedTeams()
        {
            List<TeamModel> checkedTeams = new List<TeamModel>();
            foreach (ListViewItem item in this.listViewTeams.CheckedItems)
            {
                checkedTeams.Add(Teams.First(a => a.CrmId.ToString() == item.SubItems[2].Text));
            }

            return checkedTeams;
        }

        private void listViewTeams_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected == true)
            {
                if (SelectedTeams == null)
                {
                    SelectedTeams = new List<TeamModel>();
                }
                else
                {
                    SelectedTeams.Clear();
                }

                SelectedTeams?.Add(Teams.First(a => a.CrmId.ToString() == e.Item.SubItems[2].Text));
            }
            else
            {
                SelectedTeams.Remove(Teams.First(a => a.CrmId.ToString() == e.Item.SubItems[2].Text));
            }

            UpdateDataOnUI();
        }

        private void UpdateDataOnUI()
        {
            SetBUonUI();
            ClearMultiselect();
            //DisplayAllUserRoles();
            //DisplayAllTeamFieldSecurity();
            //DisplayTeamFieldSecurity();

            if (SelectedTeams != null && SelectedTeams?.Count > 0)
            {
                if (Teams != null)
                {
                    multiSelectUsers.EnableControl(true);
                    DisplayUsers();
                    DisplayTeamUser();
                }

                var buids = SelectedTeams.Select(a => a.BUCrmId).Distinct();
                if (Roles != null && buids.Count() == 1)
                {
                    multiSelectRoles.EnableControl(true);
                    DisplayRoles(buids.First());
                    DisplayTeamRole(buids.First());
                }
                else
                {
                    MessageBox.Show("To manage Security Roles in bulk, all selected teams should be in same Business Unit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (FieldSecurity != null)
                {
                    multiSelectFS.EnableControl(true);
                    DisplayFieldSecurity();
                    DisplayTeamFieldSecurity();
                }
            }
        }

        private void ClearMultiselect()
        {
            multiSelectUsers.EnableControl(false);
            multiSelectRoles.EnableControl(false);
            multiSelectFS.EnableControl(false);
            multiSelectUsers.ClearData();
            multiSelectRoles.ClearData();
            multiSelectFS.ClearData();
        }

        private void MultiSelectUsers_RecordUnAssigned(object sender, AssignmentEventArgs e)
        {
            if (e?.Data?.Count > 0)
            {
                AddRemoveUserTeams(e.Data, false);
            }
        }

        private void MultiSelectUsers_RecordAssigned(object sender, AssignmentEventArgs e)
        {
            if (e?.Data?.Count > 0)
            {
                AddRemoveUserTeams(e.Data, true);
            }
        }

        private void MultiSelectRoles_RecordUnAssigned(object sender, AssignmentEventArgs e)
        {
            if (e?.Data?.Count > 0)
            {
                AddRemoveTeamRoles(e.Data, false);
            }
        }

        private void MultiSelectRoles_RecordAssigned(object sender, AssignmentEventArgs e)
        {
            if (e?.Data?.Count > 0)
            {
                AddRemoveTeamRoles(e.Data, true);
            }
        }

        private void MultiSelectFS_RecordAssigned(object sender, AssignmentEventArgs e)
        {
            if (e?.Data?.Count > 0)
            {
                AddRemoveTeamSecurityProfile(e.Data, true);
            }
        }

        private void MultiSelectFS_RecordUnAssigned(object sender, AssignmentEventArgs e)
        {
            if (e?.Data?.Count > 0)
            {
                AddRemoveTeamSecurityProfile(e.Data, false);
            }
        }

        private void AddRemoveTeamSecurityProfile(List<BaseModel> fieldSecurityProfiles, bool assign)
        {
            if (SelectedTeams != null && SelectedTeams?.Count > 0)
            {
                TopParentControl.WorkAsync(new WorkAsyncInfo
                {
                    Message = "Updating Field Security Profile",
                    Work = (worker, args) =>
                    {
                        List<FieldSecurityModel> teamData = new List<FieldSecurityModel>();

                        foreach (var item in fieldSecurityProfiles)
                        {
                            teamData.Add((FieldSecurityModel)item);
                        }

                        if (teamData.Count > 0)
                        {
                             Presenter.UpdateTeamFieldLevelSecurity(SelectedTeams.First(), teamData, assign);
                        }
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            UpdateDataOnUI();
                        }
                    }
                });
            }

        }

        private void AddRemoveTeamRoles(List<BaseModel> roles, bool assign)
        {
            if (SelectedTeams != null && SelectedTeams?.Count > 0)
            {
                TopParentControl.WorkAsync(new WorkAsyncInfo
                {
                    Message = "Updating Team Security Roles",
                    Work = (worker, args) =>
                    {
                        List<RoleModel> data = new List<RoleModel>();
                        foreach (var item in roles)
                        {
                            data.Add((RoleModel)item);
                        }

                        Presenter.UpdateTeamRoles(SelectedTeams.First(), data, assign);
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            UpdateDataOnUI();
                        }
                    }
                });
            }
        }

        private void AddRemoveUserTeams(List<BaseModel> users, bool assign)
        {
            if (SelectedTeams != null && SelectedTeams?.Count > 0)
            {
                var isDefaultTeam = SelectedTeams.First().IsDefault;
                if (isDefaultTeam)
                {
                    MessageBox.Show("You cannot remove user from it's default Business Unit team", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (users.Count > 0)
                    {
                        TopParentControl.WorkAsync(new WorkAsyncInfo
                        {
                            Message = "Updating User Teams",
                            Work = (worker, args) =>
                            {
                                List<UserModel> data = new List<UserModel>();
                                foreach (var item in users)
                                {
                                    data.Add((UserModel)item);
                                }

                                Presenter.UpdateTeamUsers(SelectedTeams.First(), data, assign);
                            },
                            PostWorkCallBack = (args) =>
                            {
                                if (args.Error != null)
                                {
                                    MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    UpdateDataOnUI();
                                }
                            }
                        });
                    }
                }
            }
        }

        private void SetBUonUI()
        {
            comboBoxBU.SelectedItem = null;
            if (SelectedTeams?.Count > 0)
            {
                var buids = SelectedTeams.Select(a => a.BUCrmId).Distinct();
                if (buids.Count() == 1)
                {
                    comboBoxBU.SelectedItem = currentBU = BUs.Where(a => a.CrmId == buids.First()).FirstOrDefault();
                }
            }
            if (SelectedTeams?.Count == 1)
            {
                var team = SelectedTeams.First();
                txtTeamName.Text = team.FullName;
                txtTeamType.Text = team.TeamType;
            }
            else
            {
                txtTeamName.Text = string.Empty;
                txtTeamType.Text = string.Empty;
            }
        }

        private void comboBoxBU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedTeams != null && SelectedTeams?.Count > 0)
            {
                var buids = SelectedTeams.Select(a => a.BUCrmId).Distinct();
                if (buids.Count() == 1)
                {
                    var item = (BUModel)((ComboBox)sender).SelectedItem;
                    if (item != null && currentBU.CrmId != item.CrmId)
                    {
                        var confirmResult = MessageBox.Show("Do you want to change the Business Unit of the Team?",
                                     "Confirmation",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmResult == DialogResult.Yes)
                        {
                            currentBU = item;
                            TopParentControl.WorkAsync(new WorkAsyncInfo
                            {
                                Message = "Updating Team Business Unit",
                                Work = (worker, args) =>
                                {
                                    Presenter.UpdateTeamBU(SelectedTeams, currentBU);
                                },
                                PostWorkCallBack = (args) =>
                                {
                                    if (args.Error != null)
                                    {
                                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        UpdateDataOnUI();
                                    }
                                }
                            });
                        }
                        else
                        {
                            SetBUonUI();
                        }
                    }
                }
            }
        }

        private void btnRemoveRoles_Click(object sender, EventArgs e)
        {
            var roles = this.multiSelectRoles.Assigned;
            if (roles != null && roles.Count > 0)
            {
                var response = MessageBox.Show("Do you want to remove all the security roles of the team?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (response == DialogResult.Yes)
                {
                    AddRemoveTeamRoles(roles, false);
                }
            }
        }

        private void btnRemoveUsers_Click(object sender, EventArgs e)
        {
            var users = this.multiSelectUsers.Assigned;
            if (users != null && SelectedTeams != null)
            {
                if (!SelectedTeams.First().IsDefault)
                {
                    if (users.Count > 1)
                    {
                        var response = MessageBox.Show("Do you want to remove all users from the team (except default team)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (response == DialogResult.Yes)
                        {
                            AddRemoveUserTeams(users, false);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Default Business Unit Team cannot be removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void listViewUsers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listViewTeams.Items.Count > 1)
            {
                userSorter.Sort(e.Column);
            }
        }
       
        private void btnRemoveFSPs_Click(object sender, EventArgs e)
        {
            var fsps = this.multiSelectFS.Assigned;
            if (fsps != null && fsps.Count > 0)
            {
                var response = MessageBox.Show("Do you want to remove all assigned Field Security Profile(s) of the team?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (response == DialogResult.Yes)
                {
                    AddRemoveTeamSecurityProfile(fsps, false);
                }
            }
        }
    }
}
