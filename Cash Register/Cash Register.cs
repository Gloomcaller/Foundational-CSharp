using System;

class Program
{
    static void Main(string[] args)
    {
        string? readResult = null;
        bool useTestData = false;
        Console.Clear();

        int[] cashTill = new int[] { 0, 0, 0, 0 };
        int registerCheckTillTotal = 0;
        int[,] registerDailyStartingCash = new int[,] { { 1, 50 }, { 5, 20 }, { 10, 10 }, { 20, 5 } };

        int[] testData = new int[] { 6, 10, 17, 20, 31, 36, 40, 41 };
        int testCounter = 0;

        LoadTillEachMorning(registerDailyStartingCash, cashTill);

        registerCheckTillTotal = CalculateTotalCash(registerDailyStartingCash);

        LogTillStatus(cashTill);
        Console.WriteLine(TillAmountSummary(cashTill));
        Console.WriteLine($"Expected till value: {registerCheckTillTotal}\n");

        var random = new Random();

        int transactions = useTestData ? testData.Length : 10;

        while (transactions > 0)
        {
            transactions--;

            int itemCost = useTestData ? testData[testCounter++] : random.Next(2, 50);

            int[] payments = CalculatePayment(itemCost);

            Console.WriteLine($"Customer is making a ${itemCost} purchase");
            Console.WriteLine($"\t Using {payments[3]} twenty dollar bills");
            Console.WriteLine($"\t Using {payments[2]} ten dollar bills");
            Console.WriteLine($"\t Using {payments[1]} five dollar bills");
            Console.WriteLine($"\t Using {payments[0]} one dollar bills");

            try
            {
                MakeChange(itemCost, cashTill, payments);

                registerCheckTillTotal += itemCost;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Could not make transaction: {e.Message}");
            }

            Console.WriteLine(TillAmountSummary(cashTill));
            Console.WriteLine($"Expected till value: {registerCheckTillTotal}\n");
        }

        Console.WriteLine("Press the Enter key to exit");
        do
        {
            readResult = Console.ReadLine();
        } while (readResult == null);
    }

    static void LoadTillEachMorning(int[,] registerDailyStartingCash, int[] cashTill)
    {
        for (int i = 0; i < 4; i++)
        {
            cashTill[i] = registerDailyStartingCash[i, 1];
        }
    }

    static int CalculateTotalCash(int[,] registerDailyStartingCash)
    {
        int total = 0;
        for (int i = 0; i < 4; i++)
        {
            total += registerDailyStartingCash[i, 0] * registerDailyStartingCash[i, 1];
        }
        return total;
    }

    static int[] CalculatePayment(int itemCost)
    {
        int[] payments = new int[4];
        payments[3] = itemCost / 20;
        itemCost %= 20;
        payments[2] = itemCost / 10;
        itemCost %= 10;
        payments[1] = itemCost / 5;
        itemCost %= 5;
        payments[0] = itemCost;
        return payments;
    }

    static void MakeChange(int cost, int[] cashTill, int[] payments)
    {
        int amountPaid = payments[3] * 20 + payments[2] * 10 + payments[1] * 5 + payments[0];
        int changeNeeded = amountPaid - cost;

        if (changeNeeded < 0)
            throw new InvalidOperationException("Not enough money provided");

        Console.WriteLine("Cashier Returns:");

        int[] denominations = new int[] { 20, 10, 5, 1 };

        for (int i = 0; i < 4; i++)
        {
            while (changeNeeded >= denominations[i] && cashTill[i] > 0)
            {
                cashTill[i]--;
                changeNeeded -= denominations[i];
                Console.WriteLine($"\t A {denominations[i]}");
            }
        }

        if (changeNeeded > 0)
            throw new InvalidOperationException("Can't make change. Do you have anything smaller?");
    }

    static void LogTillStatus(int[] cashTill)
    {
        Console.WriteLine("The till currently has:");
        Console.WriteLine($"{cashTill[3] * 20} in twenties");
        Console.WriteLine($"{cashTill[2] * 10} in tens");
        Console.WriteLine($"{cashTill[1] * 5} in fives");
        Console.WriteLine($"{cashTill[0]} in ones\n");
    }

    static string TillAmountSummary(int[] cashTill)
    {
        return $"The till has {cashTill[3] * 20 + cashTill[2] * 10 + cashTill[1] * 5 + cashTill[0]} dollars";
    }
}