using Grpc.Net.Client;
using GrpcService;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
     class Program
    {
        static async Task Main(string[] args)
        {

            using var channel = GrpcChannel.ForAddress("https://localhost:5071");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");

            using var channel2 = GrpcChannel.ForAddress("https://localhost:5071");
            var ChangeOrderState = new ChangeState.ChangeStateClient(channel);
            var reply2 = await ChangeOrderState.ChangeOrderStateAsync(new ChangeStateRequest { OrderId = "asdasdasd", OrderState =1, OrderStatus = 2 });


            Console.WriteLine("reply2: " + reply2);

            Console.ReadKey();
        }
    }
}
