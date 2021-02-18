using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Majestim.View.Interface.View;

namespace Majestim.UI.ThemeExcel.View
{
    public partial class TiersView : UserControl, ITiersView
    {
        public TiersView()
        {
            this.InitializeComponent();
        }

        public void ShowAllTiers()
        {
            throw new NotImplementedException();
        }

        public void ShowTiers(int id)
        {
            throw new NotImplementedException();
        }
    }
}
