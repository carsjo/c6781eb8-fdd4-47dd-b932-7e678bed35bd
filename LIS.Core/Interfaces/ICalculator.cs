namespace LIS.Core.Interfaces
{
    public interface ICalculator
    {
        string[] ParseStringToStringArray(string inputSequence);
        int[] ConvertStringArrayToIntArray(string[] inputSequence);
        ArraySegment<int> ComputeLongestIncreasingSubsequence(string inputSequence);
    }
}
