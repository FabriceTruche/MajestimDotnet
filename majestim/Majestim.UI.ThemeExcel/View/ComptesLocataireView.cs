using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BrightIdeasSoftware;
using log4net;
using Majestim.BL.OperationBase.Compta;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.Rapport.CompteLocataire;
using Majestim.DTO.DTO;
using Majestim.View.Interface.Component;
using Majestim.View.Interface.View;

namespace Majestim.UI.ThemeExcel.View
{
    public partial class ComptesLocataireView : UserControl, IComptesLocataireView
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
//        private IEnumerable<Contrat> _allContrats;

        private Func<CompteDto, bool> ComptesDefaultFunc => compte => compte.Numero.StartsWith("41");
        private Func<CompteDto, bool> ComptesTous => compte => true;
        private Func<CompteDto, bool> ComptesAucun => compte => false;

        private const int normalColor = 0;
        private const int boldColor = 1;
        private const int nbColor = 2;
        private (Color colorOk, Color colorKo)[] _colors = new[]
        {
            (Color.FromArgb(0xe6, 0xff, 0xe6), Color.FromArgb(0xff, 0xcc, 0xcc)),
            (Color.FromArgb(0x66, 0xff, 0x66), Color.FromArgb(0xff, 0x80, 0x80)),
        };

        public ComptesLocataireView()
        {
            this.InitializeComponent();
        }

        #region Evenements de controles

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComptesLocataireView_Load(object sender, EventArgs e)
        {
            // inti lv
            Generator.GenerateColumns(this.olv_report, typeof(LigneComptesLocataireRo));
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
            this.olv_report.BeforeSorting += (o, args) => args.Canceled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void OlvReport_OnFormatCell(object sender, FormatCellEventArgs arg)
        {
            if (arg.Column.AspectName == "Periode" &&
                arg.Model is LigneComptesLocataireRo lsr &&
                (lsr.LigneComptesLocataireReportType != LigneComptesLocataireRoType.EmptyRow))
            {
                arg.SubItem.Font = new Font(arg.SubItem.Font, FontStyle.Bold);
                arg.SubItem.BackColor = Color.LightBlue;
            }

            if (arg.Column.AspectName == "Solde")
            {
                arg.SubItem.Font = new Font(arg.SubItem.Font.FontFamily, 7 /*arg.SubItem.Font.Size - 2*/);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OlvReport_OnFormatRow(object sender, FormatRowEventArgs args)
        {
            if (args.Model is LigneComptesLocataireRo lsr)
            {
                switch (lsr.LigneComptesLocataireReportType)
                {
                    case LigneComptesLocataireRoType.Summary:
                        this.SetRowFormat(
                            args.Item,
                            DebitCreditHelper.SignOf(lsr.Debit, lsr.Credit), this._colors[normalColor]);
                        break;

                    case LigneComptesLocataireRoType.EmptyRow:
                        break;
                }
            }
        }

        /// <summary>
        /// maj du report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            IEnumerable<string> comptes = this.GetComptesSelected();
            IEnumerable<string> operations = this.GetOperationsSelected();

            this.UpdateReportClicked?.Invoke(
                this.uc_contrat_selector.SelectedContrat,
                this.uc_periode_debut.Selection,
                this.uc_periode_fin.Selection,
                comptes,
                operations
            );
        }

        private void rb_comptes_defaut_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateSelectionComptes(this.ComptesDefaultFunc);
        }

        private void rb_comptes_aucun_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateSelectionComptes(this.ComptesAucun);
        }

