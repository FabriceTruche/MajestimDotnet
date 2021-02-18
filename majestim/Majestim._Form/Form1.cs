using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Majestim.Helpers;
using Color = System.Drawing.Color;
using ProgressBarStyle = System.Windows.Forms.ProgressBarStyle;

namespace Majestim._Form
{
    public delegate void ProgbarEvenHandler(bool show);

    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private TaskFactory task;


        private int i;

        public Form1()
        {
            this.InitializeComponent();

            this.pb_main.Style = ProgressBarStyle.Marquee;
            this.pb_main.MarqueeAnimationSpeed = 3;
            this.pb_main.Hide();
            this.i = 555;
            this.task= Task.Factory;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Add(DateTime.Now.ToLongTimeString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }

        private async Task Run(Action action)
        {
            //IProgress<string> progress = new Progress<string>(s => this.label1.Text = s);
            await this.task.StartNew(() =>
                {
                    log.Info("1");
                    this.pb_main.Invoke(new Action(this.pb_main.Show));
                    action();
                    this.pb_main.Invoke(new Action(this.pb_main.Hide));
                    log.Info("2");
                },
                TaskCreationOptions.LongRunning
            );
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await this.Run( this.Traitement);
        }


        //this.pb_main.Visible = true;
            //log.Info("1");

            //for (long i=0; i<150000000; i++)
            //{
            //    long j = i * 2;
            //    long k = 10 - 8;

            //}
            //log.Info("2");
            //this.pb_main.Visible = false;

            //this.Test(10,"Hello");
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            this.pb_main.Visible = false;
        }

        private void Traitement()
        {
            log.Info("10");
            log.Info(this.i++);

            Thread.Sleep(2000);

            log.Info("20");
        }

        //private void SafeShow(bool show)
        //{
        //    this.pb_main.Visible = show;
        //}

        //private void StartWork(object sender, DoWorkEventArgs e)
        //{
        //    log.Info(">> start");

        //    this.pb_main.Invoke(new Action<bool>(this.SafeShow), true);
        //    this.Traitement();
        //    e.Result = e.Argument;
        //}

        //private void EndWork(object sender, RunWorkerCompletedEventArgs args)
        //{
        //    BackgroundWorker bw = args.Result as BackgroundWorker;

        //    this.pb_main.Invoke(new Action<bool>(this.SafeShow), false);
        //    bw.DoWork -= this.StartWork;
        //    bw.RunWorkerCompleted -= this.EndWork;

        //    log.Info(">> end");
        //}

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}