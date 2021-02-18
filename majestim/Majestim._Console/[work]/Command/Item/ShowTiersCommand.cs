using Majestim.Interface.View;
using Majestim._Console.Command.Item;

namespace Majestim.BL.Command.Item
{
    public class ShowTiersCommand : BaseCommand
    {
        public ShowTiersCommand()
        {
            this.Text = "Afficher les Tiers";
        }

        public override void Execute(IMainView mainView)
        {
            mainView.ShowTiersView();
        }
    }
}