using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeJam2014.Round0.ProblemB
{
    static class Case
    {
        public static string Run(string rawCase)
        {
            /* T: Number of test cases
             * 
             * C: Farm price (in cookies)
             * F: Cookies per second
             * X: Number of cookies needed to win
             */

            //At least one digit followed by 1 decimal point followed by 1-5 digits
            var tokens = rawCase.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var C = Double.Parse(tokens[0]); //Farm price (in cookies)
            var F = Double.Parse(tokens[1]); //Cookies per second
            var X = Double.Parse(tokens[2]); //Number of cookies needed to win

            //----------------------------
            double cookies = 0.0;
            double farms = 0.0;
            double cookies_per_second = 2.0;
            double seconds = 0.0;



            while (cookies < X)
			{
                double win_time = SecondsUntilWin(cookies, cookies_per_second, X);
                if (win_time <= 1)
                {
                    string final_time = (seconds + win_time).ToString("0.0000000");
                    return final_time;
                }

                //Didn't win right away? Darn! We need to figure out if we can afford a farm then.. and if we can, is it worth buying?
                double potential_win_time = SecondsUntilWin(cookies - C, cookies_per_second + F, X);
                double farm_time = SecondsUntilFarmPurchase(cookies, cookies_per_second, C);

                if ((farm_time <= 1) && (potential_win_time <= win_time))
                {
                    cookies -= C;
                    farms++;

                    cookies += farm_time * cookies_per_second;
                    cookies_per_second = farms * F + 2.0;
                    seconds += farm_time;
                }
                else
                {
                    cookies += cookies_per_second;
                    cookies_per_second = farms * F + 2.0;
                    seconds++;
                }

			}



            return string.Empty;
        }

        private static double SecondsUntilFarmPurchase(double cookies, double cookies_per_second, double purchase_price)
        {
            double seconds = 0.0;
            double cookies_needed = purchase_price - cookies;
            
            seconds = cookies_needed / cookies_per_second;

            return seconds;
        }

        private static double SecondsUntilWin(double cookies, double cookies_per_second, double cookies_to_win)
        {
            double seconds = 0.0;
            double cookies_needed = cookies_to_win - cookies;

            seconds = cookies_needed / cookies_per_second;

            return seconds;
        }

    }
}
