using System;
using System.Collections.Generic;

namespace GildedTros.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            const int days = 30;

            IList<Item> Items = new List<Item>{
                new Item {Name = "Ring of Cleansening Code", SellIn = 10, Quality = 20},
                new Item {Name = ItemName.GoodWine, SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the SOLID", SellIn = 5, Quality = 7},
                new Item {Name = ItemName.BDawgKeychain, SellIn = 0, Quality = 80},
                new Item {Name = ItemName.BDawgKeychain, SellIn = -1, Quality = 80},
                new Item {Name = ItemName.BackstagePassesForRefactor, SellIn = 15, Quality = 20},
                new Item {Name = ItemName.BackstagePassesForRefactor, SellIn = 10, Quality = 49},
                new Item {Name = ItemName.BackstagePassesForHaxx, SellIn = 5, Quality = 49},
                new Item {Name = ItemName.DuplicateCode, SellIn = 3, Quality = 7},
                new Item {Name = ItemName.LongMethods, SellIn = 3, Quality = 6},
                new Item {Name = ItemName.UglyVariableNames, SellIn = 3, Quality = 5}
            };

            var inventory = new Inventory(Items);

            for (var i = 0; i <= days; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                inventory.Update();
            }
        }
    }
}
