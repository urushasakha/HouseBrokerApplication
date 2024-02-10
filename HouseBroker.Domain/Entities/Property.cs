using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Domain.Entities
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public int PropertyTypeId { get; set; }
        public int LocationId { get; set; }
        public float Price { get; set; }
        public string? Features { get; set; }
        public string? Image { get; set; }
    }
}
