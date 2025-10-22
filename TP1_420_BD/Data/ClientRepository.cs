using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TP1_420_BD.Models;

namespace TP1_420_BD.Data
{
    // DB access
    internal class ClientRepository
    {
        // _ for private variables
        private readonly string _conStr;

        public ClientRepository(string conStr)
        {
            _conStr = conStr;
        }

        // ? = could return null
        public DataTable? ReadClients()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conStr))
                {
                    con.Open();
                    var query = "SELECT * FROM Clients;";
                    var adapter = new SqlDataAdapter(query, con);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public void CreateClient(Client client)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conStr))
                {
                    con.Open();
                    string insertSql = "INSERT INTO Clients (name, email, phone) VALUES (@Name, @Email, @Phone);";

                    using (SqlCommand cmd = new SqlCommand(insertSql, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", client.Name);
                        cmd.Parameters.AddWithValue("@Email", client.Email);
                        cmd.Parameters.AddWithValue("@Phone", client.Phone);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void UpdateClient(Client client)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conStr))
                {
                    con.Open();
                    string update = "UPDATE Clients SET name = @Name, email = @Email, phone = @Phone WHERE idClient = @Id";

                    using (SqlCommand cmd = new SqlCommand(update, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", client.IdClient);
                        cmd.Parameters.AddWithValue("@Name", client.Name);
                        cmd.Parameters.AddWithValue("@Email", client.Email);
                        cmd.Parameters.AddWithValue("@Phone", client.Phone);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void DeleteClient(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conStr))
                {
                    con.Open();
                    var updateSql = "DELETE FROM Clients WHERE idClient = @Id;";
                    SqlCommand updateCmd = new SqlCommand(updateSql, con);
                    updateCmd.Parameters.AddWithValue("@Id", id);
                    var lines = updateCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public DataTable? SearchClient(String searchString)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conStr))
                {
                    con.Open();
                    var select = @"SELECT idClient, name, email, phone FROM Clients 
                                WHERE email LIKE @Search OR name LIKE @Search OR phone LIKE @Search;";
                    SqlCommand selectCmd = new SqlCommand(select, con);
                    selectCmd.Parameters.AddWithValue("@Search", "%" + searchString + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(selectCmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Clients");
                    return dataSet.Tables["Clients"];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
