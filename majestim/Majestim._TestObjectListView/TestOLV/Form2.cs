using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BrightIdeasSoftware;
using log4net;
using Majestim._TestObjectListView.TestOLV.BO;
using Majestim._TestObjectListView.TestOLV.Editor;
using Majestim._TestObjectListView.TestOLV.Helper;

namespace Majestim._TestObjectListView.TestOLV
{
    public partial class Form2 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Sample example = new Sample();

            olv.FullRowSelect = true;
            olv.UseHotItem = true;
            Generator.GenerateColumns(olv,typeof(Bien), true);
            olv.ShowGroups = true;
            OLVColumn col = olv.GetColumn("Immeuble Object");

            // titre du groupe
            col.GroupKeyToTitleConverter = key =>
            {
                Immeuble imm = (Immeuble) key;
                return "IMMEUBLE : " + imm.Adr1 + " " + imm.Cp + " " + imm.Ville;
            };

            olv.SetObjects(example.biens);
            olv.AutoResizeColumns();
            olv.BuildGroups(col, SortOrder.Ascending);
            olv.OLVGroups.ToList().ForEach(x => x.Collapsed = false);
            olv.CellEditActivation = ObjectListView.CellEditActivateMode.None;

            // ajouter l'editeur des Immeubles
            CustomEditor.Register<Immeuble,ImmeubleEditor>();
            olv.SetAutoEditor();

            olv.ItemSelectionChanged += OlvOnItemSelectionChanged;
            olv.SelectionChanged += OlvOnSelectionChanged;
            olv.MultiSelect = true;
            olv.HideSelection = false;
        }

        private void OlvOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            log.Info($"OlvOnSelectionChanged");

            Bien bienSelected = olv.SelectedRow<Bien>();

            if (bienSelected!=null)
                log.Info($" --> {bienSelected.Nom}");
        }

        private void OlvOnItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs arg)
        {
            log.Info($"OlvOnItemSelectionChanged : {arg.IsSelected},{arg.Item.Text},{arg.ItemIndex}");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int i = 1;

            log.Info($"-----------------------------------------------------------------------------");
            foreach (object cb in olv.Objects)
            {
                PropertyInfo[] props = cb.GetType().GetProperties();

                log.Info($"  row {i++} :");
                foreach (PropertyInfo p in props)
                {
                    object value = p.GetValue(cb);
                    log.Info($"    - {p.Name}={value?.ToString()} [{value?.GetType().Name}]");
                }
            }
            log.Info($"----");
            foreach (ListViewItem lvi in olv.Items)
            {
                log.Info($"    - {lvi.Name},{lvi.Selected},{lvi.Text}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwitchEdit();
        }

        private void SwitchEdit()
        {
            if (olv.CellEditActivation == ObjectListView.CellEditActivateMode.SingleClick)
            {
                olv.CellEditActivation = ObjectListView.CellEditActivateMode.None;
                button2.Text = "Not editable";
            }
            else
            {
                olv.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
                button2.Text = "Editable";
            }
        }
    }
}








///*
//        private void OlvOnCellEditFinishing(object sender, CellEditEventArgs ce)
//        {
//            Type type = ce.RowObject.GetType();

//            log.Info($"On cell finishing editing - type={type.Name}");
//            PropertyInfo props = type.GetProperty(ce.Column.AspectName);

//            if (props != null)
//            {
//                object[] attributes = props.GetCustomAttributes(true);

//                foreach (Attribute a in attributes)
//                {
//                    if (a is ISelectList)
//                    {
//                        ce.Cancel = false;

//                        if (ce.Control is ListBox lb && lb.SelectedItem != null)
//                        {
//                            ce.NewValue = lb.SelectedItem;
//                            ce.Cancel = false;
//                        }
//                        break;
//                    }
//                }
//            }
//        }

//        private void OlvOnCellEditStarting(object sender, CellEditEventArgs ce)
//        {
//            // type de la ligne
//            Type type = ce.RowObject.GetType();

//            log.Info($"On cell start editing - type={type.Name}");

//            PropertyInfo props = type.GetProperty(ce.Column.AspectName);

//            if (props != null)
//            {
//                IEnumerable<object> list = null;
//                object[] attributes = props.GetCustomAttributes(true);

//                foreach (Attribute a in attributes)
//                {
//                    if (a is ISelectList)
//                    {
//                        list = (a as ISelectList).SelectItems(ce.RowObject);
//                        break;
//                    }
//                }

//                if (list != null)
//                {
//                    ComboBox lb = new ComboBox();

//                    lb.DropDownStyle = ComboBoxStyle.DropDownList;

//                    //lb.SizeChanged += (_sender, args) =>
//                    //{
//                    //    lb.Height = lb.PreferredHeight;
//                    //    var CurrentItemWidth = (int) this.CreateGraphics()
//                    //        .MeasureString(lb.Items[lb.Items.Count - 1].ToString(), lb.Font,
//                    //            TextRenderer.MeasureText(lb.Items[lb.Items.Count - 1].ToString(),
//                    //                new Font("Arial", 12.0F))).Width;
//                    //    if (CurrentItemWidth > lb.Width)
//                    //        lb.Width = CurrentItemWidth;
//                    //};

//                    lb.DataSource = list;

//                    //foreach (object item in list)
//                    //    lb.Items.Add(item);

//                    // UI setting
//                    lb.Bounds = new Rectangle(
//                        new Point(ce.CellBounds.X, ce.CellBounds.Y) /*+ olv.RowHeightEffective)*/ ,
//                        new Size(200, 100)
//                    );
                    
//                    //lb.MouseClick += (o, args) => { lb.Dispose(); };

//                    // done
//                    ce.Control = lb;
//                }
//                else
//                {
//                    Control ed = ObjectListView.EditorRegistry.GetEditor(ce.RowObject, ce.Column, ce.Value);

//Type propType = props.PropertyType;
//ce.Cancel = !(propType.IsPrimitive || propType.IsEnum);
//                }
//            }
//        }
//    */