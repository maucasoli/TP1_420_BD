using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_420_BD.Data;

namespace TP1_420_BD.Services
{
    internal class CommandService
    {
        public CommandService(string conStr)
        {
            _repo = new CommandRepository(conStr);
        }
        private readonly CommandRepository _repo;

        public DataTable? SearchCommandes(string searchString)
        {
            return _repo.SearchCommandes(searchString);
        }
    }
}
