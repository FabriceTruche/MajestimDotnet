using System;
using System.Collections.Generic;
using Majestim.BO;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationBase.Patrimoine;
using Majestim.BO.OperationBase.Tiers;

namespace Majestim.View.Interface.View
{
    public delegate void ContratSelectedEventHandler(ContratRo contrat);

    public interface IContratView
    {
        /// <summary>
        /// Affiche la liste de contrats passée en paramètre
        /// </summary>
        /// <param name="contrats"></param>
        void ShowContrats(IEnumerable<ContratRo> contrats);

        /// <summary>
        /// Affiche le détail d'un contrat
        /// </summary>
        /// <param name="contrat"></param>
        /// <param name="lots"></param>
        /// <param name="locataires"></param>
        void ShowContratDetail(ContratRo contrat, IEnumerable<Lot> lots, IEnumerable<Preneur> locataires);

        /// <summary>
        /// Levé lorsque la vue est affichée
        /// </summary>
        event EventHandler OnShowView;

        /// <summary>
        /// Levé lorsqie un (et un seul) contrat est sélectionné dans la vue
        /// </summary>
        event ContratSelectedEventHandler OnContratSelected;
    }
}