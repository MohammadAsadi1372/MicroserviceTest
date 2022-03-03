using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderState.Models
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> _orderCollection;

        public OrderService(
            IOptions<DatabaseSetting> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _orderCollection = mongoDatabase.GetCollection<Order>(
                bookStoreDatabaseSettings.Value.CollectionName);
        }

        public async Task<Order?> GetAsync(string OrderId) =>
            await _orderCollection.Find(x => x.OrderId == OrderId).FirstOrDefaultAsync();

        public Order? Get(string OrderId) =>
         _orderCollection.Find(x => x.OrderId == OrderId).FirstOrDefault();

        public async Task UpdateAsync(string OrderId, Order order) =>
            await _orderCollection.ReplaceOneAsync(x => x.OrderId == OrderId, order);

        public  void Update(string OrderId, Order order) =>
             _orderCollection.ReplaceOneAsync(x => x.OrderId == OrderId, order);
    }
}

