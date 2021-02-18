using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using Majestim.BL.Interface.Rapport.CompteLocataire.Compta;
using Majestim.BL.OperationBase.Compta;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.Rapport.CompteLocataire;
using Majestim.DTO.DTO;

namespace Majestim.BL.Rapport.CompteLocataire.Compta
{
    public class CompteLocataireVisitor : ICompteLocataireVisitor
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly List<LigneComptesLocataireRo> _report = new List<LigneComptesLocataireRo>();
        private DateTime? _periode;
        private DateTime? _date;

        // totaux
        private const int Recap = 0;
        private const int RecapPeriode = 1;
        private readonly DebitCreditHelper _dcHelper = new DebitCreditHelper(2);

        public void OnBegin()
        {
            this._dcHelper.Raz();
        }

        public void OnBeginPeriode(KeyValuePair<OperationDto, IList<EcritureDto>> ls)
        {
            OperationDto key = ls.Key;

            this._dcHelper[RecapPeriode] = (0, 0);
            this._periode = key.Periode;
            this._date = null;
            this._report.Add(new LigneComptesLocataireRo { LigneComptesLocataireReportType = LigneComptesLocataireRoType.EmptyRow});
        }

        public void OnBeginPeriodeDate(KeyValuePair<OperationDto, IList<EcritureDto>> ls, DateTime? date)
        {
            this._date = date;
        }

        public void OnRow(KeyValuePair<OperationDto, IList<EcritureDto>> ls)
        {
            IList<EcritureDto> ecritures = ls.Value;
            OperationDto ope = ls.Key;

            foreach (EcritureDto ecr in ecritures)
            {
                this._report.Add(new LigneComptesLocataireRo
                {
                    Compte = ecr.Compte,
                    Contrat = ope.Contrat,
                    Credit = ecr.Credit,
                    Debit = ecr.Debit,
                    Date = this._date,
                    Libelle = ecr.Libelle,
                    Operation = ope.TypeOperation,
                    Periode = this._periode,
                    Solde = this._dcHelper.GetSolde(Recap),
                    LigneComptesLocataireReportType = LigneComptesLocataireRoType.Row
                });

                this._dcHelper.Add(RecapPeriode, (ecr.Debit, ecr.Credit));
                this._periode = null;
                this._date = null;
            }
        }

        public void OnEndPeriodeDate(DateTime? date)
        {
        }

        public void OnEndPeriode(DateTime? periode)
        {
            (double? debit, double? credit) solde = this._dcHelper.Solde(RecapPeriode);

            this._report.Add(new LigneComptesLocataireRo
            {
                Debit = solde.debit,
                Credit = solde.credit,
                Libelle = $"Total pour la période {periode:MMMM yyyy} ====>",
                LigneComptesLocataireReportType = LigneComptesLocataireRoType.Summary
            });
        }

        public void OnEnd()
        {
            (double? debit, double? credit) solde = this._dcHelper.Solde(0);
            (double? debit, double? credit) totaux = this._dcHelper[Recap];

            this._report.Add(new LigneComptesLocataireRo { LigneComptesLocataireReportType = LigneComptesLocataireRoType.EmptyRow });
            this._report.Add(new LigneComptesLocataireRo
            {
                Debit = solde.debit,
                Credit = solde.credit,
                Libelle = "Totaux pour la sélection ====>",
                LigneComptesLocataireReportType = LigneComptesLocataireRoType.Summary
            });

            // placer les totaux aussi en 1ere ligne
            this._report.Insert(0, new LigneComptesLocataireRo {  LigneComptesLocataireReportType = LigneComptesLocataireRoType.EmptyRow});
            this._report.Insert(0, new LigneComptesLocataireRo
            {
                Debit = solde.debit,
                Credit = solde.credit,
                Libelle = "Solde : ",
                LigneComptesLocataireReportType = LigneComptesLocataireRoType.Summary
            });
            this._report.Insert(0, new LigneComptesLocataireRo
            {
                Debit = totaux.debit,
                Credit = totaux.credit,
                Libelle = "Totaux : ",
                LigneComptesLocataireReportType = LigneComptesLocataireRoType.Summary
            });
            this._report.Insert(0, new LigneComptesLocataireRo {  LigneComptesLocataireReportType = LigneComptesLocataireRoType.EmptyRow});
        }

        public IEnumerable<LigneComptesLocataireRo> Report => this._report;
    }
}