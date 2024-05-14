using System;
using System.Collections.Generic;
using System.Linq;

public class Recipe
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<string> Steps { get; set; }

    public Recipe()
    {
        Ingredients = new List<Ingredient>();
        Steps = new List<string>();
    }

    public void DisplayRecipe()
    {
        Console.WriteLine($"Recipe: {Name}");
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} - {ingredient.Calories} calories - {ingredient.FoodGroup}");
        }
        Console.WriteLine("Steps:");
        foreach (var step in Steps)
        {
            Console.WriteLine(step);
        }
        Console.WriteLine($"Total Calories: {CalculateTotalCalories()}");
    }

    public void ScaleRecipe(double factor)
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity *= factor;
        }
    }

    public void ResetQuantities()
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity = ingredient.OriginalQuantity;
        }
    }

    public double CalculateTotalCalories()
    {
        return Ingredients.Sum(i => i.Calories * i.Quantity);
    }

    public void NotifyIfExceeds300Calories()
    {
        if (CalculateTotalCalories() > 300)
        {
            Console.WriteLine("Recipe exceeds 300 calories!");
        }
    }
}

public class Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public double Calories { get; set; }
    public string FoodGroup { get; set; }
    public double OriginalQuantity { get; set; }

    public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
        Calories = calories;
        FoodGroup = foodGroup;
        OriginalQuantity = quantity;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var recipes = new List<Recipe>();

        while (true)
        {
            Console.WriteLine("1. Is to add Recipe");
            Console.WriteLine("2. Display Recipes");
            Console.WriteLine("3. Exit");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddRecipe(recipes);
                    break;
                case "2":
                    DisplayRecipes(recipes);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    static void AddRecipe(List<Recipe> recipes)
    {
        Console.WriteLine("Enter the recipe name:");
        var name = Console.ReadLine();

        var recipe = new Recipe { Name = name };

        while (true)
        {
            Console.WriteLine("1. Is to add Ingredient");
            Console.WriteLine("2. Is to add Step");
            Console.WriteLine("3. I'm Finish");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddIngredient(recipe);
                    break;
                case "2":
                    AddStep(recipe);
                    break;
                case "3":
                    recipes.Add(recipe);
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    static void AddIngredient(Recipe recipe)
    {
        Console.WriteLine("Enter the ingredient name:");
        var name = Console.ReadLine();

        double quantity;
        while (true)
        {
            Console.WriteLine("Enter the ingredient quantity:");
            if (double.TryParse(Console.ReadLine(), out quantity))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please the enter a valid number.");
            }
        }

        Console.WriteLine("Enter the ingredient unit:");
        var unit = Console.ReadLine();

        double calories;
        while (true)
        {
            Console.WriteLine("Enter the ingredient calories:");
            if (double.TryParse(Console.ReadLine(), out calories))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid calories. Please the enter a valid number.");
            }
        }

        Console.WriteLine("Enter the ingredient food group:");
        var foodGroup = Console.ReadLine();

        recipe.Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
    }

    static void AddStep(Recipe recipe)
    {
        Console.WriteLine("Enter the step:");
        var step = Console.ReadLine();

        recipe.Steps.Add(step);
    }

    static void DisplayRecipes(List<Recipe> recipes)
    {
        Console.WriteLine("Recipes:");
        foreach (var Recipe in recipes)
        {
            Console.WriteLine(Recipe.Name);
        }

        Console.WriteLine("Enter the recipe name to display:");
        var name = Console.ReadLine();

        var recipe = recipes.FirstOrDefault(r => r.Name == name);

        if (recipe != null)
        {
            recipe.DisplayRecipe();
        }
        else
        {
            Console.WriteLine("Recipe not found");
        }
    }
}

