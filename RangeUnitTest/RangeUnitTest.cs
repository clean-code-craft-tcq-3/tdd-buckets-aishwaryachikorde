using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CurrentChargeRanges;

namespace RangeUnitTest
{
  [TestClass]
  public class RangeUnitTest
  {
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

    [TestMethod]
    public void ConvertSensorReading12BitsToAmpsTest()
    {
      int sensorReading = 1146;
      int bitValue = 12;
      int amps = CurrentChargeRange.ConvertSensorReadingToAmps(sensorReading, bitValue);

      Assert.AreEqual(amps, 3);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Input Sensor Reading exceeds the maximum value")]
    public void ExceedMaximumReadingTest()
    {
      int sensorReading = 4095;
      int bitValue = 12;

      CurrentChargeRange.ConvertSensorReadingToAmps(sensorReading, bitValue);
    }

    [TestMethod]
    public void ConvertSensorReading10BitsToAmps()
    {
      int bitValue = 10;
      int sensorReading = 1022;
      int amps = CurrentChargeRange.ConvertSensorReadingToAmps(sensorReading, bitValue);

      Assert.AreEqual(amps, 15);
    }

    [TestMethod]
    public void ConvertAnalogReading10BitsToAbsoluteCurrentTest()
    {
      int bitValue = 10;
      int sensorReading = 0;
      int amps = CurrentChargeRange.ConvertSensorReadingToAmps(sensorReading, bitValue);

      Assert.AreEqual(amps, 15);
    }
  }
}
