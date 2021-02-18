using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using Majestim.BL.Interface.Rapport.SituationLocataire.Compta;
using Majestim.BL.OperationBase.Compta;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.Rapport.SituationLocataire;
using Majestim.DTO.DTO;

namespace Majestim.BL.Rapport.SituationLocataire.Compta
{
    public class SituationLocataireVisitor : ISituationLocataireVisitor
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // paramètres du visitor
        private readonly ChoixNbMois _nbMois;

        // totaux dc par niveau
        private const int RecapContrat = 0;
        private const int RecapPeriode = 1;
        private const int NbRecap = 2;
        private readonly DebitCreditHelper _dcHelper = new DebitCreditHelper(NbRecap);

        // ruptures
        private bool _histo;
        private string _contrat;
        private DateTime? _periode;

        // ivisitor
        private readonly List<LigneSituationRo> _report = new List<LigneSituationRo>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nbMois"></param>
        public SituationLocataireVisitor(ChoixNbMois nbMois)
        {
            this._nbMois = nbMois;
        }

        /// <summary>
        /// 
        /// </summary>
        public IList<LigneSituationRo> Report => this._report;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ls"></param>
        void ISituationLocataireVisitor.OnBeginContrat(KeyValuePair<OperationDto, IList<EcritureDto>> ls)
        {
            this._histo = this._nbMois.NbMois != -1;
            this._contrat = ls.Key.Contrat;

            this._dcHelper.Raz(); // [RecapContrat] = (0, 0);

            // empty row
            this._report.Add(new LigneSituationRo
            {
                LigneSituationReportType = LigneSituationRoType.EmptyRow
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ls"></param>
        void ISituationLocataireVisitor.OnBeginContratPeriode(KeyValuePair<OperationDto, IList<EcritureDto>> ls)
        {
            if (ls.Key.Periode == null)
                throw new Exception("La période ne peut pas être null");

            this._periode = ls.Key.Periode;

            if (this._histo)
            {
                if (!this.IsHisto(ls.Key.Periode))
                {
                    (double? debit, double? credit) = this._dcHelper.Solde(RecapContrat);

                    this._report.Add(new LigneSituationRo
                    {
                        Contrat = this._contrat,
                        _Contrat = ls.Key.Contrat,
                        Libelle = $"==== SOLDE AU {ls.Key.Periode.AddDays(-1):dd/MM/yyyy} ========>>>>",
                        Debit = debit,
                        Credit = credit,
                        LigneSituationReportType = LigneSituationRoType.ContratSolde
                    });
                    this._histo = false;
                    this._contrat = null;
                }
            }
            else
            {
                this._dcHelper[RecapPeriode] = (0, 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ls"></param>
        void ISituationLocataireVisitor.OnRow(KeyValuePair<OperationDto, IList<EcritureDto>> ls)
        {
            foreach (EcritureDto dto in ls.Value)
            {
                if (this._histo)
                {
                    // on se contente de cumuler
                    this._dcHelper.Add(RecapContrat, (dto.Debit, dto.Credit));
                }
                else
                {
                    //log.Info($"end contrat {ls.Id} libelle={ls.Libelle} debit={ls.Debit} credit={ls.Credit}");
                    this._dcHelper.Add(RecapPeriode, (dto.Debit, dto.Credit));
                    this._report.Add(new LigneSituationRo
                    {
                        Contrat = this._contrat,
                        _Contrat = ls.Key.Contrat,
                        Periode = this._periode,
                        Date = ls.Key.DateOperation,
                        Libelle = dto.Libelle,
                        Debit = dto.Debit,
                        Credit = dto.Credit,
                        Solde = this._dcHelper.GetSolde(RecapContrat),
                        LigneSituationReportType = LigneSituationRoType.Row
                    });

                    this._contrat = null;
                    this._periode = null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contrat"></param>
        /// <param name="periode"></param>
        void ISituationLocataireVisitor.OnEndContratPeriode(string contrat, DateTime? periode)
        {
            if (periode == null)
                throw new Exception("La période ne peut pas être null");
            
            if (this._histo)
                return;

            (double? debit, double? credit) = this._dcHelper.Solde(RecapPeriode);

            this._report.Add(new LigneSituationRo
            {
                _Contrat = contrat,
                Libelle = $"Solde pour la période {periode.Value:MMMM yyyy}",
                Debit = debit,
                Credit = credit,
                //Solde = this._dcHelper.GetSolde(RecapContrat),
                LigneSituationReportType = LigneSituationRoType.PeriodeSummary
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contrat"></param>
        void ISituationLocataireVisitor.OnEndContrat(string contrat)
        {
            //log.Info($"end contrat {contrat}");

            //(double? debit, double? credit) res = this.ComputeSolde(this._totalDebit, this._totalCredit);
            (double? debit, double? credit) = this._dcHelper.Solde(RecapContrat);

            this._report.Add(new LigneSituationRo
            {
                Contrat = this._contrat,
                _Contrat = contrat,
                Libelle = $"Situation de compte au {DateTime.Today:d}",
                Debit = debit,
                Credit = credit,
                LigneSituationReportType = LigneSituationRoType.ContratSummary
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="periode"></param>
        /// <returns></returns>
        private bool IsHisto(DateTime periode)
        {
            if (this._nbMois.NbMois == 0)
                return true;

            DateTime periodeHisto = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            periodeHisto = periodeHisto.AddMonths(- this._nbMois.NbMois);

            return periode <= periodeHisto;
        }
    }
}

