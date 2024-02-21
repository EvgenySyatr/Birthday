using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Birthdays
{
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
            textBoxBirthDate.Text = "2000-01-01";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            String name = textBoxName.Text;
            String birthDate = textBoxBirthDate.Text;

            if (name == "")
            {
                MessageBox.Show("Введите имя");
                return;
            }




            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            if (UserExists(name))
                MessageBox.Show("Друг с именем " + name + " уже существует");
            else
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`id`, `name`, `birthday`) VALUES (NULL, @name, @birthDate)", db.getConnection());
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@birthDate", MySqlDbType.VarChar).Value = birthDate;

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Друг " + name + " добавлен");
                else
                    MessageBox.Show("Друг " + name + " не был добавлен");

                // указываем, какую команду будем выполнять
                //adapter.SelectCommand = command;
                // заполняем объект table данными
                //adapter.Fill(table);
                db.closeConnection(); 
            }
        }


        // Метод для проверки существования пользователя в базе данных по имени
        public bool UserExists(string name)
        {
            DB db = new DB();
            using (MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM `users` WHERE `name` = @name", db.getConnection()))
            {
                command.Parameters.AddWithValue("@name", name);
                db.openConnection();
                int count = Convert.ToInt32(command.ExecuteScalar());
                db.closeConnection();
                return count > 0;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxBirthDate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
