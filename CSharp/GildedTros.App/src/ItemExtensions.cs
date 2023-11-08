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

    internal static partial class ItemExtensions
    {
        const int MinQuality = 0, MaxQuality = 50;

        internal static void Update(this Item item)
        {
            UpdateQuality(ref item);
            UpdateSellIn(ref item);
        }

        private static void UpdateQuality(ref Item item) {
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
                    UpdateQualityForLegendaryItems(ref item);
                    break;
                default:
                    UpdateQualityForNormalItem(ref item);
                    break;
            }
        }

        private static void UpdateSellIn(ref Item item)
        {
            if (item.Name != ItemNames.BDawgKeychain)
            {
                item.SellIn -= 1;
            }
        }
    }
}
