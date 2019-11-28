using HotelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelApp
{
    public enum Currency : byte
    {
        USD = 0, EUR = 1
    }

    public enum City : short
    {
        London = 0, Tokyo = 1, Dubai = 2
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Add hotels to a list
             */
            List<Hotel> hotels = new List<Hotel>();

            hotels.Add(new Hotel("My First Hotel", City.London, new List<Room>()
            {
                new Room() { Name = "Standard Room", Adults = 2, Children = 2,  Rate = new Rate() { Amount = 100.23M, Currency = Currency.EUR
                } },
                new Room() { Name = "Deluxe Room", Adults = 2, Children = 0,  Rate = new Rate() { Amount = 45.45M, Currency = Currency.EUR } },
                new Room() { Name = "Ocean View Room", Adults = 2, Children = 0,  Rate = new Rate() { Amount = 56.23M, Currency = Currency.EUR } },
                new Room() { Name = "Twin Room", Adults = 2, Children = 2,  Rate = new Rate() { Amount = 72.23M, Currency = Currency.EUR} }
            }));

            hotels.Add(new Hotel("My Second Hotel", City.Tokyo, new List<Room>()
            {
                new Room() { Name = "Standard Room", Adults = 2, Children = 2,  Rate = new Rate() { Amount = 100.23M, Currency = Currency.USD
                } },
                new Room() { Name = "Deluxe Room", Adults = 2, Children = 0,  Rate = new Rate() { Amount = 45.45M, Currency = Currency.USD } },
                new Room() { Name = "Ocean View Room", Adults = 2, Children = 0,  Rate = new Rate() { Amount = 52.23M, Currency = Currency.USD } },
                new Room() { Name = "Twin Room", Adults = 2, Children = 2,  Rate = new Rate() { Amount = 71.23M, Currency = Currency.USD} }
            }));

            hotels.Add(new Hotel("My Third Hotel", City.Dubai, new List<Room>()
            {
                new Room() { Name = "Standard Room", Adults = 2, Children = 2,  Rate = new Rate() { Amount = 5.23M, Currency = Currency.EUR
                } },
                new Room() { Name = "Deluxe Room", Adults = 2, Children = 0,  Rate = new Rate() { Amount = 2.45M, Currency = Currency.EUR } },
                new Room() { Name = "Ocean View Room", Adults = 2, Children = 0,  Rate = new Rate() { Amount = 1.23M, Currency = Currency.EUR } },
                new Room() { Name = "Twin Room", Adults = 2, Children = 2,  Rate = new Rate() { Amount = 2.23M, Currency = Currency.EUR} }
            }));
            /*
             * Add duplicate hotel on purpose
             */
            hotels.Add(new Hotel("My Third Hotel", City.Dubai, new List<Room>()
            {
                new Room() { Name = "Standard Room", Adults = 2, Children = 2,  Rate = new Rate() { Amount = 5.23M, Currency = Currency.EUR
                } },
                new Room() { Name = "Deluxe Room", Adults = 2, Children = 0,  Rate = new Rate() { Amount = 2.45M, Currency = Currency.EUR } },
                new Room() { Name = "Ocean View Room", Adults = 2, Children = 0,  Rate = new Rate() { Amount = 1.23M, Currency = Currency.EUR } },
                new Room() { Name = "Twin Room", Adults = 2, Children = 2,  Rate = new Rate() { Amount = 2.23M, Currency = Currency.EUR} }
            }));
            /*
             * Delete Hotel
             * Remove duplicate hotels
             */
            HashSet<Hotel> duplicateHotels = GetDuplicateHotels(hotels);

            foreach (Hotel duplicateHotel in duplicateHotels)
            {
                // Search for the first occurrence of the duplicated hotel and remove it
                hotels.RemoveAt(hotels.IndexOf(duplicateHotel));
            }

            byte numberOfRoomsToSearch = 2;

            foreach (Hotel hotel in hotels)
            {
                try
                {
                    decimal hotelPrice = hotel.GetPriceForNumberOfRooms(numberOfRoomsToSearch);
                    Console.WriteLine("Price for hotel {0} for {1} rooms is {2}", hotel.Name, numberOfRoomsToSearch, hotelPrice);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("ArgumentOutOfRangeException source: {0}", e.Source);
                    Console.WriteLine("ArgumentOutOfRangeException message: {0}", e.Message);
                }
            }

            //Find a room with a price lower than some value
            decimal lowestPrice = 30.2M;

            var hotelsWithlowestPrices = hotels.Where(hotel => hotel.GetPriceForNumberOfRooms(numberOfRoomsToSearch) <= lowestPrice).ToList();

            foreach (Hotel hotel in hotelsWithlowestPrices)
            {
                Console.WriteLine("Hotel {0} has the price {1} which is lowest than {2}", hotel.Name, hotel.GetPriceForNumberOfRooms(numberOfRoomsToSearch), lowestPrice);
                hotel.Print();
            }
        }
        /*
         * <summmary>
         * The scope for this is to make use of overiding System.Object.Equals and to implement IEqualityComparer 
         * </summmary>
         */
        public static HashSet<Hotel> GetDuplicateHotels(List<Hotel> hotels)
        {
            int hotelIndex = 0;

            HashSet<Hotel> duplicateHotels = new HashSet<Hotel>(new HotelNameComparer());

            foreach (Hotel hotel in hotels)
            {
                int secondHotelIndex = 0;

                foreach (Hotel secondHotel in hotels)
                {
                    /*
                     * we have overrided the Equals  
                     */
                    if (hotelIndex != secondHotelIndex && hotel.Equals(secondHotel))
                    {
                        duplicateHotels.Add(hotel);
                    }

                    secondHotelIndex++;
                }

                hotelIndex++;
            }

            return duplicateHotels;
        }
    }
}
