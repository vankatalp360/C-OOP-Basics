using System;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public ItemFactory()
        {
            
        }
        public Item CreateItem(string nameParam)
        {
            var name = nameParam;
            if (name != "HealthPotion" && name != "PoisonPotion" && name != "ArmorRepairKit")
            {
                throw new ArgumentException(/*string.Format(Inputs.InvalidItemType, name)*/$"Invalid item \"{name}\"!");
            }
            if (name == "HealthPotion")
            {
                var healthPotion = new HealthPotion();
                return healthPotion;
            }
            else if (name == "PoisonPotion")
            {
                var poisonPotion = new PoisonPotion();
                return poisonPotion;
            }
            else
            {
                var armorRepairKit = new ArmorRepairKit();
                return armorRepairKit;
            }
        }
    }
}