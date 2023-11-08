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
                ItemName.GoodWine => QualityForGoodWine(item),
                ItemName.BackstagePassesForHaxx or ItemName.BackstagePassesForRefactor => QualityForBackstagePasses(item),
                ItemName.DuplicateCode or ItemName.LongMethods or ItemName.UglyVariableNames => QualityForSmellyItems(item),
                ItemName.BDawgKeychain => QualityForLegendaryItems(item),
                _ => QualityForNormalItem(item),
            };
        }
    }
}
