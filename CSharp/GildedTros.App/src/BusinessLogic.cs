using System;

namespace GildedTros.App
{
   internal static partial class ItemExtensions
    {
        const int MinQuality = 0, MaxQuality = 50;

        private static int SellIn(Item item)
        {
            if (item.Name == ItemName.BDawgKeychain)
            {
                return item.SellIn;
            }

            return item.SellIn - 1;
        }

        private static int QualityForNormalItem(Item item)
        {
            int quality = item.Quality - QualityChange(item);
            return Math.Clamp(quality, MinQuality, MaxQuality);
        }

        private static int QualityChange(Item item)
        {
            return item.SellIn > 0 ? 1 : 2;
        }

        private static int QualityForGoodWine(Item item)
        {
            int quality = item.Quality + QualityChange(item);
            return Math.Clamp(quality, MinQuality, MaxQuality);
        }

        private static int QualityForBackstagePasses(Item item)
        {
            if (item.SellIn <= 0)
            {
                return 0;
            }
            else
            {
                int qualityChange;
                if (item.SellIn <= 5)
                {
                    qualityChange = 3;
                }
                else if (item.SellIn <= 10)
                {
                    qualityChange = 2;
                }
                else
                {
                    qualityChange = 1;
                }

                int quality = item.Quality + qualityChange;
                return Math.Clamp(quality, MinQuality, MaxQuality);
            }
        }

        private static int QualityForSmellyItems(Item item)
        {
            int quality = item.Quality - 2 * QualityChange(item);
            return Math.Clamp(quality, MinQuality, MaxQuality);
        }

        private static int QualityForLegendaryItems(Item item)
        {
            return 80;
        }
    }
}
