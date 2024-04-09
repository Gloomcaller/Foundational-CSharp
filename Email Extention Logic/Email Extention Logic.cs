using System;

class Program
{
    static void Main()
    {
        string[,] corporate =
        {
            {"Robert", "Bavin"}, {"Simon", "Bright"},
            {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
            {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
        };

        string[,] external =
        {
            {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
            {"Shay", "Lawrence"}, {"Daren", "Valdes"}
        };

        string externalDomain = "hayworth.com";

        foreach (var employee in corporate)
        {
            DisplayEmail(employee[0], employee[1]);
        }

        foreach (var employee in external)
        {
            DisplayEmail(employee[0], employee[1], externalDomain);
        }
    }

    static void DisplayEmail(string first, string last, string domain = "contoso.com")
    {
        string email = $"{first.Substring(0, 2)}{last}".ToLower();
        Console.WriteLine($"{email}@{domain}");
    }
}
