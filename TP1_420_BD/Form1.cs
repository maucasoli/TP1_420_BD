using System.Data;
using System.Windows.Forms;
using System.Drawing;
using DotNetEnv;
using Microsoft.Data.SqlClient;
using TP1_420_BD.Models;

namespace TP1_420_BD
{
    public partial class Form1 : Form
    {
        string server;
        string database;
        string conStr;

        // global variables needed to update a client
        private int selectedClientId = -1;
        private string selectedName = "";
        private string selectedEmail = "";
        private string selectedPhone = "";


        public Form1()
        {
            InitializeComponent();

            Env.Load();
            server = Env.GetString("SERVER");
            database = Env.GetString("DATABASE");
            conStr = $"Server={server};Database={database};Trusted_Connection=True;TrustServerCertificate=True";
        }


        private void clientsButton_Click(object sender, EventArgs e)
        {
            home.Visible = false;
            clients.Visible = true;
            clients.BringToFront();

            ReadClients();
        }

        private void btn_add_client_Click(object sender, EventArgs e)
        {
            var client = GetInfoClient();
            if (client != null)
            {
                InsertClient(client);
                ReadClients();
            }
        }



        private void ReadClients()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string select = "SELECT * FROM Clients;";
                SqlDataAdapter adapter = new SqlDataAdapter(select, con);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Clients");

