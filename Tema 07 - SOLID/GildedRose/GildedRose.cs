using System;
using System.Collections.Generic;
using GildedRose;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string Conjured = "Conjured, It breaks fast";

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            Items.Add(FactoryItem.createItem(FactoryItem.ItemType.AgedBrie, AgedBrie, 4, 10));
            Items.Add(FactoryItem.createItem(FactoryItem.ItemType.Backstage, Backstage, 6, 30));
            Items.Add(FactoryItem.createItem(FactoryItem.ItemType.Sulfuras, Sulfuras, 14, 20));
            Items.Add(FactoryItem.createItem(FactoryItem.ItemType.Conjured, Conjured, 40, 50));
            Items.Add(FactoryItem.createItem(FactoryItem.ItemType.NormalItem, "Item", 11, 13));

        }
        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.ChangeDay();
                item.updateQuality();
            }
        }

        public static void Main(string[] args)
        {
            //UpdateQuality();

        }
    }
}
