using System;
using System.Text;
using System.Windows.Forms;

namespace proba
{
    public class DailyForm : Form
    {
        private Button buttonBack;
        private bool _isBarbi;
        private TextBox textBoxResults;

        public DailyForm(bool isBarbi = true)
        {
            _isBarbi = isBarbi;
            InitializeComponent();
            DisplayResults();
        }

        public void InitializeComponent()
        {
            this.Text = "Denná uzávierka!";
            this.Size = new System.Drawing.Size(600, 400);

            // TextBox létrehozása
            textBoxResults = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(250, 250),
                Font = new System.Drawing.Font("Consolas", 10),
                ReadOnly = true
            };

            // Vissza gomb
            buttonBack = new Button
            {
                Text = "Späť",
                Left = 450,
                Top = 330,
                Width = 100,
            };
            buttonBack.Click += buttonBack_Click;

            this.Controls.Add(textBoxResults);
            this.Controls.Add(buttonBack);
        }

        private void DisplayResults()
        {
            // Összegek kiszámítása
            decimal celkompivo = new Pivo().celkompivo;
            decimal celkomnealko = new Nealko().celkomnealko;
            decimal celkomcigaretta = new Cigaretta().celkomcigaretta;
            decimal celkomjedlo = new Jedlo().celkomjedlo;
            decimal celkomnapoje = new Napoje().celkomnapoje;
            decimal celkomostatne = new Ostatne().celkomostatne;
            decimal celkomdestilaty = new Destilaty().celkomdestilaty;
            decimal celkomvino = new Vino().celkomvino;

            decimal celkomvsetko = celkompivo + celkomnealko + celkomcigaretta +
                                 celkomjedlo + celkomnapoje + celkomostatne + celkomdestilaty;

            // Eredmények formázása és megjelenítése
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Denný prehľad");
            sb.AppendLine();
            sb.AppendLine($"Pivo:        {celkompivo.ToString("N2")} €");
            sb.AppendLine($"Nealko:      {celkomnealko.ToString("N2")} €");
            sb.AppendLine($"Cigarety:    {celkomcigaretta.ToString("N2")} €");
            sb.AppendLine($"Jedlo:       {celkomjedlo.ToString("N2")} €");
            sb.AppendLine($"Nápoje:      {celkomnapoje.ToString("N2")} €");
            sb.AppendLine($"Ostatné:     {celkomostatne.ToString("N2")} €");
            sb.AppendLine($"Destiláty:   {celkomdestilaty.ToString("N2")} €");
            sb.AppendLine($"Vino:        {celkomvino.ToString("N2")} €");
            sb.AppendLine("---------------------");
            sb.AppendLine($"CELKOM:      {celkomvsetko.ToString("N2")} €");

            textBoxResults.Text = sb.ToString();
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