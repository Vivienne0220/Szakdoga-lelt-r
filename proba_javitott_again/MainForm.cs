using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace proba
{
    public class MainForm : Form
    {
        private Button buttonBack;
        private bool _isBarbi;
        private Panel summaryPanel;
        private PictureBox chartBox;

        public MainForm(bool isBarbi = true)
        {
            _isBarbi = isBarbi;
            InitializeComponent();
            LoadSummary();
        }

        private void InitializeComponent()
        {
            this.Text = "Mesačná inventúra";
            this.Size = new Size(600, 500);

            buttonBack = new Button
            {
                Text = "Späť",
                Left = 450,
                Top = 420,
                Width = 100,
            };
            buttonBack.Click += buttonBack_Click;
            this.Controls.Add(buttonBack);

            summaryPanel = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(540, 300),
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true
            };
            this.Controls.Add(summaryPanel);

            chartBox = new PictureBox
            {
                Location = new Point(20, 330),
                Size = new Size(400, 80),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(chartBox);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var selectionForm = new SelectionForm(_isBarbi);
            selectionForm.ShowDialog();
            this.Close();
        }

        private void LoadSummary()
        {
            var backupRoot = Path.Combine(Environment.GetEnvironmentVariable("SystemDrive") ?? "C:", "databaseBackups");
            if (!Directory.Exists(backupRoot)) return;

            var latestDirs = Directory.GetDirectories(backupRoot)
                                      .OrderByDescending(d => d)
                                      .Take(5);

            var productStats = new Dictionary<string, (string name, decimal price, int uzavZos, string category)>();
            var summaryPerBackup = new List<(string date, decimal totalRevenue)>();
            var typeTotals = new Dictionary<string, int>();

            foreach (var dir in latestDirs)
            {
                decimal totalRevenue = 0;
                var jsonFiles = Directory.GetFiles(dir, "*.json");
                foreach (var file in jsonFiles)
                {
                    var json = File.ReadAllText(file);
                    var products = JsonSerializer.Deserialize<List<JsonElement>>(json);

                    string typeName = Path.GetFileNameWithoutExtension(file);

                    foreach (var product in products)
                    {
                        if (product.ValueKind != JsonValueKind.Object)
                        {
                            Console.WriteLine("Nem objektum típusú JSON elem kihagyva.");
                            continue;
                        }

                        var name = product.TryGetProperty("product_name", out var nameProp) ? nameProp.GetString() : "Ismeretlen";
                        var uzavZos = ReadMongoInt(product, "uzavZos");
                        var price = ReadMongoDecimal(product, "price");
                        var category = product.TryGetProperty("kategoriacigi", out var cat) ? cat.GetString() : "Egyéb";

                        var revenue = price * uzavZos;
                        totalRevenue += revenue;

                        if (productStats.ContainsKey(name))
                        {
                            var data = productStats[name];
                            productStats[name] = (name, price, data.uzavZos + uzavZos, category);
                        }
                        else
                        {
                            productStats[name] = (name, price, uzavZos, category);
                        }

                        if (typeTotals.ContainsKey(typeName))
                            typeTotals[typeName] += uzavZos;
                        else
                            typeTotals[typeName] = uzavZos;
                    }
                }
                summaryPerBackup.Add((Path.GetFileName(dir), totalRevenue));
            }

            var topProducts = productStats.Values.OrderByDescending(p => p.uzavZos).Take(3).ToList();
            var max = summaryPerBackup.OrderByDescending(s => s.totalRevenue).FirstOrDefault();
            var min = summaryPerBackup.OrderBy(s => s.totalRevenue).FirstOrDefault();

            int y = 10;
            summaryPanel.Controls.Add(new Label { Text = "TOP 3 termék (eladott db):", Location = new Point(10, y), AutoSize = true });
            y += 20;
            foreach (var p in topProducts)
            {
                summaryPanel.Controls.Add(new Label { Text = $"{p.name}: {p.uzavZos} db", Location = new Point(20, y), AutoSize = true });
                y += 20;
            }

            y += 10;
            summaryPanel.Controls.Add(new Label { Text = $"Legnagyobb tržba: {max.date} - {max.totalRevenue:0.00}€", Location = new Point(10, y), AutoSize = true });
            y += 20;
            summaryPanel.Controls.Add(new Label { Text = $"Legkisebb tržba: {min.date} - {min.totalRevenue:0.00}€", Location = new Point(10, y), AutoSize = true });

            y += 30;
            summaryPanel.Controls.Add(new Label { Text = "Terméktípus eloszlás:", Location = new Point(10, y), AutoSize = true });
            y += 20;
            foreach (var cat in typeTotals)
            {
                summaryPanel.Controls.Add(new Label { Text = $"{cat.Key}: {cat.Value} db", Location = new Point(20, y), AutoSize = true });
                y += 20;
            }

            DrawPieChart(typeTotals);
        }

        private int ReadMongoInt(JsonElement elem, string prop)
        {
            if (elem.TryGetProperty(prop, out var value) &&
                value.TryGetProperty("$numberInt", out var intVal) &&
                int.TryParse(intVal.GetString(), out int result))
            {
                return result;
            }
            Console.WriteLine($"Hiányzó vagy hibás int mező: '{prop}'");
            return 0;
        }

        private decimal ReadMongoDecimal(JsonElement elem, string prop)
        {
            if (elem.TryGetProperty(prop, out var value) &&
                value.TryGetProperty("$numberDecimal", out var decVal) &&
                decimal.TryParse(decVal.GetString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }
            Console.WriteLine($"Hiányzó vagy hibás decimal mező: '{prop}'");
            return 0m;
        }

        private void DrawPieChart(Dictionary<string, int> data)
        {
            if (data.Count == 0) return;

            Bitmap bmp = new Bitmap(chartBox.Width, chartBox.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            int total = data.Values.Sum();
            float startAngle = 0f;
            Random rand = new Random();

            foreach (var entry in data)
            {
                float sweep = 360f * entry.Value / total;
                Color color = Color.FromArgb(rand.Next(100, 255), rand.Next(100, 255), rand.Next(100, 255));
                using (Brush brush = new SolidBrush(color))
                {
                    g.FillPie(brush, 10, 10, chartBox.Width - 20, chartBox.Height - 20, startAngle, sweep);
                }
                startAngle += sweep;
            }

            chartBox.Image = bmp;
        }
    }
}