using System.Collections.Generic;
using System.Drawing;

namespace Majestim.View.Interface.Command
{
    public interface ICommand
    {
        string Text { get; set; }
        Icon Icon { get; set; }
        ICommand Parent { get; set; }
        IList<ICommand> SubCommands { get; set; }
        bool HasCommand { get; }

        void Execute();
    }
}