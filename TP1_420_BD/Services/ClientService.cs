using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TP1_420_BD.Data;
using TP1_420_BD.Models;

namespace TP1_420_BD.Services
{
    // Logic between UI and DB
    internal class ClientService
    {
        private readonly ClientRepository _repo;

        public ClientService(string conStr)
        {
            _repo = new ClientRepository(conStr);
        }

        public DataTable GetClients()
        {
            return _repo.GetAll();

        }

        public bool CreateClient(Client client)
        {
           return  _repo.Create(client);
        }

        public void UpdateClient(Client client)
        {
            _repo.Update(client);
        }

        public void DeleteClient(int id)
        {
            _repo.Delete(id);
        }

        public DataTable? SearchClient(string searchString)
        {
            return _repo.Search(searchString);
        }
    }
}
