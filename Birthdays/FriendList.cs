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

namespace Birthdays
{
    public partial class FriendList : Form
    {
        List<string> friendList = new List<string>();
        private int startIndex = 0; // Индекс начала текущего диапазона
        private const int pageSize = 10; // Размер страницы

        public FriendList()
        {
            InitializeComponent();
            LoadFriendList();
            // textBoxFriendList.Text = string.Join("\r\n", friendList);
            ShowCurrentPage();

        }


        private void LoadFriendList()
        {
            // Создаем экземпляр класса DB для работы с базой данных
            DB db = new DB();

            // Создаем соединение с базой данных
            using (MySqlConnection connection = db.getConnection())
            {
                try
                {
                    // Открываем соединение
                    connection.Open();

                    // Создаем SQL-запрос для получения списка всех друзей и их дат рождения,
                    // отсортированных по дню и месяцу
                    string query = "SELECT name, birthday FROM users ORDER BY MONTH(birthday), DAY(birthday)";

                    // Создаем команду для выполнения запроса
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Выполняем команду и получаем результат в виде объекта MySqlDataReader
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Пока есть строки в результате запроса
                            while (reader.Read())
                            {
                                // Получаем имя друга и его дату рождения из результата запроса
                                string name = reader.GetString("name");
                                DateTime birthday = reader.GetDateTime("birthday");

                                // Формируем строку с именем друга и его полной датой рождения
                                string friendInfo = $"{name} ({birthday.ToString("yyyy-MM-dd")})";

                                // Добавляем эту строку в список друзей
                                friendList.Add(friendInfo);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок при выполнении запроса
                    MessageBox.Show($"Ошибка загрузки списка друзей: {ex.Message}");
                }
            }
        }


        private void ShowCurrentPage()
        {
            // Очищаем textBoxFriendList перед добавлением новых элементов
            textBoxFriendList.Clear();

            // Определяем индекс конца текущего диапазона
            int endIndex = Math.Min(startIndex + pageSize, friendList.Count);

            // Добавляем элементы текущего диапазона в textBoxFriendList
            for (int i = startIndex; i < endIndex; i++)
            {
                textBoxFriendList.AppendText(friendList[i] + Environment.NewLine);
            }
        }


        private void buttonDown_Click(object sender, EventArgs e)
        {
            // Увеличиваем индекс начала диапазона на размер страницы
            startIndex += pageSize;

            // Отображаем новую страницу
            ShowCurrentPage();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            // Уменьшаем индекс начала диапазона на размер страницы,
            // если текущий список не первые десять элементов
            if (startIndex > 0)
            {
                startIndex -= pageSize;
            }

            // Отображаем новую страницу
            ShowCurrentPage();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFriendList_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
