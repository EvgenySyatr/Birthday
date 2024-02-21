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
    public partial class changeUser : Form
    {
        private string currentFriendName;
        private DateTime currentBirthDate;
        private List<string> deletedFriends = new List<string>();
        private Dictionary<string, DateTime> deletedFriendsWithBirthdays = new Dictionary<string, DateTime>();



        public changeUser()
        {
            InitializeComponent();
            LoadFriendNames();
            UpdateFriendInfo();
        }


        private void LoadFriendNames()
        {
            // Очищаем listBoxFriends перед загрузкой новых имен
            listBoxFriends.Items.Clear();

            // Создаем экземпляр класса DB для работы с базой данных
            DB db = new DB();

            // Создаем соединение с базой данных
            using (MySqlConnection connection = db.getConnection())
            {
                try
                {
                    // Открываем соединение
                    connection.Open();

                    // Создаем SQL-запрос для получения списка всех друзей
                    string query = "SELECT name FROM users";

                    // Создаем команду для выполнения запроса
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Выполняем команду и получаем результат в виде объекта MySqlDataReader
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Пока есть строки в результате запроса
                            while (reader.Read())
                            {
                                // Получаем имя друга из результата запроса и добавляем его в listBoxFriends
                                string friendName = reader.GetString("name");
                                listBoxFriends.Items.Add(friendName);
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


        private void UpdateFriendInfo()
        {
            if (listBoxFriends.SelectedIndex != -1)
            {
                currentFriendName = listBoxFriends.SelectedItem.ToString();
                textBoxName.Text = currentFriendName;

                DB db = new DB();
                using (MySqlConnection connection = db.getConnection())
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT birthday FROM users WHERE name = @name";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@name", currentFriendName);
                            object result = command.ExecuteScalar();

                            if (result != null)
                            {
                                currentBirthDate = (DateTime)result;
                                textBoxDate.Text = currentBirthDate.ToString("yyyy-MM-dd");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка получения информации о друге: {ex.Message}");
                    }
                }
            }
        }


        private void UpdateFriendName(string newName)
        {
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE users SET name = @newName WHERE name = @currentName";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newName", newName);
                        command.Parameters.AddWithValue("@currentName", currentFriendName);
                        command.ExecuteNonQuery();
                    }

                    currentFriendName = newName;
                    listBoxFriends.Items[listBoxFriends.SelectedIndex] = newName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка изменения имени друга: {ex.Message}");
                }
            }
        }


        private void UpdateBirthDate(DateTime newBirthDate)
        {
            DB db = new DB();
            using (MySqlConnection connection = db.getConnection())
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE users SET birthday = @newBirthDate WHERE name = @name";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newBirthDate", newBirthDate);
                        command.Parameters.AddWithValue("@name", currentFriendName);
                        command.ExecuteNonQuery();
                    }

                    currentBirthDate = newBirthDate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка изменения даты рождения: {ex.Message}");
                }
            }
        }


        private void buttonChangeDate_Click(object sender, EventArgs e)
        {
            if (listBoxFriends.SelectedIndex != -1)
            {
                string newName = textBoxName.Text;
                DateTime newBirthDate;

                if (!string.IsNullOrWhiteSpace(newName) && newName != currentFriendName)
                {
                    UpdateFriendName(newName);
                }

                if (DateTime.TryParse(textBoxDate.Text, out newBirthDate) && newBirthDate != currentBirthDate)
                {
                    UpdateBirthDate(newBirthDate);
                }

                MessageBox.Show("Изменения успешно сохранены!");
            }
            else
            {
                MessageBox.Show("Выберите друга из списка!");
            }
        }


        private void DeleteFriend()
        {
            if (listBoxFriends.SelectedIndex != -1)
            {
                
              
                DB db = new DB();

                using (MySqlConnection connection = db.getConnection())
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM users WHERE name = @name";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@name", currentFriendName);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Пользователь успешно удален!");
                        deletedFriendsWithBirthdays.Add(currentFriendName, currentBirthDate); // Добавляем удаленного пользователя в словарь
                        listBoxFriends.Items.RemoveAt(listBoxFriends.SelectedIndex); // Удаляем пользователя из listBox
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления пользователя: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите друга из списка для удаления!");
            }
        }


        private void RestoreFriend()
        {
            if (deletedFriendsWithBirthdays.Count > 0)
            {
                string friendToRestore = deletedFriendsWithBirthdays.Keys.Last(); // Получаем имя последнего удаленного друга
                DateTime birthDateToRestore = deletedFriendsWithBirthdays[friendToRestore]; // Получаем дату рождения восстанавливаемого друга
                DB db = new DB();

                using (MySqlConnection connection = db.getConnection())
                {
                    try
                    {
                        connection.Open();
                        string query = "INSERT INTO users (name, birthday) VALUES (@name, @birthday)";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@name", friendToRestore);
                            command.Parameters.AddWithValue("@birthday", birthDateToRestore);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Пользователь успешно восстановлен!");
                        listBoxFriends.Items.Add(friendToRestore); // Добавляем восстановленного пользователя в listBox
                        deletedFriendsWithBirthdays.Remove(friendToRestore); // Удаляем пользователя из словаря удаленных
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка восстановления пользователя: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Нет удаленных пользователей для восстановления!");
            }
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxFriends_SelectedValueChanged(object sender, EventArgs e)
        {
            // Обновляем данные
            UpdateFriendInfo();

        }

        private void buttonRestoreUser_Click(object sender, EventArgs e)
        {
            RestoreFriend();
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            DeleteFriend();
        }
    }
}
