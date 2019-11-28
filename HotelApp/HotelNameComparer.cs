using HotelApp.Models;
using System;
using System.Collections.Generic;

namespace HotelApp
{
    class HotelNameComparer : IEqualityComparer<Hotel>
    {
        public bool Equals(Hotel h1, Hotel h2)
        {
            return h1.Name.Equals(h2.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(Hotel obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
