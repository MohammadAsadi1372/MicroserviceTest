using Grpc.Net.Client;
using GrpcClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] RM_Order request)
        {
            try
            {


                await _orderService.CreateAsync(new M_Order { UserId = request.UserId, ProductId = request.ProductId });

                var order = (((await _orderService.GetAsync(request.UserId)).OrderByDescending(c => c.CreateDate).ToList()).OrderByDescending(c => c.CreateTime).ToList()).FirstOrDefault();



                GrpcChannelOptions channelOptions = new GrpcChannelOptions();
                var channel = GrpcChannel.ForAddress("https://localhost:44391");
                var ChangeOrderState = new ChangeState.ChangeStateClient(channel);
                var reply = await ChangeOrderState.ChangeOrderStateAsync(new ChangeStateRequest { OrderId = order.OrderId, OrderState = (int)E_OrderState.START, OrderStatus = (int)E_OrderStatus.ACTIVE });

                return Ok(reply);


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
