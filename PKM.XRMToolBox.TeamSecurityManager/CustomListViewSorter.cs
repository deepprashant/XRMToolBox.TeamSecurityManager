using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace PKM.XRMToolBox.TeamSecurityManager
{
    public class CustomListViewSorter : IDisposable
    {
        private int lastCol = -1;
        private string lastSort = "ASC";
        private ListView listView;
        private DataTable sortingTable;

        public CustomListViewSorter(ListView view, int columns)
        {
            listView = view;
            sortingTable = new DataTable();
            for (int columnCount = 0; columnCount < columns; columnCount++)
            {
                sortingTable.Columns.Add("Column" + columnCount);
            }
        }

        public void Sort(int index)
        {
            sortingTable.Rows.Clear();
            foreach (ListViewItem item in listView.Items)
            {
                DataRow iRow = sortingTable.NewRow();
                for (int i = 0; i < sortingTable.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        iRow[i] = item.Text;
                    }
                    else
                    {
                        iRow[i] = item.SubItems[i] != null ? item.SubItems[i].Text : string.Empty; ;
                    }
                }

                sortingTable.Rows.Add(iRow);
            }

            if (lastCol == index)
            {
                if (lastSort == "ASC" || lastSort == string.Empty || lastSort == null)
                {
                    lastSort = "DESC";
                }
                else
                {
                    lastSort = "ASC";
                }
            }
            else
            {
                lastSort = "DESC";
            }

            lastCol = index;
            listView.Items.Clear();
            //Sort it based on the column text clicked and the sort type (asc or desc)
            sortingTable.DefaultView.Sort = sortingTable.Columns[index].ColumnName + " " + lastSort;
            sortingTable = sortingTable.DefaultView.ToTable();
            //Create a listview item from the data in each row
            foreach (DataRow iRow in sortingTable.Rows)
            {
                ListViewItem Item = new ListViewItem();
                List<string> SubItems = new List<string>();
                for (int i = 0; i < sortingTable.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        Item.Text = iRow[i].ToString();
                    }
                    else
                    {
                        SubItems.Add(iRow[i].ToString());
                    }
                }

                Item.SubItems.AddRange(SubItems.ToArray());
                listView.Items.Add(Item);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    ((IDisposable)sortingTable).Dispose();
                    ((IDisposable)listView).Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CustomListViewSorter()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
