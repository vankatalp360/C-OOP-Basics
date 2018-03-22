using System;
using System.Collections.Generic;
using System.Linq;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Bags
{
    public abstract class Bag
    {
        public int Capacity { get; private set; }
        public int Load => Items.Sum(i => i.Weight);
        public IReadOnlyCollection<Item> Items { get; private set; }

        protected Bag(int capacity)
        {
            Capacity = capacity;
            Items = new List<Item>();
        }
        public void AddItem(Item item)
        {
            var neededCapacity = Load + item.Weight;
            if (neededCapacity > Capacity)
            {
                throw new InvalidOperationException(Inputs.BagIsFull);
            }
            var items = Items.ToList();
            items.Add(item);
            Items = items;
        }

        public Item GetItem(string name)
        {
            if (!Items.Any())
            {
                throw new InvalidOperationException(Inputs.BagIsEmpty);
            }
            var item = Items.FirstOrDefault(i => i.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException(String.Format(Inputs.ItemDoesntExist, name));
            }
            var items = Items.ToList();
            items.Remove(item);
            Items = items;
            return item;
        }
    }
}