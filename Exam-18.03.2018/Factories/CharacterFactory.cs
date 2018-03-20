﻿using System;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Characters.Enums;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string type, string name)
        {
            if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            Character character;
            switch (type)
            {
                case "Warrior":
                    character = new Warrior(name, parsedFaction);
                    break;
                case "Cleric":
                    character = new Cleric(name, parsedFaction);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{type}\"!");
            }

            return character;
        }
    }
}