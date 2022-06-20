using System;
using System.Collections.Generic;

namespace CurrentChargeRanges
{
  public class CurrentChargeRange
  {
    public static List<int> SortInputArray(int[] inputNumbers)
    {
      List<int> sortedArray = new List<int>();
      if (inputNumbers == null)
      {
        throw new NullReferenceException("Values cannot be null");
      }
      sortedArray.AddRange(inputNumbers);
      sortedArray.Sort();

      return sortedArray;
    }
    
   public static List<Tuple<string, int>> GetRangeReadingList(List<int> sortedInputList)
    {
      int flag = 1;
      List<Tuple<string, int>> rangeReaderList = new List<Tuple<string, int>>();

      for (int index = 1; index <= sortedInputList.Count; index++)
      {
        if (index == sortedInputList.Count || IsConsecutive(sortedInputList[index - 1], sortedInputList[index]) == false)
        {
          rangeReaderList.Add(new Tuple<string, int>(sortedInputList[index - flag] + " - " + sortedInputList[index - 1], flag));

          flag = 1;
        }
        else
        {
          flag++;
        }
      }

      return rangeReaderList;
    }

    private static bool IsConsecutive(int currentValue, int nextValue)
    {
      int difference = nextValue - currentValue;
      return difference == 0 || difference == 1;
    }
  }
}
