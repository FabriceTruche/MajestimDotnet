using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
    public class AnalyzerRapproBordereau : AnalyzerRappro
    {
        private readonly IContratService _contratService;
        private Regex _regex = new Regex("Remise De Cheque", RegexOptions.IgnoreCase | RegexOptions.Multiline);

        public AnalyzerRapproBordereau(
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
            if (!this._regex.IsMatch(lb.Libelle))
                return null;

            // 1. vérifier le montant du bordereau 
            using (IUnitOfWork uof = new UnitOfWork(this.Context))
            {
                OneMany<BordereauDto, ChequeDto> bordereaux = uof.QueryOneMany<BordereauDto,ChequeDto>(@"
select b.*, c.*
  from Bordereau b, cheque c
  where c.bordereau_ID = b.ID
  and c.OpeDepot_ID is not NULL
  and c.OpeEncaissement_ID is null
  and (select sum(c.montant) from cheque c where c.Bordereau_ID = b.id) = @montant
"  
                    ,
                    new
                    {
                        montant = lb.Montant
                    }
                );

                // résultat
                List<LigneRapproCompta> resList = new List<LigneRapproCompta>();

                // Il peut y avoir plusieurs bordereaux validant la ligne de banque
                foreach (KeyValuePair<BordereauDto, IList<ChequeDto>> bordereau in bordereaux)
                {
                    foreach (ChequeDto chequeDto in bordereau.Value)
                    {
                        LigneRapproComptaBordereau lrc = new LigneRapproComptaBordereau(this.Regle)
                        {
                            CompteCredit = Comptes.c_511200.Text(),
                            CompteDebit = Comptes.c_512000.Text(),
                            Montant = chequeDto.Montant,
                            Operation = TypeOperation.encaissement, 
                            Date = DateTime.Today,
                            Periode = chequeDto.Periode,
                            LigneBanque = lb,
                            Libelle = chequeDto.Libelle,
                            Bordereau = bordereau.Key,
                            Cheque = chequeDto
                        };

                        // nom du contrat
                        if (chequeDto.Contrat_ID != null)
                        {
                            ContratDto dto = this._contratService.ContratById(chequeDto.Contrat_ID.Value);

                            if (dto != null)
                                lrc.Contrat = dto.Nom;
                        }

                        // ajout de la ligne de rappro compta 
                        resList.Add(lrc);
                    }
                }

                return resList;
            }
        }
    }
}

