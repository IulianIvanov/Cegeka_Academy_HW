using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class FactoryItem
    {
        public enum ItemType
        {
            AgedBrie, Backstage, Sulfuras, Conjured, NormalItem
        }
        public static Item createItem(ItemType itemType, string name, int sellIn, int quality)
        {
            switch (itemType)
            {
                case ItemType.AgedBrie: return new AgeBrie(name, sellIn, quality);
                case ItemType.Backstage: return new Backstage(name, sellIn, quality);
                case ItemType.Sulfuras: return new Sulfuras(name, sellIn, quality);
                case ItemType.Conjured: return new Conjured(name, sellIn, quality);
                case ItemType.NormalItem: return new NormalItem(name, sellIn, quality);
            }
            throw new ArgumentException($"The item type {itemType} is not recognized ");
        }
    }
}
