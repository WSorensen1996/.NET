using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using taskhero.Models.DTOs;
using taskhero.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace taskhero.Data
{


    // NuGet -> add package -> EntityFramework.SQLServer && EntityFramework.Tools

    // Tools -> Nuget -> PAckage manager console 
    // add-migration AddVillaTable 


    //Næste skridt -> denne kommand virker ikke
    // update-database


    // Retter i migrationen -> bare giv den nyt navn 
    //add - migration SeedvillasTableWithCreatedDate
    // update-database 


    // SQL table is now updated

        public class userinformationDbContext : DbContext
        {
            public userinformationDbContext(DbContextOptions<userinformationDbContext> options)
                : base(options)
            {
            }
            public DbSet<userInformation> userinformationList { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<userInformation>().HasData(
                    new userInformation
                    {
                        Id = 1,
                        birthday = "27/06/1996", 
                        catchprase = "Jeg hjælper folk",
                        description = "Jeg løser dine IT-problemer",
                        firstname = "William",
                        lastname = "Test",
                        imageURL = "TESTURL",
                        TermsAndConditionsAccepted = true,


                    },

                    new userInformation
                    {
                        Id = 2,
                        birthday = "27/06/1993",
                        catchprase = "Udannet frisøt - klipper folk billigt",
                        description = "Jeg klipper hår",
                        firstname = "Søren",
                        lastname = "Test",
                        imageURL = "TESTURL2",
                        TermsAndConditionsAccepted = true,

                    }
                    );


            }

        }
    }
