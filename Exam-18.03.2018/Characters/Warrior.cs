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
            this.CheckIsAlive();
            character.CheckIsAlive();

            if (this.Name == character.Name)
            {
                throw new InvalidOperationException(Inputs.AttackSelf);
            }
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException(string.Format(Inputs.AttackSameFaction, this.Faction));
            }
            var hitPoints = this.AbilityPoints;
            character.TakeDamage(hitPoints);
        }
    }
}