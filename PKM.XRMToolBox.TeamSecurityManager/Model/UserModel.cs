using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKM.XRMToolBox.TeamSecurityManager.Model
{
    public class UserModel : BaseModel
    {       
        public string DomainName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string PrimaryEmail { get; set; }

        public string AccessMode { get; set; }
    }
}
