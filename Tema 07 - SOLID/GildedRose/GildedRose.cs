using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    //static
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string Conjured = "Conjured Mana Cake";

        IList<Item> Items;
        public GildedRose(IList<Item> items)
        {
            IList<Item> newItems = new List<Item>();
            foreach (var item in items)
            {
                var (name, sellIn, quality) = (item.Name, item.SellIn, item.Quality);
                FactoryItem.ItemType type = FactoryItem.ItemType.NormalItem;
                if (item.Name == AgedBrie)
                    type = FactoryItem.ItemType.AgedBrie;
                if (item.Name == Backstage)
                    type = FactoryItem.ItemType.Backstage;
                if (item.Name == Sulfuras)
                    type = FactoryItem.ItemType.Sulfuras;
                if (item.Name == Conjured)
                    type = FactoryItem.ItemType.Conjured;
                //nu functioneaza sa adaug direct la items pentru ca e folosit in foreach, asa ca cream alta lista noua
                //items.Add(FactoryItem.createItem(type, name, sellIn, quality));
                newItems.Add(FactoryItem.createItem(type, name, sellIn, quality));
            }
            Items = newItems;
        }
        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.ChangeDay();
                item.updateQuality();
            }
        }

    }
}
