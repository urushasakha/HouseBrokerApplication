﻿using HouseBroker.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Domain.Entities
{
    public class TestTable: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
