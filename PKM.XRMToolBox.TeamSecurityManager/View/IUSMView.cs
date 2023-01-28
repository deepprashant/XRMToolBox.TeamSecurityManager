using Microsoft.Xrm.Sdk;
using PKM.XRMToolBox.TeamSecurityManager.Model;
using PKM.XRMToolBox.TeamSecurityManager.Presenter;
using System;
using System.Collections.Generic;
using XrmToolBox.Extensibility;

namespace PKM.XRMToolBox.TeamSecurityManager.View
{
    public interface IUSMView
    {
        IUSMPresenter Presenter { get; set; }
        List<TeamModel> SelectedTeams { get; set; }
        List<UserModel> Users { get; set; }
        List<TeamModel> Teams { get; set; }
        List<RoleModel> Roles { get; set; }
        List<BUModel> BUs { get; set; }
        List<UserRoleModel> UserRole { get; set; }
        List<UserTeamModel> UserTeam { get; set; }
        List<TeamRoleModel> TeamRole { get; set; }

        List<FieldSecurityModel> FieldSecurity { get; set; }
        List<UserFieldSecurityModel> UserFieldSecurity { get; set; }
        List<TeamFieldSecurityModel> TeamFieldSecurity { get; set; }

        PluginControlBase TopParentControl { get; set; }
        void FetchCRMData();
        void DisplayData();
        void ClearData();
        void DisplayUsers();
        void DisplayTeams();
        void DisplayRoles(Guid buId);
        void DisplayTeamUser();
        void DisplayTeamRole(Guid buId);
       // void DisplayAllUserRoles();
        void DisplayDownloadControls();
        void HideDownloadControls();
        List<TeamModel> GetCheckedTeams();        
    }
}
