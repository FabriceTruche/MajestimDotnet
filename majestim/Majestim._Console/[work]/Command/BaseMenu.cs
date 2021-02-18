using Majestim.Interface.Command;

namespace Majestim.BL.Command
{
    public class BaseMenu : IMenuCommand
    {
        public IGroupCommand[] Items { get; set; }
    }
}