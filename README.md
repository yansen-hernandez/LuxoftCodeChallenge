# LuxoftCodeChallenge

Content

Projects Detail:

POS: Here is the console application which executes the routine to calculate the change and return the smallest number of bills and coins equal to the change due

ChangeFunction: This is a utility to be reusable in any other project which receives parameters of a certain type and returns a result of a certain type as well; (see the README file inside the project for a detailed documentation of it.)

ChangeFunction.UnitTesting: here are the unit tests for the requested routine






------------------------------------------------------------------------------------------------------------------
Function Requirement

Today’s young cashiers are increasingly unable to return the correct amount of change.  As a result, we would our POS system to calculate the correct change and display the optimum (i.e. minimum) number of bills and coins to return to the customer.

  

Your task is to write a routine that takes two inputs:

Price of the item being purchased
All bills and coins provided by the customer to pay for the item
 

The routine should return the smallest number of bills and coins equal to the change due.

 

Note: the customer may not submit an optimal number of bills and coins. For example, if the price is $5.25, they might provide one $5 bill and one $1 bill, or, they could provide one $5 bill and ten dimes ($0.10).  The only expectation is that the total of what they provide is greater that or equal to the price of the item they’re purchasing.  Your function should verify this assumption.

 

Since other engineers will be using your new function, recommend an appropriate data structure for the bills and coins. This structure should be used for the input parameter and for the returned value.  Additionally, this system will be sold around the world.  Each country will have its own denomination of bills and coins. For example, here are denomination lists for two countries where our POS might be sold:

 

US: 0.01, 0.05, 0.10, 0.25, 0.50, 1.00, 2.00, 5.00, 10.00, 20.00, 50.00, 100.00
Mexico: 0.05, 0.10, 0.20, 0.50, 1.00, 2.00, 5.00, 10.00, 20.00, 50.00, 100.00
 

You are not required to physically distinguish whether the values are bills or coins, only their numeric values.

 

When a POS terminal is sold and installed in a given country, its currency setting will be set only once as a global configuration.  It should be clear to any engineers that will be calling your routine in the future how to implement this.  Your routine should not take this as input with each call.

   

  Non-Function Requirements

Write a C# .NET console app that demonstrates your working routine
Provide comments to help future engineers use, and extend your function
Unit tests should provide complete coverage of all key aspects of your function
Common Objective Oriented principles should be applied
Your routine should perform as fast as possible
You need to have robust error handling with clearly documented exception definitions for caller of your routine
