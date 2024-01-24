# CodeTest


Changes made this codetest:

1. Created a new folder called Vehicles where i store my parent vehicle class and my child classes for vehicle ergo car,motorbike.
 
2. Changed so we use enum instead of just passing string values for car and motorbike, for maintabillity, also changed name of Vehicle to IVehicle since its an interface.

3.  Made changes to TollCalculator class:

Changed it so we dont check for specific year 2013, instead add holidays to a list, this way we can handle fixed holidays and this is easier to maintain in my opinion.

Created separate method for checking time range (IsInTimeRange), for improving readabillity.

Added null check and empty array check to handle edge cases in GetTollFee func.

Createed separete method for totalfee (AdjustTotalFee) for improving readabillity.

Made classes static since they dont access instance data.

4. added new testing project:

added the MSTest test framework, adapter and SDK to conduct unit tests, setup testing for car and motorbike, the implemented tests will check if we get the assumed correct toll fee value.

5. added dependency injection for Car, Motorbike and TollCalculator classes.

added so we run example in program.cs for car and motorbike


Why add unit testing?  
Unit testing is great, because then we can test individual units of code to see if it behaves like we want it to, so it meets our given requirements, and it also helps detect issues/bugs within that given unit. In turn it can also help with code documentation and making debugging alot easier.

What is dependency injection?  
Dependency injection is a software design pattern, it allows the creation of loosely coupled code, which helps with maintanabillity, its used to achieve inversion of control (IoC) there are 3 kinds of injections:  
Constructor Injection
Property Injection
Method Injection  

 The Dependency Injection pattern involves 3 types of classes.
    Client Class: The client class (dependent class) is a class which depends on the service class.    
    Service Class: The service class (dependency) is a class that provides service to the client class.  
    Injector Class: The injector class injects the service class object into the client class.  

Dependency Injection, involves providing the dependencies from the outside. Instead of a class creating its own dependencies, they are "injected" into the class from an external source.
