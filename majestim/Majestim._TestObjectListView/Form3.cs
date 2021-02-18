using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace Majestim._TestObjectListView
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            objectListView1.ShowGroups = false;
            Generator.GenerateColumns(objectListView1, typeof(MyType));

            List<MyType> values = new List<MyType>();

            for (int i = 0; i < 300; i++)
            {
                string n = $"Hello_{(i + 1) / 10}";
                string p = $"Prenom_{i}";
                MyType my = new MyType(() => $"==> {this.objectListView1.TopItemIndex}")
                {
                    nom = n,
                    prenom = p
                };
                values.Add(my);
            }

            objectListView1.SetObjects(values);
        }
    }
}
