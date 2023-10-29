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
            foreach (var item in Items)
            {
                item.Update();
            }
        }
    }
}
