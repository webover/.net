using CarStore.Helpers;
using CarStore.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace CarStore.Models
{
    class Store: IStore
    {
        private Dictionary<int, Order> Orders = new Dictionary<int, Order>();
        private string name;
        private CityNames city;
        public Store(Order order, string name, CityNames city)
        {
            this.Orders[order.GetHashCode()] = order;
            this.name = name;
            this.city = city;
        }

        public Store(string name, CityNames city)
        {
            this.name = name;
            this.city = city;
        }

        public enum CityNames
        {
            Bucuresti = 0, Iasi = 1, Cluj = 2
        }

        public CityNames City
        {
            get { return this.city; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public Dictionary<int, Order> PlaceOrder(Order order)
        {
            this.Orders.Add(order.GetHashCode(), order);

            LogHelper.Log(Log.defaultLog, order.Customer.Name + " have placed an order for "+ order.Car.Producer.Model + " " + order.Car.Producer.Year);
            
            return this.Orders;
        }

        public Dictionary<int, Order> CancelOrder(Order order)
        {
            LogHelper.Log(Log.defaultLog, order.Customer.Name + " have canceled an order for " + order.Car.Producer.Model + " " + order.Car.Producer.Year);

            this.Orders.Remove(order.GetHashCode());            

            return this.Orders;
        }

  
    }
}
