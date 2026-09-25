using CoffeeRecipes.Enums;

namespace CoffeeRecipes;

using System.Globalization;

public class InputHelper
{
    public static int GetInt(string questionForInt)
    {
        string userInput;
        int userInputInt;
        bool resultUserInput;
    
        do
        {
            Console.WriteLine(questionForInt);
            userInput = Console.ReadLine();
            resultUserInput = int.TryParse(userInput, out userInputInt);
            if (resultUserInput == false)
            {
                Console.WriteLine($"Не получилось, попробуйте ввести еще раз");
            }
        }
        while(!resultUserInput);

        return userInputInt;
    }
    
    public static double GetDouble(string questionForUser)
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
    public static BrewMethod GetBrewMethod()
    {
        int brewMethodNumber;
        BrewMethod brewMethod = BrewMethod.Espresso;
        do
        {
            brewMethodNumber = InputHelper.GetInt("Выберите способ приготовления: 1 — Эспрессо, 2 — Воронка(V60), 3 — Дрип, 4 — Аэропресс");
            if (brewMethodNumber < 1 || brewMethodNumber > 4)
            {
                Console.WriteLine("Таких значений нет. Выберите число от 1 до 4, где 1 — Эспрессо, 2 — Воронка(V60), 3 — Дрип, 4 — Аэропресс");
            }
        } 
        while (brewMethodNumber < 1 || brewMethodNumber > 4);

        switch (brewMethodNumber)
        {
            case 1:
                brewMethod = BrewMethod.Espresso;
                break;
            case 2:
                brewMethod = BrewMethod.V60;
                break;
            case 3:
                brewMethod = BrewMethod.DripBags;
                break;
            case 4:
                brewMethod = BrewMethod.AeroPress;
                break;
        }
        return brewMethod;
    }
    
    public static RoastLevel GetRoastLevel()
    {
        int roastLevelNumber; 
        RoastLevel roastLevel = RoastLevel.Light;

        do
        {
            roastLevelNumber = InputHelper.GetInt("Выберите степень обжарки: 1 — Светлая, 2 — Средняя, 3 — Темная");
            if (roastLevelNumber < 1 || roastLevelNumber > 3)
            {
                Console.WriteLine("Таких значений нет. Попробуйте еще раз");
            }
        } 
        while (roastLevelNumber < 1 || roastLevelNumber > 3);

        switch (roastLevelNumber)
        {
            case 1:
                roastLevel = RoastLevel.Light;
                break;
            case 2:
                roastLevel = RoastLevel.Medium;
                break;
            case 3:
                roastLevel = RoastLevel.Dark;
                break;
        }

        return roastLevel;
    }
    
    public static int GetBrewTimeSeconds()
    {
        bool resultMinutes = false;
        bool resultSeconds = false;
        int minutes = 0;
        int seconds = 0;
        do
        {
            Console.WriteLine("Введите время пролива в формете минуты:секунды");
            string brewTime = Console.ReadLine();
            string[] partsTime = brewTime.Split(':');
            if (partsTime.Length != 2)
            {
                Console.WriteLine("Ошибка ввода. Попробуйте ввести значения в формате минуты:секунды еще раз");
                continue;
            }
            string minutesString = partsTime[0];
            string secondsString = partsTime[1];
            resultMinutes  = int.TryParse(minutesString, out minutes);
            resultSeconds = int.TryParse(secondsString, out seconds);
            if (seconds < 0 || seconds > 59)
            {
                Console.WriteLine("Введите корректное количество секунд");
            }

            if (minutes < 0)
            {
                Console.WriteLine("Введите корректное количество минут");
            }
        } 
        while (!resultMinutes || !resultSeconds || minutes < 0 || seconds < 0 || seconds > 59);
        int brewTimeSeconds = minutes * 60 + seconds;
        return brewTimeSeconds;
    }
}