using System;

class CodeShowcase
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Code Showcase Menu ===");
            Console.WriteLine("1. FizzBuzz");
            Console.WriteLine("2. Fortune Teller");
            Console.WriteLine("3. Hero vs Monster Game");
            Console.WriteLine("4. Validate IPv4 Addresses");
            Console.WriteLine("5. Petting Zoo Planner");
            Console.WriteLine("6. RSVP Tracker");
            Console.WriteLine("7. Find Two Coins for Target Change");
            Console.WriteLine("8. Cash Register");
            Console.WriteLine("9. Dice Minigame");
            Console.WriteLine("10. Email Extension Logic");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunFizzBuzz();
                    break;
                case "2":
                    RunFortuneTeller();
                    break;
                case "3":
                    RunHeroVsMonster();
                    break;
                case "4":
                    RunIPv4Validator();
                    break;
                case "5":
                    RunPettingZooPlanner();
                    break;
                case "6":
                    RunRSVPTracker();
                    break;
                case "7":
                    RunTwoCoinsFinder();
                    break;
                case "8":
                    RunCashRegister();
                    break;
                case "9":
                    RunDiceMinigame();
                    break;
                case "10":
                    RunEmailExtensionLogic();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
        }

        Console.WriteLine("Exiting program. Goodbye!");
    }
    static void RunFizzBuzz()
    {
        Console.Clear();
        Console.WriteLine("=== FizzBuzz ===");
        for (int i = 1; i < 101; i++)
        {
            if (i % 3 == 0 && i % 5 == 0) Console.Write(i + " FizzBuzz");
            else if (i % 5 == 0) Console.Write(i + " Buzz");
            else if (i % 3 == 0) Console.Write(i + " Fizz");
            else Console.Write(i);
            Console.WriteLine("");
        }
    }
    static void RunFortuneTeller()
    {
        Console.Clear();
        Console.WriteLine("=== Fortune Teller ===");
        Random random = new Random();
        int luck = random.Next(100);

        string[] text = { "You have much to", "Today is a day to", "Whatever work you do", "This is an ideal time to" };
        string[] good = { "look forward to.", "try new things!", "is likely to succeed.", "accomplish your dreams!" };
        string[] bad = { "fear.", "avoid major decisions.", "may have unexpected outcomes.", "re-evaluate your life." };
        string[] neutral = { "appreciate.", "enjoy time with friends.", "should align with your values.", "get in tune with nature." };

        void TellFortune()
        {
            Console.WriteLine("A fortune teller whispers the following words:");
            string[] fortune = (luck > 75 ? good : (luck < 25 ? bad : neutral));
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"{text[i]} {fortune[i]} ");
            }
            Console.WriteLine();
        }

        TellFortune();
        luck = random.Next(100);
        TellFortune();
    }
    static void RunHeroVsMonster()
    {
        Console.Clear();
        Console.WriteLine("=== Hero vs Monster Game ===");
        Random damage = new Random();
        int hero = 10, monster = 10;

        do
        {
            int heroDamage = damage.Next(1, 11);
            monster -= heroDamage;
            Console.WriteLine($"Monster was damaged and lost {heroDamage} health and now has {monster} health.");

            if (monster <= 0) continue;

            int monsterDamage = damage.Next(1, 11);
            hero -= monsterDamage;
            Console.WriteLine($"Hero was damaged and lost {monsterDamage} health and now has {hero} health.");
        } while (hero > 0 && monster > 0);

        Console.WriteLine(hero > monster ? "Hero wins!" : "Monster wins!");
    }
    static void RunIPv4Validator()
    {
        Console.Clear();
        Console.WriteLine("=== IPv4 Validator ===");
        string[] ipv4Input = { "107.31.1.5", "255.0.0.255", "555..0.555", "255...255" };

        foreach (string ip in ipv4Input)
        {
            string[] address = ip.Split(".", StringSplitOptions.RemoveEmptyEntries);
            bool validLength = address.Length == 4;
            bool validZeroes = true, validRange = true;

            foreach (string number in address)
            {
                if (number.Length > 1 && number.StartsWith("0")) validZeroes = false;
                if (int.TryParse(number, out int value) && (value < 0 || value > 255)) validRange = false;
            }

            if (validLength && validZeroes && validRange)
                Console.WriteLine($"{ip} is a valid IPv4 address");
            else
                Console.WriteLine($"{ip} is an invalid IPv4 address");
        }
    }
    static void RunPettingZooPlanner()
    {
        Console.Clear();
        Console.WriteLine("=== Petting Zoo Planner ===");

        string[] pettingZoo =
        {
            "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
            "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
            "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
        };

        Random random = new Random();

        void RandomizeAnimals()
        {
            for (int i = 0; i < pettingZoo.Length; i++)
            {
                int randomIndex = random.Next(i, pettingZoo.Length);
                string temp = pettingZoo[randomIndex];
                pettingZoo[randomIndex] = pettingZoo[i];
                pettingZoo[i] = temp;
            }
        }

        RandomizeAnimals();
        foreach (var animal in pettingZoo)
        {
            Console.WriteLine(animal);
        }
    }
    static void RunRSVPTracker()
    {
        string[] guestList = { "Rebecca", "Nadia", "Noor", "Jonte" };
        string[] rsvps = new string[10];
        int count = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== RSVP Tracker ===");
            Console.WriteLine("1. Add RSVP\n2. Show RSVPs\n3. Exit");
            Console.Write("Choose an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    if (Array.Exists(guestList, g => g.Equals(name, StringComparison.OrdinalIgnoreCase)) || count < rsvps.Length)
                    {
                        Console.Write("Party Size: ");
                        int.TryParse(Console.ReadLine(), out int partySize);
                        Console.Write("Allergies: ");
                        string allergies = Console.ReadLine();
                        rsvps[count++] = $"Name: {name}, Party: {partySize}, Allergies: {allergies ?? "none"}";
                        Console.WriteLine($"{name} added.");
                    }
                    else Console.WriteLine($"{name} not on the guest list or list full.");
                    break;
                case "2":
                    Console.WriteLine("RSVPs:");
                    for (int i = 0; i < count; i++) Console.WriteLine(rsvps[i]);
                    break;
                case "3": return;
                default: Console.WriteLine("Invalid option."); break;
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
    static void RunTwoCoinsFinder()
    {
        Console.Clear();
        Console.WriteLine("=== Two Coins Finder ===");

        int target = 30;
        int[] coins = new int[] { 5, 5, 50, 25, 25, 10, 5 };

        int[,] TwoCoins(int[] coins, int target)
        {
            int[,] result = new int[10, 2];
            int count = 0;

            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = i + 1; j < coins.Length; j++)
                {
                    if (coins[i] + coins[j] == target && count < result.GetLength(0))
                    {
                        result[count, 0] = i;
                        result[count, 1] = j;
                        count++;
                    }
                }
            }
            return result;
        }

        int[,] result = TwoCoins(coins, target);

        for (int i = 0; i < result.GetLength(0); i++)
        {
            if (result[i, 0] == 0 && result[i, 1] == 0) break;
            Console.WriteLine($"Change found at positions: {result[i, 0]}, {result[i, 1]}");
        }
    }
    static void RunCashRegister()
    {
        Console.Clear();
        Console.WriteLine("=== Cash Register ===");

        int[] denominations = { 50, 20, 10, 5, 1 };
        Console.Write("Enter the total amount to give change for: ");
        if (int.TryParse(Console.ReadLine(), out int amount))
        {
            Console.WriteLine($"Change for {amount}:");
            foreach (int denomination in denominations)
            {
                int count = amount / denomination;
                if (count > 0)
                {
                    Console.WriteLine($"{count} x {denomination}");
                    amount %= denomination;
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid amount entered.");
        }
    }
    static void RunDiceMinigame()
    {
        Console.Clear();
        Console.WriteLine("=== Dice Minigame ===");

        Random random = new Random();
        Console.Write("Enter the number of dice rolls: ");
        if (int.TryParse(Console.ReadLine(), out int rolls) && rolls > 0)
        {
            int total = 0;
            for (int i = 0; i < rolls; i++)
            {
                int roll = random.Next(1, 7);
                Console.WriteLine($"Roll {i + 1}: {roll}");
                total += roll;
            }
            Console.WriteLine($"Total score: {total}");
        }
        else
        {
            Console.WriteLine("Invalid number of rolls entered.");
        }
    }
    static void RunEmailExtensionLogic()
    {
        Console.Clear();
        Console.WriteLine("=== Email Extension Logic ===");

        string[] emails = { "user1@gmail.com", "user2@yahoo.com", "user3@hotmail.com", "user4@gmail.com" };
        Console.WriteLine("Emails:");
        foreach (string email in emails)
        {
            Console.WriteLine(email);
        }

        Console.Write("Enter the email domain to filter (e.g., gmail.com): ");
        string domain = Console.ReadLine();

        Console.WriteLine($"\nEmails with domain '{domain}':");
        foreach (string email in emails)
        {
            if (email.EndsWith("@" + domain))
            {
                Console.WriteLine(email);
            }
        }
    }

}
