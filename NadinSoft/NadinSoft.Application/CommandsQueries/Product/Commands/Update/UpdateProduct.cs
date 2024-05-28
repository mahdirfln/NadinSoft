﻿using MediatR;
using NadinSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.CommandsQueries.Product.Commands.Update
{
    public class UpdateProduct : IRequest<Domain.Entities.Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ProduceDate { get; set; }

        public string ManufacturePhone { get; set; }

        public string ManufactureEmail { get; set; }

        public bool IsAvailable { get; set; }

        public int UserId { get; set; }

    }
}
