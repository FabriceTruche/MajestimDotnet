using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BrightIdeasSoftware;
using log4net;
using MySql.Data.MySqlClient;

namespace Majestim._TestObjectListView.Example
{
    public static class ObjectListViewExtension
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void CellEditDico(this ObjectListView olv, MySqlConnection cnx)
        {
            new _ObjectListViewExtension(olv, cnx);
        }

        private class _ObjectListViewExtension
        {
            private readonly ObjectListView _olv;
            private readonly MySqlConnection _cnx;

            public _ObjectListViewExtension(ObjectListView olv, MySqlConnection cnx)
            {
                _olv = olv;
                _cnx = cnx;

                _olv.CellEditStarting += OlvOnCellEditStarting;
                _olv.CellEditFinishing += OlvOnCellEditFinishing;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="ce"></param>
            private void OlvOnCellEditStarting(object sender, CellEditEventArgs ce)
            {
                if (ce.Cancel)
                    return;

                //if (ce.Value is IChoiceList iface)
                //    this.SetChoiceListStarting(iface, ce);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="ce"></param>
            private void OlvOnCellEditFinishing(object sender, CellEditEventArgs ce)
            {
                if (ce.Cancel)
                {
                    ce.Cancel = true;
                    return;
                }

                //if (ce.Value is IChoiceList)
                //    this.SetChoiceListFinished(ce);

                ce.Cancel = false;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="iface"></param>
            /// <param name="ce"></param>
            //private void SetChoiceListStarting(IChoiceList iface, CellEditEventArgs ce)
            //{
            //    ListBox lb = new ListBox();
            //    Type type = iface.GetType();

            //    // fill list of items
            //    IEnumerable<object> list = _cnx.Query(type, @"select * from " + DbName(type.Name));
            //    list.ToList().ForEach(x => lb.Items.Add(x));

            //    // UI setting
            //    lb.Bounds = new Rectangle(
            //        new Point(ce.CellBounds.X, ce.CellBounds.Y + _olv.RowHeightEffective),
            //        new Size(100, 100)
            //    );
            //    lb.MouseClick += (o, args) => { lb.Dispose(); };

            //    // done
            //    ce.Control = lb;
            //}

            /// <summary>
            /// 
            /// </summary>
            /// <param name="ce"></param>
            private void SetChoiceListFinished(CellEditEventArgs ce)
            {
                ce.Cancel = false;

                if (ce.Control is ListBox lb)
                {
                    ce.NewValue = lb.SelectedItem;
                    ce.Cancel = false;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            private string DbName(string name)
            {
                string res = "";

                foreach (char c in name)
                {
                    char d;

                    if (Char.IsUpper(c))
                    {
                        if (res.Any())
                            res += '_';
                        d = c;
                    }
                    else
                    {
                        d = Char.ToUpper(c);
                    }

                    res += d;
                }

                return res;
            }
        }
    }
}