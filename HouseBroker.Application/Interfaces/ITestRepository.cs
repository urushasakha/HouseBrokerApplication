using HouseBroker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Application.Interfaces
{
    public interface ITestRepository
    {
        List<TestTable> GetAll();
        TestTable GetById(int id);
        int Create(TestTable model);
    }
}
