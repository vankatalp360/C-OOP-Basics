using System;
using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Characters.Enums;
using DungeonsAndCodeWizards.Contracts;

namespace DungeonsAndCodeWizards.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) 
            :base(name, 100, 50, 40, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            this.EnsureNoFriendlyFire(character);

            character.TakeDamage(this.AbilityPoints);
        }
        private void EnsureNoFriendlyFire(Character character)
        {
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }
        }
    }
}