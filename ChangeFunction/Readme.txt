To implement this utility to calculate the change it is necessary to follow the following steps:

- Add a reference to your project
go to solution, right click, add project reference, select ChangeFunction.

-Create an instance of the Change class and consume the method calculateChange, example ...
ChangeFunction.Change object = new ChangeFunction.Change ();
object.calculateChange (totalAmount, ClientPayment);

About the calculateChange method:

Input values:
totalAmount: Total price of the items being purchased, this must be decimal type
ClientPayment: All bills and coins provided by the customer to pay for the items this must be a decimal list type, input example: List <decimal> ClientPayment = new List <decimal> (new decimal [] {1000,500} );

Output values:
This method returns a list of decimal which is the total of the change due to the customer with the denominations according to the configured currencies, example:
string returnedDenominations = string.Join (",", changeFunction.calculateChange (totalAmount, ClientPayment) .ToArray ());

Errors exception:
-Payment could not be 0
-Incomplete client payment
-There is no coin of the required value to give the correct change
-Payment is less than the total amount