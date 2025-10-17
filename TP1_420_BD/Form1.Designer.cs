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
            btn_delete_client = new Button();
            btn_modify_client = new Button();
            btn_add_client = new Button();
            dgvClients = new DataGridView();
            label1 = new Label();
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
            Clients.Controls.Add(btn_delete_client);
            Clients.Controls.Add(btn_modify_client);
            Clients.Controls.Add(btn_add_client);
            Clients.Controls.Add(dgvClients);
            Clients.Controls.Add(label1);
            Clients.Dock = DockStyle.Fill;
            Clients.Location = new Point(0, 0);
            Clients.Name = "Clients";
            Clients.Size = new Size(800, 450);
            Clients.TabIndex = 2;
            Clients.Visible = false;
            // 
            // btn_delete_client
            // 
            btn_delete_client.Location = new Point(41, 207);
            btn_delete_client.Name = "btn_delete_client";
            btn_delete_client.Size = new Size(75, 23);
            btn_delete_client.TabIndex = 6;
            btn_delete_client.Text = "Delete Client";
            btn_delete_client.UseVisualStyleBackColor = true;
            btn_delete_client.Click += btn_delete_client_Click;
            // 
            // btn_modify_client
            // 
            btn_modify_client.Location = new Point(41, 153);
            btn_modify_client.Name = "btn_modify_client";
            btn_modify_client.Size = new Size(75, 23);
            btn_modify_client.TabIndex = 5;
            btn_modify_client.Text = "Modify Client";
            btn_modify_client.UseVisualStyleBackColor = true;
            btn_modify_client.Click += btn_modify_client_Click;
            // 
            // btn_add_client
            // 
            btn_add_client.Location = new Point(41, 111);
            btn_add_client.Name = "btn_add_client";
            btn_add_client.Size = new Size(75, 23);
            btn_add_client.TabIndex = 4;
            btn_add_client.Text = "Add Client";
            btn_add_client.UseVisualStyleBackColor = true;
            btn_add_client.Click += btn_add_client_Click;
            // 
            // dgvClients
            // 
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(164, 101);
            dgvClients.Name = "dgvClients";
            dgvClients.Size = new Size(556, 272);
            dgvClients.TabIndex = 3;
            dgvClients.CellClick += dgvClients_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(241, 31);
            label1.Name = "label1";
            label1.Size = new Size(336, 25);
            label1.TabIndex = 2;
            label1.Text = "Gestion Clients et Commandes";
            label1.TextAlign = ContentAlignment.TopRight;
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
        private Label label1;
        private Button btn_add_client;
        private Button btn_delete_client;
        private Button btn_modify_client;
    }
}
