using CarStore.Helpers;
using CarStore.Models;

namespace CarStore
{
    static class Log
    {
        public static LogTypes defaultLog = LogTypes.File;
    }
    class Program
    {
        static void Main(string[] args)
        {           

            Customer customer = new Customer("Alex");

            Store fordStore = new Store("FordStore", Store.CityNames.Bucuresti);

            customer.goesToStore(fordStore);

            Order fordStoreOrder = new Order()
            {
                Customer = customer,
                Car = new Car()
                {
                    Price = 15000,
                    Producer = new Producer()
                    {
                        Model = Producer.Brand.FordFocus
                    }
                },
                DeliveryInWeeks = 4
            };

            fordStore.PlaceOrder(fordStoreOrder);

            Store skodaStore = new Store("SkodaStore", Store.CityNames.Iasi);

            customer.goesToStore(skodaStore);

            fordStore.CancelOrder(fordStoreOrder);

            Order skodaStoreOrder = new Order()
            {
                Customer = customer,
                Car = new Car()
                {
                    Price = 14000,
                    Producer = new Producer()
                    {
                        Model = Producer.Brand.SkodaOctavia
                    }
                },
                DeliveryInWeeks = 3
            };

            skodaStore.PlaceOrder(skodaStoreOrder);            

        }
    }
}
