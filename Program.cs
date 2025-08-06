// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello World!");

using System;
using System.Security.Principal;


class Program
{
    static void Main(string[] args)
    {
        // This for initailizing a variable
        // string name = "Aba";
        // int age = 30;
        // System.Console.WriteLine($"My name is {name} and i'm {age} years old");

        // //This for PasswordChecker and Validation 
        // Console.Write("Enter Password: ");
        // string Password = Console.ReadLine()!;

        // Console.Write("Confirm Password: ");
        // string ConfirmPassword = Console.ReadLine()!;

        // // Console.WriteLine(Password);
        // // Console.WriteLine(ConfirmPassword);

        // if (!Password.Equals(string.Empty))
        // {
        //     if (!ConfirmPassword.Equals(string.Empty)) {
        //         if (Password.Length >= 6 && ConfirmPassword.Length >= 6)

        //             {
        //                 //i can write the next line using == instead of .Equals
        //                 if (Password.Equals(ConfirmPassword))
        //                 {
        //                     Console.WriteLine("Password Match");
        //                 }
        //                 else
        //                 {
        //                     Console.WriteLine("Password Do not Match");
        //                 }
        //             }
        //     else
        //     {
        //                 Console.WriteLine("Please Enter Atleast 6 Charaters");
        //     } 
        //     }

        //         else
        //         {
        //             Console.WriteLine("Please Enter Password Confirmation: ");
        //         }
        // }
        //  else
        // {
        //     Console.WriteLine("Please Enter Password: ");
        // }

        //Arrays

        // int num1 = 5;
        // int num2 = 10;
        // int num3 = 15;
        // int num4 = 30;

        // int[] numbers = new int[4];

        // numbers[0] = 5;
        // numbers[1] = 10;
        // numbers[2] = 15;

        // Console.Write("Enter a number: ");
        // numbers[0] = Convert.ToInt32(Console.ReadLine());
        //  Console.Write("Enter a number: ");
        // numbers[1] = Convert.ToInt32(Console.ReadLine());
        //  Console.Write("Enter a number: ");
        // numbers[2] = Convert.ToInt32(Console.ReadLine());
        //  Console.Write("Enter a number: ");
        // numbers[3] = Convert.ToInt32(Console.ReadLine());

        // Console.WriteLine($"{num1} {num2} {num3} {num4}");
        // Console.WriteLine($"{numbers[0]} {numbers[1]} {numbers[2]} {numbers[3]}");

        //USING FOR LOOP
        // for (int i = 0; i < numbers.Length; i++)
        // {
        //     Console.Write("Enter a number: ");
        //     numbers[i] = Convert.ToInt32(Console.ReadLine());
        // }

        // for (int i = 0; i < numbers.Length; i++)
        // {
        //     Console.Write($"{numbers[i]} ");
        // }
        // Console.WriteLine();

        // //USING FOREACH 
        // foreach (int num in numbers)
        // {
        //     Console.Write($"{num} ");
        // }

        //SOLVING A PROBLEM WITH ARRAY 

        const int angleCount = 3;
        int[] angles = new int[angleCount];

        for (int i = 0; i < angles.Length; i++)
        {
            Console.Write($"Enter angel {i + 1}: ");
            angles[i] = Convert.ToInt32(Console.ReadLine());
        }

        int angleSum = 0;

        foreach (int angle in angles)
        {
            angleSum += angle;
        }

        // USING THIS IS ALSO LONGER 

        // Console.Write("Enter angle 1: ");
        // int angle1 = Convert.ToInt32(Console.ReadLine());

        // Console.Write("Enter angle 2: ");
        // int angle2 = Convert.ToInt32(Console.ReadLine());

        // Console.Write("Enter angle 3: ");
        // int angle3 = Convert.ToInt32(Console.ReadLine());

        // int angleSum = angle1 + angle2 + angle3;

        //USIGN THE IF STATEMENT TO SOLVE

        // if (angleSum == 180)
        // {
        //     Console.WriteLine("Valid");
        // }
        // else
        // {
        //     Console.WriteLine("Invalid");
        // }

        //USING A SIGNLE LINE TO ALSO SOLVE THE SAME PROBLEM FOR CLEARER CODE 
        Console.WriteLine(angleSum == 180 ? "Valid" : "Invalid");

        Console.ReadLine();
    }
}