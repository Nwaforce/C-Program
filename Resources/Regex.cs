using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        int maxAttempts = 5;

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            Console.WriteLine($"Attempt {attempt} of {maxAttempts}");

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            bool isNameValid = ValidateName(name);
            bool isEmailValid = ValidateEmail(email);
            bool isPasswordValid = ValidatePassword(password);

            if (isNameValid && isEmailValid && isPasswordValid)
            {
                Console.WriteLine("Registration successful!");
                break;
            }
            else
            {
                Console.WriteLine("Registration failed due to the following errors:");
                if (!isNameValid)
                    Console.WriteLine("- Name must be at least 3 characters long.");
                if (!isEmailValid)
                    Console.WriteLine("- Email format is invalid.");
                if (!isPasswordValid)
                    Console.WriteLine("- Password must be at least 6 characters long.");
                
                if (attempt == maxAttempts)
                {
                    Console.WriteLine("Too many failed attempts. Exiting.");
                }
                else
                {
                    Console.WriteLine("Please try again.");
                }
            }
        }
    }

    static bool ValidateName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) && name.Length >= 3;
    }

    static bool ValidateEmail(string email)
    {
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }

    static bool ValidatePassword(string password)
    {
        return !string.IsNullOrEmpty(password) && password.Length >= 6;
    }
}
