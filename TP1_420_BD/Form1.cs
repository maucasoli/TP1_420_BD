using System.Data;
using System.Windows.Forms;
using DotNetEnv;
using Microsoft.Data.SqlClient;

namespace TP1_420_BD
{
    public partial class Form1 : Form
    {
        string server;
        string database;
        string conStr;

        public Form1()
        {
            InitializeComponent();

            // Récupérer les variables depuis le fichier .env
            Env.Load();
            server = Env.GetString("SERVER");
            database = Env.GetString("DATABASE");
            conStr = $"Server={server};Database={database};Trusted_Connection=True;TrustServerCertificate=True";

        }

        //private void clientsButton_Click(object sender, EventArgs e)
        //{
        //    Home.Visible = false;
        //    Clients.Visible = true;
        //    Clients.BringToFront();

        //    ReadTable();
        //}

        private void ReadTable()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string select = "SELECT * FROM Clients;";
                SqlDataAdapter adapter = new SqlDataAdapter(select, con);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Clients");

                clientsGridView.DataSource = dataSet.Tables["Clients"];
            }
        }

        private void clientsButton_Click(object sender, EventArgs e)
        {
            home.Visible = false;
            clients.Visible = true;
            clients.BringToFront();

            ReadTable();
        }

        private void commandesButton_Click(object sender, EventArgs e)
        {
            home.Visible = false;
            commandes.Visible = true;
            commandes.BringToFront();
        }

        private void clientsReturnButton_Click(object sender, EventArgs e)
        {
            home.Visible = true;
            clients.Visible = false;
        }

        private void commandesReturnButton_Click(object sender, EventArgs e)
        {
            home.Visible = true;
            commandes.Visible = false;
        }
    }
}
