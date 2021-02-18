using Majestim.Interface.View;
using Majestim._Console.Command.Item;

namespace Majestim.BL.Command.Item
{
    public class ShowContratCommand : BaseCommand
    {
        public ShowContratCommand()
        {
            this.Text = "Afficher les Contrats";
        }

        public override void Execute(IMainView mainView)
        {
            mainView.ShowContratView();
        }

    }
}