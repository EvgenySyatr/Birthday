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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Birthdays
{
    
    public partial class TodayBirthdays : Form
    {

        public TodayBirthdays()
        {
            InitializeComponent();
            textBoxComingBirths.Multiline = true;
            ShowTodayBirthdays();
            ShowComingBirthdays();
        }


        private void ShowTodayBirthdays()
        {
            string today = DateTime.Today.ToString("MM-dd");
            DB db = new DB();

            string query = "SELECT name FROM users WHERE DATE_FORMAT(birthday, '%m-%d') = @today";

            MySqlCommand command = new MySqlCommand(query, db.getConnection());
            command.Parameters.Add("@today", MySqlDbType.VarChar).Value = today;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    string name = row["name"].ToString();
                    textBoxTodayBirths.AppendText(name + "\r\n");
                }
            }
            else
            {
                textBoxTodayBirths.AppendText("Сегодня никто не празднует день рождения.\r\n");
            }
        }


        private void ShowComingBirthdays()
        {
            DateTime today = DateTime.Today;
            DateTime threeDaysFromNow = today.AddDays(3);

            string query = "SELECT name, birthday FROM users WHERE DAY(birthday) BETWEEN DAY(@today) + 1 AND DAY(@threeDaysFromNow) AND MONTH(birthday) = MONTH(@today)";

            DB db = new DB();
            MySqlCommand command = new MySqlCommand(query, db.getConnection());
            command.Parameters.AddWithValue("@today", today);
            command.Parameters.AddWithValue("@threeDaysFromNow", threeDaysFromNow);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    string name = row["name"].ToString();
                    string birthday = ((DateTime)row["birthday"]).ToString("yyyy-MM-dd");
                    textBoxComingBirths.AppendText($"{name} ({birthday})\r\n");
                }
            }
            else
            {
                textBoxComingBirths.AppendText("Нет предстоящих дней рождения в ближайшие три дня.\r\n");
            }
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void butTodayUp_Click(object sender, EventArgs e)
        {

        }

        private void textBoxComingBirths_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            
            main menu = new main();
            menu.Show();
            

        }
    }
}
