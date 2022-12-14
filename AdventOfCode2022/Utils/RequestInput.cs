namespace AdventOfCode2022.Utils
{

    public class RequestInput
    {
        public static readonly string SESSION = ":)";

        public static List<string> GetFormatedCollection(int day)
        {
            string _input = RequestInput.RequestInputForTheDay(day).Result;
            return _input.GetCollectionFromString<string>();
        }

        public static async Task<string> RequestInputForTheDay(int day) 
        {
            Uri _uri = new (@$"https://adventofcode.com/2022/day/{day}/input");

            HttpRequestMessage _request = new(HttpMethod.Get, _uri);
            _request.Headers.Add("Cookie", $"session={SESSION}");

            using HttpClient _client = new();
            var result = await _client.SendAsync(_request);
            return await result.Content.ReadAsStringAsync();
        }
    }
}
