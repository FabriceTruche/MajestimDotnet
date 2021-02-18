using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Majestim.BO.OperationBase.Contrat;
using Majestim.View.Interface.Component;

namespace Majestim.UI.ThemeExcel.Component
{
    public partial class ContratSelectorComponent : UserControl, IContratSelectorComponent
    {
        private readonly List<ContratRo> _contrats = new List<ContratRo>();

        public ContratSelectorComponent()
        {
            this.InitializeComponent();
        }

        private void rb_actif_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb)
                this.Refresh(!rb.Checked);
        }

        private void rb_tous_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb)
                this.Refresh(rb.Checked);
        }

        /// <summary>
        /// 
        /// </summary>
        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<ContratRo> Contrats
        {
            get => this._contrats;
            set
            {
                this._contrats.Clear();
                foreach (ContratRo contrat in value)
                    this._contrats.Add(contrat);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public ContratRo SelectedContrat => this.combo_contrat.SelectedItem as ContratRo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectAll"></param>
        public void Refresh(bool selectAll)
        {
            ContratRo current = this.combo_contrat.SelectedItem as ContratRo;

            this.combo_contrat.Items.Clear();
            foreach (ContratRo contrat in this._contrats)
            {
                if (contrat.DateSortie == null || selectAll)
                    this.combo_contrat.Items.Add(contrat);
            }

            if (current != null)
            {
                int index = this.combo_contrat.FindStringExact(current.Nom);
                if (index != -1)
                    this.combo_contrat.SelectedIndex = index;
            }
            else
            {
                if (this.combo_contrat.Items.Count > 0)
                    this.combo_contrat.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_contrat_DrawItem(object sender, DrawItemEventArgs e)
        {
            ContratRo item = (e.Index < 0) ? null : this.combo_contrat.Items[e.Index] as ContratRo;

            if (this.DrawBackground(e.State) || item == null)
            {
                e.DrawBackground();
            }
            else
            {
                using (Brush backgroundBrush = new SolidBrush(item.IsActif ? Color.FromArgb(0xe6, 0xff, 0xe6) : Color.FromArgb(0xff, 0xe6, 0xe6)))
                {
                    e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
                }
            }

            e.Graphics.DrawString(
                item?.ToString(),
                this.Font,
                Brushes.Black,
                new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
            );
            e.DrawFocusRectangle();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dis"></param>
        /// <returns></returns>
        private bool DrawBackground(DrawItemState dis)
        {
            return (dis & DrawItemState.Focus) == DrawItemState.Focus ||
                   (dis & DrawItemState.Selected) == DrawItemState.Selected ||
                   (dis & DrawItemState.HotLight) == DrawItemState.HotLight;
        }
    }
}
