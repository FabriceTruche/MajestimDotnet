using Majestim.View.Interface.Command;
using Majestim.View.Interface.EventHandlers;

namespace Majestim.View.Interface.View
{
    public interface ICommandView
    {
        /// <summary>
        /// Afficher l'arbre des éléments 
        /// </summary>
        /// <param name="rootCommand"></param>
        void SetCommandView(ICommand rootCommand);

        /// <summary>
        /// Levé lorsque un élément est sélectionné
        /// </summary>
        event CommandSelectedEventHandler CommandSelected;
    }
}