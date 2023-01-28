using PKM.XRMToolBox.TeamSecurityManager.Model;
using PKM.XRMToolBox.TeamSecurityManager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKM.XRMToolBox.TeamSecurityManager.Presenter
{
    public interface IUSMPresenter
    {
        IUSMView View { get; set; }
        void FetchCRMData();
        void DispayData();
        void ClearData();
        void UpdateTeamBU(List<TeamModel> teams, BUModel bu);
        void UpdateTeamRoles(TeamModel team, List<RoleModel> roles, bool assign);
        void UpdateTeamUsers(TeamModel team, List<UserModel> users, bool assign);
        void UpdateUserFieldLevelSecurity(UserModel user, List<FieldSecurityModel> users, bool assign);
        void UpdateTeamFieldLevelSecurity(TeamModel team, List<FieldSecurityModel> teams, bool assign);
    }
}
