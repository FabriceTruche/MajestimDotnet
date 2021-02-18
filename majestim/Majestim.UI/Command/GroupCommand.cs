using System.Collections.Generic;
using System.Drawing;
using Majestim.View.Interface.Command;

namespace Majestim.UI.Command
{
    public class GroupCommand : ICommand 
    {
        public GroupCommand(ICommand parent=null, string text="<root>", IList<ICommand> subCommands=null)
        {
            Parent = parent;
            Text = text;
            SubCommands = subCommands;
        }

        public string Text { get; set; }
        public Icon Icon { get; set; }
        public ICommand Parent { get; set; }
        public IList<ICommand> SubCommands { get; set; }
        public bool HasCommand { get; }

        public void Execute()
        {
        }

    }
}