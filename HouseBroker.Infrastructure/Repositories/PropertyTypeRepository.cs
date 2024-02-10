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
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<PropertyType> GetAllPropertyTypes()
        {
            return _context.PropertyTypes.ToList();
        }

    }
}
