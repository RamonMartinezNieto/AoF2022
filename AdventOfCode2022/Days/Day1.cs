using AdventOfCode2022.Utils;

namespace AdventOfCode2022.Days
{
    public static class Day1
    {

        public static int GetResultPartOne()
        {
            var input = RequestInput.RequestInputForTheDay(1).Result;
            
            List<int> calories = FormatInput(input);
            Dictionary<int, int> caloriesPerElve = GetCaloriesPerElve(calories);

            return caloriesPerElve.Values.Max(); 
        }
                
        public static int GetResultPartTwo()
        {
            var input = RequestInput.RequestInputForTheDay(1).Result;
            
            List<int> calories = FormatInput(input);
            Dictionary<int, int> caloriesPerElve = GetCaloriesPerElve(calories);

            int caloriesOfTrheeElvesWithMoreCalories = 0;
            for (int i = 0; i < 3; i++) 
            { 
                var keyOfMaxValue = caloriesPerElve.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
                caloriesOfTrheeElvesWithMoreCalories += caloriesPerElve[keyOfMaxValue];
                caloriesPerElve.Remove(keyOfMaxValue);
            }

            return caloriesOfTrheeElvesWithMoreCalories; 
        }

        private static List<int> FormatInput(string input)
        {
            var output = new List<int>();
            
            string[] _splitInput = input.Split("\n");

            output.AddRange(_splitInput.Select(x => 
                x.Equals(String.Empty) ? 0 : int.Parse(x)));

            return output;
        }

        private static Dictionary<int, int> GetCaloriesPerElve(List<int> calories)
        {
            Dictionary<int, int> caloriesPerElve = new();

            int sumCalories = 0;
            for (int i = 0; i < calories.Count; i++) 
            {
                if (calories[i] == 0)
                {
                    sumCalories = 0;
                    continue;
                }
                else 
                {
                    sumCalories += calories[i];
                    caloriesPerElve[i] = sumCalories;
                }
            }
            return caloriesPerElve;
        }

    }
}
