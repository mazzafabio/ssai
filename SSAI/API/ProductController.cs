using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SSAI.Entity.DB;
using SSAI.Helpers.Authorize;
using SSAI.Model.Request;
using SSAI.Model.Response;
using SSAI.Service;
using SSAI.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.API
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productComponent;
        private readonly IOrderService _orderComponent;


        public ProductController(IProductService productComponent, IOrderService orderComponent)
        {
            _productComponent = productComponent;
            _orderComponent = orderComponent;
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<ProductResponse> Get(int id)
        {
            var result = await _productComponent.Get(id);

            return (ProductResponse) result;
        }


        [Authorize]
        [HttpGet]
        public async Task<List<ProductResponse>> GetAll([FromQuery] int page, [FromQuery] int rowsPerPage)
        {
            var result = await _productComponent.GetAll(page, rowsPerPage);

            return result.Select(x => (ProductResponse)x).ToList();
        }


        [Authorize]
        [HttpPost]
        public async Task<ProductResponse> Add([FromBody] ProductRequest productRequest)
        {
            var result = await _productComponent.Add((Product)productRequest);

            return (ProductResponse)result;
        }


    }
}
