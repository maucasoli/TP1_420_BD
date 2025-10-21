
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Identity.Client;
using System.Security.Cryptography.Xml;

// Models/Commande.cs
namespace TP1_420_BD.Models
{
    public class Commande
    {
        public int IdCommande { get; set; }
        public string ReferenceCommande { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal Montant { get; set; }
        public int IdClient { get; set; }
    }
}
