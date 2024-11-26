using System;
using System.Drawing.Text;
using System.Windows.Forms;

namespace proba
{
    public class SelectionForm : Form
    {
        private Button buttonDaily;
        private Button buttonMonthly;
        private Button buttonBack;
        private bool _isBarbi;

        public SelectionForm(bool isBarbi = false)
        {
            _isBarbi = isBarbi;

            InitializeComponent();
            if (isBarbi) { buttonMonthly.Enabled = true; }
            else { buttonMonthly.Enabled = false; }
        }

        private void InitializeComponent()
        {

            this.Text = "Választás";
            this.Size = new System.Drawing.Size(300, 200);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            buttonDaily = new Button
            {
                Text = "Denná inventúra",
                Left = 50,
                Top = 50,
                Width = 100
            };

            buttonDaily.Click += buttonDaily_Click;

            buttonMonthly = new Button
            {
                Text = "Mesačná Inventúra",
                Left = 150,
                Top = 50,
                Width = 100
            };

            buttonMonthly.Click += buttonMonthly_Click;

            buttonBack = new Button
            {
                Text = "Vissza",
                Left = 180,
                Top = 130,
                Width = 100,
            };

            buttonBack.Click += buttonBack_Click;

            this.Controls.Add(buttonDaily);
            this.Controls.Add(buttonMonthly);
            this.Controls.Add(buttonBack);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        
        private void buttonMonthly_Click(object sender, EventArgs e)
        {
            if(buttonMonthly.Enabled == true) 
            {
                this.Hide();
                var mainForm = new MainForm();
                mainForm.ShowDialog();
                this.Close();
            }
            
        }

    
        private void buttonDaily_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Form1 = new Form1(_isBarbi);
            Form1.ShowDialog(); 
            this.Close();
        }
    }
}


