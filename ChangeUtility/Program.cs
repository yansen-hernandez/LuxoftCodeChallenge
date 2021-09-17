using System;
using System.Linq;
using System.Configuration;

namespace ChangeUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            double[] coins = new double[] { 10000, 200 };
            Console.WriteLine(p.calculateChange(200, coins));
        }

        public string calculateChange(double amount, double[] providedCoins)
        {
            
            string sAttr = ConfigurationManager.AppSettings.Get("DenominationCoins");     
            double[] DenominationCoins = sAttr.Split(',').Select(s => Double.Parse(s)).ToArray();
            double payment = providedCoins.Sum();
            double changeAmount = payment - amount;
            string resultMessage ="";

            if (changeAmount % DenominationCoins.Min() != 0 && changeAmount < DenominationCoins.Min())
            {
                return resultMessage = "There is not a coin to give the correct change";
            }
            if (payment == 0)
            {
                return resultMessage = "Payment could no be 0";
            }

            if (amount > payment)
            {
                return resultMessage = "Payment is minnor than total amount";
            }

            Array.Reverse(DenominationCoins);

            double nearValue = DenominationCoins.Aggregate((x, y) => Math.Abs(x - changeAmount) < Math.Abs(y - changeAmount) ? x : y);
            int index = Array.IndexOf(DenominationCoins, nearValue);

            for (int i = index; i< DenominationCoins.Length; i++)
            {
                double coin = DenominationCoins[i];
                double residue = changeAmount % coin;
                double division = changeAmount / coin;

                if (division < 1 )
                {
                    continue;
                }

                if (residue == 0 || changeAmount % DenominationCoins.Min() != 0)
                {
                    resultMessage = "Correct change  should be " + Math.Round(division) + " of " + coin;
                    break;
                }
                else
                {
                    changeAmount = changeAmount - (coin * Math.Round(division));
                }
            }

            return resultMessage;

        }
    }
}
