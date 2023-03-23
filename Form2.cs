using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Adsk_Miner_Destroyer
{
    public partial class Form2 : Form
    {
        private string title = "Adsk-Miner-Destroyer";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameSubKey = @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\DisallowRun\";
            string[] nameAllParameters = null;
            try
            {
                using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey(nameSubKey, true))
                {
                    if (regKey != null)
                    {
                        nameAllParameters = regKey.GetValueNames();
                        if (nameAllParameters.Length != 0)
                        {
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result = MessageBox.Show("Найдено: " + nameAllParameters.Length.ToString() + " имен ПО из черного списка, нажмите 'OK' чтобы их удалить.", title, buttons);
                            if (result == DialogResult.No)
                            {
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Черный список ПО пуст, и это замечательно!", "Adsk-Miner-Destroyer");
                        }
                        foreach (string item in nameAllParameters)
                        {
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result = MessageBox.Show("Найдено: " + item + " удалить из черного списка?", title, buttons);
                            if (result == DialogResult.Yes)
                            {
                                regKey.DeleteValue(item, true);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при удалении ПО из черного списка, у вас нет папки для запрета каких-либо ПО! *хлоп хлоп*", title);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении ПО из черного списка, убедитесь, что вы предоставили права администратора.", title);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sys32 = Environment.GetFolderPath(Environment.SpecialFolder.System);
                StreamWriter sw = new StreamWriter(sys32 + @"\drivers\etc\hosts");
                sw.WriteLine("127.0.0.1 localhost");
                sw.Close();
                MessageBox.Show("Лечение прошло успешно.", title);
            }
            catch
            {
                MessageBox.Show("Ошибка при лечении файла hosts, убедитесь, что вы предоставили права администратора.", title);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 dlg = new Form3();
            dlg.Show();
            this.Hide();
        }
    }
}
