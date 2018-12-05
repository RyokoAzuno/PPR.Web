using PPR.DAL.EFContext;
using PPR.DAL.Entities;
using PPR.DAL.Interfaces;

namespace PPR.DAL.Repositories
{
    public class PPRUnitOfWork : IUnitOfWork
    {
        private PPRContext _context;
        private DepartmentRepository _departmentRepository;
        private BrigadeRepository _brigadeRepository;
        private EquipmentRepository _equipmentRepository;
        private LastRepairRepository _lastRepairRepository;
        private NextRepairRepository _nextRepairRepository;

        public PPRUnitOfWork(string connectinString)
        {
            _context = new PPRContext(connectinString);
        }

        public IRepository<Department> Departments
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new DepartmentRepository(_context);
                return _departmentRepository;
            }
        }

        public IRepository<Brigade> Brigades
        {
            get
            {
                if (_brigadeRepository == null)
                    _brigadeRepository = new BrigadeRepository(_context);
                return _brigadeRepository;
            }
        }

        public IRepository<Equipment> Equipments
        {
            get
            {
                if (_equipmentRepository == null)
                    _equipmentRepository = new EquipmentRepository(_context);
                return _equipmentRepository;
            }
        }

        public IRepository<LastRepair> LastRepairs
        {
            get
            {
                if (_lastRepairRepository == null)
                    _lastRepairRepository = new LastRepairRepository(_context);
                return _lastRepairRepository;
            }
        }

        public IRepository<NextRepair> NextRepairs
        {
            get
            {
                if (_nextRepairRepository == null)
                    _nextRepairRepository = new NextRepairRepository(_context);
                return _nextRepairRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
