using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace Majestim._TestObjectListView
{
    public partial class UserControl1 : UserControl
    {
        private readonly CellEditEventArgs _ce;

        public UserControl1(CellEditEventArgs ce)
        {
            _ce = ce;
            InitializeComponent();
        }

        public ListBox List => this.listBox1;

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //_ce.NewValue = List.SelectedItems[0];
            this.Text = List.SelectedItems[0].ToString();

            this.Dispose();
        }
    }
}
