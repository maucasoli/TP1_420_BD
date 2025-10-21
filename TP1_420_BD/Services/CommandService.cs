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
            return _repo.SearchCommandes(searchString);
        }

        public void CreateCommand(Commande command)
        {
            _repo.CreateCommand(command);
        }

        public void UpdateCommand(Commande command)
        {
            _repo.UpdateCommand(command);
        }

        public void DeleteCommand(int id)
        {
            _repo.DeleteCommand(id);
        }

        public DataTable GetAllCommandes()
        {
            return _repo.ReadAllCommandes();
        }
    }
}
