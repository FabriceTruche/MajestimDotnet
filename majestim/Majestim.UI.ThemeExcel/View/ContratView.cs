using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Majestim.BO;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationBase.Patrimoine;
using Majestim.BO.OperationBase.Tiers;
using Majestim.View.Interface.View;

namespace Majestim.UI.ThemeExcel.View
{
    public partial class ContratView : UserControl, IContratView
    {
        public ContratView()
        {
            this.InitializeComponent();
        }

        public void ShowContrats(IEnumerable<ContratRo> contrats)
        {
            throw new NotImplementedException();
        }

        public void ShowContratDetail(ContratRo contrat, IEnumerable<Lot> lots, IEnumerable<Preneur> locataires)
        {
            throw new NotImplementedException();
        }

        public event EventHandler OnShowView;
        public event ContratSelectedEventHandler OnContratSelected;
    }
}
