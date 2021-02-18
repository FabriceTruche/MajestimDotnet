using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Majestim.BL.Interface.OperationBase.Compta;
using Majestim.BL.Interface.OperationBase.Contrat;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationBase.Patrimoine;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DAL.Interface.Repository;
using Majestim.DAL.Repository;
using Majestim.DTO.DTO;
using Majestim.DTO.Enum;
using Majestim.Interface;

namespace Majestim.BL.OperationBase.Contrat
{
    public class ContratService : IContratService
    {
        //private readonly IContratRepository _repoContrat;
        private readonly IMapperService _mapperService;
        private readonly IPeriodeService _periodeService;
        private readonly IContext _context;

        public ContratService(
            //IRepository<ContratDto> repoContrat,
            IMapperService mapperService,
            IPeriodeService periodeService,
            IContext context
            )
        {
            //this._repoContrat = repoContrat as IContratRepository;
            this._mapperService = mapperService;
            this._periodeService = periodeService;
            this._context = context;
        }

        public ContratDto ContratById(int id)
        {
            using (IUnitOfWork uow = new UnitOfWork(this._context))
                return uow.Repository<ContratDto>().GetById(id);
        }

        public ContratDto ContratByName(string name)
        {
            using (IUnitOfWork uow = new UnitOfWork(this._context))
                return uow.Repository<ContratDto>().Single($"nom = {name}");
        }

        public IList<ContratRo> Contrats()
        {
            using (IUnitOfWork uow = new UnitOfWork(this._context))
            {
                IEnumerable<ContratDto> allDto = uow.Repository<ContratDto>().GetAll();
                IMapper mapper = this._mapperService.MapperProvider.CreateMapper();
                List<ContratRo> contrats = mapper.Map<List<ContratDto>, List<ContratRo>>(allDto.ToList());

                return contrats;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IList<ContratRo> ContratsActif()
        {
            return this.Contrats().Where(x => x.IsActif).ToList();
        }

        public IEnumerable<ContratDto> ContratsDto()
        {
            using (IUnitOfWork uow = new UnitOfWork(this._context))
            {
                return uow.Repository<ContratDto>().GetAll();
            }
        }

        public IEnumerable<ContratDto> ContratsDtoActif()
        {
            return this.ContratsDto().Where(x => x.DateSortie == null);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="contrat"></param>
        /// <returns></returns>
        public IList<Lot> LotsOfContrat(ContratRo contrat)
        {
            using (IUnitOfWork uow = new UnitOfWork(this._context))
            {
                if (uow.Repository<ContratDto>() is ContratRepository repo)
                {
                    IEnumerable<LotDto> res = repo.GetLots(contrat.Id);
                    IMapper mapper = this._mapperService.MapperProvider.CreateMapper();
                    List<Lot> lots = mapper.Map<List<LotDto>, List<Lot>>(res.ToList());

                    return lots;
                }

                return null;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="contrat"></param>
        /// <returns></returns>
        //public IEnumerable<Preneur> PreneursOfContrat(Bail contrat)
        //{
        //    IEnumerable<TIERS_PRENEUR> res = this._repoContrat.GetPreneurs(contrat.Id);
        //    IMapper mapper = this._mapperService.MapperProvider.CreateMapper();
        //    List<Preneur> preneurs = mapper.Map<List<TIERS_PRENEUR>, List<Preneur>>(res.ToList());

        //    return preneurs;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contrat"></param>
        /// <param name="periode"></param>
        /// <returns></returns>
        public TypeAppel? TypeDAppel(ContratRo contrat, DateTime periode)
        {
            // pas de date d'entrée => contrat non actif => pas d'appel à faire
            if (contrat.DateEntree == null)
                return  null;

            // periode à appelée avant date entrée => pas d'appel à faire
            if (this._periodeService.PeriodeLowerThan(periode, contrat.DateEntree.Value))
                return null;

            // periode identique à la date d'entrée => premier appel
            if (this._periodeService.SamePeriode(contrat.DateEntree.Value, periode))
                return TypeAppel.premier;

            // pas de sortie prévu => appel courant
            if (contrat.DateSortiePrevue == null)
                return TypeAppel.courant;

            // sortie prévue. periode en cours ? => dernier
            if (this._periodeService.SamePeriode(contrat.DateSortiePrevue.Value, periode))
                return TypeAppel.dernier;

            // periode posterieure à la sortie prévu => contrat probablement clos => pas à appeler
            return null;
        }
    }
}