using System;

class Program
{
    static string[] pettingZoo =
    {
        "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
        "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
        "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
    };

    static void Main(string[] args)
    {
        PlanSchoolVisit("School A");
        PlanSchoolVisit("School B", 3);
        PlanSchoolVisit("School C", 2);
    }

    static void PlanSchoolVisit(string schoolName, int groups = 6)
    {
        RandomizeAnimals();
        string[,] groupsAssigned = AssignGroup(groups);
        Console.WriteLine(schoolName);
        PrintGroups(groupsAssigned);
    }

    static void RandomizeAnimals()
    {
        Random random = new Random();

        for (int i = 0; i < pettingZoo.Length; i++)
        {
            int randomIndex = random.Next(i, pettingZoo.Length);
            string temp = pettingZoo[randomIndex];
            pettingZoo[randomIndex] = pettingZoo[i];
            pettingZoo[i] = temp;
        }
    }

    static string[,] AssignGroup(int groups = 6)
    {
        string[,] result = new string[groups, pettingZoo.Length / groups];
        int start = 0;

        for (int i = 0; i < groups; i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                result[i, j] = pettingZoo[start++];
            }
        }

        return result;
    }

    static void PrintGroups(string[,] groups)
    {
        for (int i = 0; i < groups.GetLength(0); i++)
        {
            Console.Write($"Group {i + 1}: ");
            for (int j = 0; j < groups.GetLength(1); j++)
            {
                Console.Write($"{groups[i, j]}  ");
            }
            Console.WriteLine();
        }
    }
}
