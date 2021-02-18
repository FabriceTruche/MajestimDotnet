using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Dapper;
using log4net;
using Majestim.DTO.DTO;
using MySql.Data.MySqlClient;
using ToastNotifications;
namespace Majestim._TestObjectListView
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IDbConnection _cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["Majestim"].ConnectionString);
        private TypeChoix _data = new TypeChoix();


        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.propertyGrid1.SelectedObject = this._data;


            return;

            //                IEnumerable<MyType> all = c.Query<MyType>(@"
            //select nom, prenom, mail 
            //from individu i, tiers t
            //where t.id=i.id");

            this.olv.FullRowSelect = true;
            this.olv.GridLines = true;
            this.olv.ShowGroups = false;
            this.olv.SubItemChecking += this.OlvOnSubItemChecking;
            this.olv.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
            this.olv.GridLines = false;


            //OLVColumn col1 = new OLVColumn {AspectName = "Hello", IsVisible = true, Width = 60, Name = "toto", Text = "World"};
            //olv.AllColumns.Add(col1);
            //olv.Columns.Add(col1);

            //List<ContratDto> list = this._cnx.Query<ContratDto>("select * from contrat").ToList();

            Generator.GenerateColumns(this.olv, typeof(ContratDto),true);

            //OLVColumn column = olv.GetColumn(3);
            //olv.AddDecoration(new TintedColumnDecoration(column));

            //olv.FormatRow += OlvOnFormatRow;

            //this.olv.SetObjects(list);
            //this.olv.AutoResizeColumns();

            //this.AutoToasterButton();

            this.olv.CellEditStarting += this.OlvOnCellEditStarting;
            this.olv.CellEditFinishing += this.OlvOnCellEditFinishing;
        }

        private void OlvOnFormatRow(object sender, FormatRowEventArgs arg)
        {
            ContratDto tv = arg.Model as ContratDto;
            OLVListItem item = arg.Item;


            if (tv.DateSortie == null)
            {
                //item.BackColor = Color.Bisque;
            }
            if (tv.DateSortie != null)
            {
                item.Font = new Font(
                    item.Font.FontFamily, 
                    7F,
                    FontStyle.Bold
                    );

                item.BackColor = Color.LightGray;
            }
        }

        private void OlvOnCellEditStarting(object sender, CellEditEventArgs ce)
        {
            log.Info($"Cell edit starting {sender.GetType().Name}");

            if (ce.Column.AspectName == "commentaire")
            {
                var uc = new UserControl1(ce);
                ListBox lb = uc.List;

                lb.Items.Add("Hello");
                lb.Items.Add("World");
                lb.Items.Add("Fabrice");
                lb.Items.Add("Hello");
                lb.Items.Add("World");
                lb.Items.Add("Fabrice");
                lb.Items.Add("Hello");
                lb.Items.Add("World");
                lb.Items.Add("Fabrice");
                lb.Items.Add("Hello");
                lb.Items.Add("World");
                lb.Items.Add("Fabrice");
                uc.Bounds = new Rectangle(ce.CellBounds.Location, new Size(100, 100));
                ce.Control = uc;
                return;
            }

            if (ce.Column.AspectName == "nom")
            {
                UserControl2 uc = new UserControl2();
                ObjectListView list = uc.List;

                list.ShowGroups = false;

                //IEnumerable<TypeCivilite> data = _cnx.Query<TypeCivilite>("select * from type_civilite");
                //list.SetObjects(data);

                //list.Items.Add("Hello1");
                //list.Items.Add("Hello2");
                //list.Items.Add("Hello3");
                uc.Location = new Point(ce.CellBounds.Location.X, ce.CellBounds.Location.Y + list.RowHeightEffective);

                //uc.Bounds = new Rectangle(ce.CellBounds.Location, new Size(list.Width, list.Height));
                ce.Control = uc;
                return;
            }

            ce.Cancel = true;
        }

        private void OlvOnSubItemChecking(object sender, SubItemCheckingEventArgs ce)
        {
            log.Info(
                $"CHECKBOX new:{ce.NewValue} row:{ce.SubItemIndex} obj:{ce.RowObject.GetType().Name}");

            this.ModifyValue(ce.RowObject);
        }


        private void OlvOnCellEditFinishing(object sender, CellEditEventArgs ce)
        {
            log.Info(
                $"EDIT old:{ce.Value} new:{ce.NewValue} row:{ce.SubItemIndex} cancel:{ce.Cancel} obj:{ce.RowObject.GetType().Name}");

            this.ModifyValue(ce.RowObject);
        }

        private void ModifyValue(object rowObject)
        {
            //Contrat c = rowObject as Contrat;
            //log.Warn(c.id);
            //log.Warn(c.date_entree);
            //log.Warn(c.nom);
            //log.Warn(c.date_sortie);

            //if (_contratsChanged.Count(x => x.id == c.id) == 0)
            //    _contratsChanged.Add(c);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////olv.Refresh();

            //    Contrat c = new Contrat();
            //    c.nom = "Nouveau contrat";
            //    c.commentaire = "Hello";
            //    c.type_contrat_id = _cnx.Enum<TypeContrat>("local");

            //    ContratRepository cr = new ContratRepository(_cnx);
            //    c.id = cr.Insert(c);
            //    olv.AddObject(c);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Raise(() =>
            //{
            //    if (olv.SelectedObject is Contrat current)
            //    {
            //        MessageBox.Show(current.id.ToString());

            //            ContratRepository cr = new ContratRepository(_cnx);

            //            cr.Delete(current);
            //            olv.SetObjects(cr.GetAll());
            //    }
            //});
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Raise(() =>  
            //{
            //        ContratRepository cr = new ContratRepository(_cnx);

            //        foreach (Contrat c in _contratsChanged)
            //        {
            //            log.Error($"contrat changed => {c.id} - {c.nom}");
            //            cr.Update(c);
            //        }
            //        _contratsChanged.Clear();
            //        olv.SetObjects(cr.GetAll());
            //});
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Toaster("Test Long", "Ceci est un test pour afficher des textes super long ...", ToasterType.Warning, -1);
            this.listViewPrinter1.ListView = this.olv;
            this.listViewPrinter1.PrintWithDialog();
        }

        private void Raise(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                this.Toaster("Error", ex.Message + Environment.NewLine + ex.StackTrace, ToasterType.Error, -1);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._cnx.Dispose();
        }

        private void olv_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
           
        }

        private void olv_CellOver(object sender, CellOverEventArgs e)
        {
            if (e.Item!=null)
                this.label1.Text = e.Item.Text + e.Column.Name;
        }

        private void olv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewPrinter1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }
}
