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

            //Appel à la classe Commandes
            var commandesView = new Models.Commands();
            commandesView.ReadTableCommands(commandsGridView, conStr);
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

        private void deleteCommandButton_Click(object sender, EventArgs e)
        {
            if(commandsGridView.SelectedRows.Count >0)
            {
                //get the selected row
                DataGridViewRow selectedRow = commandsGridView.SelectedRows[0];

                //Extract the IdCommande
                int idCommand = Convert.ToInt32(selectedRow.Cells["IdCommande"].Value);

                // Confirm with the user

                var confirm = MessageBox.Show($"Delete commande #{idCommand}?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var command = new Models.Commands();
                    command.DeleteCommand(idCommand, conStr);
                    command.ReadTableCommands(commandsGridView, conStr);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
    }
}
