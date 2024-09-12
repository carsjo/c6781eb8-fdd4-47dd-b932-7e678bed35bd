using LIS.Core.Interfaces;

namespace LIS.Core.Services
{
    internal class Calculator : ICalculator
    {
        public int[] LongestIncreasingSubsequence(string inputSequence)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inputSequence))
                {
                    return [];
                }

                var stringArr = inputSequence.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                if (stringArr is null || stringArr.Length == 0)
                {
                    return [];
                }

                var intArr = Array.ConvertAll(stringArr, int.Parse);

                var longestSequence = new List<int>();
                // initialize with first int in sequence
                var currentSequence = new List<int> { intArr[0] };

                // loop index starting from second int
                for (var i = 1; i < intArr.Length; i++)
                {
                    // if the current int is greater than the last int in the current sequence
                    if (intArr[i] > currentSequence[^1])
                    {
                        // add it to the current sequence
                        currentSequence.Add(intArr[i]);
                    }
                    else
                    {   
                        CheckCurrentGreaterThanLongest();

                        // reset the current sequence to start with the current element
                        currentSequence.Clear();
                        currentSequence.Add(intArr[i]);
                    }
                }

                CheckCurrentGreaterThanLongest();

                return [..longestSequence];

                void CheckCurrentGreaterThanLongest()
                {
                    // if the current sequence is longer than the longest sequence found so far
                    if (currentSequence.Count > longestSequence.Count)
                    {
                        // update the longest sequence to be the current sequence
                        longestSequence = new List<int>(currentSequence);
                    }
                }
            }
            catch
            {
                // generic catch all
                return [];
            }
        }
    }
}
