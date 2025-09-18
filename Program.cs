using System;

class Program
{
    static void Main()
    {
        Registration reg = new Registration();
        bool registered = reg.Start();

        if (registered)
        {
            string[] languages = { "English", "French", "Spanish" };
            int attempts = 0;
            const int maxAttempts = 3;
            string language = "English";

            while (attempts < maxAttempts)
            {
                Console.WriteLine("\nChoose language:");
                Console.WriteLine("1. English\n2. French\n3. Spanish");
                // Console.Write("Enter option (1-3): ");
                string choice = Console.ReadLine() ?? "";

                if (choice == "1" || choice == "2" || choice == "3")
                {
                    language = languages[int.Parse(choice) - 1];
                    break;
                }
                else
                {
                    attempts++;
                    Console.WriteLine($"Invalid option. Please enter 1, 2, or 3. ({attempts}/{maxAttempts})");
                    if (attempts == maxAttempts)
                    {
                        Console.WriteLine("Too many invalid attempts. Exiting.");
                        return;
                    }
                }
            }

            Multilingual atm = new Multilingual();
            atm.Start(language);
        }
    }
}