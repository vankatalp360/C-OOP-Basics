using System;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Characters.Enums;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public CharacterFactory()
        {
            
        }
        public Character CreateCharacter(string factionParam, string typeParam, string nameParam)
        {
            Faction faction;
            var factionCurrect = Faction.TryParse(factionParam, out faction);
            var type = typeParam;
            var name = nameParam;

            if (!factionCurrect)
            {
                throw new ArgumentException($"Invalid faction \"{factionParam}\"!");
            }
            if (type != "Warrior" && type != "Cleric")
            {
                throw new ArgumentException(/*string.Format(Inputs.InvalidCaracterType, type)*/$"Invalid character type \"{type}\"!");
            }
            if (type == "Warrior")
            {
                var warrior = new Warrior(name, faction);
                return warrior;
            }
            else
            {
                var cleric = new Cleric(name, faction);
                return cleric;
            }
            
        }
    }
}