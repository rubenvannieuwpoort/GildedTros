using System;

namespace GildedTros.App
{
    internal static class ItemNames
    {
        internal const string GoodWine = "Good Wine";
        internal const string BackstagePassesForHaxx = "Backstage passes for HAXX";
        internal const string BackstagePassesForRefactor = "Backstage passes for Re:factor";
        internal const string DuplicateCode = "Duplicate Code";
        internal const string LongMethods = "Long Methods";
        internal const string UglyVariableNames = "Ugly Variable Names";
        internal const string BDawgKeychain = "B-DAWG Keychain";
    }

    internal static class ItemExtensions
    {
        const int MinQuality = 0, MaxQuality = 50;

        internal static void Update(this Item item)
        {
            // update quality
            switch (item.Name)
            {
                case ItemNames.GoodWine:
                    UpdateQualityForGoodWine(ref item);
                    break;
                case ItemNames.BackstagePassesForHaxx:
                case ItemNames.BackstagePassesForRefactor:
                    UpdateQualityForBackstagePasses(ref item);
                    break;
                case ItemNames.DuplicateCode:
                case ItemNames.LongMethods:
                case ItemNames.UglyVariableNames:
                    UpdateQualityForSmellyItems(ref item);
                    break;
                case ItemNames.BDawgKeychain:
                    // legendary items always keep their quality
                    break;
                default:
                    UpdateQualityForNormalItem(ref item);
                    break;
            }

            // update "sell in"
            if (item.Name != ItemNames.BDawgKeychain)
            {
                item.SellIn -= 1;
            }
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
                if (item.SellIn <= 5)
                {
                    item.Quality = Math.Clamp(item.Quality + 3, MinQuality, MaxQuality);
                }
                else if (item.SellIn <= 10)
                {
                    item.Quality = Math.Clamp(item.Quality + 2, MinQuality, MaxQuality);
                }
                else
                {
                    item.Quality = Math.Clamp(item.Quality + 1, MinQuality, MaxQuality);
                }
            }
        }

        private static void UpdateQualityForSmellyItems(ref Item item)
        {
            item.Quality = Math.Clamp(item.Quality - 2 * QualityChange(item), MinQuality, MaxQuality);
        }

        private static void UpdateQualityForNormalItem(ref Item item)
        {
            item.Quality = Math.Clamp(item.Quality - QualityChange(item), MinQuality, MaxQuality);
        }

        private static int QualityChange(Item item)
        {
            return item.SellIn > 0 ? 1 : 2;
        }
    }
}
