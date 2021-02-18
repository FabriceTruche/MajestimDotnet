using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            iGrid1.Cols.Add("Column1");
            iGrid1.Cols.Add("Column2");
            iGrid1.Cols.Add("Column3");

            iGrid1.Rows.Count = 5;

            iGrid1.Cells[0, 2].Value = 123;
            iGrid1.Cells[1, 2].Value = "This is text";
            iGrid1.Cells[0, 0].BackColor = Color.Coral;
        }
    }
}
