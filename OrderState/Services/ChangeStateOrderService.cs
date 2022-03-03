using Grpc.Core;
using GrpcServer;
using OrderState.Models;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace OrderState.Services
{
    public class ChangeStateOrderService : ChangeState.ChangeStateBase
    {
        private readonly OrderService _orderService;

        public ChangeStateOrderService(OrderService orderService)
        {
            this._orderService = orderService;
        }
        public override Task<GrpcServer.Order> ChangeOrderState(ChangeStateRequest request, ServerCallContext context)
        {
            var Order = _orderService.Get(request.OrderId);
            if (Order != null)
            {
                Order.OrderState = (E_OrderState)request.OrderState;
                Order.OrderStatus = (E_OrderStatus)request.OrderStatus;
                Order.ModifyDate = (string.Format("{0}/{1}/{2}", new PersianCalendar().GetYear(DateTime.Now), new PersianCalendar().GetMonth(DateTime.Now), new PersianCalendar().GetDayOfMonth(DateTime.Now)));
                Order.ModifyTime = DateTime.Now.ToString("HH:mm:ss:fff");
                _orderService.Update(Order.OrderId, Order);


                var result = new GrpcServer.Order
                {
                    CreateDate = Order.CreateDate,
                    OrderState = (int)Order.OrderState,
                    OrderStatus = (int)Order.OrderStatus,
                    ModifyDate = Order.ModifyDate,
                    ModifyTime = Order.ModifyTime,
                    OrderId = Order.OrderId,
                    UserId = Order.UserId,
                    CreateTime = Order.CreateTime,
                    ProductId = Order.ProductId
                };

                return Task.FromResult(result);
            }
            else
                return null;

        }
    }
}
