using CoffeeRecipes.Enums;

namespace CoffeeRecipes.Models;

public class Recipe
{
    public BrewMethod BrewMethod { get; set; }
    public string Roaster { get; set; }
    public string CoffeeName { get; set; }
    public RoastLevel RoastLevel { get; set; }
    public int Temperature { get; set; }
    public double CoffeeWeightGram { get; set; }
    public double GrindSize { get; set; }
    public double WaterWeightGram { get; set; }
    public int BrewTimeSecond { get; set; }
    public string Comment { get; set; }
}