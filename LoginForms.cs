using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class LoginForms : Form
    {
        public LoginForms()
        {
            InitializeComponent();
            this.pass1.AutoSize = false;
            this.pass1.Size = new Size(this.pass1.Size.Width, 65);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Point LastPoint; //переменная, отвечающая за координаты
        private void panel1_MouseMove(object sender, MouseEventArgs e) //чтобы иметь возможность двигать наше окошко по экрану с помощью мышки
        {
          if(e.Button == MouseButtons.Left) //проверяем, зажали ли мы кнопку на мышке
            {
                this.Left += e.X - LastPoint.X;//курсор по координате X
                this.Top += e.Y - LastPoint.Y;//курсор по координате Y
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {

            DB db = new DB();
            DataTable table = new DataTable(); //некая таблица в нашей баззе данных, которую мы сможем заполнять, искать в ней нужные столбцы и т.д.

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE 'login' = @uL AND 'pass' = @uP", db.getConnection()); //выборка из таблицы баззы данных //@uL, @uP - заглушки для безопасности от взлома, ниже присвоим им значения
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login1.Text;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = pass1.Text;

            adapter.SelectCommand = command; //берем наши данные и 
            adapter.Fill(table); //заполняем нашу таблицу

            this.Hide();
            mainwindow mainwindow = new mainwindow();
            mainwindow.Show();
        }

        private void reg_TextChanged(object sender, EventArgs e)
        {
            this.Hide();
            reg registerForm = new reg();
            registerForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            reg registerForm = new reg();
            registerForm.Show();
        }
    }
}
