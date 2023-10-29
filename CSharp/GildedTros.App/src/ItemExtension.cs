using System.ComponentModel.Design;

namespace GildedTros.App
{
    internal static class ItemExtensions
    {
        const int MinQuality = 0, MaxQuality = 50;

        internal static void Update(this Item item)
        {
            // update quality
            switch (item.Name)
            {
                case "Good Wine":
                    UpdateQualityForGoodWine(ref item);
                    break;
                case "Backstage passes for HAXX":
                case "Backstage passes for Re:factor":
                    UpdateQualityForBackstagePasses(ref item);
                    break;
                case "Duplicate Code":
                case "Long Methods":
                case "Ugly Variable Names":
                    UpdateQualityForSmellyItems(ref item);
                    break;
                case "B-DAWG Keychain":
                    // legendary items always keep their quality
                    break;
                default:
                    UpdateQualityForNormalItem(ref item);
                    break;
            }

            // update "sell in"
            if (item.Name != "B-DAWG Keychain")
            {
                item.SellIn -= 1;
            }
        }


        static void UpdateQualityForGoodWine(ref Item item)
        {
            item.Quality = Clamp(item.Quality + Decay(item));
        }

        static void UpdateQualityForBackstagePasses(ref Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            else
            {
                if (item.SellIn <= 5)
                {
                    item.Quality = Clamp(item.Quality + 3);
                }
                else if (item.SellIn <= 10)
                {
                    item.Quality = Clamp(item.Quality + 2);
                }
                else
                {
                    item.Quality = Clamp(item.Quality + 1);
                }
            }
        }

        static void UpdateQualityForSmellyItems(ref Item item)
        {
            item.Quality = Clamp(item.Quality - 2 * Decay(item));
        }

        static void UpdateQualityForNormalItem(ref Item item)
        {
            item.Quality = Clamp(item.Quality - Decay(item));
        }

        static int Decay(Item item)
        {
            return item.SellIn > 0 ? 1 : 2;
        }

        private static int Clamp(int quality)
        {
            if (quality < MinQuality)
            {
                return MinQuality;
            }
            if (quality > MaxQuality)
            {
                return MaxQuality;
            }
            return quality;
        }
    }
}
