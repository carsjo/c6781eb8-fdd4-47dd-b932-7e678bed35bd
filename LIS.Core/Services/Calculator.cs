using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIS.Core.Interfaces;

namespace LIS.Core.Services
{
    internal class Calculator : ICalculator
    {
        public List<int> LongestIncreasingSubsequence(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                return [];
            }

            // Step 1: Parse the input string into an array of integers
            var cleaned = input.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var numArray = Array.ConvertAll(cleaned, int.Parse); // this will fail if the number cannot be converted to an int

            if (numArray.Length == 0)
            {
                return [];
            }

            var numsLength = numArray.Length;

            // Step 2: Initialize DP arrays
            var lengths = new int[numsLength]; // array keeps track of the length of the longest increasing subsequence ending at each index.
            var predecessors = new int[numsLength]; // array helps in reconstructing the sequence by storing indices of previous elements in the LIS.

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
    }
}
