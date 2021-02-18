using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Dapper;
using Majestim.BL.Interface.OperationBase.Compta;
using Majestim.BL.Interface.OperationBase.Contrat;
using Majestim.BO.OperationBanque.RapproBancaire;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.DTO.Enum;
using Majestim.Interface;

namespace Majestim.BL.OperationBanque.RapproBancaire.Analyzer
{
    public class AnalyzerRapproChequeEmis: AnalyzerRappro
    {
        private readonly IContratService _contratService;
        //private Regex _regex = new Regex("Cheque Emis", RegexOptions.IgnoreCase | RegexOptions.Multiline);

        public AnalyzerRapproChequeEmis(
            RegleRapproDto regle, 
            IContext context,
            IContratService contratService
            ) 
            : base(regle, context)
        {
            this._contratService = contratService;
        }

        public override IList<LigneRapproCompta> AnalyzeLigneBanque(LigneBanque lb)
        {
            // 1. récupo numero cheque
            string[] data = lb.Libelle.Split('-');

            if (data.Length != 2)
                return null;

            long numCheque;

            if (!long.TryParse(data[1], out numCheque))
                return null;

            // 2. vérifier si le numero de cheque existe en base
            using (IUnitOfWork uof = new UnitOfWork(this.Context))
            {
                ChequeEmisDto cheque = uof.Repository<ChequeEmisDto>().Single($"numero={numCheque}");

                if (cheque == null)
                    return null;

                // résultat
                LigneRapproComptaChequeEmis ligneCompta = new LigneRapproComptaChequeEmis(this.Regle)
                {
                    CompteCredit = Comptes.c_511200.Text(),
                    CompteDebit = Comptes.c_512000.Text(),
                    Montant = cheque.Montant,
                    Operation = TypeOperation.operationDiverse,
                    Date = DateTime.Today,
                    Periode = null,
                    LigneBanque = lb,
                    Libelle = cheque.Libelle,
                    ChequeEmisDto = cheque
                };

                // nom du contrat
                if (cheque.Contrat_ID != null)
                {
                    ContratDto dto = this._contratService.ContratById(cheque.Contrat_ID.Value);

                    if (dto != null)
                        ligneCompta.Contrat = dto.Nom;
                }


                return new[] {ligneCompta};
            }
        }
    }
}

