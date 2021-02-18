using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BrightIdeasSoftware;
using log4net;
using Majestim._TestObjectListView.TestOLV.BO;

namespace Majestim._TestObjectListView.TestOLV.Editor
{
    public class ImmeubleEditor : ComboBox, ICustomEditor
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ImmeubleEditor() 
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Enter += (sender, args) => { this.DroppedDown = true; };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ce"></param>
        public void Init(CellEditEventArgs ce)
        {
            Sample source = new Sample();

            foreach (Immeuble imm in source.immeubles)
                this.Items.Add(imm);

            this.Bounds = new Rectangle(
                new Point(ce.CellBounds.X, ce.CellBounds.Y),
                new Size(200, 10)
            );

            this.SelectedItem = this.Items.OfType<Immeuble>().FirstOrDefault(x => x.ToString() == ce.Value.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ce"></param>
        public void Validate(CellEditEventArgs ce)
        {
            if (this.SelectedItem != null)
            {
                ce.NewValue = this.SelectedItem;
                ce.Cancel = false;
            }
        }
    }
}