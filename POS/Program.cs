using System;
using System.Collections.Generic;
using System.Linq;

namespace POS
{
    public class Program
    {
        static void Main(string[] args)
        {
            ChangeFunction.Change changeFunction = new ChangeFunction.Change();
            double totalAmount = 1100;
            List<double> ClientPayment = new List<double>(new double[] { 1000,500 });
            double calulatedChange = ClientPayment.Sum() - totalAmount;

            try
            {
                string returnedDenominations = string.Join(",", changeFunction.calculateChange(totalAmount, ClientPayment).ToArray());
                string message = String.IsNullOrWhiteSpace(returnedDenominations) ? " no change is due" : " please return the following denominations " + returnedDenominations;
                Console.WriteLine("Total to pay: " + totalAmount + " Change: " + calulatedChange + message);
            }
            
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            


        }
    }
}
