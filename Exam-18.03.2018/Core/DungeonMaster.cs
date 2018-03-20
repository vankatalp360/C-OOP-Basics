using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> Party { get; set; }
        private Stack<Item> Pool { get; set; }
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        public int LastSurvivorsRounds { get; private set; }
        public DungeonMaster()
        {
            Party = new List<Character>();
            Pool = new Stack<Item>();
            characterFactory = new CharacterFactory();
            itemFactory = new ItemFactory();
            LastSurvivorsRounds = 0;
        }

        public string JoinParty(string[] args)
        {
            var faction = args[0];
            var characterType = args[1];
            var name = args[2];
            var character = characterFactory.CreateCharacter(faction, characterType, name);
            Party.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];
            var item = itemFactory.CreateItem(itemName);
            Pool.Push(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            var character = Party.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(Inputs.CharacterNotFound, characterName));
            }
            if (!Pool.Any())
            {
                throw new InvalidOperationException($"No items left in pool!");
            }
            var item = Pool.Pop();
            character.ReceiveItem(item);
            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];
            var character = Party.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(Inputs.CharacterNotFound, characterName));
            }
            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];
            var giver = Party.FirstOrDefault(c => c.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException(string.Format(Inputs.CharacterNotFound, giverName));
            }
            var reciver = Party.FirstOrDefault(c => c.Name == receiverName);
            if (reciver == null)
            {
                throw new ArgumentException(string.Format(Inputs.CharacterNotFound, receiverName));
            }
            var item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, reciver);
            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];
            var giver = Party.FirstOrDefault(c => c.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException(string.Format(Inputs.CharacterNotFound, giverName));
            }
            var reciver = Party.FirstOrDefault(c => c.Name == receiverName);
            if (reciver == null)
            {
                throw new ArgumentException(string.Format(Inputs.CharacterNotFound, receiverName));
            }
            var item = giver.Bag.GetItem(itemName);
            giver.GiveCharacterItem(item, reciver);
            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var builder = new StringBuilder();
            foreach (var character in Party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                builder.AppendLine(character.ToString());
            }
            if (!Party.Any())
            {
                return "";
            }

            return builder.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];
            var giver = Party.FirstOrDefault(c => c.Name == attackerName);
            if (giver == null)
            {
                throw new ArgumentException(string.Format(Inputs.CharacterNotFound, attackerName));
            }
            var reciver = Party.FirstOrDefault(c => c.Name == receiverName);
            if (reciver == null)
            {
                throw new ArgumentException(string.Format(Inputs.CharacterNotFound, receiverName));
            }
            if (giver.GetType().Name != "Warrior")
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            Warrior attacker = (Warrior)giver;
            attacker.Attack(reciver);

            var builder = new StringBuilder();
            builder.AppendLine(
                $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {reciver.Health}/{reciver.BaseHealth} HP and {reciver.Armor}/{reciver.BaseArmor} AP left!");
            if (!reciver.IsAlive)
            {
                builder.AppendLine($"{reciver.Name} is dead!");
            }

            return builder.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];
            var giver = Party.FirstOrDefault(c => c.Name == healerName);
            if (giver == null)
            {
                throw new ArgumentException(string.Format(Inputs.CharacterNotFound, healerName));
            }
            var reciver = Party.FirstOrDefault(c => c.Name == healingReceiverName);
            if (reciver == null)
            {
                throw new ArgumentException(string.Format(Inputs.CharacterNotFound, healingReceiverName));
            }
            if (giver.GetType().Name != "Cleric")
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            Cleric cleric = (Cleric)giver;
            cleric.Heal(reciver);

            return
                $"{giver.Name} heals {reciver.Name} for {giver.AbilityPoints}! {reciver.Name} has {reciver.Health} health now!";
        }

        public string EndTurn(string[] str)
        {
            var builder = new StringBuilder();
            var aliveCharacters = Party.Where(c => c.IsAlive == true);
            var survivorsCount = aliveCharacters.Count();
            foreach (var character in aliveCharacters)
            {
                var healthBeforeRest = character.Health;
                character.Rest();
                builder.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");

            }
            if (survivorsCount <= 1)
            {
                LastSurvivorsRounds++;
            }
            return builder.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if (LastSurvivorsRounds > 1)
            {
                return true;
            }
            return false;
        }

    }
}