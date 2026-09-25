// See https://aka.ms/new-console-template for more information
using CoffeeRecipes.Models;
using CoffeeRecipes.Enums;
using CoffeeRecipes;

List<Recipe> recipes = new List<Recipe>();

int menuChoice;

do
{
    menuChoice = InputHelper.GetInt("Выберите действие: 1 - Создать рецепт, 2 - Показать рецепты, 3 - Редактировать рецепт, 4 - Удалить рецепт, 5 - Выйти");
    switch (menuChoice)
    {
        case 1:
            Recipe newRecipe = RecipeService.CreateRecipe();
            recipes.Add(newRecipe);
            break;
        case 2:
            if (recipes.Count == 0)
            {
                Console.WriteLine("Сохраненных рецептов еще нет");
            }
            else
            {
                RecipePrinter.PrintRecipeHeaders(recipes);
                SelectRecipe(recipes);
            }
            break;
        case 3:
            if (recipes.Count == 0)
            {
                Console.WriteLine("Рецептов для редактирования еще нет");
            }
            else
            {
                RecipeService.EditRecipe(recipes);
            }
            break;
        case 4:
            if (recipes.Count == 0)
            {
                Console.WriteLine("Сохраненных рецептов еще нет");
            }

            else
            {
                RecipeService.DeleteRecipe(recipes);
            }
            
            break;
        
        case 5:
            Console.WriteLine("Программа завершена");
            break;
        default:
            Console.WriteLine("Неверный пункт меню");
            break;
    }
} while (menuChoice !=5);

static void SelectRecipe(List<Recipe> recipes)
{
    int userInputNumberRecipe;
    do
    {
        userInputNumberRecipe = InputHelper.GetInt("Введите номер рецепта, чтобы посмотреть его полностью. Введите 0, чтобы вернуться назад");
        if (userInputNumberRecipe == 0)
        {
            return;
        }

    } while (userInputNumberRecipe < 1 || userInputNumberRecipe > recipes.Count);
    RecipePrinter.PrintRecipe(recipes[userInputNumberRecipe -1]);
}
