using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Majestim.View.Interface.View
{
    public interface IMainView
    {
        /// <summary>
        /// Fermer la vue principale ==> fermer l'App
        /// </summary>
        void Close();

        /// <summary>
        /// Afficher la vue Tiers
        /// </summary>
        void ShowTiersView();

        /// <summary>
        /// Afficher la vue Biens
        /// </summary>
        void ShowBienView();

        /// <summary>
        /// Afficher la vue des contrats
        /// </summary>
        void ShowContratView();

        /// <summary>
        /// Afficher la vue de la compta locataire
        /// </summary>
        void ShowComptaView();

        /// <summary>
        /// Affiche la vue des comptes locataires
        /// </summary>
        void ShowSituationLocataire();

        /// <summary>
        /// 
        /// </summary>
        void ShowComptesLocataire();

        /// <summary>
        /// 
        /// </summary>
        void ShowAppelLoyerView();

        /// <summary>
        /// 
        /// </summary>
        void ShowRapproBancaire();

        /// <summary>
        /// execute une action avec barreprogressBar
        /// </summary>
        Task RunProgress(Action action);

        /// <summary>
        /// Levé lorsque la vue principale est affichée
        /// </summary>
        event EventHandler OnShow;

        /// <summary>
        /// 
        /// </summary>
        event FormClosedEventHandler OnClose;
    }
}
