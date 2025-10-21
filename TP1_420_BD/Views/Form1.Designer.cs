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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            home = new Panel();
            title = new Label();
            clientsButton = new Button();
            commandesButton = new Button();
            commandes = new Panel();
            commandesReturnButton = new Button();
            addCommandButton = new Button();
            modifyCommandButton = new Button();
            deleteCommandButton = new Button();
            rechercheCommandesInput = new TextBox();
            rechercheCommandesLabel = new Label();
            dgvCommands = new DataGridView();
            commandesTitle = new Label();
            clients = new Panel();
            clientsReturnButton = new Button();
            addClientButton = new Button();
            modifyClientButton = new Button();
            deleteClientButton = new Button();
            rechercheClientsInput = new TextBox();
            rechercheClientsLabel = new Label();
            dgvClients = new DataGridView();
            clientsTitle = new Label();
            home.SuspendLayout();
            commandes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCommands).BeginInit();
            clients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // home
            // 
            home.BackgroundImage = Properties.Resources.bg_tp1;
            home.Controls.Add(title);
            home.Controls.Add(clientsButton);
            home.Controls.Add(commandesButton);
            home.Location = new Point(0, 0);
            home.Name = "home";
            home.Size = new Size(801, 453);
            home.TabIndex = 0;
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
            commandesButton.Click += commandesButton_Click;
            // 
            // commandes
            // 
            commandes.BackgroundImage = Properties.Resources.bg_tp1;
            commandes.Controls.Add(commandesReturnButton);
            commandes.Controls.Add(addCommandButton);
            commandes.Controls.Add(modifyCommandButton);
            commandes.Controls.Add(deleteCommandButton);
            commandes.Controls.Add(rechercheCommandesInput);
            commandes.Controls.Add(rechercheCommandesLabel);
            commandes.Controls.Add(dgvCommands);
            commandes.Controls.Add(commandesTitle);
            commandes.Dock = DockStyle.Fill;
            commandes.Location = new Point(0, 0);
            commandes.Name = "commandes";
            commandes.Size = new Size(800, 450);
            commandes.TabIndex = 3;
            commandes.Visible = false;
            // 
            // commandesReturnButton
            // 
            commandesReturnButton.Location = new Point(38, 34);
            commandesReturnButton.Name = "commandesReturnButton";
            commandesReturnButton.Size = new Size(75, 23);
            commandesReturnButton.TabIndex = 17;
            commandesReturnButton.Text = "< Retouner";
            commandesReturnButton.UseVisualStyleBackColor = true;
            commandesReturnButton.Click += commandesReturnButton_Click;
            // 
            // addCommandButton
            // 
            addCommandButton.BackColor = SystemColors.ButtonHighlight;
            addCommandButton.Cursor = Cursors.Hand;
            addCommandButton.FlatAppearance.BorderColor = Color.Green;
            addCommandButton.FlatAppearance.BorderSize = 2;
            addCommandButton.FlatAppearance.MouseDownBackColor = Color.Honeydew;
            addCommandButton.FlatAppearance.MouseOverBackColor = Color.MintCream;
            addCommandButton.FlatStyle = FlatStyle.Flat;
            addCommandButton.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addCommandButton.ForeColor = Color.Green;
            addCommandButton.Location = new Point(38, 184);
            addCommandButton.Name = "addCommandButton";
            addCommandButton.Size = new Size(186, 37);
            addCommandButton.TabIndex = 15;
            addCommandButton.Text = "Ajouter";
            addCommandButton.UseVisualStyleBackColor = false;
            addCommandButton.Click += addCommandButton_Click;
            // 
            // modifyCommandButton
            // 
            modifyCommandButton.BackColor = SystemColors.ButtonHighlight;
            modifyCommandButton.Cursor = Cursors.Hand;
            modifyCommandButton.FlatAppearance.BorderColor = Color.BurlyWood;
            modifyCommandButton.FlatAppearance.BorderSize = 2;
            modifyCommandButton.FlatAppearance.MouseDownBackColor = Color.PapayaWhip;
            modifyCommandButton.FlatAppearance.MouseOverBackColor = Color.OldLace;
            modifyCommandButton.FlatStyle = FlatStyle.Flat;
            modifyCommandButton.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            modifyCommandButton.ForeColor = Color.DarkGoldenrod;
            modifyCommandButton.Location = new Point(38, 249);
            modifyCommandButton.Name = "modifyCommandButton";
            modifyCommandButton.Size = new Size(186, 37);
            modifyCommandButton.TabIndex = 6;
            modifyCommandButton.Text = "Modifier";
            modifyCommandButton.UseVisualStyleBackColor = false;
            modifyCommandButton.Click += modifyCommandButton_Click;
            // 
            // deleteCommandButton
            // 
            deleteCommandButton.BackColor = SystemColors.ButtonHighlight;
            deleteCommandButton.Cursor = Cursors.Hand;
            deleteCommandButton.FlatAppearance.BorderColor = Color.Firebrick;
            deleteCommandButton.FlatAppearance.BorderSize = 2;
            deleteCommandButton.FlatAppearance.MouseDownBackColor = Color.MistyRose;
            deleteCommandButton.FlatAppearance.MouseOverBackColor = Color.Snow;
            deleteCommandButton.FlatStyle = FlatStyle.Flat;
            deleteCommandButton.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteCommandButton.ForeColor = Color.Firebrick;
            deleteCommandButton.Location = new Point(38, 315);
            deleteCommandButton.Name = "deleteCommandButton";
            deleteCommandButton.Size = new Size(186, 37);
            deleteCommandButton.TabIndex = 7;
            deleteCommandButton.Text = "Supprimer";
            deleteCommandButton.UseVisualStyleBackColor = false;
            deleteCommandButton.Click += deleteCommandButton_Click;
            // 
            // rechercheCommandesInput
            // 
            rechercheCommandesInput.Location = new Point(595, 96);
            rechercheCommandesInput.Name = "rechercheCommandesInput";
            rechercheCommandesInput.Size = new Size(164, 23);
            rechercheCommandesInput.TabIndex = 5;
            // 
            // rechercheCommandesLabel
            // 
            rechercheCommandesLabel.AutoSize = true;
            rechercheCommandesLabel.BackColor = Color.Transparent;
            rechercheCommandesLabel.Font = new Font("Microsoft Sans Serif", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rechercheCommandesLabel.ForeColor = Color.Black;
            rechercheCommandesLabel.Location = new Point(496, 99);
            rechercheCommandesLabel.Name = "rechercheCommandesLabel";
            rechercheCommandesLabel.Size = new Size(94, 16);
            rechercheCommandesLabel.TabIndex = 4;
            rechercheCommandesLabel.Text = "Recherche : ";
            // 
            // dgvCommands
            // 
            dgvCommands.AllowUserToAddRows = false;
            dgvCommands.AllowUserToDeleteRows = false;
            dgvCommands.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCommands.BackgroundColor = Color.White;
            dgvCommands.BorderStyle = BorderStyle.None;
            dgvCommands.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCommands.Location = new Point(266, 152);
            dgvCommands.Name = "dgvCommands";
            dgvCommands.ReadOnly = true;
            dgvCommands.Size = new Size(493, 239);
            dgvCommands.TabIndex = 3;
            dgvCommands.CellClick += dgvCommandes_CellClick;
            // 
            // commandesTitle
            // 
            commandesTitle.AutoSize = true;
            commandesTitle.BackColor = Color.Transparent;
            commandesTitle.Font = new Font("Microsoft Sans Serif", 21.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            commandesTitle.Location = new Point(288, 28);
            commandesTitle.Name = "commandesTitle";
            commandesTitle.Size = new Size(215, 33);
            commandesTitle.TabIndex = 2;
            commandesTitle.Text = "COMMANDES";
            commandesTitle.TextAlign = ContentAlignment.TopRight;
            // 
            // clients
            // 
            clients.BackgroundImage = Properties.Resources.bg_tp1;
            clients.Controls.Add(clientsReturnButton);
            clients.Controls.Add(addClientButton);
            clients.Controls.Add(modifyClientButton);
            clients.Controls.Add(deleteClientButton);
            clients.Controls.Add(rechercheClientsInput);
            clients.Controls.Add(rechercheClientsLabel);
            clients.Controls.Add(dgvClients);
            clients.Controls.Add(clientsTitle);
            clients.Dock = DockStyle.Fill;
            clients.Location = new Point(0, 0);
            clients.Name = "clients";
            clients.Size = new Size(800, 450);
            clients.TabIndex = 4;
            clients.Visible = false;
            // 
            // clientsReturnButton
            // 
            clientsReturnButton.Location = new Point(38, 34);
            clientsReturnButton.Name = "clientsReturnButton";
            clientsReturnButton.Size = new Size(75, 23);
            clientsReturnButton.TabIndex = 16;
            clientsReturnButton.Text = "< Retouner";
            clientsReturnButton.UseVisualStyleBackColor = true;
            clientsReturnButton.Click += clientsReturnButton_Click;
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
            addClientButton.Location = new Point(38, 184);
            addClientButton.Name = "addClientButton";
            addClientButton.Size = new Size(186, 37);
            addClientButton.TabIndex = 15;
            addClientButton.Text = "Ajouter";
            addClientButton.UseVisualStyleBackColor = false;
            addClientButton.Click += btn_add_client_Click;
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
            modifyClientButton.Location = new Point(38, 249);
            modifyClientButton.Name = "modifyClientButton";
            modifyClientButton.Size = new Size(186, 37);
            modifyClientButton.TabIndex = 6;
            modifyClientButton.Text = "Modifier";
            modifyClientButton.UseVisualStyleBackColor = false;
            modifyClientButton.Click += btn_modify_client_Click;
            // 
            // deleteClientButton
            // 
            deleteClientButton.BackColor = SystemColors.ButtonHighlight;
            deleteClientButton.Cursor = Cursors.Hand;
            deleteClientButton.FlatAppearance.BorderColor = Color.Firebrick;
            deleteClientButton.FlatAppearance.BorderSize = 2;
            deleteClientButton.FlatAppearance.MouseDownBackColor = Color.MistyRose;
            deleteClientButton.FlatAppearance.MouseOverBackColor = Color.Snow;
            deleteClientButton.FlatStyle = FlatStyle.Flat;
            deleteClientButton.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteClientButton.ForeColor = Color.Firebrick;
            deleteClientButton.Location = new Point(38, 315);
            deleteClientButton.Name = "deleteClientButton";
            deleteClientButton.Size = new Size(186, 37);
            deleteClientButton.TabIndex = 7;
            deleteClientButton.Text = "Supprimer";
            deleteClientButton.UseVisualStyleBackColor = false;
            deleteClientButton.Click += btn_delete_client_Click;
            // 
            // rechercheClientsInput
            // 
            rechercheClientsInput.Location = new Point(595, 96);
            rechercheClientsInput.Name = "rechercheClientsInput";
            rechercheClientsInput.Size = new Size(164, 23);
            rechercheClientsInput.TabIndex = 5;
            rechercheClientsInput.TextChanged += rechercheClientsInput_TextChanged;
            // 
            // rechercheClientsLabel
            // 
            rechercheClientsLabel.AutoSize = true;
            rechercheClientsLabel.BackColor = Color.Transparent;
            rechercheClientsLabel.Font = new Font("Microsoft Sans Serif", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rechercheClientsLabel.ForeColor = Color.Black;
            rechercheClientsLabel.Location = new Point(496, 99);
            rechercheClientsLabel.Name = "rechercheClientsLabel";
            rechercheClientsLabel.Size = new Size(94, 16);
            rechercheClientsLabel.TabIndex = 4;
            rechercheClientsLabel.Text = "Recherche : ";
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.BackgroundColor = Color.White;
            dgvClients.BorderStyle = BorderStyle.None;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(266, 152);
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvClients.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvClients.Size = new Size(493, 239);
            dgvClients.TabIndex = 3;
            dgvClients.CellClick += dgvClients_CellClick;
            // 
            // clientsTitle
            // 
            clientsTitle.AutoSize = true;
            clientsTitle.BackColor = Color.Transparent;
            clientsTitle.Font = new Font("Microsoft Sans Serif", 21.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clientsTitle.Location = new Point(329, 28);
            clientsTitle.Name = "clientsTitle";
            clientsTitle.Size = new Size(144, 33);
            clientsTitle.TabIndex = 2;
            clientsTitle.Text = "CLIENTS";
            clientsTitle.TextAlign = ContentAlignment.TopRight;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(commandes);
            Controls.Add(clients);
            Controls.Add(home);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion Clients et Commandes";
            home.ResumeLayout(false);
            home.PerformLayout();
            commandes.ResumeLayout(false);
            commandes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCommands).EndInit();
            clients.ResumeLayout(false);
            clients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel home;
        private Button clientsButton;
        private Button commandesButton;
        private Label title;
        private Panel commandes;
        private Button addCommandButton;
        private Button modifyCommandButton;
        private Button deleteCommandButton;
        private TextBox rechercheCommandesInput;
        private Label rechercheCommandesLabel;
        private DataGridView dgvCommands;
        private Label commandesTitle;
        private Panel clients;
        private Button addClientButton;
        private Button modifyClientButton;
        private Button deleteClientButton;
        private TextBox rechercheClientsInput;
        private Label rechercheClientsLabel;
        private Label clientsTitle;
        private Button commandesReturnButton;
        private Button clientsReturnButton;
        private DataGridView dgvClients;
    }
}
