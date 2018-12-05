using PPR.DAL.Entities;
using PPR.DAL.Initializers;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace PPR.DAL.EFContext
{
    public class PPRContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Brigade> Brigades { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<LastRepair> LastRepairs { get; set; }
        public DbSet<NextRepair> NextRepairs { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<PPRContext, Configuration>());
        //    base.OnModelCreating(modelBuilder);
        //}
        static PPRContext()
        {
            Database.SetInitializer(new PPRInitializer());
        }

        public PPRContext(string connectionString) : base(connectionString)
        {
            //Database.SetInitializer(new PPRInitializer());
            //Database.Initialize(true);
        }
    }
    internal sealed class Configuration : DbMigrationsConfiguration<PPRContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PPRContext context)
        {
            //  This method will be called after migrating to the latest version.

            Department d1 = new Department { Code = 30, Name = "Прессовый", NumberOfBrigades = 3 };
            Department d2 = new Department { Code = 40, Name = "Автоматный", NumberOfBrigades = 4 };
            Department d3 = new Department { Code = 50, Name = "Сварочный", NumberOfBrigades = 3 };
            context.Departments.Add(d1);
            context.Departments.Add(d2);
            context.Departments.Add(d3);
            context.SaveChanges();
            Brigade b1 = new Brigade { Code = 101, NumberOfPeople = 5, BrigadeChiefName = "Степанов", Department = d1 };
            Brigade b2 = new Brigade { Code = 102, NumberOfPeople = 4, BrigadeChiefName = "Сидоров", Department = d1 };
            Brigade b3 = new Brigade { Code = 103, NumberOfPeople = 5, BrigadeChiefName = "Петров", Department = d1 };
            Brigade b4 = new Brigade { Code = 201, NumberOfPeople = 6, BrigadeChiefName = "Васильев", Department = d2 };
            Brigade b5 = new Brigade { Code = 202, NumberOfPeople = 3, BrigadeChiefName = "Харитонов", Department = d2 };
            Brigade b6 = new Brigade { Code = 203, NumberOfPeople = 6, BrigadeChiefName = "Смирнова", Department = d2 };
            Brigade b7 = new Brigade { Code = 204, NumberOfPeople = 4, BrigadeChiefName = "Липницкий", Department = d2 };
            Brigade b8 = new Brigade { Code = 301, NumberOfPeople = 3, BrigadeChiefName = "Власова", Department = d3 };
            Brigade b9 = new Brigade { Code = 302, NumberOfPeople = 4, BrigadeChiefName = "Жуков", Department = d3 };
            Brigade b10 = new Brigade { Code = 303, NumberOfPeople = 3, BrigadeChiefName = "Рудинский", Department = d3 };
            context.Brigades.AddRange(new List<Brigade> { b1, b2, b3, b4, b5, b6, b7, b8, b9, b10 });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
