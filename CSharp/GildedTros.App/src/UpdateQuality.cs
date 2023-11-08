using System;

namespace GildedTros.App
{
   internal static partial class ItemExtensions
    {
        private static void UpdateQualityForNormalItem(ref Item item)
        {
            item.Quality = Math.Clamp(item.Quality - QualityChange(item), MinQuality, MaxQuality);
        }

        private static int QualityChange(Item item)
        {
            return item.SellIn > 0 ? 1 : 2;
        }

        private static void UpdateQualityForGoodWine(ref Item item)
        {
            item.Quality = Math.Clamp(item.Quality + QualityChange(item), MinQuality, MaxQuality);
        }

        private static void UpdateQualityForBackstagePasses(ref Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
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
                item.Quality = Math.Clamp(item.Quality + qualityChange, MinQuality, MaxQuality);
            }
        }

        private static void UpdateQualityForSmellyItems(ref Item item)
        {
            item.Quality = Math.Clamp(item.Quality - 2 * QualityChange(item), MinQuality, MaxQuality);
        }
        private static void UpdateQualityForLegendaryItems(ref Item item)
        {
            // legendary items always keep their quality
        }
    }
}
