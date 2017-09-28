using System;
using System.Text;

namespace task_DEV_9
{
  // Changing char sequences in strings helper.
  public class StringContentChanger
  {
    // Swapping the random char sequence from changed string by random char sequence
    // from changing string.
    // Returns new string that contains changed string after the char sequence replacement.
    public string SwapRandomCharSequence(string changed, string changing)
    {
      Random randomGenerator = new Random();

      // Replaced char sequence parameters.
      int swappedSequenceHeadPos = randomGenerator.Next(changed.Length);
      int swappedSequenceLength = randomGenerator.Next(changed.Length - swappedSequenceHeadPos + 1);

      // Replacing char sequence parameters.
      int swappingSequenceHeadPos = randomGenerator.Next(changing.Length);
      int swappingSequenceLength = randomGenerator.Next(changing.Length - swappingSequenceHeadPos + 1);

      // Build a new string of the previus changed string content and inserted random char sequence.
      StringBuilder result = new StringBuilder();
      result.Append(changed.Substring(0, swappedSequenceHeadPos))
            .Append(changing.Substring(swappingSequenceHeadPos, swappingSequenceLength))
            .Append(changed.Substring(swappedSequenceHeadPos + swappedSequenceLength));

      return result.ToString();
    }
  }
}
