using System;
using NUnit.Framework;
using Should;

namespace AutoParse.Tests
{
    [TestFixture]
    public class ScratchTests
    {

        [Test]
        public void should_parse_value()
        {
            Console.WriteLine("0009998".TryParse<int>());
            Console.WriteLine("0009998".TryParse<long>());
            Console.WriteLine("0009998".TryParse<double>());

            Assert.AreEqual("1.5".TryParse(10), 10, "Default value should be returned when string is not parsable.");
            Assert.AreEqual("1.5".TryParse<int>(), default(int), "default(T) should be returned when string is not parsable and no default has been provided.");
            
            Console.WriteLine("10-25-2013".TryParseNullable<DateTime>().HasValue);
        }
    }
}