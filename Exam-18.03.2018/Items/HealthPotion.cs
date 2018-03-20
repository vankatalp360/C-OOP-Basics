using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Items
{
    public class HealthPotion : Item
    {
        private const int HitPointsRestored = 20;
        public HealthPotion() 
            :base(5)
        {
        }

        public void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += HitPointsRestored;
        }
    }
}