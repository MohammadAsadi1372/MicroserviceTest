using Grpc.Core;
using GrpcServer;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    public class ChangeStateOrderService : ChangeState.ChangeStateBase
    {
        public override Task<GrpcServer.Order> ChangeOrderState(ChangeStateRequest request, ServerCallContext context)
        {

            var result = new GrpcServer.Order
            {
                CreateDate = "asdasdasd",
                OrderState = 1,
                OrderStatus = 1,
                ModifyDate = "dsajbdjasd",
                ModifyTime = "asdasdasd",
                OrderId = "asdasdasd",
                UserId = 8,
                CreateTime = "asdasdasd",
                ProductId = 5,
            };

            return Task.FromResult(result);

        }
    }
}
