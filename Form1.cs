using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Adsk_Miner_Destroyer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();
            dlg.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://adskoe96.github.io/links/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.donationalerts.com/r/adskoe95");
        }
    }
}
