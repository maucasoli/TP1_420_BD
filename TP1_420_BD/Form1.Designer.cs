namespace TP1_420_BD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Home = new Panel();
            title = new Label();
            clientsButton = new Button();
            commandesButton = new Button();
            Clients = new Panel();
            addClientButton = new Button();
            phoneLabel = new Label();
            phoneInput = new TextBox();
            emailLabel = new Label();
            emailInput = new TextBox();
            nameLabel = new Label();
            nameInput = new TextBox();
            addClient = new Label();
            modifyClientButton = new Button();
            DeleteClientButton = new Button();
            rechercheInput = new TextBox();
            chercheLabel = new Label();
            dgvClients = new DataGridView();
            clientsTitle = new Label();
            Home.SuspendLayout();
            Clients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // Home
            // 
            Home.BackgroundImage = Properties.Resources.bg_tp1;
            Home.Controls.Add(title);
            Home.Controls.Add(clientsButton);
            Home.Controls.Add(commandesButton);
            Home.Location = new Point(-1, -1);
            Home.Name = "Home";
            Home.Size = new Size(801, 453);
            Home.TabIndex = 0;
            // 
            // title
            // 
            title.AutoSize = true;
            title.BackColor = Color.Transparent;
            title.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            title.Location = new Point(424, 109);
            title.Name = "title";
            title.Size = new Size(336, 25);
            title.TabIndex = 2;
            title.Text = "Gestion Clients et Commandes";
            title.TextAlign = ContentAlignment.TopRight;
            // 
            // clientsButton
            // 
            clientsButton.BackColor = SystemColors.ButtonHighlight;
            clientsButton.Cursor = Cursors.Hand;
            clientsButton.FlatAppearance.BorderColor = Color.Silver;
            clientsButton.FlatAppearance.BorderSize = 2;
            clientsButton.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            clientsButton.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            clientsButton.FlatStyle = FlatStyle.Flat;
            clientsButton.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clientsButton.ForeColor = Color.DimGray;
            clientsButton.Location = new Point(523, 183);
            clientsButton.Name = "clientsButton";
            clientsButton.Size = new Size(160, 50);
            clientsButton.TabIndex = 0;
            clientsButton.Text = "Clients";
            clientsButton.UseVisualStyleBackColor = false;
            clientsButton.Click += clientsButton_Click;
            // 
            // commandesButton
            // 
            commandesButton.BackColor = SystemColors.ButtonHighlight;
            commandesButton.Cursor = Cursors.Hand;
            commandesButton.FlatAppearance.BorderColor = Color.BurlyWood;
            commandesButton.FlatAppearance.BorderSize = 2;
            commandesButton.FlatAppearance.MouseDownBackColor = Color.PapayaWhip;
            commandesButton.FlatAppearance.MouseOverBackColor = Color.OldLace;
            commandesButton.FlatStyle = FlatStyle.Flat;
            commandesButton.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            commandesButton.ForeColor = Color.DarkGoldenrod;
            commandesButton.Location = new Point(523, 255);
            commandesButton.Name = "commandesButton";
            commandesButton.Size = new Size(160, 50);
            commandesButton.TabIndex = 1;
            commandesButton.Text = "Commandes";
            commandesButton.UseVisualStyleBackColor = false;
            // 
            // Clients
            // 
            Clients.BackgroundImage = Properties.Resources.bg_tp1;
            Clients.Controls.Add(addClientButton);
            Clients.Controls.Add(phoneLabel);
            Clients.Controls.Add(phoneInput);
            Clients.Controls.Add(emailLabel);
            Clients.Controls.Add(emailInput);
            Clients.Controls.Add(nameLabel);
            Clients.Controls.Add(nameInput);
            Clients.Controls.Add(addClient);
            Clients.Controls.Add(modifyClientButton);
            Clients.Controls.Add(DeleteClientButton);
            Clients.Controls.Add(rechercheInput);
            Clients.Controls.Add(chercheLabel);
            Clients.Controls.Add(dgvClients);
            Clients.Controls.Add(clientsTitle);
            Clients.Location = new Point(0, -1);
            Clients.Name = "Clients";
            Clients.Size = new Size(801, 453);
            Clients.TabIndex = 2;
            Clients.Visible = false;
            // 
            // addClientButton
            // 
            addClientButton.BackColor = SystemColors.ButtonHighlight;
            addClientButton.Cursor = Cursors.Hand;
            addClientButton.FlatAppearance.BorderColor = Color.Green;
            addClientButton.FlatAppearance.BorderSize = 2;
            addClientButton.FlatAppearance.MouseDownBackColor = Color.Honeydew;
            addClientButton.FlatAppearance.MouseOverBackColor = Color.MintCream;
            addClientButton.FlatStyle = FlatStyle.Flat;
            addClientButton.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addClientButton.ForeColor = Color.Green;
            addClientButton.Location = new Point(522, 382);
            addClientButton.Name = "addClientButton";
            addClientButton.Size = new Size(237, 37);
            addClientButton.TabIndex = 15;
            addClientButton.Text = "Ajouter";
            addClientButton.UseVisualStyleBackColor = false;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.BackColor = Color.Transparent;
            phoneLabel.Font = new Font("Montserrat SemiBold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            phoneLabel.Location = new Point(519, 303);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(82, 20);
            phoneLabel.TabIndex = 14;
            phoneLabel.Text = "Téléphone:";
            // 
            // phoneInput
            // 
            phoneInput.Location = new Point(522, 326);
            phoneInput.Name = "phoneInput";
            phoneInput.Size = new Size(237, 23);
            phoneInput.TabIndex = 13;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.BackColor = Color.Transparent;
            emailLabel.Font = new Font("Montserrat SemiBold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailLabel.Location = new Point(519, 241);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(51, 20);
            emailLabel.TabIndex = 12;
            emailLabel.Text = "Email:";
            // 
            // emailInput
            // 
            emailInput.Location = new Point(522, 264);
            emailInput.Name = "emailInput";
            emailInput.Size = new Size(237, 23);
            emailInput.TabIndex = 11;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.BackColor = Color.Transparent;
            nameLabel.Font = new Font("Montserrat SemiBold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.Location = new Point(519, 179);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(45, 20);
            nameLabel.TabIndex = 10;
            nameLabel.Text = "Nom:";
            // 
            // nameInput
            // 
            nameInput.Location = new Point(522, 202);
            nameInput.Name = "nameInput";
            nameInput.Size = new Size(237, 23);
            nameInput.TabIndex = 9;
            // 
            // addClient
            // 
            addClient.AutoSize = true;
            addClient.BackColor = Color.Transparent;
            addClient.Font = new Font("Montserrat", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addClient.Location = new Point(520, 131);
            addClient.Name = "addClient";
            addClient.Size = new Size(158, 30);
            addClient.TabIndex = 8;
            addClient.Text = "Ajouter client: ";
            // 
            // modifyClientButton
            // 
            modifyClientButton.BackColor = SystemColors.ButtonHighlight;
            modifyClientButton.Cursor = Cursors.Hand;
            modifyClientButton.FlatAppearance.BorderColor = Color.BurlyWood;
            modifyClientButton.FlatAppearance.BorderSize = 2;
            modifyClientButton.FlatAppearance.MouseDownBackColor = Color.PapayaWhip;
            modifyClientButton.FlatAppearance.MouseOverBackColor = Color.OldLace;
            modifyClientButton.FlatStyle = FlatStyle.Flat;
            modifyClientButton.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            modifyClientButton.ForeColor = Color.DarkGoldenrod;
            modifyClientButton.Location = new Point(78, 382);
            modifyClientButton.Name = "modifyClientButton";
            modifyClientButton.Size = new Size(160, 37);
            modifyClientButton.TabIndex = 6;
            modifyClientButton.Text = "Modifier";
            modifyClientButton.UseVisualStyleBackColor = false;
            // 
            // DeleteClientButton
            // 
            DeleteClientButton.BackColor = SystemColors.ButtonHighlight;
            DeleteClientButton.Cursor = Cursors.Hand;
            DeleteClientButton.FlatAppearance.BorderColor = Color.Firebrick;
            DeleteClientButton.FlatAppearance.BorderSize = 2;
            DeleteClientButton.FlatAppearance.MouseDownBackColor = Color.MistyRose;
            DeleteClientButton.FlatAppearance.MouseOverBackColor = Color.Snow;
            DeleteClientButton.FlatStyle = FlatStyle.Flat;
            DeleteClientButton.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteClientButton.ForeColor = Color.Firebrick;
            DeleteClientButton.Location = new Point(266, 382);
            DeleteClientButton.Name = "DeleteClientButton";
            DeleteClientButton.Size = new Size(160, 37);
            DeleteClientButton.TabIndex = 7;
            DeleteClientButton.Text = "Supprimer";
            DeleteClientButton.UseVisualStyleBackColor = false;
            // 
            // rechercheInput
            // 
            rechercheInput.Location = new Point(133, 97);
            rechercheInput.Name = "rechercheInput";
            rechercheInput.Size = new Size(164, 23);
            rechercheInput.TabIndex = 5;
            // 
            // chercheLabel
            // 
            chercheLabel.AutoSize = true;
            chercheLabel.BackColor = Color.Transparent;
            chercheLabel.Font = new Font("Montserrat SemiBold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chercheLabel.ForeColor = Color.Black;
            chercheLabel.Location = new Point(34, 100);
            chercheLabel.Name = "chercheLabel";
            chercheLabel.Size = new Size(93, 20);
            chercheLabel.TabIndex = 4;
            chercheLabel.Text = "Recherche : ";
            // 
            // dgvClients
            // 
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.BackgroundColor = Color.White;
            dgvClients.BorderStyle = BorderStyle.None;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(38, 137);
            dgvClients.Name = "dgvClients";
            dgvClients.Size = new Size(432, 239);
            dgvClients.TabIndex = 3;
            // 
            // clientsTitle
            // 
            clientsTitle.AutoSize = true;
            clientsTitle.BackColor = Color.Transparent;
            clientsTitle.Font = new Font("Montserrat", 21.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clientsTitle.Location = new Point(322, 29);
            clientsTitle.Name = "clientsTitle";
            clientsTitle.Size = new Size(148, 45);
            clientsTitle.TabIndex = 2;
            clientsTitle.Text = "CLIENTS";
            clientsTitle.TextAlign = ContentAlignment.TopRight;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Clients);
            Controls.Add(Home);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Gestion Clients et Commandes";
            Home.ResumeLayout(false);
            Home.PerformLayout();
            Clients.ResumeLayout(false);
            Clients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel Home;
        private Button clientsButton;
        private Button commandesButton;
        private Label title;
        private Panel Clients;
        private DataGridView dgvClients;
        private Label clientsTitle;
        private Label chercheLabel;
        private TextBox rechercheInput;
        private Button modifyClientButton;
        private Button DeleteClientButton;
        private Label addClient;
        private Label nameLabel;
        private TextBox nameInput;
        private Button addClientButton;
        private Label phoneLabel;
        private TextBox phoneInput;
        private Label emailLabel;
        private TextBox emailInput;
    }
}
