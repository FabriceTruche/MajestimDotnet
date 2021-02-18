using System;
using System.Collections.Generic;
using System.Reflection;
using Common.Blocks.Impl;
using Common.Blocks.Interface;
using Majestim.BL.Interface.Rapport.SituationLocataire.Compta;
using Majestim.BO.Rapport.SituationLocataire;
using Majestim.DTO.DTO;

namespace Majestim._TestBlocks
{
    public class SituationVisitor : ISituationLocataireVisitor
    {
        private readonly IBlockObject _mainBlock;
        private IBlockObject _table;
        private IBlockObject _rows;
        private IBlockObject _currentContrat;

        private const string _tableName = "situationTable";

        private string[] _hCols =
        {
            "Période", "Date opération", "Libellé opération", "Type opération", "Compte", "Débit",
            "Crédit"
        };

        private string _contrat;
        private string _periode;
        private bool _newContrat;
        private bool _newPeriode;
        private double _tDebit;
        private double _tCredit;

        public IBlockObject MainBlock => this._mainBlock;

        public SituationVisitor()
        {
            this._mainBlock = Block
                .Create(Resource1.tvHtml, "Init", "Table", "Table/Header", "Table/Row", "Table/Row/Col", "Table/Row/Title").Instanciate();
            this._mainBlock.Instanciate("Init").Subs("tableName", _tableName);

            this._table = this._mainBlock.Instanciate("Table", "tableName", _tableName, "class", "f-header-title");

            foreach (string hCol in this._hCols)
            {
                this._table.Instanciate("Header", "colName", hCol, "class", "f-header-text");
            }
        }

        public void OnBeginContrat(KeyValuePair<OperationDto, IList<EcritureDto>> ls)
        {
            this._newContrat = true;
            this._tDebit = 0;
            this._tCredit = 0;
        }

        public void OnBeginContratPeriode(KeyValuePair<OperationDto, IList<EcritureDto>> ls)
        {
            this._newPeriode = true;
        }

        public void OnRow(KeyValuePair<OperationDto, IList<EcritureDto>> ls)
        {
            this.AddDetailRow(ls);
        }

        public void OnEndContratPeriode(string contrat, DateTime? periode)
        {
        }

        public void OnEndContrat(string contrat)
        {
            this.AddTotalContrat(contrat);
        }

        private void AddTotalContrat(string contrat)
        {
            IBlockObject total = this._table.Instanciate("Row", "level", "2");

            total.Subs("class", "f-title-2");

            total.Instanciate("Col", 
                "tableCellText", $"Total contrat : {contrat}", 
                "class", "f-line-text", 
                "colspan", (this._hCols.Length - 2).ToString());

            double solde = this._tCredit - this._tDebit;

            if (solde < 0)
            {
                total.Instanciate("Col",
                    "tableCellText", (-solde).ToString("C"),
                    "class", "f-currency");
                total.Instanciate("Col", "tableCellText", "");
            }
            else
            {
                total.Instanciate("Col", "tableCellText", "");
                total.Instanciate("Col",
                    "tableCellText", solde.ToString("C"),
                    "class", "f-currency");
            }

            // solde dans le bagde
            this._currentContrat.Subs(
                "solde", $"Solde: {solde:C}",
                "color", solde >= 0 ? "success" : "danger");

            this._tCredit = 0;
            this._tDebit = 0;
        }

        private void AddDetailRow(KeyValuePair<OperationDto, IList<EcritureDto>> operation)
        {
            foreach (EcritureDto ecriture in operation.Value)
            {
                // new contrat
                if (this._newContrat)
                {
                    IBlockObject rowTitle = this._table.Instanciate("Row", "level", "1");

                    rowTitle.Subs("class", "f-title-1");

                    this._currentContrat = rowTitle.Instanciate("Title",
                        "title", $"Contrat : {operation.Key.Contrat}",
                        "class", "f-line-text");

                    this._newContrat = false;
                }

                IBlockObject row = this._table.Instanciate("Row", "level", "2");
                string oddClass = row.IsOdd ? "f-row-odd" : "f-row-pair";

                // other lines of contrat (ecritures)
                row.Subs("class", oddClass);

                row.Instanciate("Col", "tableCellText",
                    this._newPeriode ? operation.Key.Periode.ToString("MMMM yyyy") : "", "class", "f-date-2");
                row.Instanciate("Col", "tableCellText", operation.Key.DateOperation.ToShortDateString(),
                    "class",
                    "f-date");
                row.Instanciate("Col", "tableCellText", ecriture.Libelle, "class", "f-long-text");
                row.Instanciate("Col", "tableCellText", operation.Key.TypeOperation);

                row.Instanciate("Col", "tableCellText", ecriture.Compte);
                row.Instanciate("Col", "tableCellText", ecriture.Debit?.ToString("C"), "class", "f-currency");
                row.Instanciate("Col", "tableCellText", ecriture.Credit?.ToString("C"), "class", "f-currency");

                this._newPeriode = false;
                this._tDebit += ecriture.Debit ?? 0;
                this._tCredit+= ecriture.Credit?? 0;
            }
        }
    }
}