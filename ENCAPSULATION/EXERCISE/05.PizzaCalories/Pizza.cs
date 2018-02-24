using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pizza
{
    private string name;
    private List<Topping> toppings;
    private Dough dough;
    private double toppingsCalories => toppings.Sum(c => c.ToppingCalories);

    private double doughCalories => dough.DoughCalories;
    private double totalCalories => toppingsCalories + doughCalories;
    public Pizza(string name)
    {
        Name = name;
        toppings = new List<Topping>();
    }
    private string Name
    {
        set => name = Validator.ValidatePizzaName(value);
    }

    public Dough Dough
    {
        get => dough;
        set => dough = value;
    }

    public List<Topping> Toppings
    {
        get => toppings;
        set => toppings = value;
    }

    public override string ToString()
    {
        return $"{name} - {totalCalories:f2} Calories.";
    }
}
