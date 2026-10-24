namespace CoffeeRecipes;
using CoffeeRecipes.Models;

public class RecipePrinter

{
    public static void PrintRecipeHeaders(List<Recipe> recipes)
    {
        int recipeNumber = 1;
        foreach (Recipe recipe in recipes)
        {
            string header = $"{recipeNumber}. {recipe.BrewMethod}";
            if (!string.IsNullOrWhiteSpace(recipe.Roaster))
            {
                header += $" — {recipe.Roaster}";
            }
            header += $" — {recipe.CoffeeName}";
            Console.WriteLine(header);
            recipeNumber++;
            
        }
    }
    public static void PrintRecipe(Recipe recipe)
    {
        Console.WriteLine($"Дата и время: {recipe.CreatedAt.ToString("dd.MM.yyyy HH:mm")}");
        Console.WriteLine($"Метод заваривания: {recipe.BrewMethod}");
        if (recipe.Roaster != null)
        {
            Console.WriteLine($"Обжарщик: {recipe.Roaster}");
        }
        Console.WriteLine($"Название кофе: {recipe.CoffeeName}");
        if (recipe.RoastLevel != null)
        {
            Console.WriteLine($"Степень обжарки: {recipe.RoastLevel}");
        }

        if (recipe.CoffeeWeightGram != null)
        {
            Console.WriteLine($"Вес зерен: {recipe.CoffeeWeightGram} г");
        }

        if (recipe.Temperature != null)
        {
            Console.WriteLine($"Температура воды: {recipe.Temperature} °C" );
        }

        if (recipe.GrindSize != null)
        {
            Console.WriteLine($"Степень помола: {recipe.GrindSize}");
        }
        if (recipe.WaterWeightGram != null)
        {
            Console.WriteLine($"Количество воды: {recipe.WaterWeightGram} г");
        }
        if (recipe.BrewTimeSecond != null)
        {
            int recipeMinutes = recipe.BrewTimeSecond.Value / 60;
            int recipeSeconds = recipe.BrewTimeSecond.Value % 60;
            Console.WriteLine($"Время пролива: {recipeMinutes}:{recipeSeconds:D2}");
        }

        if (recipe.Comment != null)
        {
            Console.WriteLine($"Комментарий: {recipe.Comment}");
        }
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