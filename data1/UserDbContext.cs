using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Product.product;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Product.data1
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator!=null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("not working");
            }
        }

        public DbSet<User> users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           modelBuilder.Entity<User>()
               .ToTable("User")
               .HasKey(u => u.UserId);

           modelBuilder.Entity<User>()
               .Property(u => u.Firstname)
               .IsRequired();

           modelBuilder.Entity<User>()
              .Property(u => u.Lastname)
              .IsRequired();

            modelBuilder.Entity<User>()
               .Property(u => u.Email);

            modelBuilder.Entity<User>()
               .Property(u => u.Phonenumber)
               .IsRequired();

           modelBuilder.Entity<User>()
              .Property(u => u.Address)
              .IsRequired();

           modelBuilder.Entity<User>()
              .Property(u => u.Gender)
              .IsRequired();


        }

    }

}



