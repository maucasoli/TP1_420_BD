using System.Data;
using Microsoft.Data.SqlClient;
using TP1_420_BD.Models;

namespace TP1_420_BD.Data
{
    internal class CommandRepository : BaseRepository<Commande>
    {
        private readonly string _conStr;

        public CommandRepository(string conStr)
        {
            _conStr = conStr;
        }

        public override DataTable? Search(string searchString)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conStr))
                {
                    con.Open();
                    var select = @"
                        SELECT c.IdCommande, c.ReferenceCommande, c.DateCommande, c.Montant, c.IdClient,
                               cl.Email AS ClientEmail
                        FROM Commandes c
                        INNER JOIN Clients cl ON c.IdClient = cl.IdClient
                        WHERE c.ReferenceCommande LIKE @search
                              OR CONVERT(varchar, c.DateCommande, 23) LIKE @search
                              OR CONVERT(varchar, c.Montant) LIKE @search
                              OR cl.Email LIKE @search;
                    ";

                    SqlCommand selectCmd = new SqlCommand(select, con);
                    selectCmd.Parameters.AddWithValue("@search", "%" + searchString + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(selectCmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Commandes");

                    return dataSet.Tables["Commandes"];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public override bool Create(Commande command)
        {
            string reference = GenerateRandomReference();

            try
            {
                using (SqlConnection con = new SqlConnection(_conStr))
                {
                    con.Open();

                    string insertQuery = @"
                    INSERT INTO Commandes (ReferenceCommande, DateCommande, Montant, IdClient)
                    VALUES (@ReferenceCommande, @DateCommande, @Montant, @IdClient)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ReferenceCommande", reference);
                        cmd.Parameters.AddWithValue("@DateCommande", command.DateCommande);
                        cmd.Parameters.AddWithValue("@Montant", command.Montant);
                        cmd.Parameters.AddWithValue("@IdClient", command.IdClient);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
           catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        public override void Update(Commande command)
        {
            using (SqlConnection con = new SqlConnection(_conStr))
            {
                con.Open();

                string updateQuery = @"
                    UPDATE Commandes
                    SET ReferenceCommande = @ReferenceCommande,
                        DateCommande = @DateCommande,
                        Montant = @Montant,
                        IdClient = @IdClient
                    WHERE IdCommande = @IdCommande";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@IdCommande", command.IdCommande);
                    cmd.Parameters.AddWithValue("@ReferenceCommande", command.ReferenceCommande);
                    cmd.Parameters.AddWithValue("@DateCommande", command.DateCommande);
                    cmd.Parameters.AddWithValue("@Montant", command.Montant);
                    cmd.Parameters.AddWithValue("@IdClient", command.IdClient);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void Delete(int idCommande)
        {
            using (SqlConnection con = new SqlConnection(_conStr))
            {
                con.Open();

                string deleteQuery = "DELETE FROM Commandes WHERE IdCommande = @IdCommande";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@IdCommande", idCommande);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override DataTable GetAll()
        {
            using (SqlConnection con = new SqlConnection(_conStr))
            {
                con.Open();

                string query = @"
                    SELECT 
                        c.IdCommande,
                        c.ReferenceCommande,
                        c.DateCommande,
                        c.Montant,
                        cl.Email AS ClientEmail,
                        cl.IdClient
                    FROM Commandes c
                    INNER JOIN Clients cl ON c.IdClient = cl.IdClient
                    ORDER BY c.IdCommande DESC;
                ";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private string GenerateRandomReference()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string suffix = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return "CMD-" + suffix;
        }
    }
}
