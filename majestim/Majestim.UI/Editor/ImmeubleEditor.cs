using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BrightIdeasSoftware;
using log4net;
using Majestim.Interface;
using Majestim.View.Interface.Editor;

namespace Majestim.UI.Editor
{
    public class ImmeubleEditor : ComboBox, ICustomEditor
    {
        private readonly IContext _context;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ImmeubleEditor(IContext context) 
        {
            _context = context;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Enter += (sender, args) => { this.DroppedDown = true; };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ce"></param>
        public void Init(CellEditEventArgs ce)
        {
            //Sample source = new Sample();
            //foreach (Immeuble imm in source.immeubles)
            //    this.Items.Add(imm);

            this.Bounds = new Rectangle(
                new Point(ce.CellBounds.X, ce.CellBounds.Y),
                new Size(200, 10)
            );

            //this.SelectedItem = this.Items.OfType<Immeuble>().FirstOrDefault(x => x.ToString() == ce.Value.ToString());
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