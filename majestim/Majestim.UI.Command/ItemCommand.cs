using Majestim.View.Interface.Command;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Majestim.UI.Command
{
    public class ItemCommand : ICommand
    {
        private readonly Action _action;

        public ItemCommand(string text, Action action)
        {
            this._action = action;
            this.Text = text;
        }

        public ItemCommand(string text, Icon icon = null)
        {
            this.Text = text;
            this.Icon = icon;
            this.SubCommands = null;
        }

        public string Text { get; set; }
        public Icon Icon { get; set; }
        public ICommand Parent { get; set; }
        public IList<ICommand> SubCommands { get; set; }
        public bool HasCommand => this._action != null;

        public virtual void Execute()
        {
            this._action?.Invoke();
        }
    }
}