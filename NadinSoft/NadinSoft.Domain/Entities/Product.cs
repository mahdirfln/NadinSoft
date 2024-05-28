using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public DateTime ProduceDate { get; set; }

        public string ManufacturePhone { get; set; }

        public string ManufactureEmail { get; set; }

        public bool IsAvailable { get; set; }

    }
}
