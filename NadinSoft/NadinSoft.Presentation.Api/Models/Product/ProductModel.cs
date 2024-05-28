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
        public string Name { get; set; }

        public int UserId { get; set; }

        public string Price { get; set; }
    }
}
