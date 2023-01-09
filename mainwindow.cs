using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
//using static System.Net.Mime.MediaTypeNames;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ToDoList
{
    public partial class mainwindow : Form
    {
        public mainwindow()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
        }

        Point LastPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //проверяем, зажали ли мы кнопку на мышке
            {
                this.Left += e.X - LastPoint.X;//курсор по координате X
                this.Top += e.Y - LastPoint.Y;//курсор по координате Y
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] dataString = File.ReadAllLines(@"..\..\Файл.txt");
                DataTable dt = new DataTable();
                dt.Columns.Add("Текстовое описание");
                dt.Columns.Add("Дата");
                dt.Columns.Add("Статус");
                int count = 1;
                string[] ss;
                foreach (string s in dataString)
                {
                    ss = s.Split('|');
                    if (ss[2] == "сделать")
                    {
                        dt.Rows.Add(ss[0], ss[1], ss[2]);
                        count++;
                    }
                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 250;
            }
            catch
            {
                MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string[] dataString = File.ReadAllLines(@"..\..\Файл.txt");
                DataTable dt = new DataTable();
                dt.Columns.Add("Текстовое описание");
                dt.Columns.Add("Дата");
                dt.Columns.Add("Статус");
                int count = 1;
                string[] ss;
                foreach (string s in dataString)
                {
                    ss = s.Split('|');
                    if (ss[2] == "в процессе")
                    {
                        dt.Rows.Add(ss[0], ss[1], ss[2]);
                        count++;
                    }
                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 250;
            }
            catch
            {
                MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                string[] dataString = File.ReadAllLines(@"..\..\Файл.txt");
                DataTable dt = new DataTable();
                dt.Columns.Add("Текстовое описание");
                dt.Columns.Add("Дата");
                dt.Columns.Add("Статус");
                int count = 1;
                string[] ss;
                foreach (string s in dataString)
                {
                    ss = s.Split('|');
                    if (ss[2] == "готово")
                    {
                        dt.Rows.Add(ss[0], ss[1], ss[2]);
                        count++;
                    }
                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 250;
            }
            catch
            {
                MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainwindow_Load(object sender, EventArgs e)
        {
            try
            {
                string[] dataString = File.ReadAllLines(@"..\..\Файл.txt");
                DataTable dt = new DataTable();
                dt.Columns.Add("Текстовое описание");
                dt.Columns.Add("Дата");
                dt.Columns.Add("Статус");
                int count = 1;
                string[] ss;
                foreach (string s in dataString)
                {
                    ss = s.Split('|');
                    dt.Rows.Add(ss[0], ss[1], ss[2]);
                    count++;
                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 250;
            }
            catch
            {
                MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
             
                string[] dataString = File.ReadAllLines(@"..\..\Файл.txt");
                DataTable dt = new DataTable();
                dt.Columns.Add("Текстовое описание");
                dt.Columns.Add("Дата");
                dt.Columns.Add("Статус");
                int count = 1;
                string[] ss;
                foreach (string s in dataString)
                {
                    ss = s.Split('|');
                    dt.Rows.Add(ss[0], ss[1], ss[2]);
                    count++;
                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 250;
            }
            catch
            {
                MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            {
                Insert insert = new Insert();
                insert.ShowDialog();
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int number_delete = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.RemoveAt(number_delete);
            string file_name = @"..\..\Файл.txt";
            string[] readText = System.IO.File.ReadAllLines(file_name);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(file_name, false))
            {
                for (int i = 0; i < readText.Length; i++)
                {
                    if (i != number_delete)
                        file.WriteLine(readText[i]);
                }
            }
            dataGridView1.Refresh();
            MessageBox.Show("Строка удалена", "Удалена", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int number = dataGridView1.CurrentRow.Index;
            string file_name = @"..\..\Файл.txt";
            string textComboBox = comboBox1.Text;
            string textReplace = "";
            string text = "";

            IEnumerable<string> result = File.ReadLines(file_name).Skip(number).Take(1);
            foreach (string str in result)
            {
                text = str.Split('|')[0] + "|" + str.Split('|')[1] + "|" + str.Split('|')[2];
                textReplace = str.Split('|')[0] + "|" + str.Split('|')[1] + "|" + textComboBox;

                Console.WriteLine(textReplace);
                Console.WriteLine(text);
                MessageBox.Show("Дело изменено со статуса " + str.Split('|')[2] + " на статус " + textComboBox);
                // Console.WriteLine(text);
            }
            int i = 0;
            string tempPath = file_name + ".tmp";
            using (StreamReader sr = new StreamReader(file_name)) // читаем
            using (StreamWriter sw = new StreamWriter(tempPath)) // и сразу же пишем во временный файл
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (number == i)
                        sw.WriteLine(textReplace);
                    else
                        sw.WriteLine(line);
                    i++;
                }
            }
            File.Delete(file_name); // удаляем старый файл
            File.Move(tempPath, file_name); // переименовываем временный файл
        }
        private void CloseButton_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
