using System;
using System.Windows.Forms;
using Majestim.View.Interface.View;

namespace Majestim.UI.Views.ThemeTreeMenu
{
    public partial class TiersView: UserControl, ITiersView
    {
        public TiersView()
        {
            this.InitializeComponent();
        }

        private void TiersControl_Load(object sender, EventArgs e)
        {
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
