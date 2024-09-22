using System.Diagnostics;

public class Program
{
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

        Console.WriteLine("Piles of seeds collected from the garden:\n\n");

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