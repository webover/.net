using CarStore.Models.Interfaces;
using System;

namespace CarStore.Models
{
    class Order : IOrder
    {
        private Customer customer;
        private Car car;
        private short deliveryInWeeks = 4;

        public Order()
        {

        }

        public Customer Customer
        {
            set { this.customer = value; }

            get { return this.customer; }
        }

        public Car Car
        {
            set { this.car = value; }

            get { return this.car; }
        }

        public short DeliveryInWeeks
        {
            set { this.deliveryInWeeks = value; }

            get { return this.deliveryInWeeks; }
        }

        public string DeliveryDate
        {
            get { return (DateTime.Now).AddDays(this.DeliveryInWeeks).ToShortDateString(); }
        }

    }
}
