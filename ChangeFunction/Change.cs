using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ChangeFunction
{
    public class Change
    {
        public List<double> returnedChanged = new List<double>();
        private double[] getCurrencyDenomination()
        {
            // Get denomination of configured currency
            string sCoins = ConfigurationManager.AppSettings.Get("DenominationCoins");
            if (String.IsNullOrEmpty(sCoins))
            {
                throw new Exception("Currency amounts were not configured in the configuration file");
            }
            return sCoins.Split(',').Select(s => Double.Parse(s)).ToArray();
        }

        /// <summary>
        /// Calculate the smallest number of bills and coins equal to the change due.
        /// Before using this utility it is necessary that you configure the value of the currencies that are used in the country in which it will be implemented, it is necessary that in the file called app.config you register the key "DenominationCoins" and the value must be separated by commas
        /// </summary>
        /// <param name="amount"> Total price of the items being purchased </param>
        /// <param name="providedCoins">All bills and coins provided by the customer to pay for the items</param>
        /// <returns></returns>
        public List<double> calculateChange(double amount, List<double> providedCoins)
        {
            /// Get denomination of configured currency
            double[] DenominationCoins = getCurrencyDenomination();

            // Get the total amount adding the bills and coind from the client
            double payment = providedCoins.Sum();
            double changeAmount = payment - amount;

            // some exceptions

            if (payment == 0)
            {
                throw new Exception("Payment could no be 0");
                
            }

            if (payment < amount)
            {
                throw new Exception("Incomplete client payment");

            }

            if (changeAmount % DenominationCoins.Min() != 0 && changeAmount < DenominationCoins.Min())
            {
                throw new Exception("There is no coin of the required value to give the correct change");
              
            }
            

            if (amount > payment)
            {
                throw new Exception("Payment is less than the total amount");
               
            }

            // order the array of currency values descending
            Array.Reverse(DenominationCoins);

            // According to the amount of the payment, the index of the largest currency that could return
            // is searched. without needing to go through the entire array.
            double nearValue = DenominationCoins.Aggregate((x, y) => Math.Abs(x - changeAmount) < Math.Abs(y - changeAmount) ? x : y);
            int index = Array.IndexOf(DenominationCoins, nearValue);

           // go through all denomination
            for (int i = index; i < DenominationCoins.Length; i++)
            {
                // adding denominations and decresing change amount
                while (changeAmount >= DenominationCoins[i])
                {
                    changeAmount -= DenominationCoins[i];
                    
                    returnedChanged.Add(DenominationCoins[i]);
                }
            }

            // returning results
            return returnedChanged;

        }
    }
}
