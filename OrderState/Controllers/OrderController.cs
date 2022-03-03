using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderState.Models;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace OrderState.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> ChangeState([FromBody] RM_OrderState request)
        {
            var Order = await _orderService.GetAsync(request.OrderId);
            if (Order != null)
            {
                Order.OrderState = request.OrderState;
                Order.OrderStatus = request.OrderStatus;
                Order.ModifyDate = (string.Format("{0}/{1}/{2}", new PersianCalendar().GetYear(DateTime.Now), new PersianCalendar().GetMonth(DateTime.Now), new PersianCalendar().GetDayOfMonth(DateTime.Now)));
                Order.ModifyTime = DateTime.Now.ToString("HH:mm:ss:fff");
                await _orderService.UpdateAsync(Order.OrderId, Order);
                return Ok(new { Data = Order });
            }
            else
                return NotFound();
        }
    }
}
