using System;
using System.Collections.Generic;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationGestion.AppelLoyer;

namespace Majestim.View.Interface.View
{
    public delegate void UpdateAppelViewClickedEventHandler(
        IList<ContratRo> contrats,
        DateTime periode
    );

    public delegate void CreerLignesComptablesEventHandler(
        IList<LigneAppel> lignesAppels
    );

    public interface IAppelLoyerView
    {
        /// <summary>
        /// fourni la liste des contrats 
        /// </summary>
        /// <param name="allContrats"></param>
        void ProvideContrats(IList<ContratRo> allContrats);

        /// <summary>
        /// fourni la liste de périodes début/fin possible
        /// </summary>
        /// <param name="periode"></param>
        void ProvidePeriode(IList<DateTime> periode);

        /// <summary>
        /// fourni le report
        /// </summary>
        /// <param name="lignesAppels"></param>
        /// <param name="rows"></param>
        void ProvideReport(IList<LigneAppel> lignesAppels, IList<LigneAppelRo> rows);

        /// <summary>
        /// 
        /// </summary>
        event EventHandler Load;

        /// <summary>
        /// mise a jour du report de la situation des comptes locataires
        /// </summary>
        event UpdateAppelViewClickedEventHandler UpdateReportClicked;

        /// <summary>
        /// demande de création des lognes d'appel
        /// </summary>
        event CreerLignesComptablesEventHandler CreerLignesComptablesClicked;
    }
}