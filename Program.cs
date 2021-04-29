using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tele_list
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "Server=localhost;User ID=root;Password=chaeto33notus;Database=contact";
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM contactlist;", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            string fornamn = reader.GetString(1);
                            string efternamn = reader.GetString(2);
                            string gatuadress = reader.GetString(3);
                            string telefon = reader.GetString(4);
                            DateTime fodelsedag = reader.GetDateTime(5);
                            Console.Write(ID + " ");
                            Console.Write(fornamn + ", ");
                            Console.Write(efternamn + ", ");
                            Console.Write(gatuadress + ", ");
                            Console.Write(telefon + ", ");
                            Console.WriteLine(fodelsedag.ToShortDateString() + ", ");
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
