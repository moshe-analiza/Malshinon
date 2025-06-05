using System.Data.SqlClient;
using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using Malshinon;
using System.Collections.Generic;

namespace Data
{
    public class UseSQL
    {
        private UseSQL()
        {
        }

        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public MySqlConnection Connection { get; set; }

        private static UseSQL _instance = null;
        public static UseSQL Instance()
        {
            if (_instance == null)
                _instance = new UseSQL();
            return _instance;
        }

        public bool IsConnect()
        {
            if (string.IsNullOrEmpty(Server) || string.IsNullOrEmpty(DatabaseName) || string.IsNullOrEmpty(UserName))
                return false;

            return true;
        }

        public void Close()
        {
            Connection.Close();
        }


        public List<Dictionary<string, object>> RunQuery(string query = "SELECT * FROM peoples")
        {
            var results = new List<Dictionary<string, object>>();

            if (!IsConnect())
                return results;

            string connstring = $"Server={Server}; database={DatabaseName}; UID={UserName}; password={Password}";

            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.GetValue(i);
                            }
                            results.Add(row);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }

            return results;
        }
    }
}