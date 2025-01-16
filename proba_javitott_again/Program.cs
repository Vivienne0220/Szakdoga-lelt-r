using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using MongoDB.Driver;

namespace proba
{
    static class Program
    {
        public static MongoClient client = new MongoClient("mongodb://localhost:27017");
        public static IMongoDatabase adatbazis = client.GetDatabase("termekek");
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm());
        }
    }
}



