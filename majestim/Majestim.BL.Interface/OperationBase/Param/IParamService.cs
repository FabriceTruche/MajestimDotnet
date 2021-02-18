using Majestim.DTO.DTO;

namespace Majestim.BL.Interface.OperationBase.Param
{
    public interface IParamService
    {
        /// <summary>
        /// retourne l'exercice courant
        /// </summary>
        /// <returns></returns>
        ExerciceDto ExerciceCourant { get; }

        /// <summary>
        /// fourni le compte locataire
        /// </summary>
        CompteDto CompteLocataire { get; }
    }
}