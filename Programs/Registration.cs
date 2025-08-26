using System;
using System.Text.RegularExpressions;

public class Registration
{
    private int maxAttempts = 5;

    public bool Start()
    {
        while (true)
        {
            bool isRegistered = false;

            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                Console.WriteLine($"Attempt {attempt} of {maxAttempts}");
                Console.Write("Enter your name: ");
                string name = Console.ReadLine()!;

                Console.Write("Enter your email: ");
                string email = Console.ReadLine()!;

                Console.Write("Enter your password: ");
                string password = Console.ReadLine()!;

                bool isNameValid = ValidateName(name);
                bool isEmailValid = ValidateEmail(email);
                bool isPasswordValid = ValidatePassword(password);

                if (isNameValid && isEmailValid && isPasswordValid)
                {
                    Console.WriteLine("\nRegistration successful!");
                    isRegistered = true;
                    break;
                }
                else
                {
                    Console.WriteLine("\nRegistration failed:");
                    if (!isNameValid) Console.WriteLine(" - Name must be at least 3 characters long.");
                    if (!isEmailValid) Console.WriteLine(" - Email format is invalid.");
                    if (!isPasswordValid) Console.WriteLine(" - Password must be at least 6 characters long.");

                    if (attempt == maxAttempts)
                    {
                        Console.WriteLine("Too many failed attempts. Exiting.");
                        return false;
                    }
                }
            }

            if (isRegistered)
            {
                Console.WriteLine("\nWelcome!");
                Console.WriteLine("1. Register another user");
                Console.WriteLine("2. Continue to ATM");
                string choice = Console.ReadLine()!;

                if (choice == "2")
                    return true;
                else if (choice == "1")
                    continue;
                else
                {
                    Console.WriteLine("Exiting...");
                    return false;
                }
            }
        }
    }

    private bool ValidateName(string name) =>
        !string.IsNullOrWhiteSpace(name) && name.Length >= 3;

    private bool ValidateEmail(string email)
    {
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }

    private bool ValidatePassword(string password) =>
        !string.IsNullOrEmpty(password) && password.Length >= 6;
}
