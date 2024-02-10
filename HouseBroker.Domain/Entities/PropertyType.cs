using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Domain.Entities
{
    public class PropertyType
    {
        [Key]
        public int Id { get; set; }
        public string PropertyTypeName { get; set; }
        public string PropertyTypeCode { get; set; }
    }
}
