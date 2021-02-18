using Unity;

namespace Majestim.Interface
{
    public interface IThemeSelector
    {
        void InitializeViewsTypes(IUnityContainer container);
        void Start();
    }
}