using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using BrightIdeasSoftware;
using log4net;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationBase.Patrimoine;
using Majestim.BO.OperationBase.Tiers;
using Majestim.Interface;
using Majestim.View.Interface.View;

namespace Majestim.UI.Views.ThemeTreeMenu
{
    public partial class ContratView : UserControl, IContratView
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IContext _context;

        public event EventHandler OnShowView;
        public event ContratSelectedEventHandler OnContratSelected;

        public ContratView(IContext context)
        {
            this._context = context;
            this.InitializeComponent();
            //DoubleBuffered(listView1, true);

            this.olvContrat.SelectionChanged += this.OlvContratOnSelectionChanged;
            this.olvContrat.FormatRow += this.OlvContratOnFormatRow;
        }

        /// <summary>
        /// grise les lignes de contrats inactifs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="formatRowEventArgs"></param>
        private void OlvContratOnFormatRow(object sender, FormatRowEventArgs ce)
        {
            if (sender is ObjectListView olv)
            {
                if (ce.Model is ContratRo contrat)
                {
                    if (contrat.IsActif)
                    {
                        // si le contrat est inactif ==> texte en rouge
                        OLVListItem item = ce.Item;
                        item.Font = new Font(item.Font, FontStyle.Bold);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void OlvContratOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            //Contrat contrat = olvContrat.SelectedRow<Contrat>();
            //if (contrat != null)
            //    OnContratSelected?.Invoke(contrat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContratControl_Load(object sender, System.EventArgs e)
        {
            // init olv contrat
            this.olvContrat.FullRowSelect = true;
            this.olvContrat.GridLines = true;
            this.olvContrat.ShowGroups = false;

            // init olv lot
            this.olvLot.ShowGroups = false;

            // init olv prenerus
            this.olvPreneur.ShowGroups = false;

            //olv.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
        }

        /// <summary>
        /// afficher les contrats
        /// </summary>
        /// <param name="contrats"></param>
        public void ShowContrats(IEnumerable<ContratRo> contrats)
        {
            log.Info("--> ShowAllContrats");
            Generator.GenerateColumns(this.olvContrat, typeof(ContratRo), true);
            this.olvContrat.SetObjects(contrats);
            this.olvContrat.AutoResizeColumns();

            Generator.GenerateColumns(this.olvLot, typeof(Lot), true);
            this.olvLot.AutoResizeColumns();
            Generator.GenerateColumns(this.olvPreneur, typeof(Preneur), true);
            this.olvPreneur.AutoResizeColumns();
        }

        /// <summary>
        /// afficher le détail du contrat
        /// </summary>
        /// <param name="contrat"></param>
        /// <param name="lots"></param>
        /// <param name="preneurs"></param>
        public void ShowContratDetail(ContratRo contrat, IEnumerable<Lot> lots, IEnumerable<Preneur> preneurs)
        {
            log.Info("--> détail du contrat");
            this.olvPreneur.ClearObjects();

            // lots
            this.olvLot.SetObjects(lots);
            this.olvLot.AutoResizeColumns();

            // preneurs
            this.olvPreneur.SetObjects(preneurs);
            this.olvPreneur.AutoResizeColumns();
        }

        private void ContratView_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                // on vient d'assigne le control dans le panel de la vue principale
                // ==> on lève les events
                this.OnShowView?.Invoke(this,new EventArgs());
            }
        }
    }
}
