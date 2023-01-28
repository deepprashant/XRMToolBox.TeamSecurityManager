using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKM.XRMToolBox.TeamSecurityManager.Model
{
    public class BaseModel
    {
        public string EntityLogicalName { get; set; }

        public Guid CrmId { get; set; }

        public string FullName { get; set; }

        public string BUName { get; set; }

        public Guid BUCrmId { get; set; }

        public bool IsDirty { get; set; }

        public Operation Action { get; set; }

        public bool IsUserSecurityProfile { get; set; }
    }
}
