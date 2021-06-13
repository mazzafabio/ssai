using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SSAI.Entity.DB;
using SSAI.Helpers.Authorize;
using SSAI.Helpers.ComputationTotalAmount;
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
    public class OrderController : ControllerBase
    {
        private readonly IProductService _productComponent;
        private readonly IOrderService _orderComponent;


        public OrderController(IProductService productComponent, IOrderService orderComponent)
        {
            _productComponent = productComponent;
            _orderComponent = orderComponent;
        }


        [Authorize]
        [HttpGet]
        public async Task<GenericResponse<List<OrderResponse>>> GetAll([FromQuery] int page, [FromQuery] int rowsPerPage)
        {
            var result = await _orderComponent.GetAll(page, rowsPerPage);

            return result;
        }


        [Authorize]
        [HttpPost]
        public async Task<GenericResponse<OrderResponse>> Add([FromBody] OrderRequest orderRequest)
        {
            var result = await _orderComponent.Add((Order)orderRequest, orderRequest.orderProducts.Select(x => (OrderProduct)x).ToList());

            return result;
        }


    }
}
