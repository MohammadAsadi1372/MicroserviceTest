namespace OrderState.Models
{
    public enum E_OrderState
    {
        NONEXISTENT = 0,

        START = 1,

        SEARCH = 2,

        COMPLETED = 3,

        SEND = 4,

        RECIVED = 5
    }

    public enum E_OrderStatus
    {
        START = 0,

        ACTIVE = 1,

        DEACTIVE = 2,

        END = 3
    }

}