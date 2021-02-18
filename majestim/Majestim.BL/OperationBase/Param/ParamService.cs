using System.Linq;
using Majestim.BL.Interface.OperationBase.Compta;
using Majestim.BL.Interface.OperationBase.Param;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.Interface;

namespace Majestim.BL.OperationBase.Param
{
    public class ParamService : IParamService
    {
        private readonly IContext _context;
        private readonly IComptesService _comptesService;
        private ExerciceDto _exerciceCourant;
        private CompteDto _compteLocataire;
        private const string NomCompteLocataire = "411000";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="comptesService"></param>
        public ParamService(
            IContext context,
            IComptesService comptesService
            )
        {
            this._context = context;
            this._comptesService = comptesService;
        }

        /// <summary>
        /// 
        /// </summary>
        public ExerciceDto ExerciceCourant
        {
            get
            {
                if (this._exerciceCourant == null)
                    using (IUnitOfWork uow = new UnitOfWork(this._context))
                    {
                        this._exerciceCourant = uow.Repository<ExerciceDto>().Query<ExerciceDto>(@"
                            select * from exercice where nom = (select valeur from paramGeneraux where cle='EXERCICE')
                            ").FirstOrDefault();
                    }

                return this._exerciceCourant;
            }
        }

        public CompteDto CompteLocataire => this._compteLocataire ??
                                            (this._compteLocataire = this._comptesService.CompteFromNom(NomCompteLocataire));
    }
}