                dgvClients.DataSource = dataSet.Tables["Clients"];
            }
        }

        private Client? GetInfoClient()
        {
            Form dialog = new Form();
            dialog.Text = "Add Client";
            dialog.Size = new Size(300, 250);
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialog.MaximizeBox = false;
            dialog.MinimizeBox = false;
            dialog.ShowIcon = false;

            Label lblName = new Label() { Text = "Name:", Left = 10, Top = 20, AutoSize = true };
            TextBox txtName = new TextBox() { Left = 100, Top = 15, Width = 150 };

            Label lblEmail = new Label() { Text = "Email:", Left = 10, Top = 60, AutoSize = true };
            TextBox txtEmail = new TextBox() { Left = 100, Top = 55, Width = 150 };

            Label lblPhone = new Label() { Text = "Phone:", Left = 10, Top = 100, AutoSize = true };
            TextBox txtPhone = new TextBox() { Left = 100, Top = 95, Width = 150 };

            Button btnOK = new Button() { Text = "Save", Left = 60, Top = 175, Width = 80, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Cancel", Left = 150, Top = 175, Width = 80, DialogResult = DialogResult.Cancel };

            dialog.Controls.Add(lblName);
            dialog.Controls.Add(txtName);
            dialog.Controls.Add(lblEmail);
            dialog.Controls.Add(txtEmail);
            dialog.Controls.Add(lblPhone);
            dialog.Controls.Add(txtPhone);

            dialog.Controls.Add(btnOK);
            dialog.Controls.Add(btnCancel);

            dialog.AcceptButton = btnOK;
            dialog.CancelButton = btnCancel;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return new Client(
                    txtName.Text,
                    txtEmail.Text,
                    txtPhone.Text
                );
            }

            return null;
        }


        private void InsertClient(Client cliente)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string insertSql = "INSERT INTO Clients (name, email, phone) VALUES (@Name, @Email, @Phone);";

                using (SqlCommand cmd = new SqlCommand(insertSql, con))
                {
                    cmd.Parameters.AddWithValue("@Name", cliente.Name);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);
                    cmd.Parameters.AddWithValue("@Phone", cliente.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btn_delete_client_Click(object sender, EventArgs e)
        {
            RetrieveIdClient();
            DeleteClient();
            ReadClients();
        }

        private void DeleteClient()
        {
            throw new NotImplementedException();
        }

        private void RetrieveIdClient()
        {
            throw new NotImplementedException();
        }

        private Client? RetrieveInfoClient(int id, string name, string email, string phone)
        {
            Form dialog = new Form();
            dialog.Text = "Edit Client";
            dialog.Size = new Size(300, 250);
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialog.MaximizeBox = false;
            dialog.MinimizeBox = false;
            dialog.ShowIcon = false;

            Label lblName = new Label() { Text = "Name:", Left = 10, Top = 20, AutoSize = true };
            TextBox txtName = new TextBox() { Left = 100, Top = 15, Width = 150, Text = name };

            Label lblEmail = new Label() { Text = "Email:", Left = 10, Top = 60, AutoSize = true };
            TextBox txtEmail = new TextBox() { Left = 100, Top = 55, Width = 150, Text = email };

            Label lblPhone = new Label() { Text = "Phone:", Left = 10, Top = 100, AutoSize = true };
            TextBox txtPhone = new TextBox() { Left = 100, Top = 95, Width = 150, Text = phone };

            Button btnOK = new Button() { Text = "Modify", Left = 60, Top = 175, Width = 80, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Cancel", Left = 150, Top = 175, Width = 80, DialogResult = DialogResult.Cancel };

            dialog.Controls.Add(lblName);
            dialog.Controls.Add(txtName);
            dialog.Controls.Add(lblEmail);
            dialog.Controls.Add(txtEmail);
            dialog.Controls.Add(lblPhone);
            dialog.Controls.Add(txtPhone);
            dialog.Controls.Add(btnOK);
            dialog.Controls.Add(btnCancel);

            dialog.AcceptButton = btnOK;
            dialog.CancelButton = btnCancel;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return new Client(id, txtName.Text, txtEmail.Text, txtPhone.Text);
            }

            return null;
        }


        private void UpdateClient(Client client)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
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

                MessageBox.Show("Client updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // 0 = header
            {
                DataGridViewRow row = dgvClients.Rows[e.RowIndex];

                selectedClientId = Convert.ToInt32(row.Cells["IdClient"].Value);
                selectedName = row.Cells["name"].Value.ToString();
                selectedEmail = row.Cells["email"].Value.ToString();
                selectedPhone = row.Cells["phone"].Value.ToString();
            }
        }

        private void btn_modify_client_Click(object sender, EventArgs e)
        {
            if (selectedClientId == -1)
            {
                MessageBox.Show("Select a client.");
                return;
            }

            var updatedClient = RetrieveInfoClient(
                selectedClientId,
                selectedName,
                selectedEmail,
                selectedPhone
            );

            if (updatedClient != null)
            {
                UpdateClient(updatedClient);
                ReadClients();

                selectedClientId = -1;
                selectedName = "";
                selectedEmail = "";
                selectedPhone = "";

            }
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
        private void addCommandButton_Click(object sender, EventArgs e)
        {
            ShowAddCommandPopup();
        }

        private void ShowAddCommandPopup()
        {
            var popup = new Form();
            popup.Text = "Add Command";
            popup.Size = new Size(450, 250);
            popup.FormBorderStyle = FormBorderStyle.FixedDialog;
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.MaximizeBox = false;
            popup.MinimizeBox = false;

            // Labels
            Label lblClient = new Label() { Text = "Client", Location = new Point(20, 20) };
            Label lblDate = new Label() { Text = "Date", Location = new Point(20, 70) };
            Label lblAmount = new Label() { Text = "Amount", Location = new Point(20, 120) };

            ComboBox cbClients = new ComboBox()
            {
                Location = new Point(120, 20),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            //Load clients
            var clients = Models.Client.GetClients(conStr);
            foreach(var c in clients)
            {
                cbClients.Items.Add(new KeyValuePair<int, string>(c.Key, $"{c.Key} - {c.Value}"));
            }

            cbClients.DisplayMember = "Value";
            cbClients.ValueMember = "Key";

            //Date picker
            DateTimePicker dtpDate = new DateTimePicker()
            {
                Location = new Point(120, 70),
                Width = 220
            };

            //TextBox Amount
            TextBox txtAmount = new TextBox()
            {
                Location = new Point(120, 120),
                Width = 220
            };

            //Buttons
            Button btnSave = new Button() { Text = "Save", Location = new Point(60, 180), Width = 100 };
            Button btnCancel = new Button() { Text = "Cancel", Location = new Point(180, 180), Width = 100 };

            // Add controls to popu
            popup.Controls.Add(lblClient);
            popup.Controls.Add(cbClients);
            popup.Controls.Add(lblDate);
            popup.Controls.Add(dtpDate);
            popup.Controls.Add(lblAmount);
            popup.Controls.Add(txtAmount);
            popup.Controls.Add(btnSave);
            popup.Controls.Add(btnCancel);

            // Save handler

            btnSave.Click += (s, e) =>
            {
                if (cbClients.SelectedItem == null)
                {
                    MessageBox.Show("Please select a client.");
                    return;
                }

                if(!decimal.TryParse(txtAmount.Text, out decimal amount) || amount < 0)
                {
                    MessageBox.Show("Please enter a valid positive number for price.");
                    return;
                }

                int selectedClientId = ((KeyValuePair<int, string>)cbClients.SelectedItem).Key;
                DateTime selectedDate = dtpDate.Value;

                try
                {
                    var command = new Models.Commands();
                    command.AddCommand(selectedClientId, selectedDate, amount, conStr);
                        MessageBox.Show("Command added.");
                        popup.DialogResult = DialogResult.OK;
                        popup.Close();

                        //Refresh
                        command.ReadTableCommands(commandsGridView, conStr);    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            };

            //Cancer handler
            btnCancel.Click += (s, e) => popup.Close();

            popup.ShowDialog();
        }


    }
}
