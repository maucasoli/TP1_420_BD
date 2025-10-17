using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

}
