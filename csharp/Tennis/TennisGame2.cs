using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _player1Point;
        private int _player2Point;

        private readonly string _player1Name;
        private readonly string _player2Name;

        private readonly Dictionary<int, string> _scoresDictionary;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;

            _player1Point = 0;
            _player2Point = 0;

            _scoresDictionary = new Dictionary<int, string>()
            {
                {0, "Love" },
                {1, "Fifteen" },
                {2, "Thirty" },
                {3, "Forty" }
            };
        }

        public string GetScore()
        {
            if (!string.IsNullOrEmpty(IsMatchWon(_player1Point,_player2Point,_player1Name,_player2Name)))
            {
                return IsMatchWon(_player1Point, _player2Point, _player1Name, _player2Name);
            }

            if (!string.IsNullOrEmpty(IsAdvantage(_player1Point, _player2Point, _player1Name, _player2Name)))
            {
                return IsAdvantage(_player1Point, _player2Point, _player1Name, _player2Name);
            }

            if (!string.IsNullOrEmpty(IsEquality(_player1Point, _player2Point)))
            {
                return IsEquality(_player1Point, _player2Point);
            }

            return _scoresDictionary[_player1Point] + "-" + _scoresDictionary[_player2Point];
        }

        private string IsMatchWon(int player1Score, int player2Score,string player1Name,string player2Name)
        {
            if (player1Score >= 4 && (player1Score - player2Score) >= 2)
            {
                return $"Win for {player1Name}";
            }

            if (player2Score >= 4 && (player2Score - player1Score) >= 2)
            {
                return $"Win for {player2Name}";
            }

            return null;
        }

        private string IsAdvantage(int player1Score, int player2Score, string player1Name, string player2Name)
        {
            if (player1Score >= 4 && (player1Score - player2Score) == 1)
            {
                return $"Advantage {player1Name}";
            }

            if (player2Score >= 4 && (player2Score - player1Score) == 1)
            {
                return $"Advantage {player2Name}";
            }

            return null;
        }

        private string IsEquality(int player1Score, int player2Score)
        {
            if (player1Score == player2Score && player1Score >= 3)
            {
                return "Deuce";
            }

            if (player1Score == player2Score && player1Score < 3)
            {
                return _scoresDictionary[player1Score] + "-All";
            }

            return null;
        }

        public void WonPoint(string player)
        {
            if (player == _player1Name) _player1Point++;

            else if (player == _player2Name) _player2Point++;
        }
    }
}

