using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Domain.Entities
{
    public class PropertyViewModel
    {
        public int Id { get; set; }
        public int PropertyTypeId { get; set; }
        public int LocationId { get; set; }
        public float Price { get; set; }
        public string? Features { get; set; }
        public IFormFile Image { get; set; }
    }
}
