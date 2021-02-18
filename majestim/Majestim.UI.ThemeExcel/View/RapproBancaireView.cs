using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Majestim.BL.Interface.OperationBanque.RapproBancaire;
using Majestim.BO.OperationBanque.RapproBancaire;
using Majestim.BO.Rapport.SituationLocataire;
using Majestim.DTO.DTO;
using Majestim.View.Interface.View;
using Majestim.Helpers;
using System.IO;

namespace Majestim.UI.ThemeExcel.View
{
    public partial class RapproBancaireView : UserControl, IRapproBancaireView
    {
        private string _testImportFile = @"C:\Users\Fabrice\Dropbox\Fabrice\Majestim\ParseDouble.txt";

        public RapproBancaireView()
        {
            this.InitializeComponent();

            // inti lv
            Generator.GenerateColumns(this.olv_banque, typeof(LigneBanqueRo));
            this.olv_banque.HeaderUsesThemes = true;
            this.olv_banque.HeaderWordWrap = true;
            this.olv_banque.IsSearchOnSortColumn = true;
            this.olv_banque.ShowSortIndicators = false;
            this.olv_banque.Sorting = SortOrder.None;
            this.olv_banque.UseHotItem = false;
            this.olv_banque.ShowGroups = false;
            this.olv_banque.UseCellFormatEvents = true;
            this.olv_banque.BeforeSorting += (o, args) => args.Handled = true;
            this.olv_banque.GridLines = true;
            this.olv_banque.FullRowSelect = true;

            Generator.GenerateColumns(this.olv_compta, typeof(LigneRapproComptaRo));
            this.olv_compta.HeaderUsesThemes = true;
            this.olv_compta.HeaderWordWrap = true;
            this.olv_compta.IsSearchOnSortColumn = true;
            this.olv_compta.ShowSortIndicators = false;
            this.olv_compta.Sorting = SortOrder.None;
            this.olv_compta.UseHotItem = false;
            this.olv_compta.ShowGroups = false;
            this.olv_compta.UseCellFormatEvents = true;
            this.olv_compta.FullRowSelect = true;
            this.olv_compta.BeforeSorting += (o, args) => args.Handled = true;

        }

        public void ProvideImportedData(string data)
        {
            throw new NotImplementedException();
        }

        public void ProvideLignesBanque(IList<LigneBanqueRo> lignesBanque)
        {
            if (lignesBanque == null)
                this.olv_banque.ClearObjects();
            else
                this.olv_banque.SetObjects(lignesBanque);
        }

        public void ProvideLignesCompta(IList<LigneRapproComptaRo> lignesRappro)
        {
            if (lignesRappro == null)
                this.olv_compta.ClearObjects();
            else
                this.olv_compta.SetObjects(lignesRappro);
        }

        public void GenererEcritures(IList<LigneRapproCompta> lignesRappro)
        {
            throw new NotImplementedException();
        }

        public event ImportDataEventHandler ImportAutoDataClick;

        public event ImportDataEventHandler ImportManuelDataClick;

        public event GenererComptaEventHandler GenererComptaClick;

        private void RapproBancaireView_Load(object sender, EventArgs e)
        {

        }

        public string GetData
        {
            get
            {
                if (File.Exists(this._testImportFile))
                {
                    string[] allLines = File.ReadAllLines(this._testImportFile);
                    string res = "";

                    foreach (string line in allLines)
                    {
                        if (string.IsNullOrEmpty(line))
                            return res;

                        res += line + Environment.NewLine;
                    }

                    return res;
                }

                return "";
            }
        }

        private void cb_import_auto_Click(object sender, EventArgs e)
        {
            this.ImportAutoDataClick?.Invoke();
        }

        private void cb_import_manu_Click(object sender, EventArgs e)
        {
            this.ImportManuelDataClick?.Invoke();
        }
    }
}
