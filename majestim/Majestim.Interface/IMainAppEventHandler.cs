using System;

namespace Majestim.Interface
{
    public interface IMainAppEventHandler
    {
        event EventHandler AppStartingEvent;
        event EventHandler AppStartedEvent;
        event EventHandler AppStoppedEvent;
    }
}