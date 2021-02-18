using System.Collections.Generic;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.Rapport.SituationLocataire;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;

namespace Majestim.BL.Interface.Rapport.SituationLocataire.Compta
{
    public interface ISituationLocataireService
    {
        /// <summary>
        /// sélection de lignes d'écritures de situation locataire
        /// </summary>
        /// <param name="contrats"></param>
        /// <returns></returns>
        OneMany<OperationDto, EcritureDto> SelectLigneSituation(IList<int> contrats);

        /// <summary>
        /// convertion des lignes de situation locataire en report
        /// </summary>
        /// <param name="nbMois"></param>
        /// <param name="ligneSituation"></param>
        /// <param name="visitor"></param>
        /// <returns></returns>
        //IList<LigneSituationRo> ConvertToReport(ChoixNbMois nbMois, OneMany<OperationDto, EcritureDto> ligneSituation, ISituationLocataireVisitor visitor);
        void Visit(OneMany<OperationDto, EcritureDto> ligneSituation, ISituationLocataireVisitor visitor);
    }
}

