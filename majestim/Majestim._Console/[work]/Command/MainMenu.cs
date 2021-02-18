using Majestim.BL.Command.Group;
using Majestim.Interface.Command;

namespace Majestim.BL.Command
{
    public class MainMenu : BaseMenu
    {
        public MainMenu()
        {
            this.Items = new IGroupCommand[]
            {
                new SocleCommandGroup(),
                new OperationCommandGroup(),
                new MouvementCommandGroup(),
            };
        }
    }
}