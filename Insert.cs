using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Insert : Form
    {
        public Insert()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e) //добавляем новое дело
        {
            if (textBox1.Text != "")
            {
                try
                {
                    string description = textBox1.Text;
                    string date = dateTimePicker1.Value.ToShortDateString();
                    string status = textBox2.Text;
                    string strWrite = description + "|" + date + "|" + status + "\n"; //Формируем строку
                    StreamWriter SW = new StreamWriter(new FileStream(@"..\..\Файл.txt", FileMode.Append, FileAccess.Write));
                    SW.Write(strWrite); //Записываем строку
                    SW.Close(); //Закрываем файл
                    MessageBox.Show("Данные добавлены!", "Подтверждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Введите данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
