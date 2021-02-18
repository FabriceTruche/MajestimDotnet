using System;
using System.Collections.Generic;
using Majestim.BO.OperationBase.Compta;
using Majestim.DTO.DTO;
using Majestim.DTO.Enum;

namespace Majestim.BL.Interface.OperationBase.Compta
{
    public interface IComptaService
    {
        /// <summary>
        /// retourn la liste de tous les comptes
        /// </summary>
        /// <returns></returns>
        IEnumerable<CompteDto> Comptes();

        /// <summary>
        /// retourne la liste des opérations
        /// </summary>
        /// <returns></returns>
        IEnumerable<TypeOperationDto> TypeOperations();

        /// <summary>
        /// créer une opération comptable
        /// </summary>
        /// <returns>vrai si l'opération a bien été créée</returns>
        OperationDto CreateOperation(DateTime periode, TypeOperation typeOpe, int? contrat = null);

        /// <summary>
        /// créer une ligne d'écriture comptable
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="compte"></param>
        /// <param name="libelle"></param>
        /// <param name="debit"></param>
        /// <param name="credit"></param>
        /// <returns></returns>
        EcritureDto CreateEcriture(OperationDto operation, int compte, string libelle, double? debit, double? credit);
    }
}
