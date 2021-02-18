using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Majestim.BL.Interface.OperationBase.Compta;
using Majestim.BL.Interface.OperationBase.Param;
using Majestim.BO.OperationBase.Compta;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.DTO.Enum;
using Majestim.Interface;

namespace Majestim.BL.OperationBase.Compta
{
    public class ComptaService : IComptaService
    {
        //private readonly IRepository<CompteDto> _repoCompte;
        //private readonly IRepository<TypeOperationDto> _repoTypeOperation;
        private readonly IContext _context;

        private readonly IMapperService _mapper;
        private readonly IParamService _paramService;

        public ComptaService(
            //IRepository<CompteDto> repoCompte,
            //IRepository<TypeOperationDto> repoTypeOperation,
            IContext context,
            IMapperService mapper,
            IParamService paramService)
        {
            //this._repoCompte = repoCompte;
            //this._repoTypeOperation = repoTypeOperation;
            this._context = context;
            this._mapper = mapper;
            this._paramService = paramService;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CompteDto> Comptes()
        {
            using (IUnitOfWork uow = new UnitOfWork(this._context))
            {
                IEnumerable<CompteDto> comptesDto = uow.Repository<CompteDto>().GetAll();
                //IMapper mapper = this._mapper.MapperProvider.CreateMapper();
                //List<CompteDto> comptes= mapper.Map<List<CompteDto>, List<CompteDto>>(comptesDto.ToList());

                return comptesDto;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TypeOperationDto> TypeOperations()
        {
            using (IUnitOfWork uow = new UnitOfWork(this._context))
            {
                IEnumerable<TypeOperationDto> operationsDto = uow.Repository<TypeOperationDto>().GetAll();
                //IMapper mapper = this._mapper.MapperProvider.CreateMapper();
                //List<CodeOperation> operations = mapper.Map<List<TypeOperationDto>, List<CodeOperation>>(operationsDto.ToList());

                return operationsDto;
            }
        }

        /// <summary>
        /// créer une opérations comptable
        /// </summary>
        /// <param name="periode"></param>
        /// <param name="typeOpe"></param>
        /// <param name="contrat"></param>
        /// <param name="contratId"></param>
        /// <returns></returns>
        public OperationDto CreateOperation(DateTime periode, TypeOperation typeOpe, int? contratId = null)
        {
            OperationDto dto = new OperationDto
            {
                DateOperation = DateTime.Today,
                Contrat_ID = contratId,
                Periode = periode,
                TypeOperation_ID = (int) typeOpe,
                Exercice_ID = this._paramService.ExerciceCourant.ID
            };

            return dto;
        }

        /// <summary>
        /// créer une écriture colmptable
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="compteId"></param>
        /// <param name="libelle"></param>
        /// <param name="debit"></param>
        /// <param name="credit"></param>
        /// <returns></returns>
        public EcritureDto CreateEcriture(OperationDto operation, int compteId, string libelle, double? debit, double? credit)
        {
            EcritureDto dto = new EcritureDto
            {
                Compte_ID=compteId,
                Credit=credit,
                Debit = debit,
                Libelle=libelle,
                Operation_ID=operation.ID
            };

            return dto;
        }
    }
}




///// <inheritdoc />
///// <summary>
///// selection d'écritures comptables
///// </summary>
///// <param name="contrat"></param>
///// <param name="periodeDebut"></param>
///// <param name="periodeFin"></param>
///// <param name="comptes"></param>
///// <param name="operations"></param>
///// <returns></returns>
//public IEnumerable<LigneEcriture> SelectLigneEcritures(
//    Bail contrat,
//    ChoixPeriode periodeDebut,
//    ChoixPeriode periodeFin,
//    IEnumerable<string> comptes,
//    IEnumerable<string> operations
//)
//{
//    return null;
//}