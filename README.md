# CodeTest


Changes made this codetest:

1. Created a new folder called Vehicles where i store my parent vehicle class and my child classes for vehicle ergo car,motorbike.
2. Changed so we use enum instead of just passing string values for car and motorbike, for maintabillity, also changed name of Vehicle to IVehicle since its an interface.
3.  Made changes to TollCalculator class:

Changed it so we dont check for specific year 2013, instead add holidays to a list, this way we can handle fixed holidays and this is easier to maintain in my opinion.

Created separate method for checking time range (IsInTimeRange), for improving readabillity.

Added null check and empoty array check to handle edge cases in GetTollFee func.

Createed separete method for totalfee (AdjustTotalFee) for improving readabillity.

Made classes static since they dont access instance data.

4. added new testing project:

added the MSTest test framework, adapter and SDK to conduct unit tests, setup testing for car and motorbike, the implemented tests will check if we get the assumed correct toll fee value.

5. added dependency injection for Car, Motorbike and TollCalculator classes.

added so we run example in program.cs for car and motorbike
