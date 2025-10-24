using System.Data;
using TP1_420_BD.Data;
using TP1_420_BD.Models;

namespace TP1_420_BD.Services
{
    internal class CommandService
    {
        private readonly CommandRepository _repo;

        public CommandService(string conStr)
        {
            _repo = new CommandRepository(conStr);
        }

        public DataTable? SearchCommandes(string searchString)
        {
            return _repo.Search(searchString);
        }

        public bool CreateCommand(Commande command)
        {
            return _repo.Create(command);
        }

        public void UpdateCommand(Commande command)
        {
            _repo.Update(command);
        }

        public void DeleteCommand(int id)
        {
            _repo.Delete(id);
        }

        public DataTable GetAllCommandes()
        {
            return _repo.GetAll();
        }
    }
}
