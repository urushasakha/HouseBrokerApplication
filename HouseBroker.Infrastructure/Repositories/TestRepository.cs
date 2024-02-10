using HouseBroker.Application.Interfaces;
using HouseBroker.Domain.Entities;
using HouseBroker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Infrastructure.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDbContext _context;
        public TestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Create(TestTable model)
        {
            _context.TestTables.Add(model); 
            return _context.SaveChanges();
        }

        public List<TestTable> GetAll()
        {
           return _context.TestTables.ToList();
        }

        public TestTable GetById(int id)
        {
            var data = _context.TestTables.FirstOrDefault(x=>x.Id==id);
            if (data!=null)
            {
                return data;
            }
            return data;
        }
    }
}
