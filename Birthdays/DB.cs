using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthdays
{
    internal class DB
    {
        private MySqlConnection connection;

        public DB()
        {
            string[] configLines = File.ReadAllLines("C:\\Users\\zhenn\\source\\repos\\Birthdays\\Birthdays\\DataBaseConfiguration.txt");

            if (configLines.Length >= 4)
            {
                string server = configLines[0].Split('=')[1].Trim();
                string port = configLines[1].Split('=')[1].Trim();
                string username = configLines[2].Split('=')[1].Trim();
                string password = configLines[3].Split('=')[1].Trim();
                string database = configLines[4].Split('=')[1].Trim();

                string connectionString = $"server={server};port={port};username={username};password={password};database={database}";

                connection = new MySqlConnection(connectionString);
            }
            else
            {
                throw new Exception("Ошибка чтения файла конфигурации базы данных.");
            }
        }

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection getConnection()
        { return connection; }

    }
}
