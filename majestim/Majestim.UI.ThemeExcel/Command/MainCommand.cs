using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Majestim.UI.Command;
using Majestim.View.Interface.Command;
using Majestim.View.Interface.View;

namespace Majestim.UI.ThemeExcel.Command
{
    public class MainCommand : GroupCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainView"></param>
        public MainCommand(IMainView mainView)
        {
            // assigner le menu à 2 niveaux
            this.SubCommands = new List<ICommand>
            {
                new GroupCommand
                {
                    Text = "Données élémentaires",
                    SubCommands = new List<ICommand>
                    {
                        new ItemCommand("Lots", mainView.ShowBienView),
                        new ItemCommand("Tiers", mainView.ShowTiersView),
                        new ItemCommand("Contrats", mainView.ShowContratView),
                        new ItemSeparator(),
                        new ItemCommand("Lignes d'appels"),
                        new ItemCommand("Lignes de rapprochements"),
                        new ItemSeparator(),
                        new GroupCommand
                        {
                            Text = "Paramètres comptable",
                            SubCommands = new List<ICommand>
                            {
                                new ItemCommand("Plan comptable"),
                                new ItemCommand("Paramètres de comptes"),
                            }
                        },
                        new ItemSeparator(),
                        new ItemCommand("Compteurs"),
                        new ItemSeparator(),
                        new ItemCommand("Bases de répartitions"),
                    }
                },
                new GroupCommand
                {
                    Text = "Opérations de gestion",
                    SubCommands = new List<ICommand>
                    {
                        new ItemCommand("Appel de loyer",mainView.ShowAppelLoyerView),
                        new ItemCommand("Régul de charges"),
                        new ItemCommand("Saisie de bordereaux"),
                    }
                },
                new GroupCommand
                {
                    Text = "Opérations de banque et comptable",
                    SubCommands = new List<ICommand>
                    {
                        new ItemCommand("Rapprochement des écritures de banque", mainView.ShowRapproBancaire),
                        new ItemCommand("Opération diverse"),
                    }
                },
                new GroupCommand
                {
                    Text = "Rapport",
                    SubCommands = new List<ICommand>
                    {
                        new ItemCommand("Situation comptes locataires", mainView.ShowSituationLocataire),
                        new ItemCommand("Consultation comptable locataires", mainView.ShowComptesLocataire),
                        new ItemCommand("Quittancement"),
                        new ItemCommand("Quittancement valant appel"),
                        new ItemCommand("Bordereaux"),
                        new ItemCommand("Attestation dépôt garantie"),
                    }
                }
            };

            // assigner les parents
            this.AssignParent(null, this.SubCommands);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="subCommands"></param>
        /// <param name="empty"></param>
        private void AssignParent(ICommand parent, IList<ICommand> subCommands)
        {
            if (subCommands != null)
                foreach (ICommand item in subCommands)
                {
                    if (parent != null)
                        item.Parent = parent;
                    this.AssignParent(item, item.SubCommands);
                }
        }
    }
}