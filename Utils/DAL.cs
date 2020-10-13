using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MyFinance.Utils
{
    public class DAL
    {
        private static string server = "localhost";
        private static string database = "financeiro";
        private static string user = "root";
        private static string password = "";
        private string connectionString = $"Server={server};Database={database};Uid={user};Pwd={password}";
        private MySqlConnection connection;

        public DAL()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        // SELECTS
        public DataTable RetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(dataTable);

            return dataTable;
        }

        // INSERT, UPDATE, DELETE
        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
