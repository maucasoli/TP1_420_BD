
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Identity.Client;
using System.Security.Cryptography.Xml;

namespace TP1_420_BD.Models
{
    internal class Commands
    {
        public void ReadTableCommands(DataGridView dgv, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string query = @"
            SELECT 
                c.IdCommande,
                c.ReferenceCommande,
                c.DateCommande,
                c.Montant,
                cl.Email AS ClientEmail
            FROM Commandes c
            INNER JOIN Clients cl ON c.IdClient = cl.IdClient
            ORDER BY c.IdCommande DESC;
        ";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv.DataSource = dt;
            }
        }


        public void DeleteCommand(int id, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string deleteQuery = "DELETE FROM Commandes WHERE IdCommande = @id";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddCommand(int clientId, DateTime dateCommand, decimal amount, string conStr)
        {

            string reference = GenerateRandomReference();

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string insertQuery = @"
            INSERT INTO Commandes (ReferenceCommande, DateCommande, Montant, IdClient)
            VALUES (@ReferenceCommande, @DateCommande, @Montant, @IdClient)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@IdClient", clientId);
                    cmd.Parameters.AddWithValue("@DateCommande", dateCommand);
                    cmd.Parameters.AddWithValue("@Montant", amount);
                    cmd.Parameters.AddWithValue("@ReferenceCommande", reference);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCommand(int idCommande, int clientId, DateTime dateCommande, decimal amount, string reference, string conStr)
        {       

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string updateQuery = "UPDATE Commandes " +
                    "SET ReferenceCommande = @ReferenceCommande, " +
                    "DateCommande = @DateCommande, " +
                    "Montant = @Montant, " +
                    "IdClient = @IdClient " +
                    "WHERE IdCommande = @IdCommande";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@IdCommande", idCommande);
                    cmd.Parameters.AddWithValue("@ReferenceCommande", reference);
                    cmd.Parameters.AddWithValue("@DateCommande", dateCommande);
                    cmd.Parameters.AddWithValue("@Montant", amount);
                    cmd.Parameters.AddWithValue("@IdClient", clientId);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        private string GenerateRandomReference()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string suffix = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return "CMD-" + suffix; // e.g., CMD-5R8X2A
        }

    }
}
