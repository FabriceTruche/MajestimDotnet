using System;
using System.Collections.Generic;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.Rapport.SituationLocataire;
using Majestim.DTO.DTO;

namespace Majestim.BL.Interface.Rapport.SituationLocataire.Compta
{
    public interface ISituationLocataireVisitor
    {
        void OnBeginContrat(KeyValuePair<OperationDto, IList<EcritureDto>> ls);
        void OnBeginContratPeriode(KeyValuePair<OperationDto, IList<EcritureDto>> ls);
        void OnRow(KeyValuePair<OperationDto, IList<EcritureDto>> ls);
        void OnEndContratPeriode(string contrat, DateTime? periode);
        void OnEndContrat(string contrat);
    }
}