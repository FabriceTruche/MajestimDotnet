using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Majestim.View.Interface.Command;
using Majestim.View.Interface.EventHandlers;
using Majestim.View.Interface.View;

namespace Majestim.UI.Views.ThemeTreeMenu
{

    public partial class MainMenuFormView : Form, IMainView, ICommandView, IPathView
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Control _bienControl;
        private readonly Control _tiersControl;
        private readonly Control _contratControl;
        private readonly Control _comptaControl;

        public MainMenuFormView(
            IBienView bienView,
            ITiersView tiersView,
            IContratView contratView,
            IComptaView comptaView)
        {
            log.Info($"==> ctor {this.GetType().Name}");
            this.InitializeComponent();
            this._bienControl = bienView as Control;
            this._tiersControl = tiersView as Control;
            this._contratControl = contratView as Control;
            this._comptaControl = comptaView as Control;
        }

        public void ShowTiersView()
        {
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(this._tiersControl);
        }

        public void ShowBienView()
        {
            this._bienControl.Location = new Point(0, 0);
            this._bienControl.Dock = DockStyle.Fill;

            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(this._bienControl);
        }

        public void ShowContratView()
        {
            this._contratControl.Location = new Point(0, 0);
            this._contratControl.Dock = DockStyle.Fill;

            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(this._contratControl);
        }

        public void ShowComptaView()
        {
            this._comptaControl.Location = new Point(0, 0);
            this._comptaControl.Dock = DockStyle.Fill;

            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(this._comptaControl);
        }

        public void ShowSituationLocataire()
        {
            throw new NotImplementedException();
        }

        public void ShowComptesLocataire()
        {
            throw new NotImplementedException();
        }

        public void ShowAppelLoyerView()
        {
            throw new NotImplementedException();
        }

        public void ShowRapproBancaire()
        {
            throw new NotImplementedException();
        }

        public Task RunProgress(Action action)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// eplorateur
        /// </summary>
        /// <param name="items"></param>
        public void SetCommandView(ICommand items)
        {
            this.AddItems(this.tv1.Nodes, items.SubCommands);
        }

        public event CommandSelectedEventHandler CommandSelected;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="items"></param>
        private void AddItems(TreeNodeCollection node, IList<ICommand> items)
        {
            if (items == null)
                return;

            foreach (ICommand command in items)
            {
                TreeNode newNode = node.Add(command.Text);
                newNode.Tag = command;
                this.AddItems(newNode.Nodes, command.SubCommands);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            this.CommandSelected?.Invoke(this, e.Node.Tag as ICommand);
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowPath(string path)
        {
            this.label1.Text = path;
        }

        private void MainMenuFormView_Load(object sender, EventArgs e)
        {
            this.OnShow?.Invoke(sender, e);
        }

        private void MainMenuFormView_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.OnClose?.Invoke(sender, e);
        }

        public event EventHandler OnShow;
        public event FormClosedEventHandler OnClose;
    }
}



/// <summary>
/// Affichier les items de menu dans la vue principale
/// </summary>
/// <param name="menuCommand"></param>
//public void SetMenuItems(IMenuCommand menuCommand)
//{
//    menuStrip1.Items.Clear();
//    foreach (IGroupCommand item in menuCommand.Items)
//    {
//        ToolStripMenuItem itemUI = new ToolStripMenuItem(item.Title);

//        itemUI.Enabled = item.Enabled;
//        menuStrip1.Items.Add(itemUI);

//        if (item.Commands != null)
//        {
//            foreach (ICommand command in item.Commands)
//            {
//                ToolStripMenuItem commandUI = new ToolStripMenuItem(command.Text);
//                itemUI.DropDownItems.Add(commandUI);
//                commandUI.Click += (sender, args) => command.Execute(this);
//            }
//        }
//    }
//}
