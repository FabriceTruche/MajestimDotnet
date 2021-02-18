using System;

namespace Majestim.Helpers
{
    public interface IProgbarHelper : IDisposable
    {
        IProgbarHelper Show();
        void Hide();
    }
}