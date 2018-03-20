﻿using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Items
{
    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit() 
            :base(10)
        {
        }

        public void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Armor = character.BaseArmor;
        }
    }
}