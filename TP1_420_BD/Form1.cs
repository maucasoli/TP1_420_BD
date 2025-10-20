using System.Data;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.RegularExpressions;
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

        private System.Windows.Forms.Timer searchTimer;

        // global variables needed to update/delete a client
        private int selectedClientId = -1;
        private string selectedName = "";
        private string selectedEmail = "";
        private string selectedPhone = "";

        // global variables needed to update/delete an order
        private int selectedCommandeId = -1;
        private DateTime dateCommand = DateTime.MinValue;
        private decimal amount = -1;
        private string reference = "";

        public Form1()
        {
            InitializeComponent();

            ConfigureDatabase();

            // delay for search function
            SearchDelay();
        }

        private void ConfigureDatabase()
        {
            Env.Load();
            server = Env.GetString("SERVER");
            database = Env.GetString("DATABASE");
            conStr = $"Server={server};Database={database};Trusted_Connection=True;TrustServerCertificate=True";
        }
        private void SearchDelay()
        {
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 500;
            searchTimer.Tick += SearchTimer_Tick;
        }


        // button clients on the home panel
        private void clientsButton_Click(object sender, EventArgs e)
        {
            home.Visible = false;
            clients.Visible = true;
            clients.BringToFront();

            ReadClients();
        }

        // read from table clients
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
                if (dgvClients.Columns["idClient"] != null)
                {
                    dgvClients.Columns["idClient"].Visible = false;
                }
                dgvClients.Columns["Name"].HeaderCell.Style.Font = new Font(dgvClients.Font, FontStyle.Bold);
                dgvClients.Columns["Email"].HeaderCell.Style.Font = new Font(dgvClients.Font, FontStyle.Bold);
                dgvClients.Columns["Phone"].HeaderCell.Style.Font = new Font(dgvClients.Font, FontStyle.Bold);
                dgvClients.ClearSelection();
            }
        }

        // create client button
        private void btn_add_client_Click(object sender, EventArgs e)
        {
            var client = GetNewClient();
            if (client != null)
            {
                InsertClient(client);
                ReadClients();
                MessageBox.Show("Client ajouté!");
            }
        }

        // update client button
        private void btn_modify_client_Click(object sender, EventArgs e)
        {
            if (selectedClientId == -1)
            {
                MessageBox.Show("Selectionner un client!");
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

        // delete client button
        private void btn_delete_client_Click(object sender, EventArgs e)
        {
            if (selectedClientId == -1)
            {
                MessageBox.Show("Selectionner un client!");
                return;
            }

            if (selectedClientId != null)
            {
                var confirmDelete = MessageBox.Show(
                  "Vous êtes sûr de vouloir supprimer le client?\n\n" +
                  selectedName + "\n" +
                  selectedEmail + "\n" +
                  selectedPhone + "\n",
                  "Confirmer la suppression",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning
              );

                if (confirmDelete == DialogResult.Yes)
                {
                    DeleteClient(selectedClientId);
                    ReadClients();

                    MessageBox.Show("Client supprimé !");

                    selectedClientId = -1;
                    selectedName = "";
                    selectedEmail = "";
                    selectedPhone = "";
                }
                else
                {
                    return;
                }
            }

        }

        private Client? GetNewClient()
        {

            Form dialog = new Form
            {
                Text = "Ajouter un Client",
                Size = new Size(360, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowIcon = false,
                BackColor = Color.White
            };

            Label lblTitle = new Label()
            {
                Text = "Entrez les informations du client",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 40
            };
            dialog.Controls.Add(lblTitle);

            Panel panel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 140,
                Padding = new Padding(20)
            };
            dialog.Controls.Add(panel);

            Label lblName = new Label() { Text = "Nom :", Top = 10, Left = 10, AutoSize = true };
            TextBox txtName = new TextBox() { Left = 110, Top = 8, Width = 200 };


            Label lblEmail = new Label() { Text = "Email :", Top = 55, Left = 10, AutoSize = true };
            TextBox txtEmail = new TextBox() { Left = 110, Top = 50, Width = 200 };

            Label lblPhone = new Label() { Text = "Téléphone :", Top = 100, Left = 10, AutoSize = true };
            TextBox txtPhone = new TextBox() { Left = 110, Top = 95, Width = 200 };

            panel.Controls.AddRange(new Control[] { lblName, txtName, lblEmail, txtEmail, lblPhone, txtPhone });

            Button btnOK = new Button()
            {
                Text = "Enregistrer",
                Left = 40,
                Top = 200,
                Width = 110,
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(40, 167, 69),
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnOK.FlatAppearance.BorderColor = Color.FromArgb(40, 167, 69);
            btnOK.FlatAppearance.BorderSize = 1;
            btnOK.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 255, 245);

            Button btnCancel = new Button()
            {
                Text = "Annuler",
                Left = 190,
                Top = 200,
                Width = 110,
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(220, 53, 69),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(220, 53, 69);
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 245, 245);

            dialog.Controls.Add(btnOK);
            dialog.Controls.Add(btnCancel);

            btnOK.Click += (s, e) =>
            {
                string name = txtName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phone = txtPhone.Text.Trim();

                Regex nameRegex = new Regex(@"^[A-Za-zÀ-ÿ\s'-]{2,}$");
                Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                Regex phoneRegex = new Regex(@"^[0-9\-\+\s]{7,15}$");

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Le nom du client est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }
                if (!nameRegex.IsMatch(name))
                {
                    MessageBox.Show("Le nom contient des caractères invalides.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("L'email est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                if (!emailRegex.IsMatch(email))
                {
                    MessageBox.Show("Format d'email invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(phone))
                {
                    MessageBox.Show("Le téléphone est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }
                if (!phoneRegex.IsMatch(phone))
                {
                    MessageBox.Show("Numéro de téléphone invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                dialog.Tag = new Client(name, email, phone);
                dialog.DialogResult = DialogResult.OK;
                dialog.Close();
            };

            dialog.AcceptButton = btnOK;
            dialog.CancelButton = btnCancel;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.Tag as Client;
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

        private void dgvCommandes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // 0 = header
            {
                DataGridViewRow row = dvgCommands.Rows[e.RowIndex];

                selectedCommandeId = Convert.ToInt32(row.Cells["IdCommande"].Value);
                selectedClientId = Convert.ToInt32(row.Cells["IdClient"].Value);
                dateCommand = Convert.ToDateTime(row.Cells["DateCommande"].Value);

                amount = Convert.ToDecimal(row.Cells["IdCommande"].Value);
                reference = Convert.ToString(row.Cells["IdCommande"].Value);


            }
        }

        private Client? RetrieveInfoClient(int id, string name, string email, string phone)
        {
            Form dialog = new Form
            {
                Text = "Modifier un Client",
                Size = new Size(360, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowIcon = false,
                BackColor = Color.White
            };

            Label lblTitle = new Label()
            {
                Text = "Modifier les informations du client",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 40
            };
            dialog.Controls.Add(lblTitle);

            Panel panel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 140,
                Padding = new Padding(20)
            };
            dialog.Controls.Add(panel);

            Label lblName = new Label() { Text = "Nom :", Top = 10, Left = 10, AutoSize = true };
            TextBox txtName = new TextBox() { Left = 110, Top = 8, Width = 200, Text = name };

            Label lblEmail = new Label() { Text = "Email :", Top = 55, Left = 10, AutoSize = true };
            TextBox txtEmail = new TextBox() { Left = 110, Top = 50, Width = 200, Text = email };

            Label lblPhone = new Label() { Text = "Téléphone :", Top = 100, Left = 10, AutoSize = true };
            TextBox txtPhone = new TextBox() { Left = 110, Top = 95, Width = 200, Text = phone };

            panel.Controls.AddRange(new Control[] { lblName, txtName, lblEmail, txtEmail, lblPhone, txtPhone });

            Button btnOK = new Button()
            {
                Text = "Modifier",
                Left = 40,
                Top = 200,
                Width = 110,
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(40, 167, 69),
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnOK.FlatAppearance.BorderColor = Color.FromArgb(40, 167, 69);
            btnOK.FlatAppearance.BorderSize = 1;
            btnOK.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 255, 245);

            Button btnCancel = new Button()
            {
                Text = "Annuler",
                Left = 190,
                Top = 200,
                Width = 110,
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(220, 53, 69),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(220, 53, 69);
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 245, 245);

            dialog.Controls.Add(btnOK);
            dialog.Controls.Add(btnCancel);

            btnOK.Click += (s, e) =>
            {
                string newName = txtName.Text.Trim();
                string newEmail = txtEmail.Text.Trim();
                string newPhone = txtPhone.Text.Trim();

                Regex nameRegex = new Regex(@"^[A-Za-zÀ-ÿ\s'-]{2,}$");
                Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                Regex phoneRegex = new Regex(@"^[0-9\-\+\s]{7,15}$");

                if (string.IsNullOrWhiteSpace(newName))
                {
                    MessageBox.Show("Le nom du client est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }
                if (!nameRegex.IsMatch(newName))
                {
                    MessageBox.Show("Le nom contient des caractères invalides.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(newEmail))
                {
                    MessageBox.Show("L'email est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                if (!emailRegex.IsMatch(newEmail))
                {
                    MessageBox.Show("Format d'email invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(newPhone))
                {
                    MessageBox.Show("Le téléphone est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }
                if (!phoneRegex.IsMatch(newPhone))
                {
                    MessageBox.Show("Numéro de téléphone invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                dialog.Tag = new Client(id, newName, newEmail, newPhone);
                dialog.DialogResult = DialogResult.OK;
                dialog.Close();
            };

            dialog.AcceptButton = btnOK;
            dialog.CancelButton = btnCancel;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.Tag as Client;
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

                MessageBox.Show("Client modifié!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void DeleteClient(int selectedClientId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    var updateSql = "DELETE FROM Clients WHERE idClient = @Id;";
                    SqlCommand updateCmd = new SqlCommand(updateSql, con);
                    updateCmd.Parameters.AddWithValue("@Id", selectedClientId);
                    var lines = updateCmd.ExecuteNonQuery();
                    ReadClients();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void rechercheClientsInput_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            SearchClient();
        }

        private void SearchClient()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    var select = @"SELECT idClient, name, email, phone FROM Clients 
                                WHERE email LIKE @Domain OR name LIKE @Domain OR phone LIKE @Domain;";
                    SqlCommand selectCmd = new SqlCommand(select, con);
                    selectCmd.Parameters.AddWithValue("@Domain", "%" + rechercheClientsInput.Text + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(selectCmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Clients");

                    dgvClients.ClearSelection();
                    dgvClients.DataSource = dataSet.Tables["Clients"];

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        private void commandesButton_Click(object sender, EventArgs e)
        {
            home.Visible = false;
            commandes.Visible = true;
            commandes.BringToFront();

            //Appel la classe Commandes
            var commandesView = new Commands();
            commandesView.ReadTableCommands(dvgCommands, conStr);
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
            if (selectedCommandeId == -1)
            {
                MessageBox.Show("Selectionner une commande!");
                return;
            }

            if (selectedCommandeId != null)
            {
                var confirmDelete = MessageBox.Show(
                  "Vous êtes sûr de vouloir supprimer la commande?\n\n",
                  "Confirmer la suppression",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning
              );

                if (confirmDelete == DialogResult.Yes)
                {



                    var command = new Commands();
                    command.DeleteCommand(selectedCommandeId, conStr);
                    command.ReadTableCommands(dvgCommands, conStr);


                    //ReadCommandes();

                    MessageBox.Show("Commande supprimé !");

                    selectedCommandeId = -1;
                }
                else
                {
                    return;
                }
            }

        }
        private void addCommandButton_Click(object sender, EventArgs e)
        {
            ShowAddCommandPopup();
        }

        private void ShowAddCommandPopup()
        {
            Form popup = new Form
            {
                Text = "Ajouter une Commande",
                Size = new Size(420, 320),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowIcon = false,
                BackColor = Color.White
            };

            Label lblTitle = new Label()
            {
                Text = "Entrez les informations de la commande",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 40
            };
            popup.Controls.Add(lblTitle);

            Panel panel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 170,
                Padding = new Padding(25)
            };
            popup.Controls.Add(panel);

            Label lblClient = new Label() { Text = "Client :", Left = 10, Top = 10, AutoSize = true };
            ComboBox cbClients = new ComboBox()
            {
                Left = 120,
                Top = 8,
                Width = 230,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            var clients = Models.Client.GetClients(conStr);
            foreach (var c in clients)
                cbClients.Items.Add(new KeyValuePair<int, string>(c.Key, $"{c.Key} - {c.Value}"));
            cbClients.DisplayMember = "Value";
            cbClients.ValueMember = "Key";

            Label lblDate = new Label() { Text = "Date :", Left = 10, Top = 60, AutoSize = true };
            DateTimePicker dtpDate = new DateTimePicker()
            {
                Left = 120,
                Top = 55,
                Width = 230,
                Format = DateTimePickerFormat.Short
            };

            Label lblAmount = new Label() { Text = "Montant :", Left = 10, Top = 110, AutoSize = true };
            TextBox txtAmount = new TextBox()
            {
                Left = 120,
                Top = 105,
                Width = 230
            };

            panel.Controls.AddRange(new Control[] { lblClient, cbClients, lblDate, dtpDate, lblAmount, txtAmount });

            Button btnSave = new Button()
            {
                Text = "Enregistrer",
                Left = 70,
                Top = 220,
                Width = 110,
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(40, 167, 69),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                DialogResult = DialogResult.OK
            };
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(40, 167, 69);
            btnSave.FlatAppearance.BorderSize = 1;
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 255, 245);

            Button btnCancel = new Button()
            {
                Text = "Annuler",
                Left = 220,
                Top = 220,
                Width = 110,
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(220, 53, 69),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(220, 53, 69);
            btnCancel.FlatAppearance.BorderSize = 2;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 245, 245);

            popup.Controls.Add(btnSave);
            popup.Controls.Add(btnCancel);

            popup.AcceptButton = btnSave;
            popup.CancelButton = btnCancel;

            btnSave.Click += (s, e) =>
            {
                if (cbClients.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner un client.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount < 0)
                {
                    MessageBox.Show("Veuillez entrer un montant valide (positif).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedClientId = ((KeyValuePair<int, string>)cbClients.SelectedItem).Key;
                DateTime selectedDate = dtpDate.Value;

                try
                {
                    var command = new Commands();
                    command.AddCommand(selectedClientId, selectedDate, amount, conStr);
                    MessageBox.Show("Commande ajoutée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    popup.DialogResult = DialogResult.OK;
                    popup.Close();

                    command.ReadTableCommands(dvgCommands, conStr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnCancel.Click += (s, e) => popup.Close();

            popup.ShowDialog();
        }


        private void modifyCommandButton_Click(object sender, EventArgs e)
        {
            if (selectedCommandeId == -1)
            {
                MessageBox.Show("Selectionner une commande!");
                return;
            }

            ShowModifyCommandPopup(selectedCommandeId, selectedClientId, dateCommand, amount, reference);
        }

        private void ShowModifyCommandPopup(int commandeId, int currentClientId, DateTime currentDate, decimal currentAmount, string reference)
        {
            Form dialog = new Form
            {
                Text = "Modifier une commande",
                Size = new Size(380, 330),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowIcon = false,
                BackColor = Color.White
            };

            Label lblTitle = new Label()
            {
                Text = "Modifier les informations de la commande",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 40
            };
            dialog.Controls.Add(lblTitle);

            Panel panel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 160,
                Padding = new Padding(20)
            };
            dialog.Controls.Add(panel);

            Label lblClient = new Label() { Text = "Client :", Top = 10, Left = 10, AutoSize = true };
            ComboBox cbClients = new ComboBox()
            {
                Left = 110,
                Top = 8,
                Width = 220,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            Label lblDate = new Label() { Text = "Date :", Top = 55, Left = 10, AutoSize = true };
            DateTimePicker dtpDate = new DateTimePicker()
            {
                Left = 110,
                Top = 50,
                Width = 220,
                Value = currentDate
            };

            Label lblAmount = new Label() { Text = "Montant :", Top = 100, Left = 10, AutoSize = true };
            TextBox txtAmount = new TextBox()
            {
                Left = 110,
                Top = 95,
                Width = 220,
                Text = currentAmount.ToString("F2")
            };

            var clients = Models.Client.GetClients(conStr);
            int indexToSelect = -1, i = 0;
            foreach (var c in clients)
            {
                var item = new KeyValuePair<int, string>(c.Key, $"{c.Key} - {c.Value}");
                cbClients.Items.Add(item);
                if (c.Key == currentClientId) indexToSelect = i;
                i++;
            }

            cbClients.DisplayMember = "Value";
            cbClients.ValueMember = "Key";
            if (indexToSelect >= 0) cbClients.SelectedIndex = indexToSelect;

            panel.Controls.AddRange(new Control[] { lblClient, cbClients, lblDate, dtpDate, lblAmount, txtAmount });

            Button btnOK = new Button()
            {
                Text = "Enregistrer",
                Left = 50,
                Top = 220,
                Width = 110,
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(40, 167, 69),
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnOK.FlatAppearance.BorderColor = Color.FromArgb(40, 167, 69);
            btnOK.FlatAppearance.BorderSize = 1;
            btnOK.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 255, 245);

            Button btnCancel = new Button()
            {
                Text = "Annuler",
                Left = 200,
                Top = 220,
                Width = 110,
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(220, 53, 69),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(220, 53, 69);
            btnCancel.FlatAppearance.BorderSize = 2;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 245, 245);

            dialog.Controls.Add(btnOK);
            dialog.Controls.Add(btnCancel);

            btnOK.Click += (s, e) =>
            {
                if (cbClients.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner un client.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbClients.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAmount.Text))
                {
                    MessageBox.Show("Le montant est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Focus();
                    return;
                }

                if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount < 0)
                {
                    MessageBox.Show("Entrez une valeur positive pour le montant.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Focus();
                    return;
                }

                int selectedClientId = ((KeyValuePair<int, string>)cbClients.SelectedItem).Key;
                DateTime selectedDate = dtpDate.Value;

                try
                {
                    var commandes = new Commands();
                    commandes.UpdateCommand(commandeId, selectedClientId, selectedDate, amount, reference, conStr);

                    MessageBox.Show("Commande modifiée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dialog.DialogResult = DialogResult.OK;
                    dialog.Close();

                    commandes.ReadTableCommands(dvgCommands, conStr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            dialog.AcceptButton = btnOK;
            dialog.CancelButton = btnCancel;

            dialog.ShowDialog();
        }


    }
}
