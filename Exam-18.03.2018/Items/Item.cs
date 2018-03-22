using System;
using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Items
{
    public abstract class Item
    {
        public int Weight { get; private set; }

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public virtual void AffectCharacter(Character character)
        {
            character.CheckIsAlive();

        }
    }
}