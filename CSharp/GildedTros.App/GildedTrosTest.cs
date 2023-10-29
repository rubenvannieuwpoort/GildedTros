using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            Inventory inventory = new Inventory(Items);
            inventory.UpdateQuality();
            Assert.Equal("fixme", Items[0].Name);
        }
    }
}