using BrightIdeasSoftware;
using log4net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Dapper;
using Majestim.DTO.DTO;

namespace Majestim._TestObjectListView.Example
{
    public partial class PersonneForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private MySqlConnection _cnx => new MySqlConnection("server=localhost;uid=root;pwd=;database=majestim");

        public PersonneForm()
        {
            // fill olv
//            var list = _cnx.Query<IndividuBiz>(@"
//select *
//from individu i
//order by i.id
//");

//            return;

            this.InitializeComponent();

            // general saspect
            this.olv.FullRowSelect = true;
            this.olv.GridLines = true;
            this.olv.ShowGroups = false;
            //olv.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
         //   olv.CellEditDico(Cnx);

            // fill data
            this.InitContrat();
            //InitIndi();
        }

        private void InitContrat()
        {

            // fill olv
            IEnumerable<ContratDto> list = this._cnx.Query<ContratDto>("select * from contrat");

            //            var list = _cnx.Query<ContratBiz>(@"
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



            //olv.Items.Clear();
            Generator.GenerateColumns(this.olv, typeof(ContratDto), true);
            this.olv.SetObjects(list);
            this.olv.AutoResizeColumns();
        }

        private void InitIndi()
        {
//            olv.Items.Clear();
//            Generator.GenerateColumns(olv, typeof(IndividuBiz), true);

//            var list = _cnx.Query<IndividuBiz, TypeCivilite, IndividuBiz>(@"
//select *
//from individu i, type_civilite ti
//where i.type_civilite_id=ti.id
//order by i.id
//",
//                (indi, tc) =>
//                {
//                    indi.type_civilite = tc;
//                    return indi;
//                });


            // fill olv
            //            var list = _cnx.Query<IndividuBiz>(@"
            //select i.*, ti.id as type_individu_id, ti.code as type_civilite
            //from individu i, type_civilite ti
            //where i.type_civilite_id=ti.id
            //order by i.id
            //");

            //olv.SetObjects(list);
            //olv.AutoResizeColumns();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.InitContrat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dump();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.UpdateData();
        }



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="ce"></param>
        //private void OlvOnCellEditStarting(object sender, CellEditEventArgs ce)
        //{
        //}

        //private void OlvOnCellEditFinishing(object sender, CellEditEventArgs ce)
        //{
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ce"></param>
        //private void SetChoiceListStarting<T>(CellEditEventArgs ce) 
        //    where T: IChoiceList
        //{
        //    ListBox lb = new ListBox();

        //    // fill list of items
        //    IEnumerable<T> list = _cnx.Query<T>(@"select * from type_contrat");
        //    list.ToList().ForEach(x => lb.Items.Add(new Mapper<T>(x, z => z.code)));

        //    // UI setting
        //    lb.Bounds = new Rectangle(
        //        new Point(ce.CellBounds.X, ce.CellBounds.Y + olv.RowHeightEffective),
        //        new Size(100, 100)
        //    );
        //    lb.MouseClick += (o, args) => { lb.Dispose(); };

        //    // done
        //    ce.Control = lb;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="TList"></typeparam>
        ///// <typeparam name="TRow"></typeparam>
        ///// <param name="ce"></param>
        //private void SetChoiceListFinished<TRow, TList>(CellEditEventArgs ce)
        //    where TList : IChoiceList, IIdent
        //    where TRow : class
        //{
        //    ce.Cancel = true;

        //    TRow row = ce.RowObject as TRow;

        //    if (!(ce.Control is ListBox lb))
        //        return;

        //    if (!(lb.SelectedItem is Mapper<TList> mapper))
        //        return;

        //    TList tc = mapper.Item;

        //    if (tc == null)
        //        return;

        //    string propName = typeof(TRow).Name.ToLower();
        //    propName = "type_" + propName.Substring(0, propName.Length - 3) + "_id";
        //    Type type = row.GetType();
        //    PropertyInfo pi = type.GetProperty(propName);
        //    pi.SetValue(row, tc.id);
        //    ce.NewValue = tc.code;
        //    ce.Cancel = false;
        //}

        private void Dump()
        {
            int i = 1;

            log.Info($"-----------------------------------------------------------------------------");
            foreach (object cb in this.olv.Objects)
            {
                PropertyInfo[] props = cb.GetType().GetProperties();

                log.Info($"  row {i++} :");
                foreach (PropertyInfo p in props)
                {
                    object value = p.GetValue(cb);
                    log.Info($"    - {p.Name}={value.ToString()} [{value.GetType().Name}]");
                }
            }
        }

        private void UpdateData()
        {
            foreach (ContratBiz contrat in this.olv.SelectedObjects)
            {
                dynamic v = new System.Dynamic.ExpandoObject();

//                ((IDictionary<string, object>)v).Add("id", contrat.id);
////                ((IDictionary<string, object>)v).Add("type_contrat_id", contrat.type_contrat.id);
//                ((IDictionary<string, object>)v).Add("nom", contrat.nom);
//                ((IDictionary<string, object>)v).Add("date_entree", contrat.date_entree);

//                Cnx.Query(@"
//update CONTRAT
//set type_contrat_id=@type_contrat_id,
//    nom=@nom,
//    date_entree=@date_entree
//where id=@id
//", (object) v);

                return;
            }
        }
    }
}