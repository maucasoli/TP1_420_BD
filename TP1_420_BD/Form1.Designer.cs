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
            Home.SuspendLayout();
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
            title.Font = new Font("Montserrat", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            title.Location = new Point(424, 109);
            title.Name = "title";
            title.Size = new Size(354, 33);
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
            clientsButton.Font = new Font("Montserrat", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clientsButton.ForeColor = Color.DimGray;
            clientsButton.Location = new Point(523, 183);
            clientsButton.Name = "clientsButton";
            clientsButton.Size = new Size(160, 50);
            clientsButton.TabIndex = 0;
            clientsButton.Text = "Clients";
            clientsButton.UseVisualStyleBackColor = false;
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
            commandesButton.Font = new Font("Montserrat", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            commandesButton.ForeColor = Color.DarkGoldenrod;
            commandesButton.Location = new Point(523, 255);
            commandesButton.Name = "commandesButton";
            commandesButton.Size = new Size(160, 50);
            commandesButton.TabIndex = 1;
            commandesButton.Text = "Commandes";
            commandesButton.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Home);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Gestion Clients et Commandes";
            Home.ResumeLayout(false);
            Home.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel Home;
        private Button clientsButton;
        private Button commandesButton;
        private Label title;
    }
}
