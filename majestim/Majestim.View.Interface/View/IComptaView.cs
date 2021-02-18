using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Majestim.BO;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;

namespace Majestim.View.Interface.View
{
    public interface IComptaView
    {
        event EventHandler OnShowView;

        /// <summary>
        /// Affiche les écritures de compte locataire pour un ensemble de contrats (ou tous si null ou vide)
        /// </summary>
        /// <param name="ecritures"></param>
        /// <param name="filter"></param>
        void ShowCompteLocataire(OneMany<OperationDto,EcritureDto> ecritures, ContratRo[] filter);

        /// <summary>
        /// Affiche les écritures de provision pour un ensemble de contrats (ou tous si null ou vide)
        /// </summary>
        /// <param name="ecritures"></param>
        /// <param name="filter"></param>
        void ShowProvisionLocataire(OneMany<OperationDto, EcritureDto> ecritures, ContratRo[] filter);

    }
}