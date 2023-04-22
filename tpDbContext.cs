using Microsoft.EntityFrameworkCore;
using TP2_POO2.Models;
namespace TP2_POO2
{
    public class TpDbContext : DbContext
    {
        public DbSet<Models.Doctor> Doctors { get; set; }
        public DbSet<Models.Patient> Patients { get; set; }
        public DbSet<Models.Prediction> Predictions { get; set; }
        public DbSet<Models.Performance> Performances { get; set; }
        public DbSet<Models.Historique>  Historiques { get; set; }         
      




        protected override void OnConfiguring(DbContextOptionsBuilder DbContextOptionsBuilder)
        {
            string connection_string = "Data Source=DESKTOP-4MISVQS\\SQLEXPRESS02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string database_TP = "databasePOO";
            DbContextOptionsBuilder.UseSqlServer($"{connection_string};Database={database_TP}; ");
        }

    }
}
