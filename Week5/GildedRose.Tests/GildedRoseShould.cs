using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class GildedRoseShould
    {
        [TestCase(0, -1)]
        [TestCase(2, 1)]
        [TestCase(1000, 999)]
        public void ReduceSellInByOneIfNoNameGiven(int sellIn, int expected)
        {
            var items = new List<Item> {new Item { SellIn = sellIn } };

            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            Assert.That(items.First().SellIn, Is.EqualTo(expected));
        }

        [TestCase(10, 8)]
//        [TestCase(1, -66)] Requires new test case
        [TestCase(1000, 998)]
        public void ReduceQualityByTwoIfNoNameGiven(int quality, int expected)
        {
            var items = new List<Item> { new Item { Quality = quality } };

            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            Assert.That(items.First().Quality, Is.EqualTo(expected));
        }

        [TestCase(0, 0)]
        [TestCase(-45, -45)]
        public void NeverReduceQualityWhenLessOrEqualToZero(int quality, int expected)
        {
            var items = new List<Item> { new Item { Quality = quality } };

            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            Assert.That(items.First().Quality, Is.EqualTo(expected));
        }
    }
}