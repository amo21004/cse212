using System.Diagnostics;

public class Program
{
    /*
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        var maximumItems = 100000;

        for(int i = 1; i <= 5; i++) {
            Console.WriteLine("Test #" + i);

            var fixedArrayResult = FixedArray(maximumItems);

            PrintResult("fixed", fixedArrayResult);

            var dynamicArrayResult = DynamicArray(maximumItems);

            PrintResult("dynamic", dynamicArrayResult);

            Console.WriteLine();
        }
    }

    static Stopwatch FixedArray(int maximumItems)
    {
        var sw = Stopwatch.StartNew();

        int[] fixedArray = new int[maximumItems];

        for (int i = 0; i < maximumItems; i++)
        {
            fixedArray[i] = i;
        }

        sw.Stop();

        return sw;
    }

    static Stopwatch DynamicArray(int maximumItems)
    {
        var sw = Stopwatch.StartNew();

        List<int> dynamicArray = new List<int>();

        for (int i = 0; i < maximumItems; i++)
        {
            dynamicArray.Add(i);
        }

        sw.Stop();

        return sw;
    }

    static void PrintResult(string what, Stopwatch sw)
    {
        Console.WriteLine("Time for populating a " + what + " array: " + sw.Elapsed.TotalMilliseconds + " seconds");
    }
    */

    // W02: Interview question
    static void Main(string[] args)
    {
        List<Seed> seeds = new List<Seed>{
            new Seed("Pumpkins", 5),
            new Seed("Peas", 25),
            new Seed("Strawberries", 10),
            new Seed("Tomatoes", 10),
            new Seed("Peas", 15),
            new Seed("Strawberries", 20)            
        };

        Stack<Seed> pilesOfSeeds = new Stack<Seed>();

        Random randomIndexGenerator = new Random();

        Console.WriteLine("Piles of Seeds Collected:\n\n");

        while(seeds.Count > 0) {
            var index = randomIndexGenerator.Next(0, seeds.Count);

            var seed = seeds[index];

            seeds.RemoveAt(index);

            pilesOfSeeds.Push(seed);

            Console.WriteLine(seed);
        }

        Console.WriteLine("\n\nPlanting them now!\n\n");


        while(pilesOfSeeds.Count > 0) {
            var seed = pilesOfSeeds.Pop();

            Console.WriteLine($"Planting: {seed}");
        }
    }
}

internal class Seed
{
    internal string Name { get; set; }
    internal int Quantity { get; set; }

    internal Seed(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Name} ({Quantity})";
    }
}