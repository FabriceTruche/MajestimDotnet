using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Dapper;
using log4net;
using Majestim.BL.Interface.OperationBase.Compta;
using Majestim.BL.Interface.OperationBase.Contrat;
using Majestim.BL.Interface.OperationGestion.AppelLoyer.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationGestion.AppelLoyer;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.DTO.Enum;
using Majestim.Interface;

namespace Majestim.BL.OperationGestion.AppelLoyer.Compta
{
    public class LignesAppelsService : ILignesAppelsService
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IContext _context;
        private readonly IContratService _contratService;
        private readonly IPeriodeService _periodeService;
        private readonly IComptaService _comptaService;

        public LignesAppelsService(
            IContext context,
            IContratService contratService,
            IPeriodeService periodeService,
            IComptaService comptaService
        )
        {
            this._context = context;
            this._contratService = contratService;
            this._periodeService = periodeService;
            this._comptaService = comptaService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baux"></param>
        /// <param name="periode"></param>
        /// <returns></returns>
        public IList<LigneAppel> CreateLignesAppel(IList<ContratRo> baux, DateTime periode)
        {
            return this.InternalCreateLigneAppels(baux, periode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="periode"></param>
        /// <returns></returns>
        public IList<LigneAppel> CreateLignesAppel(DateTime periode)
        {
            IList<ContratRo> baux = this._contratService.ContratsActif();

            return this.InternalCreateLigneAppels(baux, periode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baux"></param>
        /// <param name="periode"></param>
        /// <returns></returns>
        private IList<LigneAppel> InternalCreateLigneAppels(IList<ContratRo> baux, DateTime periode)
        {
            List<LigneAppel> list = new List<LigneAppel>();

            foreach (ContratRo bail in baux)
            {
                LigneAppel ligneAppel = this.InitAppel(bail, periode);

                if (ligneAppel != null)
                {
                    // la ligne d'appel a été créée pour ce contrat et cette période
                    list.Add(ligneAppel);

                    // 1. lignes globales
                    this.SelectLigneGlobales(ligneAppel);

                    // 2. lignes lots
                    this.SelectLigneLot(ligneAppel);

                    // 3. lignes contrat
                    this.SelectLigneContrat(ligneAppel);

                    // 4. ajustement des montants
                    this.AdjustMontants(ligneAppel);

                    // 5. statut de l'appel => Déjà appelé ou pas
                    this.GetStatutAppel(ligneAppel);
                }

            }

            return list;
        }

        /// <summary>
        /// récupérer le statut de l'appel => déjà appelé ou pas
        /// </summary>
        /// <param name="ligneAppel"></param>
        private void GetStatutAppel(LigneAppel ligneAppel)
        {
            using (IUnitOfWork uow = new UnitOfWork(this._context))
            {
                int res = uow.DbConnection.ExecuteScalar<int>(@"
select count(*)
from operation ope
where ope.contrat_id = @contratId
and ope.periode = @periode
and typeOperation_ID = @operationId
",
                    new
                    {
                        contratId = ligneAppel.Bail.Id,
                        periode = ligneAppel.Periode,
                        operationId = TypeOperation.appel
                    },
                    uow.Transaction
                );

                ligneAppel.DejaAppele = res!=0;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ligneAppel"></param>
        private void AdjustMontants(LigneAppel ligneAppel)
        {
            foreach (LigneAppelDetail detail in ligneAppel.AppelLoyerDetail)
            {
                switch (ligneAppel.TypeAppel)
                {
                    case TypeAppel.premier:
                        if (detail.TypeLigne == "LOYER" || detail.TypeLigne == "PROV")
                        {
                            if (ligneAppel.Bail.DateEntree != null && detail.DebitInitial!=null)
                            {
                                DateTime entree = ligneAppel.Bail.DateEntree.Value;
                                DateTime dernierJourMois =
                                    new DateTime(entree.Year, entree.Month, 1).AddMonths(1).AddDays(-1);
                                int nbJoursMois = dernierJourMois.Day;
                                int nbj = 1 + (nbJoursMois - entree.Day);
                                detail.Debit = Math.Round((nbj * detail.DebitInitial.Value) / nbJoursMois);
                                detail.Libelle += $" (entrée le {entree.ToShortDateString()} - {nbj}j)";
                            }
                        }
                        else if (detail.TypeLigne == "DEP")
                        {
                            LigneAppelDetail loyerPrinc =
                                ligneAppel.AppelLoyerDetail.FirstOrDefault(x => x.TypeLigne == "LOYER");

                            if (loyerPrinc != null && detail.DebitInitial!=null)
                                detail.Debit = Math.Round(detail.DebitInitial.Value);
                        }
                        break;

                    case TypeAppel.courant:
                        if (detail.TypeLigne == "LOYER" || detail.TypeLigne == "PROV")
                        {
                            if (ligneAppel.Bail.DateSortiePrevue != null && detail.DebitInitial!=null)
                            {
                                DateTime sortiePrevi = ligneAppel.Bail.DateSortiePrevue.Value;
                                DateTime dernierJourMois = this._periodeService.DernieJourMois(sortiePrevi);
                                int nbJoursMois = dernierJourMois.Day;
                                int nbj = 1 + (nbJoursMois - sortiePrevi.Day);
                                detail.Debit = Math.Round((nbj * detail.DebitInitial.Value) / nbJoursMois);
                                detail.Libelle += $" (sortie le {sortiePrevi.ToShortDateString()} - {nbj}j)";
                            }
                        }
                        break;

                    case TypeAppel.dernier:
                        break;
                }

                // cas de la regul
                if (detail.TypeLigne == "REGUL" || detail.TypeLigne == "REGUL_LOYER")
                {
                    if (detail.DebitInitial != null)
                    {
                        if ((detail.DateDebut == null) || (detail.DateFin == null))
                        {
                            log.Error(
                                $"Intervalle dates [début-fin] de la ligne d'appel ne peut pas être null: {detail.TypeLigne} - {detail.Libelle}");

                            detail.Debit = 0;
                            detail.Libelle = "<Intervalle de date ne put être null>";
                        }
                        else
                        {
                            int nbMoisTotal = this._periodeService.DiffMois(detail.DateDebut.Value, detail.DateFin.Value);
                            int nbMois = this._periodeService.DiffMois(detail.DateDebut.Value, ligneAppel.Periode);

                            // montant ajusté de la régul
                            detail.Debit = Math.Round(detail.DebitInitial.Value / nbMoisTotal, 2);

                            // libelle
                            detail.Libelle = detail.Libelle
                                .Replace("{n}", nbMois.ToString())
                                .Replace("{nb}", nbMoisTotal.ToString())
                                .Replace("{m}", detail.Debit.Value.ToString(CultureInfo.InvariantCulture));
                        }
                    }
                }
                else
                {
                    // on value le débit/crédit
                    if (detail.DebitInitial!=null)
                        detail.Debit = Math.Round(detail.DebitInitial.Value, 2);

                    if (detail.CreditInitial !=null)
                        detail.Credit = Math.Round(detail.CreditInitial.Value, 2);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bail"></param>
        /// <param name="periode"></param>
        private LigneAppel InitAppel(ContratRo bail, DateTime periode)
        {
            // 1. calcul du type d'appel
            TypeAppel? ta = this._contratService.TypeDAppel(bail, periode);

            if (ta == null)
                return null;

            return new LigneAppel
            {
                Periode = periode,
                Bail = bail,
                TypeAppel = ta.Value
            };
        }

        /// <summary>
        /// 
        /// </summary>
        private void MergeLigneAppel(LigneAppel ligneAppel, IEnumerable<LigneAppelDetail> ligneDetailToMerge)
        {
            foreach (LigneAppelDetail newLignedetail in ligneDetailToMerge)
            {
                    string code = newLignedetail.TypeLigne;

                    // la ligne existe-t-elle ?
                LigneAppelDetail detail = ligneAppel.AppelLoyerDetail.FirstOrDefault(x =>
                    x.TypeLigne.Equals(code, StringComparison.InvariantCultureIgnoreCase));

                if (detail == null)
                {
                    ligneAppel.AppelLoyerDetail.Add(newLignedetail);
                }
                else
                {
                    detail.Credit = newLignedetail.Credit;
                    detail.Debit = newLignedetail.Debit;
                    detail.CreditInitial = newLignedetail.CreditInitial;
                    detail.DebitInitial = newLignedetail.DebitInitial;

                    if (!string.IsNullOrEmpty(newLignedetail.Libelle))
                        detail.Libelle= newLignedetail.Libelle;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ligne"></param>
        private void SelectLigneGlobales(LigneAppel ligne)
        {
            using (IUnitOfWork uow = new UnitOfWork(this._context))
            {
                IEnumerable<LigneAppelDetail> typeLignes = uow.DbConnection.Query<LigneAppelDetail>(@"
select 
	lad.code typeLigne,
	lad.LIBELLE libelle,
	c.numero Compte,
    c.id CompteId
from 
	LigneAppelDefinition lad, 
	LigneAppelGlobal lag, 
	COMPTE c,
	TypeAppel ta
where lad.id = lag.LigneAppelDefinition_ID
and c.id = lad.COMPTE_ID
and lag.TYPEAPPEL_ID = ta.ID
and ta.code = @ta
",
                    new
                    {
                        ta = ligne.TypeAppel.ToString()
                    },
                    uow.Transaction
                );

                // merge lines
                this.MergeLigneAppel(ligne, typeLignes);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ligne"></param>
        private void SelectLigneLot(LigneAppel ligne)
        {
            using (IUnitOfWork uow = new UnitOfWork(this._context))
            {
                IEnumerable<LigneAppelDetail> lignesLot = uow.DbConnection.Query<LigneAppelDetail>(@"
select 
	lad.code typeLigne,
	lad.LIBELLE libelle,
	cpte.numero Compte,
	lal.debit debitInitial,
	lal.credit creditInitial
from 
	LigneAppelDefinition lad, 
	LigneAppelLot lal, 
	Contrat_Lot cl,
	CONTRAT bail,
	COMPTE cpte
where lad.id = lal.LigneAppelDefinition_ID
and cl.LOT_ID = lal.LOT_ID
and cl.CONTRAT_ID = bail.ID
and lad.COMPTE_ID = cpte.ID
and cpte.ID = lad.COMPTE_ID
and bail.NOM = @contrat
and (lal.debit>0 or lal.credit>0)
",
                    new
                    {
                        contrat = ligne.Bail.Nom
                    },
                    uow.Transaction
                );

                // merge lines
                this.MergeLigneAppel(ligne, lignesLot);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ligne"></param>
        private void SelectLigneContrat(LigneAppel ligne)
        {
            using (IUnitOfWork uow = new UnitOfWork(this._context))
            {
                IEnumerable<LigneAppelDetail> lignesContrat = uow.DbConnection.Query<LigneAppelDetail>(@"
select 
	bail.NOM, 
	bail.id,
	lad.code typeLigne,
	if(lac.LIBELLE = '', lad.libelle, lac.libelle) libelle,
	cpte.numero Compte,
	lac.debit debitInitial,
	lac.credit creditInitial,
	lac.PeriodeDebut dateDebut,
	lac.PeriodeFin dateFin
from LigneAppelContrat lac
inner join LigneAppelDefinition lad ON lad.id = lac.LigneAppelDefinition_ID
inner join CONTRAT bail ON lac.CONTRAT_ID = bail.ID
left outer join	COMPTE cpte ON cpte.ID = lad.COMPTE_ID
where bail.NOM = @contrat
and (lac.PeriodeDebut is null or (lac.PeriodeDebut is not null and lac.PeriodeDebut <= @periode))
and (lac.PeriodeFin is null or (lac.PeriodeFin is not null and lac.PeriodeFin >= @periode))
and (lac.debit>0 or lac.credit>0)
",
                    new
                    {
                        contrat = ligne.Bail.Nom,
                        periode = ligne.Periode
                    },
                    uow.Transaction
                );

                // merge lines
                this.MergeLigneAppel(ligne, lignesContrat);
            }
        }
    }
}
