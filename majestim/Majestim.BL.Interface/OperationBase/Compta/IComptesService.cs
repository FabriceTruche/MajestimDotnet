using Majestim.DTO.DTO;

namespace Majestim.BL.Interface.OperationBase.Compta
{
    public interface IComptesService
    {
        /// <summary>
        /// nom d'un compte selon son id
        /// </summary>
        /// <param name="compteId"></param>
        /// <returns></returns>
        string NomFromId(int compteId);

        /// <summary>
        /// id d'un compte selon son nom
        /// </summary>
        /// <param name="compte"></param>
        /// <returns></returns>
        int? IdFromNom(string compte);

        /// <summary>
        /// dto compte selon son nom
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        CompteDto CompteFromNom(string nom);

        /// <summary>
        /// dto compte selon son nom
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CompteDto CompteFromId(int id);
    }
}