namespace DungeonsAndCodeWizards
{
    public class Inputs
    {
        public static string Dead => "";
        public static string WrongName => "Name cannot be null or whitespace!";
        public static string MustBeAlive => "Must be alive to perform this action!";
        public static string BagIsFull => "Bag is full!";
        public static string BagIsEmpty => "Bag is empty!";
        public static string ItemDoesntExist => "No item with name {0} in bag!";
        public static string AttackSelf => "Cannot attack self!";
        public static string AttackSameFaction => "Friendly fire! Both characters are from {0} faction!";
        public static string HealEnemy => "Cannot heal enemy character!";
        public static string InvalidCaracterType => "Invalid character \"{0}\"!";
        public static string InvalidItemType => "Invalid item \"{0}\"!";
        public static string CharacterNotFound => "Character {0} not found!";

    }
}