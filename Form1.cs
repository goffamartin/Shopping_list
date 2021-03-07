using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_list
{
    public partial class Form1 : Form
    {
        static List<Panel> panelList = new List<Panel>();
        public Form1()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel()
            {
                Size = new Size(460, 40),
                Location = new Point(40, 10)
            };
            TextBox txtBox = new TextBox()
            {
                Parent = panel,
                Size = new Size(300, 20),
                Location = new Point(10, 10),
            };
            CheckBox chckBox = new CheckBox()
            {
                Parent = panel,
                Size = new Size(20, 20),
                Location = new Point(330, 10),
            };
            Button btn = new Button()
            {
                Parent = panel,
                Size = new Size(75, 20),
                Location = new Point(360, 10),
                Text = "Smazat",
            };
            btn.Click += new System.EventHandler(this.RemoveButton_Click);

            panelList.Add(panel);
            Controls.Add(panel);

            Organize();
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Controls.Remove((Panel)b.Parent);
            panelList.Remove((Panel)b.Parent);
            Organize();
        }
        private void Organize()
        {
            foreach (Control p in this.Controls)
            {
                if(p.GetType().Name == "Panel")
                    p.Location = new Point(45, 50 + panelList.IndexOf((Panel)p) * 50);
                if (p.GetType().Name == "Button")
                    p.Location = new Point(20, 50 + panelList.Count * 50);
            }
        }
    }
}
