//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Reflection;
//using System.Windows.Forms;
//using BrightIdeasSoftware;
//using log4net;
//using Majestim.BL.OperationBase.Compta;
//using Majestim.BO.OperationBase.Compta;
//using Majestim.BO.OperationBase.Contrat;
//using Majestim.BO.Rapport.SituationLocataire;
//using Majestim.View.Interface.View;

//namespace Majestim.UI.ThemeExcel.View
//{
//    public partial class SituationLocataire2View : UserControl, ISituationLocataireView
//    {
//        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

//        private const int normalColor = 0;
//        private const int boldColor = 1;
//        private const int nbColor = 2;

//        private readonly (Color colorOk, Color colorKo)[] _colors = 
//        {
//            (Color.FromArgb(0xe6, 0xff, 0xe6), Color.FromArgb(0xff, 0xcc, 0xcc)),
//            (Color.FromArgb(0x66, 0xff, 0x66), Color.FromArgb(0xff, 0x80, 0x80)),
//        };

//        public SituationLocataire2View()
//        {
//            this.InitializeComponent();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void SituationLocataireView_Load(object sender, EventArgs e)
//        {
//            // init de la liste des nb mois
//            this.combo_nbmois.Items.AddRange(new object[]
//                {
//                    new ChoixNbMois { NbMois=-1, Libelle = "Toutes les opérations"},
//                    new ChoixNbMois { NbMois=0, Libelle = "Solde locataire"},
//                    new ChoixNbMois { NbMois=1, Libelle = "1 mois"},
//                    new ChoixNbMois { NbMois=2, Libelle = "2 mois"},
//                    new ChoixNbMois { NbMois=3, Libelle = "3 mois"},
//                }
//            );
//            this.combo_nbmois.SelectedIndex = 0;

//            // inti lv
//            Generator.GenerateColumns(this.olv_report, typeof(LigneSituationRo));
//            this.olv_report.HeaderUsesThemes = true;
//            this.olv_report.HeaderWordWrap = true;
//            this.olv_report.IsSearchOnSortColumn = true;
//            this.olv_report.ShowSortIndicators = false;
//            this.olv_report.Sorting = SortOrder.None;
//            this.olv_report.UseHotItem = false;
//            this.olv_report.ShowGroups = false;
//            this.olv_report.FormatRow += this.OlvReport_OnFormatRow;
//            this.olv_report.FormatCell += this.OlvReport_OnFormatCell;
//            this.olv_report.CellOver += this.OlvReportOnCellOver;
//            olv_report.TriggerCellOverEventsWhenOverHeader = true;
//            this.olv_report.UseCellFormatEvents = true;
//            this.olv_report.BeforeSorting += (o, args) => args.Handled = true;
//        }

//        private void OlvReportOnCellOver(object sender, CellOverEventArgs cellOverEventArgs)
//        {
            
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="arg"></param>
//        private void OlvReport_OnFormatCell(object sender, FormatCellEventArgs arg)
//        {
//            if (!(arg.Model is LigneSituationRo lsr))
//                return;

//            if (arg.Column.AspectName == "Contrat" && 
//                (lsr.LigneSituationReportType != LigneSituationRoType.EmptyRow)) //  && arg.CellValue != null))
//            {
//                arg.SubItem.Font = new Font(arg.SubItem.Font, FontStyle.Bold);
//                arg.SubItem.BackColor = Color.LightBlue;
//            }

//            if (arg.Column.AspectName == "Solde")
//            {
//                arg.SubItem.Font = new Font(arg.SubItem.Font.FontFamily, 7);
//            }

//            if (arg.Column.AspectName == "Contrat" &&
//                (lsr.LigneSituationReportType == LigneSituationRoType.ContratSolde))
//            {
//                //arg.SubItem.Font = new Font(arg.SubItem.Font, FontStyle.Bold);
//                //arg.SubItem.BackColor = Color.LightBlue;
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="args"></param>
//        private void OlvReport_OnFormatRow(object sender, FormatRowEventArgs args)
//        {
//            if (args.Model is LigneSituationRo lsr)
//            {
//                switch (lsr.LigneSituationReportType)
//                {
//                    case LigneSituationRoType.ContratSolde:
//                    case LigneSituationRoType.PeriodeSummary:
//                        this.SetRowFormat(
//                            args.Item,
//                            DebitCreditHelper.SignOf(lsr.Debit, lsr.Credit), this._colors[normalColor]);
//                        break;

//                    case LigneSituationRoType.ContratSummary:
//                        this.SetRowFormat(
//                            args.Item,
//                            DebitCreditHelper.SignOf(lsr.Debit, lsr.Credit), this._colors[boldColor]);
//                        break;

//                    case LigneSituationRoType.EmptyRow:
//                        break;
//                }
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void btn_Update_Click(object sender, EventArgs e)
//        {
//            this.UpdateReportClick?.Invoke(this.combo_nbmois.SelectedItem as ChoixNbMois, this.uc_contrats.SelectedContrats);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="item"></param>
//        /// <param name="sign"></param>
//        /// <param name="color"></param>
//        private void SetRowFormat(OLVListItem item, Sign sign, (Color ok, Color ko) color )
//        {
//            item.Font = new Font(item.Font, FontStyle.Bold);

//            switch (sign)
//            {
//                case Sign.Positive:
//                case Sign.Zero:
//                    item.BackColor = color.ok;
//                    break;

//                case Sign.Negative:
//                    item.BackColor = color.ko;
//                    break;

//                default:
//                    throw new ArgumentOutOfRangeException(nameof(sign), sign, null);
//            }
//        }

//        public void ProvideContrats(IList<ContratRo> allContrats)
//        {
//            this.uc_contrats.Contrats = allContrats;
//            this.uc_contrats.Refresh(false);
//        }

//        public void ProvideReport(IList<LigneSituationRo> rows)
//        {
//            log.Info("Maj du report");
//            this.olv_report.SetObjects(rows);
//            //this.olv_report.AutoResizeColumns();
//        }

//        public event ContratSelectedEventHandler ContratSelected;
//        public event LayoutEventHandler LoadEvent;
//        public event SituationLocataireParamHandler UpdateReportClick;

//    }
//}
