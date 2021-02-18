using System;
using System.Reflection;
using AutoMapper;
using log4net;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationBase.Patrimoine;
using Majestim.BO.OperationBase.Tiers;
using Majestim.DTO.DTO;
using Majestim.Interface;

namespace Majestim.Mapper
{
    public class MapperService : IMapperService
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IConfigurationProvider MapperProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainAppEventHandler"></param>
        public MapperService(IMainAppEventHandler mainAppEventHandler)
        {
            mainAppEventHandler.AppStartedEvent += this.MainAppEventHandlerOnAppStartedEvent;
        }

        /// <summary>
        /// Initiialise les mapper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void MainAppEventHandlerOnAppStartedEvent(object sender, EventArgs eventArgs)
        {
            log.Info("Init dicos ...");
            this.InitDicos();

            log.Info("Init AutoMapper ...");
            this.InitMapper();

            // exemple
            //this.Test();
        }

        //private void Test()
        //{
        //    CONTRAT C = new CONTRAT
        //    {
        //        ID = 123,
        //        CHARGES_COMMUNES = true,
        //        DATE_ENTREE = DateTime.Today,
        //        TYPE_CONTRAT_ID = 4,
        //    };

        //    IMapper iface = this.MapperProvider.CreateMapper();
        //    BO.Contrat contrat = iface.Map<CONTRAT, BO.Contrat>(C);

        //    log.Info($"{C.TYPE_CONTRAT_ID} -- {contrat.TypeContrat}");

        //    contrat.TypeContrat = TypeContrat.local;
        //    contrat.Commentaire = "Hello";

        //    CONTRAT C2 = iface.Map<BO.Contrat, CONTRAT>(contrat);

        //    log.Info($"{C2.TYPE_CONTRAT_ID} -- {contrat.TypeContrat}");
        //}

        /// <summary>
        /// 
        /// </summary>
        private void InitDicos()
        {
            // todo in DB
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitMapper()
        {
            this.MapperProvider = new MapperConfiguration(cfg =>
            {
                // contrats
                cfg.CreateMap<ContratRo, ContratDto>()
                    .ForMember(dest => dest.TypeContrat_ID, act => { act.MapFrom(src => 1 + (int) src.TypeContrat); })
                    .ReverseMap()
                    .ForMember(dest => dest.TypeContrat, act => { act.MapFrom(src => src.TypeContrat_ID - 1); })
                    ;

                // lot
                cfg.CreateMap<Lot, LotDto>()
                    .ForMember(dest => dest.TypeLot_ID, act => { act.MapFrom(src => 1 + (int) src.TypeLot); })
                    .ForMember(dest => dest.Immeuble_ID, act => { act.MapFrom(src => src.Immeuble.Id); })
                    .ForMember(dest => dest.Adresse_ID, act => { act.MapFrom(src => src.Adresse.Id); })
                    .ReverseMap()
                    .ForMember(dest => dest.TypeLot, act => { act.MapFrom(src => src.TypeLot_ID - 1); })
                    ;

                // immeuble
                cfg.CreateMap<Immeuble, ImmeubleDto>()
                    .ForMember(dest => dest.Adresse_ID, act => { act.MapFrom(src => src.Adresse.Id); })
                    .ReverseMap()
                    ;

                // Individu
                cfg.CreateMap<Individu, IndividuDto>()
                    .ForMember(dest => dest.TypeCivilite_ID,
                        act => { act.MapFrom(src => 1 + (int) src.TypeCivilite); })
                    .ReverseMap()
                    .ForMember(dest => dest.TypeCivilite, act => { act.MapFrom(src => src.TypeCivilite_ID - 1); })
                    ;

                // Personne Morale
                cfg.CreateMap<PersonneMorale, PersonneMoraleDto>()
                    .ForMember(dest => dest.TypePersonneMorale_ID,
                        act => { act.MapFrom(src => 1 + (int) src.TypePersonneMorale); })
                    .ForMember(dest => dest.Adresse_ID, act => { act.MapFrom(src => src.Adresse.Id); })
                    .ReverseMap()
                    .ForMember(dest => dest.TypePersonneMorale,
                        act => { act.MapFrom(src => src.TypePersonneMorale_ID - 1); })
                    ;

                //// Tiers View vs Preneur
                //cfg.CreateMap<Preneur, TIERS_PRENEUR>()
                //    .ForMember(dest => dest.TYPE_PRENEUR_ID,
                //        act => { act.MapFrom(src => 1 + (int)src.TypePreneur); })
                //    .ForMember(dest => dest.TYPE_TIERS, act => { act.MapFrom(src => src.TypeTiers); })
                //    .ReverseMap()
                //    .ForMember(dest => dest.TypePreneur, act => { act.MapFrom(src => src.TYPE_PRENEUR_ID - 1); })
                //    .ForMember(dest => dest.TypeTiers, act => { act.MapFrom(src => src.TYPE_TIERS); })
                //    ;

                // comptaLocataire
                //cfg.CreateMap<LigneEcriture, LIGNE_ECRITURE_VIEW>()
                //    .ForMember(dest => dest.COMPTE_NUMERO, act => { act.MapFrom(src => src.Compte); })
                //    .ForMember(dest => dest.CONTRAT_NOM, act => { act.MapFrom(src => src.Contrat); })
                //    .ForMember(dest => dest.CREDIT, act => { act.MapFrom(src => src.Credit); })
                //    .ForMember(dest => dest.DATE_OPERATION, act => { act.MapFrom(src => src.Date); })
                //    .ForMember(dest => dest.DEBIT, act => { act.MapFrom(src => src.Debit); })
                //    .ForMember(dest => dest.ECRITURE_ID, act => { act.MapFrom(src => src.Id); })
                //    .ForMember(dest => dest.ECRITURE_LIBELLE, act => { act.MapFrom(src => src.Libelle); })
                //    .ForMember(dest => dest.TYPE_OPERATION_CODE, act => { act.MapFrom(src => src.CodeOperation); })
                //    .ForMember(dest => dest.PERIODE, act => { act.MapFrom(src => src.Periode); })
                //    .ReverseMap()
                //    ;

                //// compte
                //cfg.CreateMap<Compte, CompteDto>()
                //    .ReverseMap()
                //    ;

                //// type_operation
                //cfg.CreateMap<CodeOperation, TypeOperationDto>()
                //    .ReverseMap()
                //    ;

            });
        }

    }
}
