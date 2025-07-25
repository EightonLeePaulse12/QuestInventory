using System;
using System.Runtime.CompilerServices;

namespace QuestInventory
{
    class Program
    {
        // Public variables for use in entire class
        public static bool running = true;
        private static readonly List<string> inventory =  [ "Sword of Destiny", "Shield of Light", "Healing Potion", "Ring of Invisibility" ];
        // Main method to start the program
        static void Main()
        {
            int option;

            while (running)
            {
                ShowStarterMenu();
                option = int.Parse(Console.ReadLine());
                try
                {
                    HandleInventoryOperations(option);
                } catch(FormatException e)
                {
                      Console.WriteLine("Invalid input. Please enter a number.");
                }

                
            }
        }

        // Show starter menu with inventory options
        private static void ShowStarterMenu()
        {
            Console.WriteLine("Welcome to the Quest Inventory!");
            Console.WriteLine("Your current inventory:");
            Console.WriteLine("==================================");
            foreach (string item in Program.inventory)
            {
                Console.WriteLine($"- {item}");
            }
            Console.WriteLine("==================================");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Pick up an item");
            Console.WriteLine("2. Check inventory");
            Console.WriteLine("3. Use an item");
            Console.WriteLine("4. Rest (exit)");
            Console.WriteLine("5. Clear console");
        }

        // Handle all the inventory operations based on user input
        private static void HandleInventoryOperations(int option)
        {
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Please enter the name of the item you want to pick up: ");
                        string itemToAdd = Console.ReadLine();
                        PickUpAnItem(itemToAdd);
                        Console.WriteLine("Picked up " + itemToAdd + "!");
                        break;
                    case 2:
                        Console.WriteLine("Your current inventory:");
                        Console.WriteLine("==================================");
                        CheckInventory();
                        break;
                    case 3:
                        Console.WriteLine("Please enter the name of the item you want to use: ");
                        UseItem();
                        break;

                    case 4:
                        Rest();
                        break;
                    case 5:
                        ClearConsole();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

            }
        }

        // Method to pick up an item and add it to the inventory
        private static void PickUpAnItem(string item)
        {  
            inventory.Add(item);
            Console.WriteLine(item + " has been added to your inventory!");
        }

        // Method to check the current inventory
        private static void CheckInventory()
        {
            
            foreach (string item in inventory)
            {
                Console.WriteLine($"- {item}");
            }
        }

        // Method to use an item from the inventory
        private static void UseItem()
        {
            string itemToUse = Console.ReadLine();
            if(inventory.Contains(itemToUse))
            {
                inventory.RemoveAt(inventory.IndexOf(itemToUse));
            } else
            {
                Console.WriteLine(itemToUse + " is not in your inventory!");
            }

            Console.WriteLine($"You have used {itemToUse}!");
        }

        // Method to clear the console and show the starter menu again
        private static void ClearConsole()
        {
            Console.Clear();
            ShowStarterMenu();
        }

        // Method to rest and exit the game
        private static void Rest()
        {
            Console.WriteLine("You have rested and regained your strength!");
            Console.WriteLine("Exiting the game...");
            Environment.Exit(0);
            running = false;
        }

        
    }
}
