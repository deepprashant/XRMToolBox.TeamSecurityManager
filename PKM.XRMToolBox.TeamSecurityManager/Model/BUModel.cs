using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKM.XRMToolBox.TeamSecurityManager.Model
{
    public class BUModel : BaseModel
    {
        public string ParentBUName { get; set; }

        public Guid ParentBUCrmId { get; set; }
    }
}
