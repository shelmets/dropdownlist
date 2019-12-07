using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropDownList
{
    public partial class EnterSyn : Form
    {
        string University;
        IStream str;
        public EnterSyn(string univer, IStream s)
        {
            University = univer;
            str = s;
            InitializeComponent(univer);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button.Visible = true;
        }
        private void button_Click(object sender, EventArgs e)
        {
            MessageBox.Show(str.CreateSynonum(University, textBox1.Text));
            this.Close();
        }
    }
}
