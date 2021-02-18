using System;
using System.Reflection;
using log4net;
using Majestim.View.Interface.Command;
using Majestim.View.Interface.View;

namespace Majestim.Presenters
{
    public class CommandPresenter
    {
        private readonly IMainView _mainView;
        private readonly ICommandView _commandView;
        private readonly IPathView _pathView;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainView"></param>
        /// <param name="commandView"></param>
        /// <param name="pathView"></param>
        /// <param name="command"></param>
        public CommandPresenter(IMainView mainView, ICommandView commandView, IPathView pathView, ICommand command)
        {
            this._mainView = mainView;
            this._commandView = commandView;
            this._pathView = pathView;
            commandView.CommandSelected += this.OnCommandSelected;
            commandView.SetCommandView(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainView"></param>
        /// <param name="command"></param>
        private void OnCommandSelected(IMainView mainView, ICommand command)
        {
            string path = this.GetPath(command);

            log.Info($"command selected : {path}");
            this._pathView.ShowPath(path);
            command.Execute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private string GetPath(ICommand command)
        {
            string ls = "";

            if (command.Parent != null)
                ls = this.GetPath(command.Parent) + " | ";

            return ls + command.Text;
        }
    }
}