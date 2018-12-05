using PPR.DAL.Entities;

namespace PPR.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Department> Departments { get; }
        IRepository<Brigade> Brigades { get; }
        IRepository<Equipment> Equipments { get; }
        IRepository<LastRepair> LastRepairs { get; }
        IRepository<NextRepair> NextRepairs { get; }
        void Commit();
    }
}
