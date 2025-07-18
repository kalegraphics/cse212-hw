public static class Arrays
{
        // Step 1: I Create an array of doubles with a length equal to 'length'
        // Step 2: Use a loop from 0 to length - 1
        // Step 3: In each iteration, compute the multiple: number * (i + 1)
        // Step 4: Store it in the array
      
      

    public static double[] MultiplesOf(double number, int length)
    {
        double[] result = new double[length];
        // Step 2 - 4
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
          // Step 5: Return the array
        return result;
    }

    
   
    
    
    
    public static void RotateListRight(List<int> data, int amount)
    {
       // Step 1: I Calculate the index from where to split: data.Count - amount
    int splitIndex = data.Count - amount;

     // Step 2: Get the last 'amount' items using GetRange
    List<int> endPart = data.GetRange(splitIndex, amount);

    // Step 3: Get the first part (the rest) using GetRange
    List<int> startPart = data.GetRange(0, splitIndex);

    // Step 4: Clear the original list (optional if you're modifying it in-place)
    data.Clear();

    // Step 5: Add the last part followed by the first part to form the rotated list
    data.AddRange(endPart);
    data.AddRange(startPart);

    }
}
