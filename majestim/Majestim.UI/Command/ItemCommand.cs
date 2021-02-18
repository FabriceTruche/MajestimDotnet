using System;
using System.Collections.Generic;
using System.Drawing;
using Majestim.View.Interface.Command;

namespace Majestim.UI.Command
{
    public class ItemCommand : ICommand
    {
        private readonly Action _action;

        public ItemCommand(ICommand parent, string text, Action action)
        {
            _action = action;
            Parent = parent;
            Text = text;
        }

        public ItemCommand(ICommand parent, string text, Icon icon = null)
        {
            Parent = parent;
            Text = text;
            Icon = icon;
            SubCommands = null;
        }

        public string Text { get; set; }
        public Icon Icon { get; set; }
        public ICommand Parent { get; set; }
        public IList<ICommand> SubCommands { get; set; }
        public bool HasCommand => _action != null;

        public virtual void Execute()
        {
            _action?.Invoke();
        }
    }
}