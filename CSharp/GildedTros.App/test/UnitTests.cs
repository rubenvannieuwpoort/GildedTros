using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class UnitTests
    {
        public void TestBeforeAfter(Item before, Item after)
        {
            List<Item> items = new List<Item> { before };
            Inventory inventory = new Inventory(items);

            inventory.UpdateQuality();

            Assert.Equal(after.Name, items[0].Name);
            Assert.Equal(after.SellIn, items[0].SellIn);
            Assert.Equal(after.Quality, items[0].Quality);
        }

        [Fact]
        public void QualityOfNormalItemShouldDecreaseByOneBeforeSellDate()
        {
            TestBeforeAfter(
                new Item { Name = "foo", SellIn = 5, Quality = 10 },
                new Item { Name = "foo", SellIn = 4, Quality = 9 }
            );
        }

        [Fact]
        public void QualityOfNormalItemShouldDecreaseByTwoAfterSellDate()
        {
            TestBeforeAfter(
                new Item { Name = "foo", SellIn = 0, Quality = 10 },
                new Item { Name = "foo", SellIn = -1, Quality = 8 }
            );
        }

        [Fact]
        public void QualityOfNormalItemShouldNotBecomeNegative()
        {
            TestBeforeAfter(
                new Item { Name = "foo", SellIn = 0, Quality = 0 },
                new Item { Name = "foo", SellIn = -1, Quality = 0 }
            );
        }

        [Fact]
        public void QualityAndSellInOfLegendaryItemsShouldNotChange()
        {
            TestBeforeAfter(
                new Item { Name = "B-DAWG Keychain", SellIn = 10, Quality = 80 },
                new Item { Name = "B-DAWG Keychain", SellIn = 10, Quality = 80 }
            );
        }

        [Fact]
        public void QualityOfGoodWineShouldIncreaseByOneBeforeSellDate()
        {
            TestBeforeAfter(
                new Item { Name = "Good Wine", SellIn = 10, Quality = 10 },
                new Item { Name = "Good Wine", SellIn = 9, Quality = 11 }
            );
        }

        [Fact]
        public void QualityOfGoodWineShouldIncreaseByTwoAfterSellDate()
        {
            TestBeforeAfter(
                new Item { Name = "Good Wine", SellIn = 0, Quality = 10 },
                new Item { Name = "Good Wine", SellIn = -1, Quality = 12 }
            );
        }

        [Fact]
        public void QualityOfBackstagePassesShouldBecomeZeroAfterSellDate()
        {
            TestBeforeAfter(
                new Item { Name = "Backstage passes for Re:factor", SellIn = 0, Quality = 10 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = -1, Quality = 0 }
            );

            TestBeforeAfter(
                new Item { Name = "Backstage passes for HAXX", SellIn = 0, Quality = 10 },
                new Item { Name = "Backstage passes for HAXX", SellIn = -1, Quality = 0 }
            );
        }

        [Fact]
        public void QualityOfBackstagePassesShouldIncreaseByThreeWhenThereAre5DaysOrLessLeft()
        {
            TestBeforeAfter(
                new Item { Name = "Backstage passes for Re:factor", SellIn = 5, Quality = 0 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 4, Quality = 3 }
            );

            TestBeforeAfter(
                new Item { Name = "Backstage passes for HAXX", SellIn = 5, Quality = 0 },
                new Item { Name = "Backstage passes for HAXX", SellIn = 4, Quality = 3 }
            );
        }

        [Fact]
        public void QualityOfBackstagePassesShouldIncreaseByThreeWhenThereAreMoreThan5ButLessThen11DaysLeft()
        {
            TestBeforeAfter(
                new Item { Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 0 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 9, Quality = 2 }
            );

            TestBeforeAfter(
                new Item { Name = "Backstage passes for HAXX", SellIn = 10, Quality = 0 },
                new Item { Name = "Backstage passes for HAXX", SellIn = 9, Quality = 2 }
            );
        }

        [Fact]
        public void QualityOfBackstagePassesShouldIncreaseByOneWhenThereAreMoreThan10DaysLeft()
        {
            TestBeforeAfter(
                new Item { Name = "Backstage passes for Re:factor", SellIn = 11, Quality = 0 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 1 }
            );

            TestBeforeAfter(
                new Item { Name = "Backstage passes for HAXX", SellIn = 11, Quality = 0 },
                new Item { Name = "Backstage passes for HAXX", SellIn = 10, Quality = 1 }
            );
        }

        [Fact]
        public void QualityOfBackstagePassesShouldNotBecomeMoreThan50()
        {
            TestBeforeAfter(
                new Item { Name = "Backstage passes for Re:factor", SellIn = 5, Quality = 49 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 4, Quality = 50 }
            );

            TestBeforeAfter(
                new Item { Name = "Backstage passes for HAXX", SellIn = 5, Quality = 49 },
                new Item { Name = "Backstage passes for HAXX", SellIn = 4, Quality = 50 }
            );
        }
    }
}