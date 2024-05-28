using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NadinSoft.Application.CommandsQueries.Product.Commands.Create;
using NadinSoft.Application.CommandsQueries.Product.Commands.Delete;
using NadinSoft.Application.CommandsQueries.Product.Commands.Update;
using NadinSoft.Application.CommandsQueries.Product.Queries;
using NadinSoft.Domain.Entities;
using NadinSoft.Presentation.Api.Helpers;
using NadinSoft.Presentation.Api.Models.Product;

namespace NadinSoft.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [CusttomAuthorizeAttribute]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private IMapper _mapper;

        public ProductController(IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<int> Create([FromQuery] CreateProductModel model)
        {
            var request = _mapper.Map<CreateProductModel, CreateProduct>(model);

            var userId = Request.HttpContext.Items["User"];
            if (userId == null)
                return 0;

            request.UserId = Convert.ToInt32(userId);

            return await _mediator.Send(request);
        }

        [HttpPut("Update")]
        public async Task<int> Update([FromQuery] UpdateProductModel model)
        {
            var userId = Request.HttpContext.Items["User"];
            if (userId == null)
                return 0;

            var product = await _mediator.Send(new GetProductById() { Id = model.Id });

            if (product.UserId != Convert.ToInt32(userId))
                return 0;

            var request = _mapper.Map<UpdateProductModel, UpdateProduct>(model);
            request.UserId = product.UserId;

            product = await _mediator.Send(request);

            return product.Id;
        }

        [HttpDelete("Delete")]
        public async Task<bool> Delete([FromQuery] int id)
        {
            var userId = Request.HttpContext.Items["User"];
            if (userId == null)
                return false;

            var product = await _mediator.Send(new GetProductById() { Id = id });

            if (product.UserId != Convert.ToInt32(userId))
                return false;

            return await _mediator.Send(new DeleteProduct() { Id = id });
        }

        [HttpGet("GetAll")]
        public async Task<IList<ProductModel>> GetAll([FromQuery] SearchProductModel model)
        {
            var searchProducts = new SearchProducts();
            searchProducts.Id = model.Id;
            searchProducts.UserId = model.UserId;

            var products = await _mediator.Send(searchProducts);
            var productListModel = _mapper.Map<IList<Product>,
                    IList<ProductModel>>(products);

            return productListModel;
        }
    }
}
