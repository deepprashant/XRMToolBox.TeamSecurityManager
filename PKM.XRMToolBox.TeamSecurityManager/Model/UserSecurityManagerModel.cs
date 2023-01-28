using Microsoft.Xrm.Sdk;
using PKM.XRMToolBox.TeamSecurityManager.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKM.XRMToolBox.TeamSecurityManager.Model
{
    public class UserSecurityManagerModel
    {
        public bool IsReady { get; set; }
        public List<UserModel> Users { get; set; }
        public List<TeamModel> Teams { get; set; }
        public List<RoleModel> Roles { get; set; }
        public List<BUModel> BUs { get; set; }
        public List<FieldSecurityModel> FieldSecurityis { get; set; }
        public List<UserRoleModel> UserRoles { get; set; }
        public List<UserTeamModel> UserTeams { get; set; }
        public List<TeamRoleModel> TeamRoles { get; set; }
        public List<UserFieldSecurityModel> UserFieldSecurityis { get; set; }
        public List<TeamFieldSecurityModel> TeamFieldSecurityis { get; set; }
        public IOrganizationService OrgService { get; set; }

        public UserSecurityManagerModel(IOrganizationService service)
        {
            OrgService = service;
        }

        public void LoadData(bool loadUser = false, bool loadTeam = false, bool loadRole = false, bool loadBU = false,
            bool loadUserRole = false, bool loadUserTeam = false, bool loadTeamRole = false, bool loadFieldSecurity = false
            , bool loadTeamFieldSecurity = false)
        {
            if (OrgService != null)
            {
                IsReady = false;
                var tasks = new List<Task>();
                if (loadUser) tasks.Add(Task.Factory.StartNew(() => LoadCRMUsers()));
                if (loadTeam) tasks.Add(Task.Factory.StartNew(() => LoadCRMTeams()));
                if (loadRole) tasks.Add(Task.Factory.StartNew(() => LoadCRMRoles()));
                if (loadBU) tasks.Add(Task.Factory.StartNew(() => LoadCRMBUs()));
                if (loadFieldSecurity) tasks.Add(Task.Factory.StartNew(() => LoadCRMFieldSecurity()));
                Task.WaitAll(tasks.ToArray());
                tasks.Clear();
                if (loadUserRole) tasks.Add(Task.Factory.StartNew(() => LoadCRMUserRoles()));
                if (loadUserTeam) tasks.Add(Task.Factory.StartNew(() => LoadCRMUserTeams()));
                if (loadTeamRole) tasks.Add(Task.Factory.StartNew(() => LoadCRMTeamRoles()));
                //if (loadUserFieldSecurity) tasks.Add(Task.Factory.StartNew(() => LoadCRMUserFieldSecurity()));
                if (loadTeamFieldSecurity) tasks.Add(Task.Factory.StartNew(() => LoadCRMTeamFieldSecurity()));
                Task.WaitAll(tasks.ToArray());
                IsReady = true;
            }
        }

        public void ReLoadData()
        {
            Users = null;
            Teams = null;
            Roles = null;
            UserRoles = null;
            UserTeams = null;
            TeamRoles = null;
            LoadData(true, true, true, true, true, true, true);
        }

        public void ReLoadData(IOrganizationService service)
        {
            OrgService = service;
            ReLoadData();
        }

        public void UpdateTeamBUAndRefresh(List<TeamModel> teams, BUModel bu)
        {
            foreach (TeamModel team in teams)
            {
                Entity teamEntity = new Entity(team.EntityLogicalName);
                teamEntity.Id = team.CrmId;
                teamEntity.Attributes.Add("businessunitid", new EntityReference(bu.EntityLogicalName, bu.CrmId));
                try
                {
                    OrgService.Update(teamEntity);
                    team.BUCrmId = bu.CrmId;
                    team.BUName = bu.FullName;
                }
                catch
                {
                    throw;
                }
            }

            this.LoadData(false, false, false, false, false, false, true);
        }

        public void UpdateTeamRolesAndRefresh(TeamModel team, List<RoleModel> roles, bool assign)
        {
            EntityReferenceCollection roleCollection = new EntityReferenceCollection();
            foreach (RoleModel role in roles)
            {
                roleCollection.Add(new EntityReference(role.EntityLogicalName, role.CrmId));
            }

            if (roleCollection.Count > 0)
            {
                try
                {
                    if (assign)
                    {
                        OrgService.Associate(
                             team.EntityLogicalName,
                             team.CrmId,
                             new Relationship("teamroles_association"),
                             roleCollection);
                    }
                    else
                    {
                        OrgService.Disassociate(
                             team.EntityLogicalName,
                             team.CrmId,
                             new Relationship("teamroles_association"),
                             roleCollection);
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                this.LoadData(false, false, false, false, false, false, true);
            }
        }

        public void UpdateTeamsUsersAndRefresh(TeamModel team, List<UserModel> users, bool assign)
        {
            EntityReferenceCollection userCollection = new EntityReferenceCollection();
            foreach (UserModel user in users)
            {
                userCollection.Add(new EntityReference(user.EntityLogicalName, user.CrmId));
            }

            if (userCollection.Count > 0)
            {
                try
                {
                    if (assign)
                    {
                        OrgService.Associate(
                             team.EntityLogicalName,
                             team.CrmId,
                             new Relationship("teammembership_association"),
                             userCollection);
                    }
                    else
                    {
                        OrgService.Disassociate(
                             team.EntityLogicalName,
                             team.CrmId,
                             new Relationship("teammembership_association"),
                             userCollection);
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                this.LoadData(false, false, false, false, false, true, false);
            }
        }

        private void LoadCRMUsers()
        {
            var data = OrgService.GetUsers();
            Users = (from en in data.Entities
                     select new UserModel()
                     {
                         EntityLogicalName = en.LogicalName,
                         CrmId = en.Id,
                         FullName = en.Contains("fullname") ? en["fullname"].ToString() : string.Empty,
                         DomainName = en.Contains("domainname") ? en["domainname"].ToString() : string.Empty,
                         BUName = ((EntityReference)en["businessunitid"]).Name,
                         BUCrmId = ((EntityReference)en["businessunitid"]).Id,
                         FirstName = en.Contains("firstname") ? en["firstname"].ToString() : string.Empty,
                         LastName = en.Contains("lastname") ? en["lastname"].ToString() : string.Empty,
                         Title = en.Contains("title") ? en["title"].ToString() : string.Empty,
                         PrimaryEmail = en.Contains("internalemailaddress") ? en["internalemailaddress"].ToString() : string.Empty,
                         AccessMode = en.Contains("accessmode") ? en.FormattedValues["accessmode"].ToString() : string.Empty
                     }).ToList();
        }

        private void LoadCRMTeams()
        {
            var data = OrgService.GetTeams();
            Teams = (from en in data.Entities
                     select new TeamModel()
                     {
                         EntityLogicalName = en.LogicalName,
                         CrmId = en.Id,
                         FullName = en.Contains("name") ? ((bool)en["isdefault"] ? en["name"].ToString() + " (default)" : en["name"].ToString()) : "--",
                         BUName = ((EntityReference)en["businessunitid"]).Name,
                         BUCrmId = ((EntityReference)en["businessunitid"]).Id,
                         IsDefault = (bool)en["isdefault"],
                         TeamType =  en.FormattedValues["teamtype"]
                     }).ToList();
        }

        private void LoadCRMRoles()
        {
            var data = OrgService.GetSecurityRole();
            Roles = (from en in data.Entities
                     select new RoleModel()
                     {
                         EntityLogicalName = en.LogicalName,
                         CrmId = en.Id,
                         FullName = en.Contains("name") ? en["name"].ToString() : "--",
                         BUName = ((EntityReference)en["businessunitid"]).Name,
                         BUCrmId = ((EntityReference)en["businessunitid"]).Id
                     }).ToList();
        }

        private void LoadCRMBUs()
        {
            var data = OrgService.GetBusinessUnits();
            BUs = (from en in data.Entities
                   select new BUModel()
                   {
                       EntityLogicalName = en.LogicalName,
                       CrmId = en.Id,
                       FullName = en.Contains("name") ? en["name"].ToString() : "--",
                       ParentBUName = en.Contains("parentbusinessunitid") ? ((EntityReference)en["parentbusinessunitid"])?.Name : string.Empty,
                       ParentBUCrmId = en.Contains("parentbusinessunitid") ? ((EntityReference)en["parentbusinessunitid"]).Id : default(Guid)
                   }).ToList();
        }

        private void LoadCRMUserRoles()
        {
            var data = OrgService.GetUserRole();
            UserRoles = (from en in data.Entities
                         select new UserRoleModel()
                         {
                             EntityLogicalName = en.LogicalName,
                             CrmId = en.Id,
                             User = Users.FirstOrDefault(a => a.CrmId == (Guid)en["systemuserid"]),
                             Role = Roles.FirstOrDefault(a => a.CrmId == (Guid)en["roleid"])
                         }).ToList();
            UserRoles.RemoveAll(a => a.User == null || a.Role == null);
        }

        private void LoadCRMUserTeams()
        {
            var data = OrgService.GetUserTeam();
            UserTeams = (from en in data.Entities
                         select new UserTeamModel()
                         {
                             EntityLogicalName = en.LogicalName,
                             CrmId = en.Id,
                             User = Users.FirstOrDefault(a => a.CrmId == (Guid)en["systemuserid"]),
                             Team = Teams.FirstOrDefault(a => a.CrmId == (Guid)en["teamid"])
                         }).ToList();
            UserTeams.RemoveAll(a => a.User == null || a.Team == null);
        }

        private void LoadCRMTeamRoles()
        {
            var data = OrgService.GetTeamRole();
            TeamRoles = (from en in data.Entities
                         select new TeamRoleModel()
                         {
                             EntityLogicalName = en.LogicalName,
                             CrmId = en.Id,
                             Team = Teams.FirstOrDefault(a => a.CrmId == (Guid)en["teamid"]),
                             Role = Roles.FirstOrDefault(a => a.CrmId == (Guid)en["roleid"])
                         }).ToList();
        }

        private void LoadCRMFieldSecurity()
        {
            var data = OrgService.GetFieldSecurityProfiles();
            FieldSecurityis = (from en in data.Entities
                         select new FieldSecurityModel()
                         {
                             EntityLogicalName = en.LogicalName,
                             CrmId = en.Id,
                             BUName = "",
                             FullName = en.Contains("name") ? en["name"].ToString() : "--"
                         }).ToList();
        }

        //private void LoadCRMUserFieldSecurity()
        //{
        //    var data = OrgService.GetUserFieldSecurityProfile();
        //    UserFieldSecurityis = (from en in data.Entities
        //                           select new UserFieldSecurityModel()
        //                           {
        //                               EntityLogicalName = en.LogicalName,
        //                               CrmId = en.Id,
        //                               User = Users.FirstOrDefault(a => a.CrmId == (Guid)en["systemuserid"]),
        //                               BUName = "",
        //                               FieldSecurity = FieldSecurityis.FirstOrDefault(a => a.CrmId == (Guid)en["fieldsecurityprofileid"]),
        //                               IsUserSecurityProfile = true
        //                 }).ToList();
        //}

        private void LoadCRMTeamFieldSecurity()
        {
            var data = OrgService.GetTeamFieldSecurityProfile();
            TeamFieldSecurityis = (from en in data.Entities
                     select new TeamFieldSecurityModel()
                     {
                         EntityLogicalName = en.LogicalName,
                         CrmId = en.Id,
                         BUName = "",
                         Team = Teams.FirstOrDefault(a => a.CrmId == (Guid)en["teamid"]),
                         FieldSecurity = FieldSecurityis.FirstOrDefault(a => a.CrmId == (Guid)en["fieldsecurityprofileid"]),
                         IsUserSecurityProfile = false
                     }).ToList();
        }

        public void UpdateTeamFSProfileAndRefresh(TeamModel team, List<FieldSecurityModel> fieldSecurities, bool assign)
        {
            EntityReferenceCollection collection = new EntityReferenceCollection();
            foreach (FieldSecurityModel fieldSecurity in fieldSecurities)
            {
                collection.Add(new EntityReference(fieldSecurity.EntityLogicalName, fieldSecurity.CrmId));
            }

            if (collection.Count > 0)
            {
                try
                {
                    if (assign)
                    {
                        OrgService.Associate(
                             team.EntityLogicalName,
                             team.CrmId,
                             new Relationship("teamprofiles_association"),
                             collection);
                    }
                    else
                    {
                        OrgService.Disassociate(
                             team.EntityLogicalName,
                             team.CrmId,
                             new Relationship("teamprofiles_association"),
                             collection);
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                this.LoadData(false, false, false, false, false, false, false, false, true);
            }
        }
    }
}
