using PKM.XRMToolBox.TeamSecurityManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKM.XRMToolBox.TeamSecurityManager.CustomEvent
{
    public class AssignmentEventArgs : EventArgs
    {
        private List<BaseModel> _data;

        public AssignmentEventArgs(List<BaseModel> data)
        {
            _data = data;
        }

        public List<BaseModel> Data
        {
            get { return _data; }
        }
    }
}
