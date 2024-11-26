using System;
using System.Windows.Forms;

namespace proba
{
    public class Jedlo : Form
    {
        private DataGridView datapivo;

        private DataGridView datapivoB;

        private Button buttonBack;
        private Button buttonAdd;

        private Button buttonBackB;
        private Button buttonNewB;
        private Button buttonUpdateB;
        private Button buttonDeleteB;

        private TextBox textboxnevB;
        private TextBox textboxpredB;
        private TextBox textboxprijB;
        private TextBox textboxuzvB;
        private TextBox textboxcenaB;

        private TextBox textboxKod;

        private bool _isBarbi;

        public Jedlo(bool isBarbi = true)
        {
            _isBarbi = isBarbi;

            if (isBarbi) { InitializeComponentB(); }

            else { InitializeComponent(); }
        }

        private void InitializeComponent()
        {
            this.Text = "Pivo";
            this.Size = new System.Drawing.Size(600, 400);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            datapivo = new DataGridView
            {
                Size = new System.Drawing.Size(560, 200),
                Location = new System.Drawing.Point(10, 20),
            };

            buttonBack = new Button
            {
                Text = "Vissza",
                Left = 450,
                Top = 330,
                Width = 100,
            };

            buttonAdd = new Button
            {
                Text = "+",
                Left = 230,
                Top = 230,
                Width = 80,
                Height = 30,
            };

            textboxKod = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 230),
                Text = "Produkt kód",
            };

            buttonBack.Click += buttonBack_Click;
            buttonAdd.Click += buttonAdd_Click;

            this.Controls.Add(buttonAdd);
            this.Controls.Add(buttonBack);
            this.Controls.Add(datapivo);
            this.Controls.Add(textboxKod);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Form1 = new Form1(_isBarbi);
            Form1.ShowDialog();
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponentB()
        {
            this.Text = "Pivo";
            this.Size = new System.Drawing.Size(600, 400);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            datapivoB = new DataGridView
            {
                Size = new System.Drawing.Size(560, 200),
                Location = new System.Drawing.Point(10, 20),
            };

            buttonBackB = new Button
            {
                Text = "Vissza",
                Left = 450,
                Top = 330,
                Width = 100,
            };

            textboxnevB = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 230),
                Text = "Produkt kód",
            };

            textboxpredB = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 250),
                Text = "Zostatok pred",
            };

            textboxprijB = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 270),
                Text = "Príjem",
            };

            textboxuzvB = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 290),
                Text = "Zostatok uzávierke",
            };

            textboxcenaB = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 310),
                Text = "Cena",
            };

            buttonNewB = new Button
            {
                Text = "Hozzáad",
                Left = 230,
                Top = 230,
                Width = 80,
                Height = 30,
            };

            buttonUpdateB = new Button
            {
                Text = "Update",
                Left = 230,
                Top = 260,
                Width = 80,
                Height = 30,
            };

            buttonDeleteB = new Button
            {
                Text = "Törlés",
                Left = 230,
                Top = 290,
                Width = 80,
                Height = 30,
            };

            buttonBackB.Click += buttonBackB_Click;
            buttonNewB.Click += buttonNewB_Click;
            buttonUpdateB.Click += buttonUpdateB_Click;
            buttonDeleteB.Click += buttonDeleteB_Click;

            this.Controls.Add(buttonBackB);
            this.Controls.Add(buttonNewB);
            this.Controls.Add(buttonUpdateB);
            this.Controls.Add(buttonDeleteB);
            this.Controls.Add(datapivoB);
            this.Controls.Add(textboxnevB);
            this.Controls.Add(textboxpredB);
            this.Controls.Add(textboxprijB);
            this.Controls.Add(textboxuzvB);
            this.Controls.Add(textboxcenaB);
        }

        private void buttonNewB_Click(object sender, EventArgs e)
        {

        }

        private void buttonUpdateB_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteB_Click(object sender, EventArgs e)
        {

        }

        private void buttonBackB_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Form1 = new Form1(_isBarbi);
            Form1.ShowDialog();
            this.Close();
        }

    }
}


