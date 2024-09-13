using LIS.Core.Interfaces;

namespace LIS.Core.Services
{
    internal class Calculator : ICalculator
    {
        public string[] ParseStringToStringArray(string inputSequence)
        {
            if (string.IsNullOrWhiteSpace(inputSequence))
            {
                return [];
            }

            return inputSequence.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries) ?? [];
        }

        public int[] ConvertStringArrayToIntArray(string[] inputSequence)
        {
            try
            {
                return Array.ConvertAll(inputSequence, int.Parse);
            }
            catch
            {
                return [];
            }
        }

        public int[] ComputeLongestIncreasingSubsequence(string inputSequence)
        {
            try
            {
                var stringArr = ParseStringToStringArray(inputSequence);
                if (stringArr.Length == 0)
                {
                    return [];
                }

                var intArr = ConvertStringArrayToIntArray(stringArr);
                if (intArr.Length == 0)
                {
                    return [];
                }

                var maxLength = 0;
                var maxStartIndex = 0;
                var currentStartIndex = 0;
                var currentLength = 1;

                for (var i = 1; i < intArr.Length; i++)
                {
                    if (intArr[i] > intArr[i - 1])
                    {
                        currentLength++;
                    }
                    else
                    {
                        CheckCurrentGreaterThanMax();

                        currentStartIndex = i;
                        currentLength = 1;
                    }
                }

                CheckCurrentGreaterThanMax();

                var longestSequence = new List<int>();
                for (var i = 0; i < maxLength; i++)
                {
                    longestSequence.Add(intArr[maxStartIndex + i]);
                }

                return [.. longestSequence];

                void CheckCurrentGreaterThanMax()
                {
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxStartIndex = currentStartIndex;
                    }
                }
            }
            catch
            {
                return [];
            }
        }

    }
}
