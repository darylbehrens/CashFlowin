using CashFlowin.Models;
using NUnit.Framework;
using p = CashFlowin.Models.Period;
using static CashFlowin.Models.Date;

namespace CashFlowin.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PeriodUnionTest()
        {
            // Arrange
            var periodOne = p.Create(Create(2021, 01, 01), Create(2021, 02, 01));
            var periodTwo = p.Create(Create(2021, 01, 31), Create(2021, 02, 01));

            // Act
            var periodThree = p.Union(periodOne, periodTwo);

            Assert.AreEqual(periodThree.Start.Value, Create(2021, 01, 31).Value);
            Assert.AreEqual(periodThree.End.Value, Create(2021, 02, 01).Value);
        }
    }
}