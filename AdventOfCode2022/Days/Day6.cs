namespace AdventOfCode2022.Days
{
    internal class Day6
    {
        List<string> Input = new();

        public Day6()
        {
            Input = RequestInput.GetFormatedCollection(6);
        }

        internal int GetResultPartOne()
            =>  GetMark(Input.First(),4);
        
        internal int GetResultPartTwo()
            => GetMark(Input.First(), 14);

        private static int GetMark(string buffer, int repeated)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                int range = i + repeated;
                var characters = buffer[i..range].ToCharArray();
                var isRepeatedAnyChar = characters
                                            .GroupBy(x => x)
                                            .Where(y => y.Count() > 1)
                                            .Any();

                if (isRepeatedAnyChar) continue;
                else return i + repeated;
            }
            throw new Exception("Any thing is wrong in the algorithm");
        }
    }
}
