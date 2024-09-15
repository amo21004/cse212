using System.Diagnostics;

public class Program
{
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
}