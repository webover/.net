using CarStore.Models.Interfaces;

namespace CarStore.Models
{
    class Producer : IProducer
    {
        public enum Brand
        {
            FordFocus = 0, SkodaOctavia = 1
        };

        private Brand model;

        public Producer()
        {

        }
        public Brand Model
        {
            set { this.model = value; }

            get { return this.model; }
        }

        public int Year { get { return (System.DateTime.Now).Year; } }

    }
}
