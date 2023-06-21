using DemoLibrary;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    var result = paymentProcessor.MakePayment($"Demo{i}", i);

                    Console.WriteLine(result.TransactionAmount);
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.Write("Skipped invalid record ");
                    if(e.InnerException != null) 
                    {
                        Console.WriteLine("InnerException");
                    }
                }
                catch (FormatException f)
                {
                    if(i==5) Console.Write("Formatting Issue ");
                    else
                    {
                        Console.Write($"Null value for item {i} ");
                    }
                    if (f.InnerException != null)
                    {
                        Console.WriteLine("InnerException");
                    }
                } 
                catch (Exception e)
                {
                    Console.WriteLine($"Null value for item {i} ");
                    if (e.InnerException != null)
                    {
                        Console.WriteLine("InnerException");
                    }
                }
                
            }
            Console.ReadLine();
        }
    }
} 