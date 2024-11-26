using System;
using System.Windows.Forms;

namespace proba
{
    public class DailyForm: Form
    {
        private Button buttonBack;
        private bool _isBarbi;
        public DailyForm(bool isBarbi = true)
        {
            _isBarbi = isBarbi;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Denná uzávierka!";
            this.Size = new System.Drawing.Size(600, 400);

            buttonBack = new Button
            {
                Text = "Vissza",
                Left = 450,
                Top = 330,
                Width = 100,
            };

            buttonBack.Click += buttonBack_Click;
            this.Controls.Add(buttonBack);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Form1 = new Form1(_isBarbi);
            Form1.ShowDialog();
            this.Close();
        }
    }
}

