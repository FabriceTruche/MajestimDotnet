using System.Reflection;
using System.Windows.Forms;
using log4net;
using Unity;

namespace Majestim.Application.App
{
    public class WinFormApp : BaseMainApp
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public WinFormApp(IUnityContainer container) : base(container)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
        }

        /// <summary>
        /// </summary>
        public override void ShowMainView()
        {
            Form form = this.MainView as Form;
            form.FormClosed += (sender, args) => { this.AppStopped(); };
            //form.Load += (sender, args) => { this.AppStarted(); };

            System.Windows.Forms.Application.Run(form);
        }
    }
}