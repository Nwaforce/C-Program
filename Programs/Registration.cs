using System;
using System.Text.RegularExpressions;

class 
{
    static void Main()
    {
        int maxAttempts = 5;
        while (true)
        {
            bool isRegistered = false;


            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                Console.WriteLine($"Attempt {attempt} of {maxAttempts}");
                Console.WriteLine();
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
                    Console.WriteLine();
                    Console.WriteLine("Registration successful!");
                    isRegistered = true;
                    break;
                }

                else
                {
                    Console.WriteLine("Registration failed due to the following errors:");
                    if (!isNameValid)
                        Console.WriteLine("Name must be at least 3 characters long.");
                    if (!isEmailValid)
                        Console.WriteLine("Email format is invalid.");
                    if (!isPasswordValid)
                        Console.WriteLine("Password must be at least 6 characters long.");

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
            Console.WriteLine();
            if (isRegistered)
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("1. Register another user");
                Console.WriteLine("2. Exit");
                string choice = Console.ReadLine();
                if (choice == "2")
                {
                    Console.WriteLine("Goodbye!");
                    return;
                }
                else if (choice == "1")
                {
                    continue;

                }
                else
                {
                    Console.WriteLine("Exiting.");
                    return;
                }
            }
        }
    }
   public static bool ValidateName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) && name.Length >= 3;
    }

   public static bool ValidateEmail(string email)
    {
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }

   public static bool ValidatePassword(string password)
    {
        return !string.IsNullOrEmpty(password) && password.Length >= 6;
    }
}
