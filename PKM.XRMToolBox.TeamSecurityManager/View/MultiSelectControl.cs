using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PKM.XRMToolBox.TeamSecurityManager.Model;
using PKM.XRMToolBox.TeamSecurityManager.CustomEvent;

namespace PKM.XRMToolBox.TeamSecurityManager.UserControls
{
    public delegate void RecordUnAssignedEventHandler(object sender,
                                                  AssignmentEventArgs e);

    public delegate void RecordAssignedEventHandler(object sender,
                                                  AssignmentEventArgs e);
    public partial class MultiSelectControl : UserControl
    {
        private List<BaseModel> available;
        private List<BaseModel> assigned;
        public event RecordAssignedEventHandler RecordAssigned;
        public event RecordUnAssignedEventHandler RecordUnAssigned;
        private CustomListViewSorter assignedSorter;
        private CustomListViewSorter availableSorter;        

        public List<BaseModel> Available
        {
            get
            {
                return available;
            }
            set
            {
                available = value;
                DisplayData();
            }
        }

        public List<BaseModel> Assigned
        {
            get
            {
                return assigned;
            }
            set
            {
                assigned = value;
                DisplayData();
            }
        }

        public List<BaseModel> ToAssigned { get; set; }

        public List<BaseModel> ToUnAssigned { get; set; }

        public void EnableControl(bool enable)
        {
            if (enable)
            {
                btnAssign.Enabled = true;
                btnUnAssign.Enabled = true;
            }
            else
            {
                btnAssign.Enabled = false;
                btnUnAssign.Enabled = false;
            }
        }

        public MultiSelectControl()
        {
            InitializeComponent();
            assignedSorter = new CustomListViewSorter(this.listViewAssigned, 3);
            availableSorter = new CustomListViewSorter(this.listViewAvailable, 3);
        }

        public void HideBUColum()
        {
            this.listViewAssigned.Columns[1].Width = 0;
            this.listViewAvailable.Columns[1].Width = 0;
        }
   
        public void ClearData()
        {
            Available = null;
            Assigned = null;
            ToAssigned = null;
            ToUnAssigned = null;
        }

        protected virtual void OnRecordAssigned(AssignmentEventArgs e)
        {
            if (RecordAssigned != null)
                RecordAssigned(this, e);
        }

        protected virtual void OnRecordUnAssigned(AssignmentEventArgs e)
        {
            if (RecordUnAssigned != null)
                RecordUnAssigned(this, e);
        }

        private void DisplayData()
        {
            DisplayAssigned();
            DisplayAvailable();
        }

        private void DisplayAssigned()
        {
            listViewAssigned.Items.Clear();

            if (Assigned != null)
            {
                foreach (var d in Assigned.OrderBy(a => a.FullName))
                {
                    ListViewItem item = new ListViewItem(d.FullName);

                    if (d.BUName != null)
                    {
                        item.SubItems.Add(d.BUName.ToString());
                    }     
                    
                    item.SubItems.Add(d.CrmId.ToString());
                    listViewAssigned.Items.Add(item);

                }
            }

            gbAssigned.Text = string.Format("Assigned: {0}", (listViewAssigned.Items != null ? listViewAssigned.Items.Count.ToString() : "0"));
        }

        private void DisplayAvailable()
        {
            listViewAvailable.Items.Clear();
            if (Available != null)
            {
                var finalSet = Available;
                if (Assigned != null)
                {
                    finalSet = Available.Except(Assigned).ToList();
                }

                foreach (var d in finalSet.OrderBy(a => a.FullName))
                {
                    ListViewItem item = new ListViewItem(d.FullName);

                    if (d.BUName != null)
                    {
                        item.SubItems.Add(d.BUName.ToString());
                    }  

                    item.SubItems.Add(d.CrmId.ToString());
                    listViewAvailable.Items.Add(item);
                }
            }

            gbAvailable.Text = string.Format("Available: {0}", (listViewAvailable.Items != null ? listViewAvailable.Items.Count.ToString() : "0"));
        }

        private void btnUnAssign_Click(object sender, EventArgs e)
        {
            var items = listViewAssigned.CheckedItems;
            if (items != null && items.Count > 0)
            {
                ToUnAssigned = new List<BaseModel>();
                foreach (ListViewItem item in items)
                {
                    ToUnAssigned.AddRange(Assigned.Where(a => a.CrmId.ToString() == item.SubItems[2].Text));
                }

                OnRecordUnAssigned(new AssignmentEventArgs(ToUnAssigned));
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            var items = listViewAvailable.CheckedItems;
            if (items != null && items.Count > 0)
            {
                ToAssigned = new List<BaseModel>();
                foreach (ListViewItem item in items)
                {
                    ToAssigned.AddRange(Available.Where(a => a.CrmId.ToString() == item.SubItems[2].Text));
                }

                OnRecordAssigned(new AssignmentEventArgs(ToAssigned));
            }
        }

        private void listViewAssigned_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listViewAssigned.Items.Count > 1)
            {
                assignedSorter.Sort(e.Column);
            }
        }

        private void listViewAvailable_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listViewAvailable.Items.Count > 1)
            {
                availableSorter.Sort(e.Column);
            }
        }        
    }
}
