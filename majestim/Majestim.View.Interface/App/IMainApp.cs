using System;
using Majestim.Interface;
using Majestim.View.Interface.View;

namespace Majestim.View.Interface.App
{
    public interface IMainApp : IMainAppEventHandler
    {
        void StartApp();
        void ShowMainView();

        IMainView MainView { get; }
    }
}