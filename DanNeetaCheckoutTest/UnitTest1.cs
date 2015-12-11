using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DanNeetaCheckoutTest
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase("", 0)]
        [TestCase("A",50)]
        [TestCase("AAA",130)]
        [TestCase("AAAAAA",260)]
        [TestCase("B",30)]
        [TestCase("BB",45)]
        [TestCase("BBBB",90)]
        [TestCase("AB",80)]
        [TestCase("C",20)]
        [TestCase("D",15)]
        public void ScanTest(string Items, int Price)
        {
            Assert.That(Checkout.Scan(Items), Is.EqualTo(Price));
        }
    }

    public class Checkout
    {
        public static int Scan(string items)
        {
            int price = 0;

            Dictionary<char, int> itemprice = new Dictionary<char, int>()
                {
                    {'A', 50},
                    {'B', 30},
                    {'C', 20},
                    {'D', 15}

                };

            Dictionary<char, int> multipleitems = new Dictionary<char, int>()
                {
                    {'A', 0},
                    {'B', 0},
                    {'C', 0},
                    {'D', 0}
                };

            foreach (char item in items)
            {
                    price += itemprice[item];
                    multipleitems[item]++;

                if (multipleitems['A'] == 3)
                {
                    price -= 20;
                    multipleitems['A'] = 0;
                }
                if (multipleitems['B']== 2)
                {
                    price -= 15;
                    multipleitems['B'] = 0;
                }
            }
            return price;
        }
    }
}