using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace Majestim.Helpers
{
    public class ProgbarHelper : IProgbarHelper
    {
        private readonly ProgressBar _pb;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// injection du control
        /// </summary>
        /// <param name="pb"></param>
        public ProgbarHelper(ProgressBar pb)
        {
            this._pb = pb;
        }

        /// <summary>
        /// affichage par using
        /// </summary>
        /// <returns></returns>
        IProgbarHelper IProgbarHelper.Show()
        {
            this._pb.MarqueeAnimationSpeed = 5;
            this._pb.Style = ProgressBarStyle.Marquee;

            int x = (this._pb.Parent.ClientSize.Width - this._pb.Width) - 20;
            int y = (this._pb.Parent.ClientSize.Height - this._pb.Height) - 20;

            this._pb.Location = new Point(x, y);
            this._pb.Show();

            return this;
        }

        /// <summary>
        /// masquer le control par fin de using
        /// </summary>
        public void Dispose()
        {
            this._pb.Hide();
            this._pb.Style = ProgressBarStyle.Continuous;
        }

        /// <summary>
        /// 
        /// </summary>
        void IProgbarHelper.Hide()
        {
            this._pb.Hide();
            this._pb.Style = ProgressBarStyle.Continuous;
        }
    }
}
