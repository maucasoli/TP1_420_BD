using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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

                MessageBox.Show("Client modifier!");
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
                MessageBox.Show("Choisir un client.");
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
