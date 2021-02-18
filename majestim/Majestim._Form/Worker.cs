using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace Majestim._Form
{
    public class Worker
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly object _thisObject;
        private readonly ProgressBar _pb;
        private Delegate _action;
        private readonly BackgroundWorker _bw = new BackgroundWorker();

        public object ReturnValue { get; private set; }

        public Worker(object thisObject, ProgressBar pb)
        {
            this._thisObject = thisObject;
            this._pb = pb;
        }

        public void Invoke(Delegate action, params object[] args)
        {
            this._action = action;
            this._bw.DoWork += this.StartWork;
            this._bw.RunWorkerCompleted += this.EndWork;
            this._bw.RunWorkerAsync(args);
        }

        private void SafeShow(bool show)
        {
            this._pb.Visible = show;
        }

        private void StartWork(object sender, DoWorkEventArgs e)
        {
            log.Info(">> start");

            this._pb.Invoke(new Action<bool>(this.SafeShow), true);
            this.ReturnValue = this._action.Method.Invoke(this._thisObject, e.Argument as object[]);
        }
        private void EndWork(object sender, RunWorkerCompletedEventArgs args)
        {
            log.Info(">> finished");

            this._pb.Invoke(new Action<bool>(this.SafeShow), false);
            this._bw.DoWork -= this.StartWork;
            this._bw.RunWorkerCompleted -= this.EndWork;
        }
    }
}