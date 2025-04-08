using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections;

namespace proba
{
    public partial class Form1 : Form
    {
        private bool _isBarbi;

        public Form1(bool isBarbi = false)
        {
            _isBarbi = isBarbi;
            InitializeComponent();
            if (isBarbi) { button9.Enabled = true; }
            else { button9.Enabled = false; }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            var selectionForm = new SelectionForm(_isBarbi);
            selectionForm.ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Enabled == true)
            {
                this.Hide();
                var dailyForm = new DailyForm();
                dailyForm.ShowDialog();
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pivo = new Pivo(_isBarbi);
            pivo.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var nealko = new Nealko(_isBarbi);
            nealko.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var destilaty = new Destilaty(_isBarbi);
            destilaty.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            var jedlo = new Jedlo(_isBarbi);
            jedlo.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var cigaretta = new Cigaretta(_isBarbi);
            cigaretta.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var napoje = new Napoje(_isBarbi);
            napoje.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var ostatne = new Ostatne(_isBarbi);
            ostatne.ShowDialog();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            var vino = new Vino(_isBarbi);
            vino.ShowDialog();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var tablak = Program.termekAdatbazis.ListCollectionNames().ToList();
            foreach (var tabla in tablak)
            {
                var collection = Program.termekAdatbazis.GetCollection<BsonDocument>(tabla);

                var documents = collection.Find(new BsonDocument()).ToList();
                var json = JsonConvert.SerializeObject(documents, Formatting.Indented);

                string dateString = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

                string systemDrive = Environment.GetEnvironmentVariable("SystemDrive");

                string filePath = Path.Combine(systemDrive, "databaseBackups", dateString);

                string backupFilePath = Path.Combine(filePath, $"{tabla}.json");

                string directoryPath = Path.GetDirectoryName(backupFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (File.Exists(backupFilePath))
                {
                    File.Delete(backupFilePath);
                }

                File.WriteAllText(backupFilePath, json);

            }
        }
    }
}