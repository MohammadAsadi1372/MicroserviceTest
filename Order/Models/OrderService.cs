using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.Models
{
    public class OrderService
    {
        private readonly IMongoCollection<M_Order> _orderCollection;

        public OrderService(
            IOptions<DatabaseSetting> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _orderCollection = mongoDatabase.GetCollection<M_Order>(
                bookStoreDatabaseSettings.Value.CollectionName);
        }

        public async Task<List<M_Order>> GetAsync() =>
            await _orderCollection.Find(_ => true).ToListAsync();

        public async Task<List<M_Order?>> GetAsync(int UserId) =>
            await _orderCollection.Find(x => x.UserId == UserId).ToListAsync();

        public async Task CreateAsync(M_Order order) =>
            await _orderCollection.InsertOneAsync(order);

        public async Task UpdateAsync(string id, M_Order order) =>
            await _orderCollection.ReplaceOneAsync(x => x.Id == id, order);

        public async Task RemoveAsync(string id) =>
            await _orderCollection.DeleteOneAsync(x => x.Id == id);
    }
}

