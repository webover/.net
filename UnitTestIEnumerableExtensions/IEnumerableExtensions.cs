using IEnumerableExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestIEnumerableExtensions
{
    [TestClass]
    public class UnitTestIEnumerableExtensions
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange            
            List<int> list = new List<int> { 1, 3, 5, 4, 7, 8, 9 };
            int expectedMaxValue = 9;
            int expectedMinValue = 1;
            int expectedSumValue = 37;
            int expectedProductValue = 30240;
            int expectedAverageValue = 4320;
            
            List<int?> listNullable = new List<int?> { 1, null, 5, 4, 7, 8, null };
            int? expactedNullableSum = 25;

            // Act
            int actualMinValue = list.Min();
            int actualMaxValue = list.Max();
            int actualSumValue = list.Sum();
            int actualProductValue = list.Product();
            int actualAverageValue = list.Average();
            int? actualSumNullable = listNullable.Sum();

            // Assert
            Assert.AreEqual(expectedMaxValue, actualMaxValue, "Max Values are not equal");
            Assert.AreEqual(expectedMinValue, actualMinValue, "Min Values are not equal");
            Assert.AreEqual(expectedSumValue, actualSumValue, "Sum Values are not equal");
            Assert.AreEqual(expectedProductValue, actualProductValue, "Product Values are not equal");
            Assert.AreEqual(expectedAverageValue, actualAverageValue, "Average Values are not equal");

            Assert.AreEqual(expactedNullableSum, actualSumNullable, "Nullable sum values are not equal");
        }
    }
}
