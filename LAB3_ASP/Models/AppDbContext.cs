
using Microsoft.EntityFrameworkCore;
namespace LAB3_SIWON.Models
{
    public class AppDbContext:DbContext
    {

        public DbSet<ContactEntity>Contacts { get; set; }

        private string DbPath { get; set; }
            

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "contacts.db");
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: $"Data source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>()
                .HasData(
                new ContactEntity
                {
                    Id=1,
                    First_Name="Adam",
                    Last_Name="Kowal",
                    Email="adam@wsei.edu.pl",
                    PhoneNumber="123456789",
                    BirthDate= new DateOnly(year:2000,month:10, day:23)
                },
                 new ContactEntity
                 {
                     Id = 2,
                     First_Name = "Ada",
                     Last_Name = "Wal",
                     Email = "ada@wsei.edu.pl",
                     PhoneNumber = "123457789",
                     BirthDate = new DateOnly(year: 2001, month: 10, day: 23)
                 }


                );
        }
    }
}
