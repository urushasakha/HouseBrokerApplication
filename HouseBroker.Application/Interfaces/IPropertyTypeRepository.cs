﻿using HouseBroker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Application.Interfaces
{
    public interface IPropertyTypeRepository
    {
        List<PropertyType> GetAllPropertyTypes();

    }
}
