using LIS.Core.Interfaces;

namespace LIS.Core.Services
{
    internal class Calculator : ICalculator
    {
        public List<int> LongestIncreasingSubsequence(string inputSequence)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inputSequence))
                {
                    return [];
                }

                // Step 1: Parse the input string into an array of integers
                var cleaned = inputSequence.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                if (cleaned is null || cleaned.Length == 0)
                {
                    return [];
                }

                // this will fail if the string cannot be converted to an int, out of scope
                var numArray = Array.ConvertAll(cleaned, int.Parse);
                var numsLength = numArray.Length;

                // Step 2: Initialize arrays
                // array keeps track of the length of the longest increasing subsequence ending at each index.
                var lengths = new int[numsLength];
                // array helps in reconstructing the sequence by storing indices of previous elements in the LIS.
                var predecessors = new int[numsLength];

                for (var i = 0; i < numsLength; i++)
                {
                    lengths[i] = 1;
                    predecessors[i] = -1;
                }

                // Step 3: Compute the LIS
                // Two nested loops compare each element with all previous elements to update the lengths and predecessors.
                for (var i = 0; i < numsLength; i++)
                {
                    for (var j = 0; j < i; j++)
                    {
                        if (numArray[i] > numArray[j] && lengths[i] < lengths[j] + 1)
                        {
                            lengths[i] = lengths[j] + 1;
                            predecessors[i] = j;
                        }
                    }
                }

                // Step 4: Find the index of the maximum length of LIS
                var maxLength = lengths.Max();
                var maxIndex = Array.IndexOf(lengths, maxLength);

                // Step 5: Reconstruct the LIS
                // Starting from the index of the maximum length, trace back using predecessors to build the LIS.
                var lis = new List<int>();

                while (maxIndex != -1)
                {
                    lis.Add(numArray[maxIndex]);
                    maxIndex = predecessors[maxIndex];
                }

                // reverse the LIS to get it in correct order
                lis.Reverse();
                return lis;
            }
            catch
            {
                // generic catch, normally you would catch specific exceptions then the Exception-class in order to reduce the StackTrace
                return [];
            }
        }
    }
}
