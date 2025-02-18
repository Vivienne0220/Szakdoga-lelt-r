﻿using System;
using System.Windows.Forms;

namespace proba
{
    public class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        internal string username;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblError;

        private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e); 
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "Barbi" && password == "1111")
            {
                this.Hide();
                var selectionForm = new SelectionForm(true);
                selectionForm.ShowDialog();
                this.Close();

            }

            else if (username == "Pracovník" && password == "2222")
            {
                this.Hide();
                var selectionForm = new SelectionForm();
                selectionForm.ShowDialog();
                this.Close();
            }

            else
            {
                lblError.Text = "Nesprávne meno alebo heslo!";
            }
        }

        private void InitializeComponent()
        {
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblError = new Label();
            btnLogin = new Button();
            SuspendLayout();

            // lblUsername
            lblUsername.Location = new Point(20, 20);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 23);
            lblUsername.Text = "Meno:";

            // txtUsername
            txtUsername.Location = new Point(140, 20);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(150, 27);
            txtUsername.KeyDown += TxtUsername_KeyDown;

            // lblPassword
            lblPassword.Location = new Point(20, 60);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 23);
            lblPassword.Text = "Heslo:";

            // txtPassword
            txtPassword.Location = new Point(140, 60);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(150, 27);
            txtPassword.PasswordChar = '*'; // Rejtett jelszó
            txtPassword.KeyDown += TxtPassword_KeyDown;

            // lblError
            lblError.Location = new Point(20, 100);
            lblError.Name = "lblError";
            lblError.Size = new Size(270, 23);
            lblError.ForeColor = Color.Red;

            // btnLogin
            btnLogin.Location = new Point((ClientSize.Width - btnLogin.Width) / 2, 140);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 30);
            btnLogin.Text = "Prihlásenie";
            btnLogin.Click += BtnLogin_Click;

            // LoginForm
            ClientSize = new Size(320, 200);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblError);
            Controls.Add(btnLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            Text = "Prihlásenie";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

