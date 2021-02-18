using Majestim.BL.Command.Item;
using Majestim.Interface.Command;

namespace Majestim.BL.Command.Group
{
    public class SocleCommandGroup : BaseCommandGroup
    {
        public SocleCommandGroup()
        {
            this.Enabled = true;
            this.Title = "Socle";
            this.Commands = new ICommand[]
            {
                new ShowBienCommand(),
                new ShowTiersCommand(),
                new ShowContratCommand(),
            };
        }
    }
}