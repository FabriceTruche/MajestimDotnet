using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Majestim.BO.OperationBase.Patrimoine;
using Majestim.View.Interface.Command;
using Majestim.View.Interface.View;

namespace Majestim.UI.ThemeExcel.View
{
    public partial class BienView : UserControl, IBienView
    {
        public BienView()
        {
            this.InitializeComponent();
        }

        public void ShowBiens(IEnumerable<Bien> biens)
        {
            throw new NotImplementedException();
        }

        public event EventHandler OnBiensDisplayed;
    }
}
