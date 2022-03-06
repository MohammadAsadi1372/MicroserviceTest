using MassTransit;
using OrderService;
using System.Threading.Tasks;

namespace Customer.Microservice.Consumers
{
    public class TestConsumer : IConsumer<WeatherForecast>
    {
        public async Task Consume(ConsumeContext<WeatherForecast> context)
        {
            await Task.Run(() => { var obj = context.Message; });
        }
    }
}
