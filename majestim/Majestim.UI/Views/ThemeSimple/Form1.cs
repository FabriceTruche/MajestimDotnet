using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Dapper;
using log4net;
using Majestim.BO.OperationBase.Contrat;
using Majestim.BO.OperationBase.Patrimoine;
using Majestim.BO.OperationBase.Tiers;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.Interface;
using Majestim.View.Interface.Command;
using Majestim.View.Interface.EventHandlers;
using Majestim.View.Interface.View;

namespace Majestim.UI.Views.ThemeSimple
{
    public partial class Form1 : Form, IMainView, ICommandView, IPathView, IContratView, ITiersView, IBienView
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        public Form1(IContext context)
        {
            log.Info($"==> ctor {this.GetType().Name}");
            this.InitializeComponent();

            using (IUnitOfWork uow = new UnitOfWork(context))
            {
                IEnumerable<ContratRo> r = uow.DbConnection.Query<ContratRo>("select * from contrat");

                log.Info("--> ShowAllContrats");
                Generator.GenerateColumns(this.olv, typeof(ContratRo), true);
                this.olv.SetObjects(r);
                this.olv.AutoResizeColumns();
            }
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

        public event EventHandler OnShow;
        public event FormClosedEventHandler OnClose;

        public void SetCommandView(ICommand rootCommand)
        {
        }

        public event CommandSelectedEventHandler CommandSelected;
        public void ShowPath(string path)
        {
        }

        public void ShowContrats(IEnumerable<ContratRo> contrats)
        {
        }

        public void ShowContratDetail(ContratRo contrat, IEnumerable<Lot> lots, IEnumerable<Preneur> locataires)
        {
        }

        public event EventHandler OnShowView;
        public event ContratSelectedEventHandler OnContratSelected;

        public void ShowBiens(IEnumerable<Bien> biens)
        {
        }

        public event EventHandler OnBiensDisplayed;

        public void ShowAllTiers()
        {
            throw new NotImplementedException();
        }

        public void ShowTiers(int id)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //OnShow?.Invoke(this,new EventArgs());
        }
    }
}
