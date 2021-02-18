using System.Collections.Generic;
using Majestim.Interface;
using Majestim.View.Interface.Command;
using Majestim.View.Interface.View;

namespace Majestim.UI.Command
{
    public class MainMenuCommand : GroupCommand
    {
        private readonly IMainView _mainView;
        private readonly IContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainView"></param>
        /// <param name="context"></param>
        public MainMenuCommand(
            IMainView mainView, 
            IContext context
            )
        {
            _mainView = mainView;
            _context = context;

            // items de menu de premier niveau
            ICommand elementBaseMenu = new GroupCommand(null, "Gestion des éléments de base");
            elementBaseMenu.SubCommands =
                new List<ICommand>
                {
                    new ItemCommand(elementBaseMenu, "Gestion des Contrats", mainView.ShowContratView),
                    new ItemCommand(elementBaseMenu, "Gestion des Tiers", mainView.ShowTiersView),
                    new ItemCommand(elementBaseMenu, "Gestion des Biens", mainView.ShowBienView),
                };

            ICommand mouvLocataireMenu = new GroupCommand(null, "Gestion des entrées/sorties");
            mouvLocataireMenu.SubCommands =
                new List<ICommand>
                {
                    new ItemCommand(mouvLocataireMenu, "Entrée locataire"),
                    new ItemCommand(mouvLocataireMenu, "Sortie locataire"),
                };

            ICommand comptaMenu = new GroupCommand(null, "Compta");
            comptaMenu.SubCommands =
                new List<ICommand>
                {
                    new ItemCommand(comptaMenu, "Compta locataire", mainView.ShowComptaView),
                };

            ICommand operationGestionMenu = new GroupCommand(null, "Opérations de gestion");
            operationGestionMenu.SubCommands =
                new List<ICommand>
                {
                    new ItemCommand(operationGestionMenu, "Régul de charges"),
                    new ItemCommand(operationGestionMenu, "Banque"),
                    new ItemCommand(operationGestionMenu, "Quittance"),
                };

            this.SubCommands =
                new List<ICommand>
                {
                    elementBaseMenu,
                    comptaMenu,
                    mouvLocataireMenu,
                    operationGestionMenu
                };
        }
    }
}




/*        public IList<ICommand> SubCommands => new List<ICommand>
        {
            new GroupCommand
            {
                Text = "Elements de base",
                SubCommands = new List<ICommand>
                {
                    this.CreateListBiens(),
                    this.CreateListTiers(),
                    this.CreateListContrats()
                }
            }
        };

        public void Execute()
        {
        }

 
             /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ICommand CreateListTiers()
        {
            return new GroupCommand {Text = "Tiers"};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ICommand CreateListBiens()
        {
            return new GroupCommand { Text = "Biens" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ICommand CreateListContrats()
        {
            ICommand root = new GroupCommand { Text = "Contrats" };

            // retrive data
            var res = _context.Connection.Query<CONTRAT>("select * from contrat");

            return root;
        }

     
     
     */
