using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CurrentChargeRanges
{
  public class CurrentChargeRange
  {
    public static float maximumTemparatureSensorReading = 4094;

    static Dictionary<int, SensorParameters> maximumTemperatures = new Dictionary<int, SensorParameters>
    {
      { 12, new SensorParameters {Ampere = 10f, AnalogReadings = 4094, MinValue = 0} },
      { 10, new SensorParameters {Ampere = 15f, AnalogReadings = 1022, MinValue = 511} }
    };

    public static int ConvertSensorReadingToAmps(int inputSensorReading, int bitValue)
    {
      if (inputSensorReading > maximumTemparatureSensorReading)
        throw new Exception("Input Sensor Reading exceeds the maximum value");

      if (inputSensorReading < maximumTemperatures[bitValue].MinValue)
        inputSensorReading = maximumTemperatures[bitValue].AnalogReadings - inputSensorReading;

      int amps = (int)Math.Abs(Math.Ceiling(maximumTemperatures[bitValue].Ampere * inputSensorReading / maximumTemperatures[bitValue].AnalogReadings));

      return amps;
    }

    [ExcludeFromCodeCoverage]
    public static void Main(string[] args)
    {
      List<int> sortedInputNumbers = SortInputArray(new[] { 3, 3, 5, 4, 10, 11, 12 });
      List<Tuple<string, int>> rangeReaderList = GetRangeReadingList(sortedInputNumbers);
      DisplayOnConsole(rangeReaderList);
    }


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
      int rangeTracker = 1;
      List<Tuple<string, int>> rangeReaderList = new List<Tuple<string, int>>();

      for (int index = 1; index <= sortedInputList.Count; index++)
      {
        if (index == sortedInputList.Count || IsConsecutive(sortedInputList[index - 1], sortedInputList[index]) == false)
        {
          rangeReaderList.Add(new Tuple<string, int>(sortedInputList[index - rangeTracker] + " - " + sortedInputList[index - 1], rangeTracker));

          rangeTracker = 1;
        }
        else
        {
          rangeTracker++;
        }
      }

      return rangeReaderList;
    }

    private static bool IsConsecutive(int currentValue, int nextValue)
    {
      int difference = nextValue - currentValue;
      return difference == 0 || difference == 1;
    }

    private static void DisplayOnConsole(List<Tuple<string, int>> tupleList)
    {
      Console.WriteLine("Range, \tReading");
      foreach (Tuple<string, int> tupleReadings in tupleList)
      {
        Console.WriteLine(tupleReadings.Item1 + ",  " + tupleReadings.Item2);
      }
    }
  }
}
