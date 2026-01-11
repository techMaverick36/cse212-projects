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
        double[] multiples = new double[length]; // Step 1: Create an array of doubles with the specified length
        for (int i = 0; i < length; i++) // Step 2: Loop through each index of the array
        {
            multiples[i] = number * (i + 1); // Step 3: Calculate the multiple and assign it to the current index
        }
        return multiples; // Step 4: Return the filled array
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
        int count = data.Count; // Step 1: Get the count of elements in the list
        amount = amount % count; // Step 2: Normalize the amount to avoid unnecessary rotations
        if (amount == 0) return; // Step 3: If amount is 0, no rotation is needed
        List<int> temp = new List<int>(data); // Step 4: Create a temporary copy of the original list
        for (int i = 0; i < count; i++) // Step 5: Loop through each index of the list
        {
            data[(i + amount) % count] = temp[i]; // Step 6: Calculate the new index and assign the value from the temporary list
        }
    }
}
