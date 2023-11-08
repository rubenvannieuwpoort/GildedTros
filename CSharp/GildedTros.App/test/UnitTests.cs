using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class UnitTests
    {
        private void ExpectAfterOneDay(Item before, Item after)
        {
            List<Item> items = new List<Item> { before };
            Inventory inventory = new Inventory(items);

            inventory.Update();

            Assert.Equal(after.Name, items[0].Name);
            Assert.Equal(after.SellIn, items[0].SellIn);
            Assert.Equal(after.Quality, items[0].Quality);
        }

        [Fact]
        public void QualityOfNormalItemShouldDecreaseByOneBeforeSellDate()
        {
            ExpectAfterOneDay(
                new Item { Name = "foo", SellIn = 5, Quality = 10 },
                new Item { Name = "foo", SellIn = 4, Quality = 9 }
            );
        }

        [Fact]
        public void QualityOfNormalItemShouldDecreaseByTwoAfterSellDate()
        {
            ExpectAfterOneDay(
                new Item { Name = "foo", SellIn = 0, Quality = 10 },
                new Item { Name = "foo", SellIn = -1, Quality = 8 }
            );
        }

        [Fact]
        public void QualityOfNormalItemShouldNotBecomeNegative()
        {
            ExpectAfterOneDay(
                new Item { Name = "foo", SellIn = 0, Quality = 0 },
                new Item { Name = "foo", SellIn = -1, Quality = 0 }
            );
        }

        [Fact]
        public void QualityAndSellInOfLegendaryItemsShouldNotChange()
        {
            ExpectAfterOneDay(
                new Item { Name = ItemName.BDawgKeychain, SellIn = 10, Quality = 80 },
                new Item { Name = ItemName.BDawgKeychain, SellIn = 10, Quality = 80 }
            );
        }

        [Fact]
        public void QualityOfGoodWineShouldIncreaseByOneBeforeSellDate()
        {
            ExpectAfterOneDay(
                new Item { Name = ItemName.GoodWine, SellIn = 10, Quality = 10 },
                new Item { Name = ItemName.GoodWine, SellIn = 9, Quality = 11 }
            );
        }

        [Fact]
        public void QualityOfGoodWineShouldIncreaseByTwoAfterSellDate()
        {
            ExpectAfterOneDay(
                new Item { Name = ItemName.GoodWine, SellIn = 0, Quality = 10 },
                new Item { Name = ItemName.GoodWine, SellIn = -1, Quality = 12 }
            );
        }

        [Fact]
        public void QualityOfBackstagePassesShouldBecomeZeroAfterSellDate()
        {
            ExpectAfterOneDay(
                new Item { Name = ItemName.BackstagePassesForRefactor, SellIn = 0, Quality = 10 },
                new Item { Name = ItemName.BackstagePassesForRefactor, SellIn = -1, Quality = 0 }
            );

            ExpectAfterOneDay(
                new Item { Name = ItemName.BackstagePassesForHaxx, SellIn = 0, Quality = 10 },
                new Item { Name = ItemName.BackstagePassesForHaxx, SellIn = -1, Quality = 0 }
            );
        }

        [Fact]
        public void QualityOfBackstagePassesShouldIncreaseByThreeWhenThereAre5DaysOrLessLeft()
        {
            ExpectAfterOneDay(
                new Item { Name = ItemName.BackstagePassesForRefactor, SellIn = 5, Quality = 0 },
                new Item { Name = ItemName.BackstagePassesForRefactor, SellIn = 4, Quality = 3 }
            );

            ExpectAfterOneDay(
                new Item { Name = ItemName.BackstagePassesForHaxx, SellIn = 5, Quality = 0 },
                new Item { Name = ItemName.BackstagePassesForHaxx, SellIn = 4, Quality = 3 }
            );
        }

        [Fact]
        public void QualityOfBackstagePassesShouldIncreaseByThreeWhenThereAreMoreThan5ButLessThen11DaysLeft()
        {
            ExpectAfterOneDay(
                new Item { Name = ItemName.BackstagePassesForRefactor, SellIn = 10, Quality = 0 },
                new Item { Name = ItemName.BackstagePassesForRefactor, SellIn = 9, Quality = 2 }
            );

            ExpectAfterOneDay(
                new Item { Name = ItemName.BackstagePassesForHaxx, SellIn = 10, Quality = 0 },
                new Item { Name = ItemName.BackstagePassesForHaxx, SellIn = 9, Quality = 2 }
            );
        }

        [Fact]
        public void QualityOfBackstagePassesShouldIncreaseByOneWhenThereAreMoreThan10DaysLeft()
        {
            ExpectAfterOneDay(
                new Item { Name = ItemName.BackstagePassesForRefactor, SellIn = 11, Quality = 0 },
                new Item { Name = ItemName.BackstagePassesForRefactor, SellIn = 10, Quality = 1 }
            );

            ExpectAfterOneDay(
                new Item { Name = ItemName.BackstagePassesForHaxx, SellIn = 11, Quality = 0 },
                new Item { Name = ItemName.BackstagePassesForHaxx, SellIn = 10, Quality = 1 }
            );
        }

        [Fact]
        public void QualityOfBackstagePassesShouldNotBecomeMoreThan50()
        {
            ExpectAfterOneDay(
                new Item { Name = ItemName.BackstagePassesForRefactor, SellIn = 5, Quality = 49 },
                new Item { Name = ItemName.BackstagePassesForRefactor, SellIn = 4, Quality = 50 }
            );

            ExpectAfterOneDay(
                new Item { Name = ItemName.BackstagePassesForHaxx, SellIn = 5, Quality = 49 },
                new Item { Name = ItemName.BackstagePassesForHaxx, SellIn = 4, Quality = 50 }
            );
        }

        [Fact]
        public void QualityOfCodeSmellsShouldDecreaseByTwoBeforeSellDate()
        {
            ExpectAfterOneDay(
                new Item { Name = ItemName.DuplicateCode, SellIn = 5, Quality = 10 },
                new Item { Name = ItemName.DuplicateCode, SellIn = 4, Quality = 8 }
            );

            ExpectAfterOneDay(
                new Item { Name = ItemName.LongMethods, SellIn = 5, Quality = 10 },
                new Item { Name = ItemName.LongMethods, SellIn = 4, Quality = 8 }
            );

            ExpectAfterOneDay(
                new Item { Name = ItemName.UglyVariableNames, SellIn = 5, Quality = 10 },
                new Item { Name = ItemName.UglyVariableNames, SellIn = 4, Quality = 8 }
            );
        }

        [Fact]
        public void QualityOfCodeSmellsShouldDecreaseByFourAfterSellDate()
        {
            ExpectAfterOneDay(
                new Item { Name = ItemName.DuplicateCode, SellIn = 0, Quality = 10 },
                new Item { Name = ItemName.DuplicateCode, SellIn = -1, Quality = 6 }
            );

            ExpectAfterOneDay(
                new Item { Name = ItemName.LongMethods, SellIn = 0, Quality = 10 },
                new Item { Name = ItemName.LongMethods, SellIn = -1, Quality = 6 }
            );

            ExpectAfterOneDay(
                new Item { Name = ItemName.UglyVariableNames, SellIn = 0, Quality = 10 },
                new Item { Name = ItemName.UglyVariableNames, SellIn = -1, Quality = 6 }
            );
        }

        [Fact]
        public void QualityOfCodeSmellsShouldNotBecomeNegative()
        {
            ExpectAfterOneDay(
                new Item { Name = ItemName.DuplicateCode, SellIn = 0, Quality = 3 },
                new Item { Name = ItemName.DuplicateCode, SellIn = -1, Quality = 0 }
            );

            ExpectAfterOneDay(
                new Item { Name = ItemName.LongMethods, SellIn = 0, Quality = 3 },
                new Item { Name = ItemName.LongMethods, SellIn = -1, Quality = 0 }
            );

            ExpectAfterOneDay(
                new Item { Name = ItemName.UglyVariableNames, SellIn = 0, Quality = 3 },
                new Item { Name = ItemName.UglyVariableNames, SellIn = -1, Quality = 0 }
            );
        }
    }
}