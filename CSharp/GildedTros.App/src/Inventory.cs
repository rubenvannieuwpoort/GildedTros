using System.Collections.Generic;

namespace GildedTros.App
{
    public class Inventory
    {
        IList<Item> Items;
        public Inventory(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void Update()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Good Wine" 
                    && Items[i].Name != "Backstage passes for Re:factor"
                    && Items[i].Name != "Backstage passes for HAXX")
                {
                    if (Items[i].Name != "B-DAWG Keychain")
                    {
                        if (Items[i].Name == "Duplicate Code" ||
                            Items[i].Name == "Long Methods" ||
                            Items[i].Name == "Ugly Variable Names")
                        {
                            Items[i].Quality = System.Math.Max(0, Items[i].Quality - 2);
                        }
                        else
                        {
                            Items[i].Quality = System.Math.Max(0, Items[i].Quality - 1);
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes for Re:factor"
                        || Items[i].Name == "Backstage passes for HAXX")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "B-DAWG Keychain")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Good Wine")
                    {
                        if (Items[i].Name != "Backstage passes for Re:factor"
                            && Items[i].Name != "Backstage passes for HAXX")
                        {
                            if (Items[i].Name != "B-DAWG Keychain")
                            {
                                if (Items[i].Name == "Duplicate Code" ||
                                    Items[i].Name == "Long Methods" ||
                                    Items[i].Name == "Ugly Variable Names")
                                {
                                    Items[i].Quality = System.Math.Max(0, Items[i].Quality - 2);
                                }
                                else
                                {
                                    Items[i].Quality = System.Math.Max(0, Items[i].Quality - 1);
                                }
                            }
                            
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
