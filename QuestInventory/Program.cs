using System;
using System.Runtime.CompilerServices;

namespace QuestInventory
{
    class Program
    {
        public static bool running = true;
        private static List<string> inventory = new List<string> { "Sword of Destiny ⚔️", "Shield of Light 🛡️", "Healing Potion 🍷", "Ring of Invisibility 💍" };
        static void Main(string[] args)
        {
            
            int option;

            while (running)
            {
                showStarterMenu();
                option = int.Parse(Console.ReadLine());

                handleInventoryOperations(option);
            }
        }

        private static void showStarterMenu()
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

        private static void handleInventoryOperations(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Please enter the name of the item you want to pick up: ");
                    string itemToAdd = Console.ReadLine();
                    pickUpAnItem(itemToAdd);
                    Console.WriteLine("Picked up " + itemToAdd + "!");
                    break;
                case 2:
                    Console.WriteLine("Your current inventory:");
                    Console.WriteLine("==================================");
                    checkInventory();
                    break;
                case 3:
                    Console.WriteLine("Please enter the name of the item you want to use: ");
                    useItem();
                    break;

                case 4:
                    rest();
                    break;
                case 5:
                    clearConsole();
                    break;

            }
        }

        private static void pickUpAnItem(string item)
        {  
            inventory.Add(item);
            Console.WriteLine(item + " has been added to your inventory!");
        }

        private static void checkInventory()
        {
            
            foreach (string item in inventory)
            {
                Console.WriteLine($"- {item}");
            }
        }
        
        private static void useItem()
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

        

        private static void clearConsole()
        {
            Console.Clear();
            showStarterMenu();
        }

        private static void rest()
        {
            Console.WriteLine("You have rested and regained your strength!");
            Console.WriteLine("Exiting the game...");
            Environment.Exit(0);
            running = false;
        }

        
    }
}
