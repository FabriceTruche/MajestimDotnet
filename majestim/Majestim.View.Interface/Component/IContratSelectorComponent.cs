using System;
using System.Collections.Generic;
using Majestim.BO.OperationBase.Contrat;

namespace Majestim.View.Interface.Component
{
    public interface IContratSelectorComponent
    {
        /// <summary>
        /// set/get liste des contrats
        /// </summary>
        IEnumerable<ContratRo> Contrats { get; set; }

        /// <summary>
        /// reoturne la liste des contrats sélectionnés
        /// </summary>
        ContratRo SelectedContrat { get; }

        /// <summary>
        /// refresh liste des contrats
        /// </summary>
        /// <param name="selectAll"></param>
        void Refresh(bool selectAll);
    }
}