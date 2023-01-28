using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKM.XRMToolBox.TeamSecurityManager.Model
{
    public class UserRoleModel : BaseModel
    {
        public UserModel User { get; set; }
        public RoleModel Role { get; set; }
    }
}
