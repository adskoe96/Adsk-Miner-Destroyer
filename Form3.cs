using System;
using System.IO;
using System.Windows.Forms;

namespace Adsk_Miner_Destroyer
{
    public partial class Form3 : Form
    {
        private string title = "Adsk-Miner-Destroyer";
        private string programdatapath = Environment.ExpandEnvironmentVariables("%ProgramData%");
        public Form3()
        {
            InitializeComponent();
        }
        private void UpdateList()
        {
            string[] alldirectories = Directory.GetDirectories(programdatapath);
            checkedListBox1.Items.Clear();
            foreach (string dirname in alldirectories)
            {
                checkedListBox1.Items.Add(dirname);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();
            dlg.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selected = checkedListBox1.CheckedItems;
            if (selected.Count != 0)
            {
                foreach (string selectedName in selected)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Удалить выбранную папку: " + selectedName + " ?", title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        if (Directory.Exists(selectedName)) Directory.Delete(selectedName, true);
                    }
                }
                MessageBox.Show("Операция завершена.", title);
            }
            else
            {
                MessageBox.Show("Для продолжения выберите папки в окошке галочками.", title);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
