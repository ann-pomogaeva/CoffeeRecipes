// See https://aka.ms/new-console-template for more information
using CoffeeRecipes.Models;
using System.Globalization;

Console.WriteLine("Введите название кофе");
string coffeeName= Console.ReadLine(); 
Console.WriteLine($"Вы ввели {coffeeName}");

double coffeeWeightGram = GetDouble("Введите вес зерна в граммах");
Console.WriteLine($"Вес зерна {coffeeWeightGram}");
double waterWeightGram = GetDouble("Введите количество воды в проливе в граммах");
Console.WriteLine($"Вес воды {waterWeightGram}");
double grindSize = GetDouble("Введите значение помола");
Console.WriteLine($"Размер помола {grindSize}");

bool resultTemperature;
string inputTemperature;
int temperature;

do
{
    Console.WriteLine("Введите температуру пролива");
    inputTemperature = Console.ReadLine();
    resultTemperature = int.TryParse(inputTemperature, out temperature);
    if (resultTemperature == false)
    {
        Console.WriteLine($"Не получилось, попробуйте ввести еще раз");
    }
}
while(!resultTemperature);
Console.WriteLine($"Температура воды {temperature}");

Recipe firstRecipe = new Recipe();
firstRecipe.CoffeeName = coffeeName;
firstRecipe.CoffeeWeightGram = coffeeWeightGram;
firstRecipe.WaterWeightGram = waterWeightGram;
firstRecipe.Temperature = temperature;
firstRecipe.GrindSize = grindSize;

static double GetDouble(string questionForUser)
{
    string userInput;
    string userInputReplace;
    double userInputDouble;
    bool resultUserInput;

    do
    {
        Console.WriteLine(questionForUser);
        userInput = Console.ReadLine();
        userInputReplace = userInput.Replace(",", ".");
        resultUserInput = double.TryParse(userInputReplace, CultureInfo.InvariantCulture, out userInputDouble);
        if (resultUserInput == false)
        {
            Console.WriteLine($"Не получилось, попробуйте ввести еще раз");
        }
    }
    while(!resultUserInput);
    
    return userInputDouble;
}