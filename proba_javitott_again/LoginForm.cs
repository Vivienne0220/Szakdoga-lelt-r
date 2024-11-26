using System;
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
        private Label lblError;

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

            else if (username == "Dolgozó" && password == "2222")
            {
                this.Hide();
                var selectionForm = new SelectionForm();
                selectionForm.ShowDialog();
                this.Close();
            }

            else
            {
                lblError.Text = "Helytelen felhasználónév vagy jelszó!";
            }
        }

        private void InitializeComponent()
        {
            this.Text = "Bejelentkezés";
            this.Size = new Size(300, 200);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            var lblUsername = new Label { Text = "Felhasználónév:", Left = 20, Top = 20, Width = 100 };
            txtUsername = new TextBox { Left = 130, Top = 20, Width = 120 };

            var lblPassword = new Label { Text = "Jelszó:", Left = 20, Top = 60, Width = 100 };
            txtPassword = new TextBox { Left = 130, Top = 60, Width = 120, PasswordChar = '*' };

            lblError = new Label { Text = "", Left = 20, Top = 100, Width = 230, ForeColor = System.Drawing.Color.Red };

            btnLogin = new Button { Text = "Bejelentkezés", Left = 80, Top = 130, Width = 100 };
            btnLogin.Click += BtnLogin_Click;

            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblError);
            this.Controls.Add(btnLogin);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}

