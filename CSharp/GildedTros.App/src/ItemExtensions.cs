namespace GildedTros.App
{
    internal static partial class ItemExtensions
    {
        internal static void Update(this Item item)
        {
            item.Quality = Quality(item);
            item.SellIn = SellIn(item);
        }

        private static int Quality(Item item) {
            return item.Name switch
            {
                ItemNames.GoodWine => QualityForGoodWine(item),
                ItemNames.BackstagePassesForHaxx or ItemNames.BackstagePassesForRefactor => QualityForBackstagePasses(item),
                ItemNames.DuplicateCode or ItemNames.LongMethods or ItemNames.UglyVariableNames => QualityForSmellyItems(item),
                ItemNames.BDawgKeychain => QualityForLegendaryItems(item),
                _ => QualityForNormalItem(item),
            };
        }
    }
}
