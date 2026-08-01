// See https://aka.ms/new-console-template for more information

// Factory Method implementation
using DesignPatterns.Factory;

Console.WriteLine($"Factory Method Implementation Started -------- ");
FactoryMethod.Main();
Console.WriteLine($"Factory Method Implementation Completed -------- ");

Console.WriteLine();

Console.WriteLine($"Factory Implementation Started -------- ");
Factory.Main();
Console.WriteLine($"Factory Implementation Completed -------- ");

Console.WriteLine();

Console.WriteLine($"Inner Factory Implementation Started -------- ");
InnerFactory.Main();
Console.WriteLine($"Inner Factory Implementation Completed -------- ");

Console.WriteLine();

Console.WriteLine($"Async Factory Method Implementation Started -------- ");
await AsyncFactoryMethod.Main();
Console.WriteLine($"Async Factory Method Implementation Completed -------- ");

Console.WriteLine();

Console.WriteLine($"Abstract Factory Implementation Started -------- ");
AbstractFactory.Main();
Console.WriteLine($"Abstract Factory Implementation Completed -------- ");


