using System.Collections.Generic;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.Rapport.CompteLocataire;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;

namespace Majestim.BL.Interface.Rapport.CompteLocataire.Compta
{
    public interface ICompteLocataireService
    {
        /// <summary>
        /// selectionne un ensemble de lignes comptables
        /// </summary>
        /// <param name="contrat"></param>
        /// <param name="periodeDebut"></param>
        /// <param name="periodeFin"></param>
        /// <param name="comptes"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        OneMany<OperationDto,EcritureDto> SelectLigneEcritures(
            ContratRo contrat,
            ChoixPeriode periodeDebut,
            ChoixPeriode periodeFin,
            IEnumerable<string> comptes,
            IEnumerable<string> operations
        );

        /// <summary>
        /// convertion des lignes de situation locataire en report
        /// </summary>
        /// <param name="nbMois"></param>
        /// <param name="ligneSituation"></param>
        /// <param name="visitor"></param>
        /// <returns></returns>
        IEnumerable<LigneComptesLocataireRo> ConvertToReport(OneMany<OperationDto, EcritureDto> ligneSituation, ICompteLocataireVisitor visitor);
    }
}

