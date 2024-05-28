﻿namespace NadinSoft.Presentation.Api.Models.Product
{
    public class UpdateProductModel : BaseEntityModel
    {
        public string Name { get; set; }

        public DateTime ProduceDate { get; set; }

        public string ManufacturePhone { get; set; }

        public string ManufactureEmail { get; set; }

        public bool IsAvailable { get; set; }
    }
}
