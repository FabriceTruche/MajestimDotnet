using System;
using System.Collections.Generic;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.Rapport.CompteLocataire;
using Majestim.DTO.DTO;

namespace Majestim.BL.Interface.Rapport.CompteLocataire.Compta
{
    public interface ICompteLocataireVisitor
    {
        void OnBegin();
        void OnBeginPeriode(KeyValuePair<OperationDto,IList<EcritureDto>> ls);
        void OnBeginPeriodeDate(KeyValuePair<OperationDto, IList<EcritureDto>> ls, DateTime? date);
        void OnRow(KeyValuePair<OperationDto, IList<EcritureDto>> ls);
        void OnEndPeriodeDate(DateTime? date);
        void OnEndPeriode(DateTime? periode);
        void OnEnd();

        IEnumerable<LigneComptesLocataireRo> Report { get; }
    }
}