using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BrightIdeasSoftware;
using log4net;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationGestion.AppelLoyer;
using Majestim.View.Interface.View;

namespace Majestim.UI.ThemeExcel.View
{
    public partial class AppelLoyerView : UserControl, IAppelLoyerView
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private const int okColor = 0;
        private const int warnColor = 1;
        //private const int infoColor = 2;

        private readonly (Color color, Color colorHighlight)[] _colors = 
        {
            (Color.FromArgb(0xe6, 0xff, 0xe6), Color.FromArgb(0x66, 0xff, 0x66)),
            (Color.FromArgb(0xff, 0xcc, 0xcc), Color.FromArgb(0xff, 0x80, 0x80)),
            //(Color.FromArgb(0xcc, 0xe6, 0xff), Color.FromArgb(080, 0xc1, 0xff)),
        };

        public AppelLoyerView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppelLoyerView_Load(object sender, EventArgs e)
        {
            // inti lv
            Generator.GenerateColumns(this.olv_report, typeof(LigneAppelRo));
            this.olv_report.HeaderUsesThemes = true;
            this.olv_report.HeaderWordWrap = true;
            this.olv_report.IsSearchOnSortColumn = true;
            this.olv_report.ShowSortIndicators = false;
            this.olv_report.Sorting = SortOrder.None;
            this.olv_report.UseHotItem = false;
            this.olv_report.ShowGroups = false;
            this.olv_report.FormatRow += this.OlvReport_OnFormatRow;
            this.olv_report.FormatCell += this.OlvReport_OnFormatCell;
            this.olv_report.UseCellFormatEvents = true;
            this.olv_report.BeforeSorting += (o, args) => args.Handled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void OlvReport_OnFormatCell(object sender, FormatCellEventArgs args)
        {
            if ((args.Column.AspectName == "Contrat") &&
                args.Model is LigneAppelRo lar)
                switch (lar.LigneAppelLoyerReportType)
                {
                    case LigneAppelRoType.Row:
                    {
                        OLVListSubItem item = args.SubItem;

                        item.Font = new Font(item.Font, FontStyle.Bold);
                        item.BackColor = this.FromStatus(lar.DejaAppele).colorHighlight;
                        break;
                    }

                    case LigneAppelRoType.EmptyRow:
                    case LigneAppelRoType.Total:
                        break;
                }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OlvReport_OnFormatRow(object sender, FormatRowEventArgs args)
        {
            if (args.Model is LigneAppelRo lar)
            {
                switch (lar.LigneAppelLoyerReportType)
                {
                    case LigneAppelRoType.Total:
                    {
                        OLVListItem item = args.Item;

                        item.Font = new Font(item.Font, FontStyle.Bold);
                        item.BackColor = this.FromStatus(lar.DejaAppele).color;
                        break;
                    }

                    case LigneAppelRoType.EmptyRow:
                    case LigneAppelRoType.Row:
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dejaAppele"></param>
        /// <returns></returns>
        private (Color color, Color colorHighlight) FromStatus(bool dejaAppele)
        {
            return dejaAppele ? this._colors[warnColor] : this._colors[okColor];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            this.UpdateReport();
        }

        private void UpdateReport()
        {
            this.UpdateReportClicked?.Invoke(this.uc_contrats.SelectedContrats, this.uc_periode.Selection.Periode);
        }

        public void ProvideContrats(IList<ContratRo> allContrats)
        {
            this.uc_contrats.Contrats = allContrats;
            this.uc_contrats.Refresh();
        }

        public void ProvidePeriode(IList<DateTime> periodes)
        {
            this.uc_periode.HasDefault = false;
            this.uc_periode.Init(periodes.Select(x => new ChoixPeriode(x)), "");

            DateTime periodeCourante = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            this.uc_periode.SelectedItem = periodeCourante;
        }

        public void ProvideReport(IList<LigneAppel> lignesAppels, IList<LigneAppelRo> rows)
        {
            this.LignesAppels = lignesAppels;
            this.olv_report.SetObjects(rows);
        }

        private void btn_generer_appels_Click(object sender, EventArgs e)
        {
            try
            {
                this.CreerLignesComptablesClicked?.Invoke(this.LignesAppels);
                this.UpdateReport();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show(exception.StackTrace, "Une erreur s'est produite", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                //throw;
            }
        }

        private IList<LigneAppel> LignesAppels { get; set; }

        public event UpdateAppelViewClickedEventHandler UpdateReportClicked;
        public event CreerLignesComptablesEventHandler CreerLignesComptablesClicked;

    }
}



