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
    internal class CommandRepository
    {
        // _ for private variables
        private readonly string _conStr;

        public CommandRepository(string conStr)
        {
            _conStr = conStr;
        }
        public DataTable? SearchCommandes(string searchString)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conStr))
                {
                    con.Open();
                    var select = @"SELECT IdCommande, ReferenceCommande, DateCommande, Montant, IdClient 
                                  FROM Commandes
                                  WHERE ReferenceCommande LIKE @search
                                  OR CONVERT(varchar, DateCommande, 23) LIKE @search
                                  OR CONVERT(varchar, Montant) LIKE @search;";

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
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


    }
}
