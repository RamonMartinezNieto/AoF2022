namespace AdventOfCode2022.Days;

internal class Day4
{
    record ZonesElve(int FirstZone, int SecondZone);
    record PairElves(ZonesElve FirstElve, ZonesElve SecondElve);

    internal static (int counterZonesIn, int overLapSections) GetResultPartOne()
    {
        List<PairElves> pairOfEleves = FormatInput(RequestInput.GetFormatedCollection(4));

        int counterZonesIn = 0;
        int overLapSections = 0;

        foreach (PairElves pairOfEleve in pairOfEleves)
        {
            if (IsZoneContainerInOpposite(pairOfEleve))  
                counterZonesIn++;
                  
            
            if (IsZoneOverlap(pairOfEleve))
                overLapSections++;
            
        }

        return (counterZonesIn, overLapSections);
    }


    private static bool IsZoneOverlap(PairElves pairOfEleve)
    {
        int[] allZonesFirstElve = GetFilledArrayZones(pairOfEleve.FirstElve);
        int[] allZonesSecondElve = GetFilledArrayZones(pairOfEleve.SecondElve);

        bool resultFirstReseach = allZonesSecondElve.Any(zone => allZonesFirstElve.Contains(zone));

        return resultFirstReseach;
    }

    private static bool IsZoneContainerInOpposite(PairElves pairOfEleve)
    {
        int[] allZonesFirstElve = GetFilledArrayZones(pairOfEleve.FirstElve);
        int[] allZonesSecondElve = GetFilledArrayZones(pairOfEleve.SecondElve);

        bool resultFirstReseach = allZonesSecondElve.All(zone => allZonesFirstElve.Contains(zone));

        if (!resultFirstReseach)
            resultFirstReseach = allZonesFirstElve.All(zone => allZonesSecondElve.Contains(zone));

        return resultFirstReseach;
    }

    private static int[] GetFilledArrayZones(ZonesElve zonesElve)
    {
        int firstZone = zonesElve.FirstZone;
        int secondZone = zonesElve.SecondZone;

        int[] allZones = new int[(secondZone + 1) - firstZone];

        int index = 0;
        for (int i = firstZone; i <= secondZone; i++)
        {
            allZones[index++] = i;
        }

        return allZones;
    }

    private static List<PairElves> FormatInput(List<string> input)
    {
        List<PairElves> pairOfEleves = new();
        foreach (string pairElves in input)
        {
            if (pairElves.Equals(string.Empty)) continue;

            string[] elves = pairElves.Split(',');

            int[] zonesFirstElve = elves[0].Split('-').Select(x => int.Parse(x)).ToArray();
            int[] zonesSecondElve = elves[1].Split('-').Select(x => int.Parse(x)).ToArray();

            pairOfEleves.Add(new PairElves(
                    new ZonesElve(zonesFirstElve[0], zonesFirstElve[1]),
                    new ZonesElve(zonesSecondElve[0], zonesSecondElve[1])
                ));
        }
        return pairOfEleves;
    }

    private static List<string> GetFormatedCollection()
    {
        string _input = RequestInput.RequestInputForTheDay(4).Result;
        return _input.GetCollectionFromString<string>();
    }
}
