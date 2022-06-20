using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrentChargeRanges;
using System;

namespace RangeUnitTest
{
  [TestClass]
  public class RangeUnitTest
  {
    [TestMethod]
    public void TestSortInputArray()
    {
      //Positive scenario
      List<int> sortInputList = CurrentChargeRange.SortInputArray(new[] { 1, 3, 4, 2, 6, 5 });
      CollectionAssert.AreEqual(sortInputList, new[]{ 1, 2,3,4,5,6 });

      List<int> sortSmallestList = CurrentChargeRange.SortInputArray(new[] { 4, 5 });
      CollectionAssert.AreEqual(sortSmallestList, new[] { 4, 5});

      List<int> sortNegativeList = CurrentChargeRange.SortInputArray(new[] { -1, -2, 0, 1, 5, 6 });
      CollectionAssert.AreEqual(sortNegativeList, new[] {-2,-1, 0, 1, 5, 6 });

      //Negative Scenario
      Assert.ThrowsException<NullReferenceException>(() => CurrentChargeRange.SortInputArray(null));
    }

    [TestMethod]
    public void TestGetRangeReading()
    {
      //Test with one group of consecutive numbers
      List<Tuple<string, int>> smallestRangeList = CurrentChargeRange.GetRangeReadingList(new List<int> { 1, 2 });
      CollectionAssert.AreEqual(smallestRangeList, new List<Tuple<string, int>> { new("1 - 2", 2) });

      //Test with multiple group of consecutive numbers
      List<Tuple<string, int>> multipleRangeList = CurrentChargeRange.GetRangeReadingList(new List<int> { -1, 0, 1, 2, 5, 6, 7, 79, 80 });
      CollectionAssert.AreEqual(multipleRangeList, new List<Tuple<string, int>> { new("-1 - 2", 4), new("5 - 7", 3), new("79 - 80", 2) });

      //Negative Scenario with unsorted array
      List<Tuple<string, int>> unSortedRangeList = CurrentChargeRange.GetRangeReadingList(new List<int> { 1, 0, -1, 2, 5, 6, 7, 79, 80 });
      CollectionAssert.AreNotEqual(unSortedRangeList, new List<Tuple<string, int>> { new("-1 - 2", 4), new("5 - 7", 3), new("79 - 80", 2) });
    }
  }
}
