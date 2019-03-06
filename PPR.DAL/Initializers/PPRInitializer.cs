using PPR.DAL.EFContext;
using PPR.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PPR.DAL.Initializers
{
    public class PPRInitializer : DropCreateDatabaseIfModelChanges<PPRContext>
    {
        protected override void Seed(PPRContext context)
        {
            
            Department d1 = new Department { Code = 30, Name = "Прессовый", NumberOfBrigades = 3 };
            Department d2 = new Department { Code = 40, Name = "Автоматный", NumberOfBrigades = 4 };
            Department d3 = new Department { Code = 50, Name = "Сварочный", NumberOfBrigades = 3 };
            context.Departments.Add(d1);
            context.Departments.Add(d2);
            context.Departments.Add(d3);
            context.SaveChanges();
            Brigade b1 = new Brigade { Code = 101, NumberOfPeople = 5, BrigadeChiefName = "Степанов", Department =  d1};
            Brigade b2 = new Brigade { Code = 102, NumberOfPeople = 4, BrigadeChiefName = "Сидоров", Department = d1 };
            Brigade b3 = new Brigade { Code = 103, NumberOfPeople = 5, BrigadeChiefName = "Петров", Department = d1 };
            Brigade b4 = new Brigade { Code = 201, NumberOfPeople = 6, BrigadeChiefName = "Васильев", Department = d2 };
            Brigade b5 = new Brigade { Code = 202, NumberOfPeople = 3, BrigadeChiefName = "Харитонов", Department = d2 };
            Brigade b6 = new Brigade { Code = 203, NumberOfPeople = 6, BrigadeChiefName = "Смирнова", Department = d2 };
            Brigade b7 = new Brigade { Code = 204, NumberOfPeople = 4, BrigadeChiefName = "Липницкий", Department = d2 };
            Brigade b8 = new Brigade { Code = 301, NumberOfPeople = 3, BrigadeChiefName = "Власова", Department = d3 };
            Brigade b9 = new Brigade { Code = 302, NumberOfPeople = 4, BrigadeChiefName = "Жуков", Department = d3 };
            Brigade b10 = new Brigade { Code = 303, NumberOfPeople = 3, BrigadeChiefName = "Рудинский", Department = d3 };
            context.Brigades.AddRange(new List<Brigade>{b1, b2, b3, b4, b5, b6, b7, b8, b9, b10 });
            context.SaveChanges();
            Equipment e1 = new Equipment { InventoryNumber = "5d", Name = "супер станок2", Model = "rt", NumberOfEngines = 2, Power = 2, URC = 2.2f, Notes = "это супер станок", Department = d1 };
            Equipment e2 = new Equipment { InventoryNumber = "3i", Name = "молоты", Model = "t54d", NumberOfEngines = 2, Power = 20, URC = 1.3f, Notes = "это супер станок2", Department = d2 };
            Equipment e3 = new Equipment { InventoryNumber = "3b", Name = "гидравлический пресс", Model = "cb4", NumberOfEngines = 4, Power = 340, URC = 6.7f, Notes = "это супер станок3", Department = d3 };
            Equipment e4 = new Equipment { InventoryNumber = "3m", Name = "обжимной станок", Model = "98ty", NumberOfEngines = 2, Power = 120, URC = 3.3f, Notes = "это супер станок4", Department = d1 };
            Equipment e5 = new Equipment { InventoryNumber = "3o", Name = "чеканочный пресс", Model = "uyr5", NumberOfEngines = 2, Power = 70, URC = 2.1f, Notes = "это супер станок5", Department = d2 };
            Equipment e6 = new Equipment { InventoryNumber = "2h", Name = "лазерная резка", Model = "235y", NumberOfEngines = 7, Power = 1300, URC = 11.4f, Notes = "это супер станок6", Department = d3 };
            Equipment e7 = new Equipment { InventoryNumber = "2k", Name = "плазменный резак", Model = "ty56", NumberOfEngines = 5, Power = 500, URC = 9.1f, Notes = "это супер станок7", Department = d3 };
            Equipment e8 = new Equipment { InventoryNumber = "4x", Name = "гигаватная плита", Model = "xxx8", NumberOfEngines = 9, Power = 3000, URC = 20.0f, Notes = "это супер станок8", Department = d2 };
            Equipment e9 = new Equipment { InventoryNumber = "6t", Name = "сверлильный станок", Model = "hg45", NumberOfEngines = 1, Power = 50, URC = 3.6f, Notes = "это супер станок9", Department = d1 };
            Equipment e10 = new Equipment { InventoryNumber = "95", Name = "электро-точилка", Model = "pj86", NumberOfEngines = 2, Power = 20, URC = 1.4f, Notes = "это супер станок10", Department = d1 };
            context.Equipments.AddRange(new List<Equipment> {e1, e2, e3, e4, e5, e6, e7, e8, e9, e10 });
            context.SaveChanges();
            LastRepair lr1 = new LastRepair { RepairType = "о", Technician = "Петров", Date = new DateTime(2018, 02, 01).Date, Equipment = e1 };
            LastRepair lr2 = new LastRepair { RepairType = "м", Technician = "Липницкий", Date = new DateTime(2018, 02, 03).Date, Equipment = e2 };
            LastRepair lr3 = new LastRepair { RepairType = "с", Technician = "Рудинский", Date = new DateTime(2018, 02, 10).Date, Equipment = e3 };
            LastRepair lr4 = new LastRepair { RepairType = "к", Technician = "Смирнова", Date = new DateTime(2018, 02, 08).Date, Equipment = e4 };
            LastRepair lr5 = new LastRepair { RepairType = "о", Technician = "Жуков", Date = new DateTime(2018, 02, 06).Date, Equipment = e5 };
            LastRepair lr6 = new LastRepair { RepairType = "м", Technician = "Сидоров", Date = new DateTime(2018, 02, 14).Date, Equipment = e6 };
            LastRepair lr7 = new LastRepair { RepairType = "с", Technician = "Власова", Date = new DateTime(2018, 02, 13).Date, Equipment = e7 };
            LastRepair lr8 = new LastRepair { RepairType = "к", Technician = "Васильев", Date = new DateTime(2018, 02, 16).Date, Equipment = e8 };
            LastRepair lr9 = new LastRepair { RepairType = "о", Technician = "Степанов", Date = new DateTime(2018, 02, 20).Date, Equipment = e9 };
            LastRepair lr10 = new LastRepair { RepairType = "к", Technician = "Смирнова", Date = new DateTime(2018, 01, 02).Date, Equipment = e10 };
            context.LastRepairs.AddRange(new List<LastRepair> { lr1, lr2, lr3, lr4, lr5, lr6, lr7, lr8, lr9, lr10 });
            context.SaveChanges(); 
            NextRepair nr1 = new NextRepair { RepairType = "с", Technician = "Степанов", Date = new DateTime(2018, 03, 01).Date, Equipment = e1 };
            NextRepair nr2 = new NextRepair { RepairType = "о", Technician = "Васильев", Date = new DateTime(2018, 03, 03).Date, Equipment = e2 };
            NextRepair nr3 = new NextRepair { RepairType = "к", Technician = "Власова", Date = new DateTime(2018, 03, 10).Date, Equipment = e3 };
            NextRepair nr4 = new NextRepair { RepairType = "к", Technician = "Сидоров", Date = new DateTime(2018, 03, 08).Date, Equipment = e4 };
            NextRepair nr5 = new NextRepair { RepairType = "м", Technician = "Смирнова", Date = new DateTime(2018, 03, 06).Date, Equipment = e5 };
            NextRepair nr6 = new NextRepair { RepairType = "о", Technician = "Жуков", Date = new DateTime(2018, 03, 14).Date, Equipment = e6 };
            NextRepair nr7 = new NextRepair { RepairType = "о", Technician = "Рудинский", Date = new DateTime(2018, 03, 13).Date, Equipment = e7 };
            NextRepair nr8 = new NextRepair { RepairType = "с", Technician = "Липницкий", Date = new DateTime(2018, 03, 16).Date, Equipment = e8 };
            NextRepair nr9 = new NextRepair { RepairType = "м", Technician = "Петров", Date = new DateTime(2018, 03, 20).Date, Equipment = e9 };
            NextRepair nr10 = new NextRepair { RepairType = "о", Technician = "Степанов", Date = new DateTime(2018, 02, 04).Date, Equipment = e10 };
            context.NextRepairs.AddRange(new List<NextRepair> { nr1, nr2, nr3, nr4, nr5, nr6, nr7, nr8, nr9, nr10 });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
