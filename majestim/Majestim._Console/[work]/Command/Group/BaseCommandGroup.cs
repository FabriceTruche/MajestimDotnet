using Majestim.Interface.Command;

namespace Majestim.BL.Command.Group
{
    public class BaseCommandGroup : IGroupCommand
    {
        public BaseCommandGroup()
        {
            this.Enabled = false;
        }

        public bool Enabled { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICommand[] Commands { get; set; }
    }
}