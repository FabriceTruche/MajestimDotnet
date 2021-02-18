using Majestim.View.Interface.Command;
using System.Collections.Generic;
using System.Drawing;

namespace Majestim.UI.Command
{
    public class GroupCommand : ICommand 
    {
        public GroupCommand(string text="<root>", IList<ICommand> subCommands=null)
        {
            this.Text = text;
            this.SubCommands = subCommands;
            this.HasCommand = true;
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