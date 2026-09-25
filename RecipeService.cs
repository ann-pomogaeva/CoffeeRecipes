namespace CoffeeRecipes;
using CoffeeRecipes.Models;
using CoffeeRecipes.Enums;

public class RecipeService
{
    public static Recipe CreateRecipe()
    {
        BrewMethod brewMethod = InputHelper.GetBrewMethod();
        Console.WriteLine("Введите название обжарщика");
        string roaster = Console.ReadLine();
        Console.WriteLine("Введите название кофе");
        string coffeeName = Console.ReadLine();
        RoastLevel roastLevel = InputHelper.GetRoastLevel();
        double coffeeWeightGram = InputHelper.GetDouble("Введите вес зерна в граммах");
        int temperature = InputHelper.GetInt("Введите температуру воды");
        double grindSize = InputHelper.GetDouble("Введите значение помола");
        double waterWeightGram = InputHelper.GetDouble("Введите количество воды в проливе в граммах");
        int brewTimeSeconds = InputHelper.GetBrewTimeSeconds();
        Console.WriteLine("Введите комментарий");
        string comment = Console.ReadLine();
    
        Recipe recipe = new Recipe();
        recipe.CoffeeName = coffeeName;
        recipe.CoffeeWeightGram = coffeeWeightGram;
        recipe.WaterWeightGram = waterWeightGram;
        recipe.Temperature = temperature;
        recipe.GrindSize = grindSize;
        recipe.BrewMethod = brewMethod;
        recipe.Roaster = roaster;
        recipe.RoastLevel = roastLevel;
        recipe.BrewTimeSecond = brewTimeSeconds;
        recipe.Comment = comment;
        return recipe;
    }
    
    public static void EditRecipe(List<Recipe> recipes)
{
   RecipePrinter.PrintRecipeHeaders(recipes);
    
    int userNumberEdit;
    do
    {
        userNumberEdit = InputHelper.GetInt("Введите номер рецепта, чтобы изменить его");
        if (userNumberEdit < 1 || userNumberEdit > recipes.Count)
        {
            Console.WriteLine("Такого рецепта нет, попробуйте еще раз");
        }
        
    } while (userNumberEdit < 1 || userNumberEdit > recipes.Count);

    Recipe originalRecipe = recipes[userNumberEdit - 1];
    Recipe recipeToEdit = new Recipe();
    
    recipeToEdit.BrewMethod = originalRecipe.BrewMethod;
    recipeToEdit.Roaster = originalRecipe.Roaster;
    recipeToEdit.CoffeeName = originalRecipe.CoffeeName;
    recipeToEdit.RoastLevel = originalRecipe.RoastLevel;
    recipeToEdit.CoffeeWeightGram = originalRecipe.CoffeeWeightGram;
    recipeToEdit.Temperature = originalRecipe.Temperature;
    recipeToEdit.GrindSize = originalRecipe.GrindSize;
    recipeToEdit.WaterWeightGram = originalRecipe.WaterWeightGram;
    recipeToEdit.BrewTimeSecond = originalRecipe.BrewTimeSecond;
    recipeToEdit.Comment = originalRecipe.Comment;

    int editMenuChoise;
    do
    {
        RecipePrinter.PrintRecipe(recipeToEdit);
        Console.WriteLine("");
        Console.WriteLine("Введите номер поля, чтобы изменить его");
        RecipePrinter.PrintEditMenu();
        editMenuChoise = InputHelper.GetInt("");
        
        switch (editMenuChoise)
        {
            case 1:
                recipeToEdit.BrewMethod = InputHelper.GetBrewMethod();
                break;
            case 2:
                Console.WriteLine("Введите название обжарщика");
                string roaster = Console.ReadLine();
                recipeToEdit.Roaster = roaster;
                break;
            case 3:
                Console.WriteLine("Введите название кофе");
                string newCoffeeName= Console.ReadLine();
                recipeToEdit.CoffeeName = newCoffeeName;
                break;
            case 4:
                recipeToEdit.RoastLevel = InputHelper.GetRoastLevel();
                break;
            case 5:
                double newCoffeeWeightGram = InputHelper.GetDouble("Введите вес зерна в граммах");
                recipeToEdit.CoffeeWeightGram = newCoffeeWeightGram;
                break;
            case 6:
                int newTemperature = InputHelper.GetInt("Введите температуру воды");
                recipeToEdit.Temperature = newTemperature;
                break;
            case 7:
                double newGrindSize = InputHelper.GetDouble("Введите значение помола");
                recipeToEdit.GrindSize = newGrindSize;
                break;
            case 8:
                double newWaterWeightGram = InputHelper.GetDouble("Введите количество воды в проливе в граммах");
                recipeToEdit.WaterWeightGram = newWaterWeightGram;
                break;
            case 9:
                recipeToEdit.BrewTimeSecond = InputHelper.GetBrewTimeSeconds();
                break;
            case 10:
                Console.WriteLine("Введите комментарий");
                string comment = Console.ReadLine();
                recipeToEdit.Comment = comment;
                break;
            case 11:
                recipes[userNumberEdit - 1] = recipeToEdit;
                Console.WriteLine("Измененный рецепт:");
                RecipePrinter.PrintRecipe(recipeToEdit);
                break;
            case 12:
                Console.WriteLine("Изменения отменены");
                break;
        }
    } while (editMenuChoise != 11 && editMenuChoise != 12);
    
}
   public static void DeleteRecipe(List<Recipe> recipes)
    {
        int userNumberDelete;
        int deleteConfirmation;
        do
        {
            do
            {
                RecipePrinter.PrintRecipeHeaders(recipes);
                userNumberDelete = InputHelper.GetInt("Введите номер рецепта для удаления. Чтобы вернуться назад, нажмите 0");
                if (userNumberDelete < 0 || userNumberDelete > recipes.Count)
                {
                    Console.WriteLine("Такого рецепта нет, попробуйте еще раз");
                }
                else if (userNumberDelete == 0)
                {
                    return;
                }
            
            } while (userNumberDelete <0 || userNumberDelete > recipes.Count);

            do
            {
                Recipe recipeToDelete = recipes[userNumberDelete - 1];
                deleteConfirmation =
                    InputHelper.GetInt(
                        $"Вы действительно хотите удалить {recipeToDelete.CoffeeName}? Если да, нажмите 1. Если нет, нажмите 0");
                if (deleteConfirmation == 1)
                {
                    recipes.Remove(recipeToDelete);
                    Console.WriteLine("Рецепт удален");
                }
                else if (deleteConfirmation != 0)
                {
                    Console.WriteLine("Вы ввели некорректное значение");
                }
            } while (deleteConfirmation != 0 && deleteConfirmation !=1);

        } while (deleteConfirmation == 0);
    }
    
}