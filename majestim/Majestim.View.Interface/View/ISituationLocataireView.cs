using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Majestim.BO;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.Rapport.SituationLocataire;

namespace Majestim.View.Interface.View
{
    public delegate void SituationLocataireParamHandler(ChoixNbMois nbMois, IList<ContratRo> contrats);

    public interface ISituationLocataireView
    {
        /// <summary>
        /// Fourni la liste de tous les contrats
        /// </summary>
        /// <returns></returns>
        void ProvideContrats(IList<ContratRo> allContrats);

        /// <summary>
        /// fourni les lignes du report
        /// </summary>
        /// <param name="rows"></param>
        void ProvideReport(IList<LigneSituationRo> rows);

        /// <summary>
        /// 
        /// </summary>
        event ContratSelectedEventHandler ContratSelected; 

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Load;

        /// <summary>
        /// mise a jour du report de la situation des comptes locataires
        /// </summary>
        event SituationLocataireParamHandler UpdateReportClick;
    }
}