using System;
using System.Collections.Generic;
using Majestim.BO.OperationBase.Compta;

namespace Majestim.View.Interface.Component
{
    public interface IPeriodeSelectorComponent
    {
        /// <summary>
        /// set/get periodes
        /// </summary>
        IEnumerable<ChoixPeriode> Periodes { get; }

        /// <summary>
        /// retourne les pér
        /// </summary>
        ChoixPeriode Selection { get; }

        /// <summary>
        /// indique si la liste contient une valeur par défaut
        /// </summary>
        bool HasDefault { get; set; }

        /// <summary>
        /// Texte de la valeur par défaut
        /// </summary>
        string TextDefault { get; set; }

        /// <summary>
        /// texte du label
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// sélectionne un élément de la liste
        /// </summary>
        DateTime SelectedItem { set; }

        /// <summary>
        /// initialise la combo
        /// </summary>
        /// <param name="defaultText">texte de la valeur par défaut (pas de sélection). si null ou empty => pas de valeur par défaut</param>
        /// <param name="selectFirst">sélection de la première valeur si true</param>
        /// <param name="periodes">liste des périodes possibles</param>
        void Init(
            IEnumerable<ChoixPeriode> periodes,
            string defaultText = "Aucune",
            bool selectFirst = true
            );
    }
}