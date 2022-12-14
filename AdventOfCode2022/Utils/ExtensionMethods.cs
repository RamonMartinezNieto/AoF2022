namespace AdventOfCode2022.Utils
{
    public static class ExtensionMethods
    {
        public static List<T> GetCollectionFromString<T>(this string input, char splitBy = '\n')
        {
            var output = new List<T>();

            string[] _splitInput = input.Split(splitBy);

            output.AddRange(_splitInput.Select(x =>
                x.Equals(string.Empty) ? 
                    (T)Convert.ChangeType(0, typeof(T)) :
                    (T)Convert.ChangeType(x, typeof(T))));

            output.RemoveAt(output.Count() -1);

            return output;
        }

    }
}
