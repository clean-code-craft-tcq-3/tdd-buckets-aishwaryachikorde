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
      int[] actualArray = { 1, 3, 4, 2, 6, 5 };
      List<int> sortedInputList = CurrentChargeRange.SortInputArray(actualArray);
      CollectionAssert.AreEquivalent(sortedInputList, actualArray);

      //Negative Scenario
      Assert.ThrowsException<NullReferenceException>(() => CurrentChargeRange.SortInputArray(null));
    }
  }
}
