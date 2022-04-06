namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public Item() { }

        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void ChangeDay()
        {
            SellIn--;
        }

        public virtual void updateQuality()
        {
        }
    }

    public class AgeBrie : Item
    {
        public AgeBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void updateQuality()
        {
            if (Quality >= 50)
            {
                return;
            }

            Quality += 2;
        }
    }

    public class Backstage : Item
    {
        public Backstage(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void updateQuality()
        {

            if (SellIn < 11)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 2;
                }
            }
            if (SellIn < 6)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 3;
                }
            }
            if (SellIn == 0)
                Quality = 0;

        }
    }
    public class Sulfuras : Item
    {
        public Sulfuras(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void updateQuality()
        {
            Quality = 80;
            SellIn = 80;
        }
    }
    public class Conjured : Item
    {
        public Conjured(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void updateQuality()
        {
            if (SellIn == 0)
            {
                Quality -= 4;
            }
            Quality -= 2;
        }
    }
    public class NormalItem : Item
    {
        public NormalItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void updateQuality()
        {
            if (SellIn == 0)
            {
                Quality -= 2;
            }
            Quality -= 1;
        }
    }
}
