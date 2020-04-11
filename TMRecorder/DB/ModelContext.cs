using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TMRecorder.DB
{
    public class ModelContext : DbContext
    {
        public ModelContext(string connectionString) : base("name=TMR")
        {
            this.Database.Connection.ConnectionString = connectionString;
        }

        public DbSet<Player> Players { get; set; }

        internal static ModelContext Create(AppSettings settings)
        {
            FileInfo fi = new FileInfo(Path.Combine(settings.DefaultDirectory, "TMR.mdf"));

            if (!fi.Exists)
            {
                // Copy the default TMR.mdf into the destination directory
                File.Copy(settings.DbPath, fi.FullName);
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" 
                + fi.FullName 
                + ";Integrated Security=True";

            return new ModelContext(connectionString);
        }
    }
}
