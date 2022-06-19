using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RangeUnitTest
{
  [TestClass]
  public class RangeUnitTest
  {
    [TestMethod]
    public void TestSortInputArray()
    {
      List<int> expectedList = new List<int>() { 1, 2, 3, 4, 5, 6 };
      int[] actualArray = { 1, 3, 4, 2, 6, 5 };
      List<int> sortedInputList = SortInputArray(new[] {1, 3, 4, 2, 6, 5});

      CollectionAssert.AreEqual(expectedList, actualArray);
    }
  }
}
