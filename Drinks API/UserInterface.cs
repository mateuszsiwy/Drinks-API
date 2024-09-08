using System;
using System.Security.Cryptography.X509Certificates;
using Spectre.Console;
using System.Linq;

namespace Drinks_API
{
    internal class UserInterface
    {
        static public async Task StartApp()
        {
            AnsiConsole.MarkupLine("[green]Welcome to the Drinks menu[/]");
            await DisplayInterface();
        }

        static public async Task DisplayInterface()
        {
            var table = new Table();

            table.AddColumn("Categories Menu");
            table.AddRow("Ordinary Drink");
            table.AddRow("Cocktail");
            table.AddRow("Shake");
            table.AddRow("Other / Unknown");
            table.AddRow("Cocoa");
            table.AddRow("Shot");
            table.AddRow("Coffee / Tea");
            table.AddRow("Homemade Liqueur");
            table.AddRow("Punch / Party Drink");
            table.AddRow("Beer");
            table.AddRow("Soft Drink");

            AnsiConsole.Write(table);

            await ProcessUserInputAsync();
        }

        static public async Task ProcessUserInputAsync()
        {
            AnsiConsole.MarkupLine("[green]Choose a category (enter the exact name):[/]");
            var input = Console.ReadLine();

            switch (input?.Trim().ToLower())
            {
                case "ordinary drink":
                    AnsiConsole.MarkupLine("[blue]You chose Ordinary Drink[/]");
                    // Call a function to handle this choice
                    break;
                case "cocktail":
                    AnsiConsole.MarkupLine("[blue]You chose Cocktail[/]");
                    break;
                case "shake":
                    AnsiConsole.MarkupLine("[blue]You chose Milk / Float / Shake[/]");
                    break;
                case "other / unknown":
                    AnsiConsole.MarkupLine("[blue]You chose Other / Unknown[/]");
                    break;
                case "cocoa":
                    AnsiConsole.MarkupLine("[blue]You chose Cocoa[/]");
                    break;
                case "shot":
                    AnsiConsole.MarkupLine("[blue]You chose Shot[/]");
                    break;
                case "coffee / tea":
                    AnsiConsole.MarkupLine("[blue]You chose Coffee / Tea[/]");
                    break;
                case "homemade liqueur":
                    AnsiConsole.MarkupLine("[blue]You chose Homemade Liqueur[/]");
                    break;
                case "punch / party drink":
                    AnsiConsole.MarkupLine("[blue]You chose Punch / Party Drink[/]");
                    break;
                case "beer":
                    AnsiConsole.MarkupLine("[blue]You chose Beer[/]");
                    break;
                case "soft drink / soda":
                    AnsiConsole.MarkupLine("[blue]You chose Soft Drink / Soda[/]");
                    break;
                default:
                    AnsiConsole.MarkupLine("[red]Invalid choice! Please choose a valid category.[/]");
                    await ProcessUserInputAsync(); // Re-prompt user for correct input
                    break;
            }

            await ShowDrinks(input);

        }

        static public async Task ShowDrinks(string category)
        {
            var operations = new Operations();
            

            try
            {
                List<Drink> drinks = await operations.GetDrinks(category);
                

                var table = new Table();
                table.AddColumn("Id");
                table.AddColumn("Drink name");

                foreach (var drink in drinks)
                {
                    table.AddRow(drink.DrinkId, drink.Name);
                }
                AnsiConsole.Write(table);

                Console.WriteLine("Please enter the name id of the drink, or type esc to return to menu");

                while (true)
                {

                    string drinkId = Console.ReadLine();

                    if(drinkId == "esc")
                    {
                        await DisplayInterface();
                    }
                    
                    bool drinkExists = drinks.Any(x => x.DrinkId == drinkId);
                    if(drinkExists)
                    {
                        await ShowDrinkInfo(drinkId);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid id");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            
        }

        static public async Task ShowDrinkInfo(string id)
        {
            var operations = new Operations();
            List<DrinkDetail> drinks = await operations.GetDrinksInfo(id);
            foreach (var drink in drinks)
            {
                
                var table = new Table();
                table.AddColumn("Property");
                table.AddColumn("Value");

                
                table.AddRow("Name", drink.Name);
                table.AddRow("Category", drink.Category);
                table.AddRow("Alcoholic", drink.Alcoholic);
                table.AddRow("Glass", drink.Glass);
                table.AddRow("Instructions", drink.Instructions);
                table.AddRow("Thumbnail", drink.Thumbnail);

                
                var ingredientsTable = new Table();
                ingredientsTable.AddColumn("Ingredient");
                ingredientsTable.AddColumn("Measure");

                AddIngredientRow(ingredientsTable, drink.Ingredient1, drink.Measure1);
                AddIngredientRow(ingredientsTable, drink.Ingredient2, drink.Measure2);
                AddIngredientRow(ingredientsTable, drink.Ingredient3, drink.Measure3);
                AddIngredientRow(ingredientsTable, drink.Ingredient4, drink.Measure4);
                AddIngredientRow(ingredientsTable, drink.Ingredient5, drink.Measure5);
                AddIngredientRow(ingredientsTable, drink.Ingredient6, drink.Measure6);
                AddIngredientRow(ingredientsTable, drink.Ingredient7, drink.Measure7);
                AddIngredientRow(ingredientsTable, drink.Ingredient8, drink.Measure8);
                AddIngredientRow(ingredientsTable, drink.Ingredient9, drink.Measure9);
                AddIngredientRow(ingredientsTable, drink.Ingredient10, drink.Measure10);
                AddIngredientRow(ingredientsTable, drink.Ingredient11, drink.Measure11);
                AddIngredientRow(ingredientsTable, drink.Ingredient12, drink.Measure12);
                AddIngredientRow(ingredientsTable, drink.Ingredient13, drink.Measure13);
                AddIngredientRow(ingredientsTable, drink.Ingredient14, drink.Measure14);
                AddIngredientRow(ingredientsTable, drink.Ingredient15, drink.Measure15);

                
                AnsiConsole.MarkupLine($"[bold underline green]Drink Details - {drink.Name}[/]");
                AnsiConsole.Write(table);
                AnsiConsole.MarkupLine("[bold underline yellow]Ingredients[/]");
                AnsiConsole.Write(ingredientsTable);
                AnsiConsole.MarkupLine("\n");
            }
        }

        private static void AddIngredientRow(Table table, string ingredient, string measure)
        {
            if (!string.IsNullOrWhiteSpace(ingredient))
            {
                table.AddRow(ingredient, string.IsNullOrWhiteSpace(measure) ? "N/A" : measure);
            }
        }
    
        


    }
}
