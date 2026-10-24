namespace CoffeeRecipes;
using CoffeeRecipes.Models;
using CoffeeRecipes.Enums;

public class RecipeService
{
    public static Recipe CreateRecipe()
    {
        DateTime createdAt = DateTime.Now;
        BrewMethod brewMethod = InputHelper.GetBrewMethod();
        string? roaster = InputHelper.GetOptionalString("Введите название обжарщика");
        string coffeeName = InputHelper.GetRequiredString("Введите название кофе");
        RoastLevel? roastLevel = InputHelper.GetOptionalRoastLevel();
        double? coffeeWeightGram = InputHelper.GetOptionalDouble("Введите вес зерна в граммах");
        int? temperature = InputHelper.GetOptionalInt("Введите температуру воды");
        double? grindSize = InputHelper.GetOptionalDouble("Введите значение помола");
        double? waterWeightGram = InputHelper.GetOptionalDouble("Введите количество воды в проливе в граммах");
        int? brewTimeSeconds = InputHelper.GetOptionalBrewTimeSeconds();
        string? comment = InputHelper.GetOptionalString("Введите комментарий");

        Recipe recipe = new Recipe();
        recipe.CreatedAt = createdAt; 
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
                    recipeToEdit.Roaster = InputHelper.GetOptionalString("Введите название обжарщика");
                    break;
                case 3:
                    recipeToEdit.CoffeeName = InputHelper.GetRequiredString("Введите название (страну) кофе");
                    break;
                case 4:
                    recipeToEdit.RoastLevel = InputHelper.GetOptionalRoastLevel();
                    break;
                case 5:
                    recipeToEdit.CoffeeWeightGram = InputHelper.GetOptionalDouble("Введите вес зерна в граммах");
                    break;
                case 6:
                    recipeToEdit.Temperature = InputHelper.GetOptionalInt("Введите температуру воды");
                    break;
                case 7:
                    recipeToEdit.GrindSize = InputHelper.GetOptionalDouble("Введите значение помола");
                    break;
                case 8:
                    recipeToEdit.WaterWeightGram = InputHelper.GetOptionalDouble("Введите количество воды в проливе в граммах");
                    break;
                case 9:
                    recipeToEdit.BrewTimeSecond = InputHelper.GetOptionalBrewTimeSeconds();
                    break;
                case 10:
                    recipeToEdit.Comment = InputHelper.GetOptionalString("Введите комментарий");
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
        do
        {
            RecipePrinter.PrintRecipeHeaders(recipes);
            userNumberDelete =
                InputHelper.GetInt("Введите номер рецепта для удаления. Чтобы вернуться назад, нажмите 0");
            if (userNumberDelete == 0)
            {
                return;
            }

            if (userNumberDelete < 1 || userNumberDelete > recipes.Count)
            {
                Console.WriteLine("Такого рецепта нет, попробуйте еще раз");
            }
        } while (userNumberDelete < 1 || userNumberDelete > recipes.Count);

        Recipe recipeToDelete = recipes[userNumberDelete - 1];
        int deleteConfirmation;

        do
        {
            deleteConfirmation =
                InputHelper.GetInt(
                    $"Вы действительно хотите удалить {recipeToDelete.CoffeeName}? \n Если да, нажмите 1. Если нет, нажмите 0");
            if (deleteConfirmation == 1)
            {
                recipes.Remove(recipeToDelete);
                Console.WriteLine("Рецепт удален");
                return;
            }

            if (deleteConfirmation != 0)
            {
                Console.WriteLine("Введите 1 или 0");
            }
        } while (deleteConfirmation != 0);
    }
}