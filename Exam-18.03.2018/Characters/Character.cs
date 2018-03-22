using System;
using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Characters.Enums;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Characters
{
    public abstract class Character
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Inputs.WrongName);
                }
                name = value;
            }
        }

        public double BaseHealth { get; private set; }
        public double Health { get; private set; }
        public double BaseArmor { get; private set; }
        public double Armor { get; private set; }
        public double AbilityPoints { get; private set; }
        public Bag Bag { get; private set; }
        public Faction Faction { get; private set; }
        public bool IsAlive { get; private set; }
        public virtual double RestHealMultiplier { get; protected set; }

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.RestHealMultiplier = 0.2;
            IsAlive = true;
        }
        public void TakeDamage(double hitPoints)
        {
            if (!IsAlive)
            {
                return;
            }
            var leftHitPoints = 0d;
            if (Armor > 0)
            {
                if (Armor >= hitPoints)
                {
                    Armor -= hitPoints;
                }
                else
                {
                    leftHitPoints = hitPoints - Armor;
                    Armor = 0;
                    if (Health <= hitPoints)
                    {
                        IsAlive = false;
                        Health = 0;
                    }
                    else
                    {
                        Health -= leftHitPoints;
                    }
                }
            }
            else
            {
                if (Health <= hitPoints)
                {
                    IsAlive = false;
                    Health = 0;
                }
                else
                {
                    Health -= hitPoints;
                }
            }
        }

        public void Rest()
        {
            CheckIsAlive();

            Health += BaseHealth * RestHealMultiplier;
            if (Health > BaseHealth)
            {
                Health = BaseHealth;
            }
        }

        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            if (character.IsAlive && this.IsAlive)
            {
                item.AffectCharacter(character);
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (IsAlive && character.IsAlive)
            {
                character.ReceiveItem(item);
            }
        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }
        public void IncreaseHealth(double health)
        {
            Health += health;
            if (Health > BaseHealth)
            {
                Health = BaseHealth;
            }
        }

        public void DecreaseHealth(double health)
        {
            Health -= health;
            if (Health <= 0)
            {
                Health = 0;
                IsAlive = false;
            }
        }

        public void RepairArmor()
        {
            Armor = BaseArmor;
        }

        public void CheckIsAlive()
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException(Inputs.MustBeAlive);
            }
        }

        public override string ToString()
        {
            var status = IsAlive ? "Alive" : "Dead";
            return $"{Name} - HP: {Health}/{BaseHealth}, AP: {Armor}/{BaseArmor}, Status: {status}";
        }
    }
}