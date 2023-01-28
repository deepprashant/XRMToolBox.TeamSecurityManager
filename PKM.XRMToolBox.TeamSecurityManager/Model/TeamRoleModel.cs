using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKM.XRMToolBox.TeamSecurityManager.Model
{
    public class TeamRoleModel : BaseModel
    {        
        public TeamModel Team { get; set; }
        public RoleModel Role { get; set; }
    }
}
