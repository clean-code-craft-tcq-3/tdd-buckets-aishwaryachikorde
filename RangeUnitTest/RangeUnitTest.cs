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
      List<int> sortedInputList = CurrentChargeRange.SortInputArray(new[] { 1, 3, 4, 2, 6, 5 });
      CollectionAssert.AreEqual(sortedInputList, new[]{ 1, 2,3,4,5,6 });

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
       List<Tuple<string, int>> smallestRangeList = CurrentChargeRange.GetRangeReadingList(new List<int> { 1, 2 });
       CollectionAssert.AreEqual(smallestRangeList, new List<Tuple<string, int>> { new("1-2", 2) });
  }
 }