        private void rb_comptes_all_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateSelectionComptes(this.ComptesTous);
        }


        #endregion

        #region Interface de la view

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="allContrats"></param>
        public void ProvideContrats(IEnumerable<ContratRo> allContrats)
        {
            this.uc_contrat_selector.Contrats = allContrats;
            this.uc_contrat_selector.Refresh(false);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="periodesDebut"></param>
        /// <param name="periodesFin"></param>
        public void ProvidePeriodes(IEnumerable<DateTime> periodesDebut, IEnumerable<DateTime> periodesFin)
        {
            if (periodesDebut != null)
                this.uc_periode_debut.Init(periodesDebut.ToList().Select(x => new ChoixPeriode(x)));

            if (periodesFin != null)
                this.uc_periode_fin.Init(periodesFin.ToList().Select(x => new ChoixPeriode(x)));
        }

        public void ProvideComptes(IEnumerable<CompteDto> comptes)
        {
            this.lb_compte.Items.Clear();
            foreach (CompteDto compte in comptes)
                this.lb_compte.Items.Add(compte);

            this.UpdateSelectionComptes(this.ComptesDefaultFunc);
        }

        private void UpdateSelectionComptes(Func<CompteDto, bool> func)
        {
            for (int i = 0; i < this.lb_compte.Items.Count; i++)
            {
                if (this.lb_compte.Items[i] is CompteDto compte)
                {
                    this.lb_compte.SetSelected(i, func(compte));
                }
            }
        }

        public void ProvideTypeOperations(IEnumerable<TypeOperationDto> operations)
        {
            this.lb_operation.Items.Clear();
            foreach (TypeOperationDto operation in operations)
                this.lb_operation.Items.Add(operation);

            for (int i = 0; i < this.lb_operation.Items.Count; i++)
                this.lb_operation.SetSelected(i, true);
        }

        public void ProvideReport(IEnumerable<LigneComptesLocataireRo> rows)
        {
            this.olv_report.SetObjects(rows);
        }

        #endregion

        #region Méthodes private

        /// <summary>
        /// retourne la liste des opérations sélectionnées
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string> GetOperationsSelected()
        {
            return
                this.lb_operation.Items.Cast<TypeOperationDto>().Where((t, i) => this.lb_operation.GetSelected(i)).Select(t => t.Code).ToList();
        }

        /// <summary>
        /// retourne la liste des comptes sélectionnés
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string> GetComptesSelected()
        {
            return
                this.lb_compte.Items.Cast<CompteDto>().Where((t, i) => this.lb_compte.GetSelected(i)).Select(t => t.Numero).ToList();
        }

        private void SetRowFormat(OLVListItem item, Sign sign, (Color ok, Color ko) color)
        {
            item.Font = new Font(item.Font, FontStyle.Bold);

            switch (sign)
            {
                case Sign.Positive:
                case Sign.Zero:
                    item.BackColor = color.ok;
                    break;

                case Sign.Negative:
                    item.BackColor = color.ko;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(sign), sign, null);
            }
        }
        #endregion 

        public event ContratSelectedEventHandler ContratSelected;
        public event UpdateReportClickedEventHandler UpdateReportClicked;
    }
}






//private void rb_actif_CheckedChanged(object sender, EventArgs e)
//{
//    this.UpdateContratsList(!(sender as RadioButton).Checked);
//}

//private void rb_tous_CheckedChanged(object sender, EventArgs e)
//{
//    this.UpdateContratsList((sender as RadioButton).Checked);
//}

//private void combo_contrat_SelectionChangeCommitted(object sender, EventArgs e)
//{

//    if (this.combo_contrat.SelectedItem is Contrat contrat)
//    {
//        log.Info($"--> {contrat.Nom}");
//        this.ContratSelected?.Invoke(contrat);
//    }
//}
/// <summary>
/// affichage spécialisé pour les ocnyayscontrats actifs/inactifs
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
//private void combo_contrat_DrawItem(object sender, DrawItemEventArgs e)
//{
//    Contrat item = (e.Index < 0) ? null : this.combo_contrat.Items[e.Index] as Contrat;

//    if (this.DrawBackground(e.State) || item==null)
//    {
//        e.DrawBackground();
//    }
//    else
//    {
//        using (Brush backgroundBrush = new SolidBrush(item.IsActif ? Color.FromArgb(0xe6, 0xff, 0xe6) : Color.FromArgb(0xff, 0xe6, 0xe6)))
//        {
//            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
//        }
//    }

//    e.Graphics.DrawString(
//        item?.ToString(),
//        this.Font,
//        Brushes.Black,
//        new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
//    );
//    e.DrawFocusRectangle();
//}
/// <summary>
/// maj liste des contrats
/// </summary>
/// <param name="showAll"></param>
//private void UpdateContratsList(bool showAll)
//{
//    Contrat current = this.combo_contrat.SelectedItem as Contrat;

//    this.combo_contrat.Items.Clear();
//    foreach (Contrat contrat in this._allContrats)
//    {
//        if (contrat.DateSortie == null || showAll)
//        {
//            this.combo_contrat.Items.Add(contrat);
//        }
//    }

//    if (current != null)
//    {
//        int index = this.combo_contrat.FindStringExact(current.Nom);
//        if (index != -1)
//            this.combo_contrat.SelectedIndex = index;
//    }
//    else
//    {
//        if (this.combo_contrat.Items.Count > 0)
//            this.combo_contrat.SelectedIndex = 0;
//    }

//}


//private bool DrawBackground(DrawItemState dis)
//{
//    return (dis & DrawItemState.Focus) == DrawItemState.Focus ||
//           (dis & DrawItemState.Selected) == DrawItemState.Selected ||
//           (dis & DrawItemState.HotLight) == DrawItemState.HotLight;
//}

