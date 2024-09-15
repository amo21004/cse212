public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        /*
        Plan:

        We will start the method by declaring a fixed array named multiples of type double which will be equal in size to the number represented inside the
        variable length

        We will then create a for loop that loops number of times represented by length

        So, we will name the counter i, start with 0, check whether i is less than length, if it is, we run the code within the loop and then increase i by one
        The loop ends when the condition i < length evaluates to false

        Every time the body of the loop is executed, we will multiple the number by i + 1 and store the value in index i of multiples

        Finally, we return the fixed array named multiples
        */

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        /*
        Plan:

        We will use GetRange to get the end portion and store it inside a variable named left

        We will use GetRange to get the start portion and store it inside a variable named right

        We will then concatenate the two variables and store it in a variable named rotated

        We will then use a loop to replace the values of data with that of rotated
        */
        
        List<int> left = data.GetRange(data.Count - amount, amount);

        List<int> right = data.GetRange(0, data.Count - amount);

        List<int> rotated = left.Concat(right).ToList();

        for(int i = 0; i < data.Count; i++) {
            data[i] = rotated[i];
        }
    }
}
