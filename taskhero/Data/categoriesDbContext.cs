using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using taskhero.Models.DTOs;
using taskhero.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace taskhero.Data { 

    // NuGet -> add package -> EntityFramework.SQLServer && EntityFramework.Tools

    // Tools -> Nuget -> PAckage manager console 
    // add-migration AddVillaTable 


    //Næste skridt -> denne kommand virker ikke
    // update-database

    // Retter i migrationen -> bare giv den nyt navn 
    //add - migration SeedvillasTableWithCreatedDate
    // update-database 


    // SQL table is now updated

    // f taskhero.Data.categoriesDbContex

    public class categoriesDbContext : DbContext
        {
            public categoriesDbContext(DbContextOptions<categoriesDbContext> options)
                : base(options)
            {
            }
            public DbSet<categories> category { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<categories>().HasData(
                    new categories
                    {
                        Id = 1, 
                        category = "undervisning",
                        imageURL = "https://firebasestorage.googleapis.com/v0/b/helpinghand00-c0649.appspot.com/o/services%2Fdefault_images%2Ftutering.jpg?alt=media&token=2fe9b124-d15b-4e26-95bd-6ca8b863d406",
                    },

                    new categories
                    {
                        Id = 2,
                        category = "undervisning",
                        imageURL = "https://firebasestorage.googleapis.com/v0/b/helpinghand00-c0649.appspot.com/o/services%2Fdefault_images%2Ftutering.jpg?alt=media&token=2fe9b124-d15b-4e26-95bd-6ca8b863d406",
                    }
                   );


            }

        }
    }

