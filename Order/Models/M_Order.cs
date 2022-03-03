using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Globalization;

namespace Order.Models
{
    public class M_Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string OrderId { get; set; } = Guid.NewGuid().ToString();

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public E_OrderState OrderState { get; set; } = E_OrderState.NONEXISTENT;

        public E_OrderStatus OrderStatus { get; set; } = E_OrderStatus.START;

        public string CreateDate { get; set; } = (string.Format("{0}/{1}/{2}", new PersianCalendar().GetYear(DateTime.Now), new PersianCalendar().GetMonth(DateTime.Now), new PersianCalendar().GetDayOfMonth(DateTime.Now)));

        public string CreateTime { get; set; } = DateTime.Now.ToString("HH:mm:ss:fff");

        public string ModifyDate { get; set; } = (string.Format("{0}/{1}/{2}", new PersianCalendar().GetYear(DateTime.Now), new PersianCalendar().GetMonth(DateTime.Now), new PersianCalendar().GetDayOfMonth(DateTime.Now)));

        public string ModifyTime { get; set; } = DateTime.Now.ToString("HH:mm:ss:fff");
    }
}
