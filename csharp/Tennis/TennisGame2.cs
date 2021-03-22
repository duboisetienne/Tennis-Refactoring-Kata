using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _player1Point;
        private int _player2Point;

        private string _player1Result;
        private string _player2Result;

        private string _player1Name;
        private string _player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;

            _player1Point = 0;
            _player2Point = 0;

            _player1Result = "";
            _player2Result = "";
        }

        public string GetScore()
        {
            var score = "";
            if (_player1Point == _player2Point && _player1Point < 3)
            {
                if (_player1Point == 0)
                    score = "Love";
                if (_player1Point == 1)
                    score = "Fifteen";
                if (_player1Point == 2)
                    score = "Thirty";
                score += "-All";
            }
            if (_player1Point == _player2Point && _player1Point > 2)
                score = "Deuce";

            if (_player1Point > 0 && _player2Point == 0)
            {
                if (_player1Point == 1)
                    _player1Result = "Fifteen";
                if (_player1Point == 2)
                    _player1Result = "Thirty";
                if (_player1Point == 3)
                    _player1Result = "Forty";

                _player2Result = "Love";
                score = _player1Result + "-" + _player2Result;
            }
            if (_player2Point > 0 && _player1Point == 0)
            {
                if (_player2Point == 1)
                    _player2Result = "Fifteen";
                if (_player2Point == 2)
                    _player2Result = "Thirty";
                if (_player2Point == 3)
                    _player2Result = "Forty";

                _player1Result = "Love";
                score = _player1Result + "-" + _player2Result;
            }

            if (_player1Point > _player2Point && _player1Point < 4)
            {
                if (_player1Point == 2)
                    _player1Result = "Thirty";
                if (_player1Point == 3)
                    _player1Result = "Forty";
                if (_player2Point == 1)
                    _player2Result = "Fifteen";
                if (_player2Point == 2)
                    _player2Result = "Thirty";
                score = _player1Result + "-" + _player2Result;
            }
            if (_player2Point > _player1Point && _player2Point < 4)
            {
                if (_player2Point == 2)
                    _player2Result = "Thirty";
                if (_player2Point == 3)
                    _player2Result = "Forty";
                if (_player1Point == 1)
                    _player1Result = "Fifteen";
                if (_player1Point == 2)
                    _player1Result = "Thirty";
                score = _player1Result + "-" + _player2Result;
            }

            if (_player1Point > _player2Point && _player2Point >= 3)
            {
                score = "Advantage player1";
            }

            if (_player2Point > _player1Point && _player1Point >= 3)
            {
                score = "Advantage player2";
            }

            if (_player1Point >= 4 && _player2Point >= 0 && (_player1Point - _player2Point) >= 2)
            {
                score = "Win for player1";
            }
            if (_player2Point >= 4 && _player1Point >= 0 && (_player2Point - _player1Point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        public void WonPoint(string player)
        {
            if (player == _player1Name) _player1Point++;

            else if (player == _player2Name) _player2Point++;
        }
    }
}

