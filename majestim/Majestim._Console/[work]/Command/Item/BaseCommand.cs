using Majestim.Interface.Command;
using Majestim.Interface.View;

namespace Majestim._Console.Command.Item
{
    public class BaseCommand : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseCommand()
        {
            this.Enabled = true;
            this.Tooltip = $"tooltip for {this.GetType().Name}";
            this.Text = this.GetType().Name;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Execute(IMainView mainView)
        {
            MessageBox.Show("To do ...", this.GetType().Name);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Tooltip { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }
    }
}