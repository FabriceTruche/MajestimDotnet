using Unity;

namespace Majestim.Interface
{
    public interface IStarter
    {
        /// <summary>
        /// Container IoC
        /// </summary>
        //IUnityContainer Container { get; }

        /// <summary>
        /// démarrage de l'appli
        /// </summary>
        void Start();
    }
}