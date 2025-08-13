using System;
using System.Security.Principal;


class PasswordValidator
{
    static void Main(string[] args)
    {
        int maxAttempts = 3;
        int attempt = 0;
        int minLength = 6;
        bool success = false;

        while (attempt < maxAttempts)
        {
            Console.Write("Enter Password: ");
            string password = Console.ReadLine()!;

            Console.Write("Confirm Password: ");
            string confirmPassword = Console.ReadLine()!;

            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(confirmPassword))
            {
                if (password.Length >= minLength && confirmPassword.Length >= minLength)
                {
                    if (password.Equals(confirmPassword))
                    {
                        Console.WriteLine("Password Match");
                        success = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Passwords do not match.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter at least 6 characters.");
                }
            }
            else
            {
                Console.WriteLine("Password fields cannot be empty.");
            }

            attempt++;
            if (attempt < maxAttempts)
            {
                Console.WriteLine($"You have {maxAttempts - attempt} attempts left.\n");
            }
        }

        if (!success)
        {
            Console.WriteLine("Too many failed attempts. Program exiting.");
        }
        Console.ReadLine();
    }
}