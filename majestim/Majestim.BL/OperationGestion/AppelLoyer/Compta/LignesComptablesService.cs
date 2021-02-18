using System;
using System.Collections.Generic;
using Majestim.BL.Interface.OperationBase.Compta;
using Majestim.BL.Interface.OperationBase.Param;
using Majestim.BL.Interface.OperationGestion.AppelLoyer.Compta;
using Majestim.BO.OperationGestion.AppelLoyer;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.DTO.Enum;
using Majestim.Interface;

namespace Majestim.BL.OperationGestion.AppelLoyer.Compta
{
    public class LignesComptablesService : ILignesComptablesService
    {
        private readonly IContext _context;
        private readonly IComptaService _comptaService;
        private readonly IComptesService _comptesService;
        private readonly IParamService _paramService;

        public LignesComptablesService(
            IContext context,
            IComptaService comptaService,
            IComptesService comptesService,
            IParamService paramService)
        {
            this._context = context;
            this._comptaService = comptaService;
            this._comptesService = comptesService;
            this._paramService = paramService;
        }

        /// <summary>
        /// génération des écritures cmptables
        /// </summary>
        /// <param name="appels"></param>
        /// <returns></returns>
        public bool CreateLignesComptables(IList<LigneAppel> appels)
        {
            using (IUnitOfWork uow = new UnitOfWork(this._context))
            {
                IRepository<OperationDto> opeRepo = uow.Repository<OperationDto>();
                IRepository<EcritureDto> ecrRepo = uow.Repository<EcritureDto>();

                foreach (LigneAppel appel in appels)
                {
                    OperationDto newOpe =
                        this._comptaService.CreateOperation(appel.Periode, TypeOperation.appel, appel.Bail.Id);

                    opeRepo.Insert(newOpe);

                    foreach (LigneAppelDetail appelDetail in appel.AppelLoyerDetail)
                    {
                        if (appelDetail.Compte == null)
                            continue;

                        int? compteId = this._comptesService.IdFromNom(appelDetail.Compte);

                        if (compteId == null)
                            throw new Exception($"Le compte {appelDetail.Compte} n'existe pas");

                        // on passe l'écriture 
                        EcritureDto newEcr = this._comptaService.CreateEcriture(
                            newOpe,
                            compteId.Value,
                            appelDetail.Libelle,
                            appelDetail.Debit,
                            appelDetail.Credit);

                        ecrRepo.Insert(newEcr);

                        // ET celle du 411000
                        EcritureDto newEcrCompteLocataire = this._comptaService.CreateEcriture(
                            newOpe,
                            this._paramService.CompteLocataire.ID,
                            appelDetail.Libelle,
                            appelDetail.Credit,     // contre-partie
                            appelDetail.Debit       // contre-partie
                            );

                        ecrRepo.Insert(newEcrCompteLocataire);
                    }
                }
                uow.Commit();
            }

            return true;
        }
    }
}