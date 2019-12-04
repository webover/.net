using IClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace UnitTestIClock
{
    [TestClass]
    public class UnitTestIClock
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange            

            Clock clock = new Clock();

            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);

            XmlSerializer serializer = new XmlSerializer(typeof(BusinessDate));
            serializer.Serialize(writer, clock.Today);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb.ToString());

            // Act
            var today = DateTime.Now.ToLongDateString();

            // Assert
            Assert.AreEqual(today, doc.InnerText, "Actual value and Arrange value are equal");
        }
    }
}
