using HouseBroker.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Domain.Entities
{
    public class Location:BaseEntity
    {
        [Key]
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationCode { get; set; }
    }
}
