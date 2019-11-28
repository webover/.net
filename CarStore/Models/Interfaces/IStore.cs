using System.Collections.Generic;

namespace CarStore.Models.Interfaces
{
    interface IStore
    {
        public enum CityNames { };

        public string Name
        {
            get;
        }

        public Dictionary<int, Order> PlaceOrder(Order order);

        public Dictionary<int, Order> CancelOrder(Order order);
    }
}
