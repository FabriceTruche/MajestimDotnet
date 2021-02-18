using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using BrightIdeasSoftware;
using log4net;
using Majestim.BO.OperationBase.Compta;
using Majestim.BO.OperationBase.Contrat;
using Majestim.DAL;
using Majestim.DAL.Interface.DAL;
using Majestim.DTO.DTO;
using Majestim.Interface;
using Majestim.View.Interface.View;

namespace Majestim.UI.Views.ThemeTreeMenu
{
    public partial class ComptaView : UserControl, IComptaView
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IContext _context;

        public event EventHandler OnShowView;

        public ComptaView(IContext context)
        {
            this._context = context;
            this.InitializeComponent();
            //DoubleBuffered(listView1, true);

            this.olvCompta.FormatRow += this.OlvComptaOnFormatRow;
        }

        /// <summary>
        /// grise les lignes de contrats inactifs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ce"></param>
        private void OlvComptaOnFormatRow(object sender, FormatRowEventArgs ce)
        {
            //if (sender is ObjectListView olv)
            //{
            //    if (ce.Model is LigneEcriture cl)
            //    {
            //    }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComptaControl_Load(object sender, System.EventArgs e)
        {
            // init olv contrat
            this.olvCompta.FullRowSelect = true;
            this.olvCompta.GridLines = true;
            this.olvCompta.ShowGroups = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComptaView_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                // on vient d'assigne le control dans le panel de la vue principale
                // ==> on lève les events
                this.OnShowView?.Invoke(this,new EventArgs());
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="ecritures"></param>
        /// <param name="filter"></param>
        public void ShowCompteLocataire(OneMany<OperationDto, EcritureDto> ecritures, ContratRo[] filter)
        {
            log.Info("--> Show compta locataire 411");
            Generator.GenerateColumns(this.olvCompta, typeof(EcritureDto), true);
            this.olvCompta.SetObjects(ecritures);
            this.olvCompta.AutoResizeColumns();
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="ecritures"></param>
        /// <param name="filter"></param>
        public void ShowProvisionLocataire(OneMany<OperationDto, EcritureDto> ecritures, ContratRo[] filter)
        {
            log.Info("--> Show provision locataire 419");
        }
    }
}









// fill olv
//            var list = _context.Connection.Query<ContratBiz>(@"
//            select c.*, tc.id as type_contrat_id, tc.code as type_contrat 
//            from contrat c, type_contrat tc 
//            where c.type_contrat_id=tc.id
//            order by c.id
//            ");

//            var list = _cnx.Query<ContratBiz, TypeContrat, ContratBiz>(@"
//select *
//from contrat c, type_contrat tc
//where c.type_contrat_id=tc.id
//order by c.id
//",
//                (indi, tc) =>
//                {
//                    indi.type_contrat = tc;
//                    return indi;
//                });


//    listView1.Visible = false;

//    using (MySqlConnection c = new MySqlConnection("server=localhost;uid=root;pwd=;database=majestim"))
//    {
//        IEnumerable<Contrat> all = new ContratRepository(c).GetAll();
//        List<string> props = new List<string>();

//        props.Add("id");
//        props.Add("nom");
//        props.Add("commentaire");
//        props.Add("date_entree_prevue");
//        props.Add("date_sortie_prevue");
//        props.Add("date_entree");
//        props.Add("date_sortie");

//        this.listView1.Columns.Clear();
//        foreach (string prop in props)
//            this.listView1.Columns.Add(prop);

//        foreach (Contrat contrat in all)
//        {
//            PropertyInfo p = contrat.GetType().GetProperty(props[0]);
//            ListViewItem item = new ListViewItem(p.GetValue(contrat)?.ToString());

//            for (int i = 1; i < props.Count; i++)
//            {
//                p = contrat.GetType().GetProperty(props[i]);
//                item.SubItems.Add(p.GetValue(contrat)?.ToString());
//            }

//            item.Tag = new DataRow<Contrat> {RowObject = contrat};

//            this.listView1.Items.Add(item);
//        }
//        for (int i = 0; i < this.listView1.Columns.Count; i++)
//            this.listView1.Columns[i].Width = -2; // AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
//    }

//    listView1.Visible = true;
//}

//private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
//{
//    ListView.SelectedListViewItemCollection current = (sender as ListView).SelectedItems;

//    if (current.Count != 1)
//        return;

//    Contrat contrat = (current[0].Tag as DataRow<Contrat>)?.RowObject;

//    if (contrat == null)
//        return;

//    listView2.Visible = false;

//    using (MySqlConnection c = new MySqlConnection("server=localhost;uid=root;pwd=;database=majestim"))
//    {
//        IEnumerable<Lot> all = c.Query<Lot>("select b.*,l.* from bien b, lot l, contrat_lot cl where cl.lot_id = l.id and b.id=l.id and cl.contrat_id=@id", contrat);
//        List<string> props = new List<string>();

//        props.Add("id");
//        props.Add("numero");
//        props.Add("description");
//        props.Add("surface");
//        props.Add("etage");

//        this.listView2.Columns.Clear();
//        this.listView2.Items.Clear();

//        foreach (string prop in props)
//            this.listView2.Columns.Add(prop);

//        foreach (Lot obj in all)
//        {
//            PropertyInfo p = obj.GetType().GetProperty(props[0]);
//            ListViewItem item = new ListViewItem(p.GetValue(obj)?.ToString());

//            for (int i = 1; i < props.Count; i++)
//            {
//                p = obj.GetType().GetProperty(props[i]);
//                item.SubItems.Add(p.GetValue(obj)?.ToString());
//            }

//            this.listView2.Items.Add(item);
//        }
//        for (int i = 0; i < this.listView2.Columns.Count; i++)
//            this.listView2.Columns[i].Width = -2; // .AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
//    }

//    listView2.Visible = true;
//private void DoubleBuffered(Control control, bool enable)
//{
//    var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
//    doubleBufferPropertyInfo.SetValue(control, enable, null);
//}

