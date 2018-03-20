namespace P03.WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        void AskFood();
        void Eat(IFood food);
    }
}