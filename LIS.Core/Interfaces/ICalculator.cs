namespace LIS.Core.Interfaces
{
    public interface ICalculator
    {
        string[] ParseStringToStringArray(string inputSequence);
        int[] ConvertStringArrayToIntArray(string[] inputSequence);
        int[] ComputeLongestIncreasingSubsequence(string inputSequence);
    }
}
