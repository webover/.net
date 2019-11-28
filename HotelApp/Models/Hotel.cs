using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    /// <summary>
    /// Class Hotel - hotel name, city and a list of rooms
    /// </summary>
    /// <remarks>    
    /// </remarks>
    class Hotel : DisplayFields
    {
        private string name;
        private City city;
        private List<Room> rooms;

        public Hotel(string name, City city, List<Room> Room)
        {
            Name = name;
            City = city;
            Rooms = Room;

            this.Print();
        }
        [Required]
        public List<Room> Rooms
        {
            get { return this.rooms; }
            set
            {
                this.rooms = value;
                /*
                 * print each room
                 */
                this.rooms.ForEach(room => { room.Print(); });
            }
        }
        [Required]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        [Required]
        public City City
        {
            get { return this.city; }
            set { this.city = value; }
        }
        /*
         * we overide System.Object.Equals so we would know that 2 hotels are equal when their names are 
         */
        public override bool Equals(System.Object obj)
        {
            return (obj is Hotel) && ((Hotel)obj).Name == Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public decimal GetPriceForNumberOfRooms(byte numberOfRooms, byte days = 1)
        {
            if (numberOfRooms > this.Rooms.Count)
            {
                throw new ArgumentOutOfRangeException("numberOfRooms", "Maximum allowed rooms for hotel " + this.Name + " is " + this.Rooms.Count + ".");
            }

            byte counter = 0;
            decimal roomsPriceTotal = 0;

            foreach (Room room in this.Rooms)
            {
                if (numberOfRooms == counter)
                {
                    break;
                }

                roomsPriceTotal += room.GetPriceForDays(days);

                counter++;
            }

            return roomsPriceTotal;
        }
    }
}
