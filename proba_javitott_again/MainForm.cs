using System;
using System.Windows.Forms;

namespace proba
{
    public class MainForm : Form
    {
        private Button buttonBack;
        private bool _isBarbi;
        public MainForm(bool isBarbi = true)
        {
            _isBarbi = isBarbi;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Mesačná inventúra";
            this.Size = new System.Drawing.Size(600, 400);

            buttonBack = new Button
            {
                Text = "Späť",
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
            var selectionForm = new SelectionForm(_isBarbi);
            selectionForm.ShowDialog();
            this.Close();
        }
    }
}

