using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using log4net;

namespace Majestim._TestObjectListView
{
    public partial class UserControl2 : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ObjectListView List => this.objectListView1; 

        public UserControl2()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            log.Info("listView1_SelectedIndexChanged");
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            log.Info("listView1_ItemSelectionChanged");

            //ListView.SelectedListViewItemCollection l = List.SelectedItems;
            //if (l.Count == 1)
            //{
            //    ListViewItem r = l[0];
            //    this.Text = r.Text;
            //    this.Dispose();
            //}

        }

        private void objectListView1_SelectionChanged(object sender, EventArgs e)
        {
            log.Info("objectListView1_SelectionChanged");

            //if (List.SelectedObject is TypeCivilite tc)
            //{
            //    this.Text = tc.id.ToString();
            //}

            this.Dispose();
        }
    }
}
