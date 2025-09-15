using System;

class Program
{
    static void Main()
    {
    
        Registration reg = new Registration();
        bool registered = reg.Start();

        if (registered)
        {
            {
            Console.WriteLine("\nChoose language:");
            Console.WriteLine("1. English\n2. French\n3. Spanish");
            string choice = Console.ReadLine()!;
            string language = choice switch
            {
                "2" => "French",
                "3" => "Spanish",
                _   => "English"
            };
            Multilingual  atm = new Multilingual();
            atm.Start(language); 
           }
       }
    }
}