using CarStore.Models.Interfaces;

namespace CarStore.Models
{
    class Car : ICar
    {
        private Producer producer;
        private decimal price;

        public Car()
        {

        }


        public decimal Price
        {
            set { this.price = value; }
            get { return this.price; }
        }

        public Producer Producer
        {
            set { this.producer = value; }
            get { return this.producer; }
        }


    }
}
