using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace IClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();

            Console.WriteLine($"{clock.Now}");
            Console.WriteLine($"{clock.UtcNow}");

            BusinessDate businessToday = clock.Today;

            Clock clockS = new Clock();

            Console.WriteLine($"{clock.Now}");
            Console.WriteLine($"{clock.UtcNow}");

            BusinessDate businessTodayS = clockS.Today;

            List<BusinessDate> clocks = new List<BusinessDate> { businessToday, businessTodayS };

            clocks.Sort();

            if (businessToday.Equals(businessTodayS))
            {
                Console.WriteLine($"businessToday  and businessTodayS are equal");
            }

            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);

            XmlSerializer serializer = new XmlSerializer(typeof(BusinessDate));
            serializer.Serialize(writer, businessToday);

            Console.WriteLine($"BussinessDate {sb}");

        }
    }
}
