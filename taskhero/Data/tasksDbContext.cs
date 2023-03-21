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

        public class tasksDbContext : DbContext
        {
            public tasksDbContext(DbContextOptions<tasksDbContext> options)
                : base(options)
            {
            }
            public DbSet<tasks> Task { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<tasks>().HasData(
                    new tasks
                    {
                        Id = 1,
                        PrioritizationID = 123, 
                        TaskOwnerName = "William",
                        category = "undervisning",
                        description = "5 semester Matematik studerende på UNI - underviser gerne alle niveauer herunder . tager 200 i timen",
                        imageURL = "https://firebasestorage.googleapis.com/v0/b/helpinghand00-c0649.appspot.com/o/services%2Fdefault_images%2Ftutering.jpg?alt=media&token=2fe9b124-d15b-4e26-95bd-6ca8b863d406",
                        location = "København",
                        ownerID = "k25Q4LoPo6SWlEcuesV9PRyeFDT2",
                        price = "200",
                        subject = "Matematisk undervisning udbydes",
                        taskType = "Service",
                        timeCreated = "1/21/2023"

                    },

                    new tasks
                    {
                        Id = 2,
                        PrioritizationID = 123,
                        TaskOwnerName = "Anna",
                        category = "undervisning",
                        description = "Underviser i klaver",
                        imageURL = " ",
                        location = "Odense",
                        ownerID = "k25Q4LoPo6SWlEcuesV9PRyeFDT2",
                        price = "200",
                        subject = "Dansk undervisning udbydes",
                        taskType = "Service",
                        timeCreated = "1/21/2023"

                    }
                    );


            }

        }
    }

