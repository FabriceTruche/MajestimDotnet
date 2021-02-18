using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using BrightIdeasSoftware;
using log4net;
using Majestim.BO.OperationBase.Patrimoine;
using Majestim.View.Interface.View;

namespace Majestim.UI.Views.ThemeTreeMenu
{
    public partial class BienView: UserControl, IBienView
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public BienView()
        {
            //log.Info($"==> ctor {this.GetType().Name}");
            this.InitializeComponent();
        }

        private void BienControl_Load(object sender, EventArgs e)
        {
            this.olv.FullRowSelect = true;
            this.olv.GridLines = true;
            this.olv.ShowGroups = false;

            this.OnBiensDisplayed?.Invoke(sender, e);
        }

        public void ShowBiens(IEnumerable<Bien> biens)
        {
            log.Info("--> ShowBines");
            Generator.GenerateColumns(this.olv, typeof(Bien), true);
            this.olv.SetObjects(biens);
            this.olv.AutoResizeColumns();

        }

        public event EventHandler OnBiensDisplayed;

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
    }
}
