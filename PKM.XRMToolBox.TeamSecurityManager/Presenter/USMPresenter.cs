using Microsoft.Xrm.Sdk;
using PKM.XRMToolBox.TeamSecurityManager.Model;
using PKM.XRMToolBox.TeamSecurityManager.View;
using System;
using System.Collections.Generic;

namespace PKM.XRMToolBox.TeamSecurityManager.Presenter
{
    public class USMPresenter : IUSMPresenter
    {
        IOrganizationService _service;
        private IUSMView _view;
        UserSecurityManagerModel model;
        public IUSMView View { get => _view; set => _view = value; }

        public USMPresenter(IUSMView view, IOrganizationService service)
        {
            View = view;
            _service = service;
            model = new UserSecurityManagerModel(_service);
        }

        public void FetchCRMData()
        {
            model.LoadData(true, true, true, true, true, true, true, true, true);
        }

        public void DispayData()
        {
            View.Users = model.Users;
            View.Teams = model.Teams;
            View.Roles = model.Roles;
            View.BUs = model.BUs;
            View.UserRole = model.UserRoles;
            View.UserTeam = model.UserTeams;
            View.TeamRole = model.TeamRoles;
            
            View.FieldSecurity = model.FieldSecurityis;
            View.UserFieldSecurity = model.UserFieldSecurityis;
            View.TeamFieldSecurity = model.TeamFieldSecurityis;
           
        }

        public void ClearData()
        {
            View.Users = null;
            View.Teams = null;
            View.Roles = null;
            View.BUs = null;
            View.UserRole = null;
            View.UserTeam = null;
            View.TeamRole = null;
        }

        public void UpdateTeamBU(List<TeamModel> teams, BUModel bu)
        {
            model.UpdateTeamBUAndRefresh(teams, bu);
            View.TeamRole = model.TeamRoles;
        }

        public void UpdateTeamRoles(TeamModel team, List<RoleModel> roles, bool assign)
        {
            model.UpdateTeamRolesAndRefresh(team, roles, assign);
            View.TeamRole = model.TeamRoles;
        }

        public void UpdateTeamUsers(TeamModel team, List<UserModel> users, bool assign)
        {
            model.UpdateTeamsUsersAndRefresh(team, users, assign);
            View.UserTeam = model.UserTeams;
        }

        public void UpdateUserFieldLevelSecurity(UserModel user, List<FieldSecurityModel> profiles, bool assign)
        {
            //model.UpdateUserFSProfileAndRefresh(user, profiles, assign);
            //View.UserFieldSecurity = model.UserFieldSecurityis;
        }

        public void UpdateTeamFieldLevelSecurity(TeamModel team, List<FieldSecurityModel> profiles, bool assign)
        {
            model.UpdateTeamFSProfileAndRefresh(team, profiles, assign);
            View.TeamFieldSecurity = model.TeamFieldSecurityis;
        }
    }
}
