namespace GildedTros.App
{
    internal static class ItemExtensions
    {
        internal static void Update(this Item item)
        {
            if (item.Name != "Good Wine"
                && item.Name != "Backstage passes for HAXX"
                && item.Name != "Backstage passes for Re:factor")
            {
                if (item.Name != "B-DAWG Keychain")
                {
                    if (item.Name == "Duplicate Code" ||
                        item.Name == "Long Methods" ||
                        item.Name == "Ugly Variable Names")
                    {
                        item.Quality = System.Math.Max(0, item.Quality - 2);
                    }
                    else
                    {
                        item.Quality = System.Math.Max(0, item.Quality - 1);
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes for Re:factor"
                    || item.Name == "Backstage passes for HAXX")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != "B-DAWG Keychain")
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Good Wine")
                {
                    if (item.Name != "Backstage passes for Re:factor"
                        && item.Name != "Backstage passes for HAXX")
                    {
                        if (item.Name != "B-DAWG Keychain")
                        {
                            if (item.Name == "Duplicate Code" ||
                                item.Name == "Long Methods" ||
                                item.Name == "Ugly Variable Names")
                            {
                                item.Quality = System.Math.Max(0, item.Quality - 2);
                            }
                            else
                            {
                                item.Quality = System.Math.Max(0, item.Quality - 1);
                            }
                        }

                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }
}
