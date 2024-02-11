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
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddProperty(Property property)
        {
            _context.Properties.Add(property);
            return _context.SaveChanges();
        }

        public int DeleteProperty(int id)
        {
            var data = _context.Properties.FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                _context.Properties.Remove(data);
                return _context.SaveChanges(); // Returns the number of affected rows
            }

            return 0;

        }

        public List<Property> GetAllPropertyList()
        {
            return _context.Properties.ToList();
        }

        public Property GetPropertyById(int? id)
        {
            var data = _context.Properties.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                return data;
            }
            else
            {
                return data;
            }
            
        }

        public int UpdateProperty(Property property)
        {
            if (property != null)
            {
                _context.Properties.Update(property);
               
            }
            return _context.SaveChanges();
        }
    }
}
