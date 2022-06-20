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
    
    public static List<Tuple<string, int>> GetRangeReadingList(List<int> sortedList)
    {
      List<Tuple<string, int>> rangeReaderList = new List<Tuple<string, int>>();

      return rangeReaderList;
    }
  }
}
