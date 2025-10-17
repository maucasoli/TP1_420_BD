using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TP1_420_BD.Models
{
    public class Client
    {
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Client() { }

        public Client(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public Client(int idClient, string name, string email, string phone)
        {
            IdClient = idClient;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public static Dictionary<int, string> GetClients(string conStr)
        {
            var clients = new Dictionary<int, string>();

            using(SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string query = "SELECT idClient, Name FROM Clients";

                using(SqlCommand cmd = new SqlCommand(query, con))
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        clients.Add(id, name);
                    }
                }
            }
            return clients;
        }
    }
}
