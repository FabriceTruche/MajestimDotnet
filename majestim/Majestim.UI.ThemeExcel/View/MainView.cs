using System;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Majestim.View.Interface.Command;
using Majestim.View.Interface.EventHandlers;
using Majestim.View.Interface.View;
using Unity;

namespace Majestim.UI.ThemeExcel.View
{
    public sealed partial class MainView : Form, IMainView, ICommandView, IPathView
    {
        private readonly IUnityContainer _container;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private string _title;
        private int _imageIndex = 0;
        private TaskFactory _task;

        public MainView(IUnityContainer container)
        {
            this._container = container;
            this.InitializeComponent();
            this._title = this.Text;
            //this.pb_main.Visible = false;
            this._task = Task.Factory;
        }

        public void ShowTiersView()
        {
        }

        public void ShowBienView()
        {
        }

        public void ShowContratView()
        {
        }

        public void ShowComptaView()
        {
        }

        public void ShowSituationLocataire()
        {
            this.ShowComponent(this._container.Resolve<ISituationLocataireView>() as Control);
        }

        public void ShowComptesLocataire()
        {
            this.ShowComponent(this._container.Resolve<IComptesLocataireView>() as Control);
        }

        public void ShowAppelLoyerView()
        {
            this.ShowComponent(this._container.Resolve<IAppelLoyerView>() as Control);
        }

        public void ShowRapproBancaire()
        {
            this.ShowComponent(this._container.Resolve<IRapproBancaireView>() as Control);
        }

        public async Task RunProgress(Action action)
        {
            log.Info("Start action with progress bar ...");
            await this._task.StartNew(() =>
                {
                    this.pb_main.Invoke(new Action(this.pb_main.Show));
                    action();
                    this.pb_main.Invoke(new Action(this.pb_main.Hide));
                },
                TaskCreationOptions.LongRunning
            );
            log.Info("Finished action with progress bar ...");
        }

        public event EventHandler OnShow;
        public event FormClosedEventHandler OnClose;

        public void SetCommandView(ICommand node)
        {
            this.menuStrip1.Items.Clear();

            foreach (ICommand cmd in node.SubCommands)
            {
                ToolStripMenuItem item = new ToolStripMenuItem {Text = cmd.Text};
                this.menuStrip1.Items.Add(item);
                this.AddMenuItems(item, cmd);
            }
        }

        public event CommandSelectedEventHandler CommandSelected;

        public void ShowPath(string path)
        {
            this.Text = this._title + " - " + path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        private void AddMenuItems(ToolStripMenuItem menu, ICommand node)
        {
            if (node?.SubCommands != null)
            {
                foreach (ICommand cmd in node.SubCommands)
                {
                    if (cmd.Text == "-")
                    {
                        menu.DropDownItems.Add(new ToolStripSeparator());
                    }
                    else
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem {Text = cmd.Text};
                        item.Tag = cmd;
                        item.Enabled = cmd.HasCommand;
                        item.Click += new EventHandler(this.menuItem_Clicked);
                        item.Image = this.imageList1.Images[this._imageIndex++];
                        menu.DropDownItems.Add(item);
                        this.AddMenuItems(item, cmd);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void menuItem_Clicked(object sender, EventArgs eventArgs)
        {
            if (sender is ToolStripMenuItem item && item.Tag is ICommand cmd)
                this.CommandSelected?.Invoke(this, cmd);
        }

        /// <summary>
        /// affiche le composant
        /// </summary>
        /// <param name="control"></param>
        private void ShowComponent(Control control)
        {
            control.Location = new Point(0, 0);
            control.Dock = DockStyle.Fill;
            this.panel_Main.Controls.Clear();
            this.panel_Main.Controls.Add(control);
        }
    }
}