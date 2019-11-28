using System;

namespace Class
{
    class Hotel
    {
        protected string name;
        protected string city;

        static Hotel()
        {
            Console.ReadKey();
        }

        public Hotel()
        {

        }


        public virtual string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public string City
        {
            get { return this.name; }
        }
    }

}
