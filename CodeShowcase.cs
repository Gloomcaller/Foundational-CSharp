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

    // FizzBuzz example
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

    // Fortune Teller example
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

    // Hero vs Monster game
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

    // IPv4 Validation
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

    // Petting Zoo Planner
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

    // RSVP Tracker
    static void RunRSVPTracker()
    {
        Console.Clear();
        Console.WriteLine("=== RSVP Tracker ===");
        // Add RSVP logic here
        Console.WriteLine("RSVP logic to be added.");
    }

    // Two Coins Finder
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
}
