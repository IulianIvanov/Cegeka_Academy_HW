using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData("itemNou", 15, 3)]
        public void foo(string name, int sellIn, int quality)
        {
            var item = new Item(name, sellIn, quality);
            IList<Item> Items = new List<Item>();
            Items.Add(item);

            var app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("itemNou", Items[0].Name);
        }
    }
}
