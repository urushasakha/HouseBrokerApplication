using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Domain.Common
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public string? ApplicationUserId { get; set; }
    }
}
