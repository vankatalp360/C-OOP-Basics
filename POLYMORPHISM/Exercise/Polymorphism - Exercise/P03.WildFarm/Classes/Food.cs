using P03.WildFarm.Contracts;

namespace P03.WildFarm.Classes
{
    public abstract class Food : IFood
    {
        public Food()
        {
            
        }
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }

    }
}