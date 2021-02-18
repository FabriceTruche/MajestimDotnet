using System.Collections.Generic;
using System.Drawing;
using Majestim.View.Interface.Command;

namespace Majestim.Web.UI.Views
{
    public class WebCommand : ICommand
    {
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