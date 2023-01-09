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
    public partial class reg : Form
    {
        public reg()
        {
            InitializeComponent();
            this.pass.AutoSize = false;
            this.pass.Size = new Size(this.pass.Size.Width, 65);
            name.Text = "Введите имя";
            surname.Text = "Введите фамилию";
            login.Text = "Введите логин";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void name_Enter(object sender, EventArgs e)
        {
            if (name.Text == "Введите имя")
                name.Text = "";
        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (name.Text == "")
                name.Text = "Введите имя";
        }

        private void surname_Enter(object sender, EventArgs e)
        {
            if (surname.Text == "Введите фамилию")
                surname.Text = "";
        }

        private void surname_Leave(object sender, EventArgs e)
        {
            if (surname.Text == "")
                surname.Text = "Введите фамилию";
        }

        private void login_Enter(object sender, EventArgs e)
        {
            if (login.Text == "Введите логин")
                login.Text = "";
        }

        private void login_Leave(object sender, EventArgs e)
        {
            if (login.Text == "")
                login.Text = "Введите логин";
        }

        private void regbutton_Click(object sender, EventArgs e)
        {
            if (name.Text == "Введите имя") //проверки, чтобы пользователь смог зарегистрироваться, только если введет все данные.
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (surname.Text == "Введите фамилию")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }
            if (login.Text == "Введите логин")
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (pass.Text == "")
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            if (checkUser())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `name`, `surname`) VALUES ('@login', '@pass', '@name', '@surname')", db.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("регистрация завершена");
            else
                MessageBox.Show("регистрация не завершена");


            db.closeConnection();
        }
        public Boolean checkUser()
        {
            DB db = new DB();
            DataTable table = new DataTable(); //некая таблица в нашей баззе данных, которую мы сможем заполнять, искать в ней нужные столбцы и т.д.

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE 'login' = @uL", db.getConnection()); //выборка из таблицы баззы данных //@uL, @uP - заглушки для безопасности от взлома, ниже присвоим им значения
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login.Text;

            adapter.SelectCommand = command; //берем наши данные и 
            adapter.Fill(table); //заполняем нашу таблицу

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("такой логин уже существует, введите другой");
                return true;
            }
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            mainwindow mainwindow = new mainwindow();
            mainwindow.Show();
        }
    }
}
