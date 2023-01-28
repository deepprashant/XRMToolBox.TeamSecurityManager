using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKM.XRMToolBox.TeamSecurityManager.Model
{
    public class TeamModel : BaseModel
    {
        public bool IsDefault { get; set; }

        public string TeamType { get; set; }
    }
}
