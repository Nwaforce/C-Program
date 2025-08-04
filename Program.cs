// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello World!");

using System;


class Program
{
    static void Main(string[] args)
    {
        // string name = "Aba";
        // int age = 30;
        // System.Console.WriteLine($"My name is {name} and i'm {age} years old");
        Console.Write("Enter Password: ");
        string Password = Console.ReadLine()!;

        Console.Write("Confirm Password: ");
        string ConfirmPassword = Console.ReadLine()!;

        // Console.WriteLine(Password);
        // Console.WriteLine(ConfirmPassword);

        if (!Password.Equals(string.Empty) && !ConfirmPassword.Equals(string.Empty))
        {
            //i can write the next line using == instead of .Equals
            if (Password.Equals(ConfirmPassword))
            {
                Console.WriteLine("Password Match");
            }
            else
            {
                Console.WriteLine("Password Do not Match");
            }
        }
        else
        {
            Console.WriteLine("Please Enter Password: ");
        }

        Console.ReadLine();

    }
}