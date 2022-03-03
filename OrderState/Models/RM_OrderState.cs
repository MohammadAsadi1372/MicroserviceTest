namespace OrderState.Models
{
    public class RM_OrderState
    {
        public string OrderId { get; set; }
        public E_OrderState OrderState { get; set; }
        public E_OrderStatus OrderStatus { get; set; }
    }
}
