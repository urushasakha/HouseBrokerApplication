using HouseBroker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Application.Interfaces
{
    public interface IPropertyRepository
    {
        List<Property> GetAllPropertyList();

        Property GetPropertyById(int? id);

        //int AddProperty(Property property);
        int AddProperty(Property property);
        int UpdateProperty(Property property);
        int DeleteProperty(int id);

    }
}
