using NadinSoft.Presentation.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Presentation.Api.Models.Product
{
    public class ProductModel : BaseEntityModel
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public DateTime ProduceDate { get; set; }

        public string ManufacturePhone { get; set; }

        public string ManufactureEmail { get; set; }

        public bool IsAvailable { get; set; }
    }
}
