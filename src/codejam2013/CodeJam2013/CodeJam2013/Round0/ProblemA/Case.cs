using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeJam2013.Round0.ProblemA
{
    static class Case
    {
        public static string Run(string board)
        {
            //Find horizontal wins
            for (int i = 0; i < 4; i++)
            {
                var row = board.Substring(4 * i, 4);
                
                if (IsWinner("X", row))
                    return Win("X");

                if (IsWinner("O", row))
                    return Win("O");
            }


            //Find vertical wins
            for (int i = 0; i < 4; i++)
            {
                var col = "";
                col += board.Substring(0 + i, 1);
                col += board.Substring(4 + i, 1);
                col += board.Substring(8 + i, 1);
                col += board.Substring(12 + i, 1);

                if (IsWinner("X", col))
                    return Win("X");

                if (IsWinner("O", col))
                    return Win("O");
            }
            
            //Find left-to-right diagonal wins
            var diagLTR = "";
            for (int i = 0; i < 4; i++)
            {
                diagLTR += board.Substring(i * 4 + i, 1);
            }

            if (IsWinner("X", diagLTR))
                return Win("X");

            if (IsWinner("O", diagLTR))
                return Win("O");

            //Find right-to-left diagonal wins
            var diagRTL = "";
            for (int i = 1; i <= 4; i++)
            {
                diagRTL += board.Substring(i * 4 - i, 1);
            }

            if (IsWinner("X", diagRTL))
                return Win("X");

            if (IsWinner("O", diagRTL))
                return Win("O");

            //Find incomplete games
            if (board.Any(c => c.ToString() == "."))
                return Incomplete();

            return Draw();
        }

        private static bool IsWinner(string player, string line)
        {
            return line.All(c => c.ToString().Replace("T", player) == player);
        }

        private static string Win(string player)
        {
            return player + " won";
        }

        private static string Draw()
        {
            return "Draw";
        }

        private static string Incomplete()
        {
            return "Game has not completed";
        }
    }
}
