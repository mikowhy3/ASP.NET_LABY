
using Microsoft.EntityFrameworkCore;
namespace LAB3_SIWON.Models
{
    public class AppDbContext:DbContext
    {

        public DbSet<ContactEntity>Contacts { get; set; }

        public DbSet<OrganizationEntity> Organizations { get; set; }


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

            modelBuilder.Entity<OrganizationEntity>()
                .ToTable("organizations")
                .HasData(
                    
                    new OrganizationEntity()
                    {
                        Id=101,
                        NIP="1234560",
                        Name="Wsei",
                        Regon="998282010229"
                    },
                    new OrganizationEntity()
                    {
                        Id = 102,
                        NIP = "1234555",
                        Name = "Firma",
                        Regon = "9982820100023"
                    }

                );

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(o => o.Address)
                .HasData(

                    new { OrganizationEntityId = 101, Street="św. Filipa 17", City="Kraków" },  
                    new { OrganizationEntityId = 102, Street = "Dworcowa 7", City = "Łódź" }

                );

            modelBuilder.Entity<ContactEntity>()
                .Property(c => c.OrganizationId)
                .HasDefaultValue(101);

            modelBuilder.Entity<ContactEntity>()
                .HasData(
                new ContactEntity
                {
                    Id=1,
                    First_Name="Adam",
                    Last_Name="Kowal",
                    Email="adam@wsei.edu.pl",
                    PhoneNumber="123456789",
                    BirthDate= new DateOnly(year:2000,month:10, day:23),
                    Created=DateTime.Now,
                    OrganizationId=101
                },
                 new ContactEntity
                 {
                     Id = 2,
                     First_Name = "Ada",
                     Last_Name = "Wal",
                     Email = "ada@wsei.edu.pl",
                     PhoneNumber = "123457789",
                     BirthDate = new DateOnly(year: 2001, month: 10, day: 23),
                     OrganizationId = 101
                 }


                );
        }
    }
}
