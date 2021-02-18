using System;
using System.Collections.Generic;
using Majestim.BO;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.Rapport.CompteLocataire;
using Majestim.DTO.DTO;

namespace Majestim.View.Interface.View
{
    public delegate void PeriodeSelectedEventHandler(ChoixPeriode periode);
    public delegate void UpdateReportClickedEventHandler(
        ContratRo contrat,
        ChoixPeriode periodeDebut, 
        ChoixPeriode periodeFin, 
        IEnumerable<string> comptes,
        IEnumerable<string> operations
        );

    public interface IComptesLocataireView
    {
        /// <summary>
        /// fourni la liste des contrats 
        /// </summary>
        /// <param name="allContrats"></param>
        void ProvideContrats(IEnumerable<ContratRo> allContrats);

        /// <summary>
        /// fourni la liste de périodes début/fin possible
        /// </summary>
        /// <param name="periodesDebut"></param>
        /// <param name="periodesFin"></param>
        void ProvidePeriodes(IEnumerable<DateTime> periodesDebut, IEnumerable<DateTime> periodesFin);

        /// <summary>
        /// fourni la liste des comptes (code)
        /// </summary>
        /// <param name="comptes"></param>
        void ProvideComptes(IEnumerable<CompteDto> comptes);

        /// <summary>
        /// fourni la liste des codes opérations
        /// </summary>
        /// <param name="typeOperations"></param>
        void ProvideTypeOperations(IEnumerable<TypeOperationDto> typeOperations);

        /// <summary>
        /// fourni le report
        /// </summary>
        /// <param name="rows"></param>
        void ProvideReport(IEnumerable<LigneComptesLocataireRo> rows);

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Load;

        /// <summary>
        /// mise a jour du report de la situation des comptes locataires
        /// </summary>
        event UpdateReportClickedEventHandler UpdateReportClicked;
    }
}