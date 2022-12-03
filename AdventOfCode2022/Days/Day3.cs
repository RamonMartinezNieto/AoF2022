using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Days;

// ASCII
// UPPERCASE: 65 A -> 90 Z 
// LOWERCASE: 97 a -> 122 Z 

public class Day3
{
    public const int LOWERCASE_START = 97 - 1; 
    public const int UPPERCASE_START = 65 - 1; 
    


    public static int GetResultPartOne()
    {
        int result = 0; 
        var input = GetFormatedCollection();
        
        foreach (var item in input) 
        {
            if (item.Equals("")) continue;

            var _mid = item.Length / 2;
            var firstHalf = item[.._mid];
            var secondHalf = item[_mid..];

            int letterMatch = Regex.Match(secondHalf, $"[{firstHalf}]").Value.First();

            result += result += GetPointsOfLetters(letterMatch);
        }

        return result;
    }

    internal static object GetResultPartTwo()
    {
        int result = 0;
        var input = GetFormatedCollection();
        var queueElves = new Queue<string>(input);
        
        int totalElves = input.Count();
        
        while (queueElves.Any()) 
        {
            if (queueElves.Equals("")) continue;

            string[] groupOfEleves = new string[3];

            //los grupos de tres
            for (int i = 0; i < 3; i++) 
                groupOfEleves[i] = queueElves.Dequeue();

            var firstElve = groupOfEleves[0];
            var secondElve = groupOfEleves[1];
            var thirdElve = groupOfEleves[2];

            var lettersMatchWithSecondElve = Regex.Matches(secondElve, $"[{firstElve}]").ToArray();
            var lettersMatches = lettersMatchWithSecondElve.Select(x => x.Value).Distinct().ToArray();
            int matchLettersTrhreElves = Regex.Match(thirdElve, $"[{string.Join(string.Empty, lettersMatches)}]").Value.First();

            result += GetPointsOfLetters(matchLettersTrhreElves);
        }

        return result;
    }

    private static List<string> GetFormatedCollection()
    {
        string _input = RequestInput.RequestInputForTheDay(3).Result;
        return _input.GetCollectionFromString<string>();
    }

    private static int GetPointsOfLetters(int asciiLetterMatch) 
        => (asciiLetterMatch > LOWERCASE_START)
                           ? asciiLetterMatch - LOWERCASE_START
                           : (asciiLetterMatch - UPPERCASE_START) + 26;
        

    public static int GetResultPartOneSeMeFueLaPinzaConLookup()
    {
        int result = 0;
        var input = GetFormatedCollection().ToArray();

        var map = input.Select(x => {
            var _mid = x.Length / 2;
            return new KeyValuePair<string, string>(x[.._mid], x[_mid..]);
        }).ToList();

        foreach (var item in map)
        {
            var firstHalf = item.Key;
            var secondHalf = item.Value;

            if (firstHalf.Equals("")) continue;

            StringBuilder builder = new();
            builder.Append('[');
            builder.Append(firstHalf);
            builder.Append(']');

            int letterMatch = Regex.Match(secondHalf, builder.ToString()).Value.First();

            result += (letterMatch > LOWERCASE_START)
                        ? letterMatch - LOWERCASE_START
                        : (letterMatch - UPPERCASE_START) + 26;

        }

        return result;
    }
}
