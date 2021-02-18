using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Majestim.BO.OperationBase.Contrat;
using Majestim.View.Interface.Component;

namespace Majestim.UI.ThemeExcel.Component
{
    public partial class ContratsSelectorComponent : UserControl, IContratsSelectorComponent
    {
        private readonly List<ContratRo> _contrats = new List<ContratRo>();

        public ContratsSelectorComponent()
        {
            this.InitializeComponent();
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<ContratRo>  Contrats
        {
            get => this.lb_contrats.Items.Cast<ContratRo>().ToList();

            set
            {
                this._contrats.Clear();
                foreach (ContratRo contrat in value)
                    this._contrats.Add(contrat);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public IList<ContratRo> SelectedContrats => this.lb_contrats.SelectedItems.Cast<ContratRo>().ToList();

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="selectAll"></param>
        public void Refresh(bool selectAll=false)
        {
            this.lb_contrats.Items.Clear();
            foreach (ContratRo contrat in this._contrats)
            {
                if (contrat.DateSortie == null || selectAll)
                {
                    int index = this.lb_contrats.Items.Add(contrat);

                    // sélectionner le contrat si
                    // - date sortie null 
                    //   ET
                    //   - date sortie prev null ou
                    //   - date sortie prev > date dujour
                    // OU
                    // - date sortie > date du jour
                    // finalement : sélectionné si pas en cours de fermeture
                    this.lb_contrats.SetSelected(index, contrat.DateSortie == null && contrat.DateSortiePrevue == null);
                }
            }
        }

        private void rb_actif_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton s)
                this.Refresh(!s.Checked);
        }

        private void rb_tous_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton s)
                this.Refresh(s.Checked);
        }
    }
}
