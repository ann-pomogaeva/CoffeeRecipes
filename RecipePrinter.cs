namespace CoffeeRecipes;
using CoffeeRecipes.Models;

public class RecipePrinter

{
    public static void PrintRecipeHeaders(List<Recipe> recipes)
    {
        int recipeNumber = 1;
        foreach (Recipe recipe in recipes)
        {
            Console.WriteLine($"{recipeNumber}. {recipe.BrewMethod} — {recipe.Roaster} — {recipe.CoffeeName}");
            recipeNumber++;
        }
    }
    public static void PrintRecipe(Recipe recipe)
    {
        int recipeMinutes = recipe.BrewTimeSecond / 60;
        int recipeSeconds = recipe.BrewTimeSecond % 60;

        Console.WriteLine($"Метод заваривания: {recipe.BrewMethod}");
        Console.WriteLine($"Обжарщик: {recipe.Roaster}");
        Console.WriteLine($"Название кофе: {recipe.CoffeeName}");
        Console.WriteLine($"Степень обжарки: {recipe.RoastLevel}");
        Console.WriteLine($"Вес зерен: {recipe.CoffeeWeightGram} г");
        Console.WriteLine($"Температура воды: {recipe.Temperature} °C" );
        Console.WriteLine($"Степень помола: {recipe.GrindSize}");
        Console.WriteLine($"Количество воды: {recipe.WaterWeightGram} г");
        Console.WriteLine($"Время пролива: {recipeMinutes}:{recipeSeconds:D2}");
        Console.WriteLine($"Комментарий: {recipe.Comment}");
    }
    public static void PrintEditMenu()
    {
        Console.WriteLine("1 — Метод заваривания");
        Console.WriteLine("2 — Обжарщик");
        Console.WriteLine("3 — Название кофе");
        Console.WriteLine("4 — Степень обжарки");
        Console.WriteLine("5 — Вес зерен");
        Console.WriteLine("6 — Температура воды");
        Console.WriteLine("7 — Степень помола");
        Console.WriteLine("8 — Количество воды");
        Console.WriteLine("9 — Время пролива");
        Console.WriteLine("10 — Комментарий");
        Console.WriteLine("11 — Сохранить изменения");
        Console.WriteLine("12 — Отменить изменения");
    }
}