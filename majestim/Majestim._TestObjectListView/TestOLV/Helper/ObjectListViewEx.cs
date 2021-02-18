using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BrightIdeasSoftware;
using log4net;
using Majestim._TestObjectListView.TestOLV.Editor;

namespace Majestim._TestObjectListView.TestOLV.Helper
{
    public static class ObjectListViewEx
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="olv"></param>
        /// <returns></returns>
        public static T SelectedRow<T>(this ObjectListView olv) where T : class
        {
            if (olv.Items.OfType<OLVListItem>().Count(x => x.Selected) == 1)
            {
                T itemSelected = olv.Items.OfType<OLVListItem>().Single(x => x.Selected).RowObject as T;

                return itemSelected;
            }

            return null;
        }

        /// <summary>
        /// attach event
        /// </summary>
        /// <param name="olv"></param>
        public static void SetAutoEditor(this ObjectListView olv)
        {
            olv.CellEditStarting += OlvOnCellEditStarting;
            olv.CellEditFinishing += OlvOnCellEditFinishing;
        }

        /// <summary>
        /// debut editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ce"></param>
        private static void OlvOnCellEditStarting(object sender, CellEditEventArgs ce)
        {
            Control control = CustomEditor.GetEditor(ce.Column.DataType);

            if (control == null)
                return;

            if (!(control is ICustomEditor iface))
                return;

            iface.Init(ce);
            ce.Control = control;

        }

        /// <summary>
        /// fin editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ce"></param>
        private static void OlvOnCellEditFinishing(object sender, CellEditEventArgs ce)
        {
            if (!(ce.Control is ICustomEditor iface))
                return;

            iface.Validate(ce);
        }
    }
}







//// type de la ligne
//Type type = ce.Column.DataType;
//if (type != typeof(Immeuble))
//    return;

//log.Info($"On cell start editing - type={type.Name}");

//var res = new Sample();
//var list = res.immeubles;

//if (list != null)
//{
//    ComboBox lb = new ComboBox();

//    lb.DropDownStyle = ComboBoxStyle.DropDownList;
//    lb.DropDown += LbOnDropDown;
//    lb.Enter += LbOnEnter;
//    //lb.ValueMember = "Id";
//    //lb.DisplayMember = "ToString";

//    foreach (Immeuble imm in list)
//        lb.Items.Add(imm);

//    // UI setting
//    lb.Bounds = new Rectangle(
//        new Point(ce.CellBounds.X, ce.CellBounds.Y) /*+ olv.RowHeightEffective)*/,
//        new Size(200, 10)
//    );

//    // done
//    ce.Control = lb;

//    lb.SelectedItem = lb.Items.OfType<Immeuble>().FirstOrDefault(x => x.ToString() == ce.Value.ToString());

//    // dump
//    log.Info($"value={ce.Value}");

//}
//else
//{
//    ce.Cancel = !(type.IsPrimitive || type.IsEnum);
//}
//private static void LbOnEnter(object sender, EventArgs eventArgs)
//{
//    log.Info($"ENTER");
//    ComboBox lb = sender as ComboBox;
//    lb.DroppedDown = true;
//}

//private static void LbOnDropDown(object sender, EventArgs eventArgs)
//{
//    log.Info($"DROPOWN");
//}

// type de la ligne
//Type type = ce.Column.DataType;
//if (type != typeof(Immeuble))
//    return;

//log.Info($"On cell finishing editing - type={type.Name}");
//ce.Cancel = false;
//if (ce.Control is ComboBox lb && lb.SelectedItem != null)
//{
//    ce.NewValue = lb.SelectedItem;
//    ce.Cancel = false;
//}
