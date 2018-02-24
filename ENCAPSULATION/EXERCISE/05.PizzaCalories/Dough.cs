using System;
using System.Collections.Generic;
using System.Text;

public class Dough
{
    private string flour;
    private string bakingTechnique;
    private double weight;
    private double flourCalories;
    private double techniqueCalories;
    public double DoughCalories => 2 * weight* flourCalories * techniqueCalories;

    private string Flour
    {
        set => flourCalories = Validator.ValidateFlourType(value);
    }

    private string BakingTechnique
    {
        set => techniqueCalories = Validator.ValidateBakingTechnique(value);
    }

    private double Weight
    {
        set => weight = Validator.ValidateDoughtWeight(value);
    }

    public Dough(string flour, string technique, double weight)
    {
        Flour = flour;
        BakingTechnique = technique;
        Weight = weight;
    }
}
