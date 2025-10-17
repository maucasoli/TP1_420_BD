
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Identity.Client;

namespace TP1_420_BD.Models
{
    internal class Commands
    {
      public void ReadTableCommands(DataGridView gridView, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string select = "SELECT * FROM Commandes;";
                SqlDataAdapter adapter = new SqlDataAdapter(select, con);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Commandes");

                gridView.DataSource = dataSet.Tables["Commandes"];
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
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string insertQuery = "INSERT INTO commandes (DateCommande, Montant, IdClient) VALUES (@DateCommande, @Montant, @IdClient)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@IdClient", clientId);
                    cmd.Parameters.AddWithValue("@DateCommande", dateCommand);
                    cmd.Parameters.AddWithValue("@Montant", amount);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
