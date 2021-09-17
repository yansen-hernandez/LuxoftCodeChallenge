using NUnit.Framework;
using System.Collections.Generic;

namespace POS.UnitTest
{
    public class Tests
    {
     
        [Test]
        public void Returns_smallest_number_of_bills_and_coins_equal_to_the_change_due()
        {
            //Arrange
            var exec = new ChangeFunction.Change();
            List<double> ExpectedChange = new List<double>(new double[] { 100, 100, 100, 100, 100 });
            List<double> ClientPayment = new List<double>(new double[] { 1000, 500, 500 });
            //Assert
            exec.calculateChange(1500, ClientPayment);
            //Act
            Assert.AreEqual(ExpectedChange, exec.returnedChanged);
        }

        [Test]
        public void Returns_empty_list_of_denomintation_because_no_change_is_due()
        {
            //Arrange
            var exec = new ChangeFunction.Change();
            List<double> ExpectedChange = new List<double>(new double[] { });
            List<double> ClientPayment = new List<double>(new double[] { 1000 });
            //Assert
            exec.calculateChange(1000, ClientPayment);
            //Act
            Assert.AreEqual(ExpectedChange, exec.returnedChanged);
        }

        [Test]
        public void Returns_Payment_could_not_be_0()
        {
            //Arrange
            var exec = new ChangeFunction.Change();
            List<double> ClientPayment = new List<double>(new double[] { 0 });
            //Assert
            Assert.Throws<System.Exception>(() => exec.calculateChange(1500, ClientPayment));

        }

        [Test]
        public void Incomplete_client_payment()
        {
            //Arrange
            var exec = new ChangeFunction.Change();
            List<double> ClientPayment = new List<double>(new double[] { 1000 });
            //Assert
            Assert.Throws<System.Exception>(() => exec.calculateChange(1500, ClientPayment));

        }

        [Test]
        public void There_is_no_coin_of_the_required_value_to_give_the_correct_change()
        {
            //Arrange
            var exec = new ChangeFunction.Change();
            List<double> ClientPayment = new List<double>(new double[] { 1000,0.0001 });
            //Assert
            Assert.Throws<System.Exception>(() => exec.calculateChange(1500, ClientPayment));

        }

        [Test]
        public void Payment_is_less_than_the_total_amount()
        {
            //Arrange
            var exec = new ChangeFunction.Change();
            List<double> ClientPayment = new List<double>(new double[] { 1000 });
            //Assert
            Assert.Throws<System.Exception>(() => exec.calculateChange(1500, ClientPayment));

        }
    }
}