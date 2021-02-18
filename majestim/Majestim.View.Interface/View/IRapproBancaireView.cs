using System.Collections.Generic;
using Majestim.BO.OperationBanque.RapproBancaire;
using Majestim.DTO.DTO;

namespace Majestim.View.Interface.View
{
    public delegate void ImportDataEventHandler();

    public delegate void GenererComptaEventHandler(IList<LigneRapproCompta> lignesRappro);

    public interface IRapproBancaireView
    {
        /// <summary>
        /// fourni les données brutes à la vue
        /// </summary>
        void ProvideImportedData(string data);

        /// <summary>
        /// fournit les lignes de banques à la vue
        /// </summary>
        /// <param name="lignesBanque"></param>
        void ProvideLignesBanque(IList<LigneBanqueRo> lignesBanque);

        /// <summary>
        /// fournit les lignes de rappro de compta
        /// </summary>
        void ProvideLignesCompta(IList<LigneRapproComptaRo> lignesRappro);

        /// <summary>
        /// générer les lignes d'écriture
        /// </summary>
        /// <param name="lignesRappro"></param>
        void GenererEcritures(IList<LigneRapproCompta> lignesRappro);

        /// <summary>
        /// fourni les données à importer
        /// </summary>
        string GetData { get; }

        /// <summary>
        /// 
        /// </summary>
        event ImportDataEventHandler ImportAutoDataClick;

        /// <summary>
        /// 
        /// </summary>
        event ImportDataEventHandler ImportManuelDataClick;

        /// <summary>
        /// 
        /// </summary>
        event GenererComptaEventHandler GenererComptaClick;

    }
}