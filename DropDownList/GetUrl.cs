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
    public partial class GetUrl : Form
    {
        public GetUrl(string country, string url)
        {
            InitializeComponent(country, url);
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void linkLabelUrl_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            this.linkLabelUrl.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start(this.linkLabelUrl.Text);
        }
    }
}
