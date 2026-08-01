// See https://aka.ms/new-console-template for more information
using DesignPatterns.Solid;

// Open and Closed Principle
Console.WriteLine($"Open and Closed Principle Started ------ ");
OpenAndClosed.Main();
Console.WriteLine($"Open and Closed Principle Completed ------ ");

Console.WriteLine();

// Liskov Substitution Principle
Console.WriteLine($"Liskov Substitution Principle Started ------ ");
LiskovSubstitution.Main();
Console.WriteLine($"Liskov Substitution Principle Completed ------ ");

Console.WriteLine();

// Interface Seggregation Principle
Console.WriteLine($"Interface Seggregation Principle Started ------ ");
InterfaceSeggregate.Main();
Console.WriteLine($"Interface Seggregation Principle Completed ------ ");

Console.WriteLine();

// Dependency Inversion Principle
Console.WriteLine($"Dependency Inversion Principle Started ------ ");
DependencyInversion.Main();
Console.WriteLine($"Dependency Inversion Principle Completed ------ ");