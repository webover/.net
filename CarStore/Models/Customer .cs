using CarStore.Helpers;
using CarStore.Models.Interfaces;
using System;

namespace CarStore.Models
{
    class Customer : IPerson
    {
        private string name;

        public Customer(string name)
        {
            this.name = name;
        }

        public void goesToStore(Store store)
        {
            LogHelper.Log(Log.defaultLog, this.name + " goes to the store " + store.Name + " in " + store.City + " to buy a car");
        }

        public string Name
        {
            get { return this.name; }
        }
    }
}
