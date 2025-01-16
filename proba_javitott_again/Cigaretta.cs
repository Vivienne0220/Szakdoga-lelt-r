using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Data;
using System.Windows.Forms;

namespace proba
{
    public class Cigaretta : Form
    {
        private IMongoCollection<Termekek> cigiTabla = Program.adatbazis.GetCollection<Termekek>("cigaretta");

        private DataGridView datacigi;
        private DataGridView datacigiB;

        private Button buttonBack;
        private Button buttonAdd;

        private TextBox textboxKod;
        private TextBox textboxnev;

        private Button buttonBackB;
        private Button buttonNewB;
        private Button buttonUpdateB;
        private Button buttonDeleteB;

        private TextBox textboxnevB;
        private TextBox textboxpredB;
        private TextBox textboxprijB;
        private TextBox textboxuzvB;
        private TextBox textboxcenaB;
        private TextBox textboxKodB;
        private TextBox textboxzosB;

        private bool _isBarbi;

        public Cigaretta(bool isBarbi = true)
        {
            _isBarbi = isBarbi;

            if (isBarbi) { InitializeComponentB(); }

            else { InitializeComponent(); }
        }

        private void InitializeComponent()
        {
            this.Text = "Cigaretta";
            this.Size = new System.Drawing.Size(600, 400);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            datacigi = new DataGridView
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

            textboxnev = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 250),
                Text = "Produkt meno",
            };

            buttonBack.Click += buttonBack_Click;
            buttonAdd.Click += buttonAdd_Click;

            this.Controls.Add(buttonAdd);
            this.Controls.Add(buttonBack);
            this.Controls.Add(datacigi);
            this.Controls.Add(textboxKod);
            this.Controls.Add(textboxnev);
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
            var termek = new Termekek
            {
                ProductCode = textboxKod.Text
            };
        }

        private void InitializeComponentB()
        {
            this.Text = "Cigaretta - Barbi";
            this.Size = new System.Drawing.Size(600, 450);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            datacigiB = new DataGridView
            {
                Size = new System.Drawing.Size(560, 200),
                Location = new System.Drawing.Point(10, 20),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };

            buttonBackB = new Button
            {
                Text = "Vissza",
                Left = 450,
                Top = 380,
                Width = 100,
            };

            textboxKodB = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 230),
                Text = "Produkt kód",
            };

            textboxnevB = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 255),
                Text = "Názov",
            };

            textboxpredB = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 280),
                Text = "Zostatok predošl",
            };

            textboxprijB = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 305),
                Text = "Prijem",
            };

            textboxzosB = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 330),
                Text = "Zostatok",
            };

            textboxuzvB = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 355),
                Text = "Uzávierka",
            };

            textboxcenaB = new TextBox
            {
                Size = new System.Drawing.Size(150, 20),
                Location = new System.Drawing.Point(10, 380),
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
            this.Controls.Add(datacigiB);
            this.Controls.Add(textboxnevB);
            this.Controls.Add(textboxpredB);
            this.Controls.Add(textboxprijB);
            this.Controls.Add(textboxuzvB);
            this.Controls.Add(textboxcenaB);
            this.Controls.Add(textboxKodB);
            this.Controls.Add(textboxzosB);

            refreshDataGrid();
        }

        private void buttonNewB_Click(object sender, EventArgs e)
        {
            var newTermek = new Termekek
            {
                ProductId = ObjectId.GenerateNewId().ToString(),
                ProductCode = textboxKodB.Text,
                ProductName = textboxnevB.Text,
                Price = decimal.Parse(textboxcenaB.Text)
            };

            cigiTabla.InsertOne(newTermek);
            refreshDataGrid();
        }

        private void buttonUpdateB_Click(object sender, EventArgs e)
        {
            var filterDefinition = Builders<Termekek>.Filter.Eq(a => a.ProductCode, textboxKodB.Text);
            var updateDefinition = Builders<Termekek>.Update
                .Set(a => a.ProductName, textboxnevB.Text)
                .Set(a => a.Price, decimal.Parse(textboxcenaB.Text));

            cigiTabla.UpdateOne(filterDefinition, updateDefinition);
            refreshDataGrid();
        }

        private void buttonDeleteB_Click(object sender, EventArgs e)
        {
            var filterDefinition =  Builders<Termekek>.Filter.Eq(a => a.ProductCode, textboxKodB.Text);
            cigiTabla.DeleteOne(filterDefinition);

            refreshDataGrid();

        }

        private void buttonBackB_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Form1 = new Form1(_isBarbi);
            Form1.ShowDialog();
            this.Close();
        }

        private void refreshDataGrid()
        {
            var filterDefinition = Builders<Termekek>.Filter.Empty;
            var term = cigiTabla.Find(filterDefinition).ToList();
            
            var dataTable = new DataTable();
            dataTable.Columns.Add("Product Kód");
            dataTable.Columns.Add("Product Mena");
            dataTable.Columns.Add("Cena");

            foreach (var termek in term)
            {
                var row = dataTable.NewRow();
                row["Product Kód"] = termek.ProductCode;
                row["Product Mena"] = termek.ProductName;
                row["Cena"] = termek.Price.ToString();

                dataTable.Rows.Add(row);
            }
            
            datacigiB.DataSource = dataTable;
        }

    }
}


