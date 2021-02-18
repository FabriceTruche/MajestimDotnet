using System.Collections.Generic;
using Majestim.BO.OperationBase.Contrat;

namespace Majestim.View.Interface.Component
{
    public interface IContratsSelectorComponent
    {
        /// <summary>
        /// set/get liste des contrats
        /// </summary>
        IList<ContratRo> Contrats { get; set; }

        /// <summary>
        /// reoturne la liste des contrats sélectionnés
        /// </summary>
        IList<ContratRo> SelectedContrats { get; }

        /// <summary>
        /// refresh liste des contrats
        /// </summary>
        /// <param name="selectAll"></param>
        void Refresh(bool selectAll);
    }
}