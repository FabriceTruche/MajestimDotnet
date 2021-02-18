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
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.View.Interface.View;

namespace Majestim.UI.ThemeExcel.View
{
    public partial class ComptaView : UserControl, IComptaView
    {
        public ComptaView()
        {
            this.InitializeComponent();
        }

        public event EventHandler OnShowView;
        public void ShowCompteLocataire(OneMany<OperationDto, EcritureDto> ecritures, ContratRo[] filter)
        {
            throw new NotImplementedException();
        }

        public void ShowProvisionLocataire(OneMany<OperationDto, EcritureDto> ecritures, ContratRo[] filter)
        {
            throw new NotImplementedException();
        }
    }
}
