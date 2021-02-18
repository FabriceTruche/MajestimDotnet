using System.Linq;
using BrightIdeasSoftware;

namespace Majestim.UI.Helper
{
    public static class ObjectListViewEx
    {
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
    }
}
