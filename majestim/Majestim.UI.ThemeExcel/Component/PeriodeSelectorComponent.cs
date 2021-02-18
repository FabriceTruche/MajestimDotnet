using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Majestim.BO.OperationBase.Compta;
using Majestim.View.Interface.Component;

namespace Majestim.UI.ThemeExcel.Component
{
    public partial class PeriodeSelectorComponent : UserControl, IPeriodeSelectorComponent
    {
        /// <summary>
        /// 
        /// </summary>
        public PeriodeSelectorComponent()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ChoixPeriode> Periodes => this.combo_periode.Items.Cast<ChoixPeriode>().ToList();

        /// <summary>
        /// 
        /// </summary>
        public ChoixPeriode Selection => this.combo_periode.SelectedItem as ChoixPeriode;

        /// <summary>
        /// 
        /// </summary>
        public bool HasDefault { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TextDefault { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Label
        {
            get=> this.label_periode.Text;
            set => this.label_periode.Text = value;
        }

        /// <summary>
        /// sélectionne un élément de la liste
        /// </summary>
        public DateTime SelectedItem
        {
            set
            {
                foreach (ChoixPeriode item in this.combo_periode.Items)
                {
                    if (item.Periode == value)
                    {
                        this.combo_periode.SelectedItem = item;
                        return;
                    }
                }   
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="defaultText"></param>
        /// <param name="selectFirst"></param>
        /// <param name="periodes"></param>
        public void Init(
            IEnumerable<ChoixPeriode> periodes,
            string defaultText = "Aucune",
            bool selectFirst = true)
        {
            this.combo_periode.Items.Clear();
            this.HasDefault = !string.IsNullOrEmpty(defaultText);

            if (this.HasDefault)
                this.combo_periode.Items.Add(new ChoixPeriode(defaultText));

            foreach (ChoixPeriode periode in periodes)
                this.combo_periode.Items.Add(periode);

            if (selectFirst && this.combo_periode.Items.Count > 0)
                this.combo_periode.SelectedIndex = 0;
        }

        /// <summary>
        /// dessine les valeurs de la combo avec la valeur par défaut en italic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_periode_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (!(sender is ComboBox combo))
                return;

            ChoixPeriode item = (e.Index < 0) ? null : combo.Items[e.Index] as ChoixPeriode;
            Font newFont = (item != null && item.Periode == DateTime.MinValue)
                ? new Font(e.Font, FontStyle.Bold | FontStyle.Italic)
                : e.Font;

            e.DrawBackground();
            e.Graphics.DrawString(
                item?.ToString(),
                newFont,
                Brushes.Black,
                new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
            );
            e.DrawFocusRectangle();
        }
    }
}
