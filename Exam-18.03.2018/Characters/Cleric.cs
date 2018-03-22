using System;
using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Characters.Enums;
using DungeonsAndCodeWizards.Contracts;

namespace DungeonsAndCodeWizards.Characters
{
    public class Cleric : Character, IHealable
    {
        public override double RestHealMultiplier => 0.5;

        public Cleric(string name, Faction faction) 
            :base(name, 50, 25, 40, new Backpack(), faction)
        {
        }

        public void Heal(Character character)
        {
            this.CheckIsAlive();
            character.CheckIsAlive();

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException(Inputs.HealEnemy);
            }
            var healPoints = this.AbilityPoints;
            character.IncreaseHealth(healPoints);
        }
    }
}