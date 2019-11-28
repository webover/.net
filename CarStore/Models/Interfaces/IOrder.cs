namespace CarStore.Models.Interfaces
{
    interface IOrder
    {
        public Customer Customer
        {
            get;
            set;
        }

        public Car Car
        {
            get;
            set;
        }

        public short DeliveryInWeeks
        {
            set;
            get;
        }

        public string DeliveryDate
        {
            get;
        }

    }
}
