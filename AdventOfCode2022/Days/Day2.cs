namespace AdventOfCode2022.Days;

internal class Day2
{
    private const char WIN = 'W';
    private const char LOSE = 'L';
    private const char DRAW = 'D';

    private static readonly Dictionary<char, int> points = new()
    {
        { 'X', 1 },
        { 'Y', 2 },
        { 'Z', 3 },
        { LOSE, 0 },
        { DRAW, 3 },
        { WIN, 6 }
    };
    
    private static readonly Dictionary<string, int> rules = new()
    {
        { "AY", 1 },
        { "AZ", 0 },
        { "AX", 2 },
        { "BX", 0 },
        { "BZ", 1 },
        { "BY", 2 },
        { "CX", 1 },
        { "CY", 0 },
        { "CZ", 2 },
    };
    
    private static readonly Dictionary<char, char> rulesPartTwo = new()
    {
        { 'X', LOSE }, 
        { 'Y', DRAW }, 
        { 'Z', WIN }
    };


    public static int GetResultPartOne()
    {
        List<string> _plays = GetFormatedCollection();
        int _totalScore = 0;

        foreach (var _game in _plays) 
        {
            char[] _currentGame = _game.ToCharArray();
            if (_currentGame[0].Equals('0')) continue;
            _totalScore += CalculateScore(_currentGame[0], _currentGame[2]);
        }

        return _totalScore;
    }

    public static int GetResultPartTwo()
    {
        List<string> _plays = GetFormatedCollection();
        int _totalScore = 0;

        foreach (var _game in _plays)
        {
            char[] _currentGame = _game.ToCharArray();
            if (_currentGame[0].Equals('0')) continue;
            _totalScore += CalculateScorePartWo(_currentGame[0], _currentGame[2]);
        }

        return _totalScore;
    }

    private static List<string> GetFormatedCollection() 
    {
        string _input = RequestInput.RequestInputForTheDay(2).Result;
        return _input.GetCollectionFromString<string>();
    }

    private static int CalculateScore(char player, char ourGame)
    {
        int whoWon = rules[$"{player}{ourGame}"];

        int scoreCurrentGame = whoWon switch
        {
            0 => points[LOSE],
            1 => points[WIN],
            2 => points[DRAW]
        };

        scoreCurrentGame += points[ourGame];

        return scoreCurrentGame;
    }

    private static int CalculateScorePartWo(char player, char ourGame)
    {
        char whoWon = rulesPartTwo[ourGame];

        var predictResult = whoWon switch
        {
            LOSE => rules.First(x => (x.Value == 0 && x.Key.Contains(player))),
            DRAW => rules.First(x => (x.Value == 2 && x.Key.Contains(player))),
            WIN =>  rules.First(x => (x.Value == 1 && x.Key.Contains(player)))
        };

        ourGame = predictResult.Key.ToCharArray()[1];

        int scoreCurrentGame = points[whoWon];
        scoreCurrentGame += points[ourGame];

        return scoreCurrentGame;
    }
}
