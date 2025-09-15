using System;
using System.Collections.Generic;

public class Multilingual
{
    private double balance = 0;
    private Dictionary<string, Dictionary<string, string>> messages;

    public Multilingual()
    {
        messages = new Dictionary<string, Dictionary<string, string>>()
        {
            {"English", new Dictionary<string, string>() {
                {"welcome", "Welcome to the ATM"},
                {"menu", "\n1. Check Balance\n2. Deposit\n3. Withdraw\n4. Exit\nChoose an option: "},
                {"balance", "Your balance is: "},
                {"deposit", "Enter deposit amount: "},
                {"withdraw", "Enter withdraw amount: "},
                {"exit", "Thank you for using the ATM!"},
                {"invalid", "Invalid option. Try again."},
                {"insufficient", "Insufficient funds!"}
            }},
            {"French", new Dictionary<string, string>() {
                {"welcome", "Bienvenue au distributeur automatique"},
                {"menu", "\n1. Vérifier le solde\n2. Dépôt\n3. Retrait\n4. Quitter\nChoisissez une option: "},
                {"balance", "Votre solde est : "},
                {"deposit", "Entrez le montant du dépôt : "},
                {"withdraw", "Entrez le montant du retrait : "},
                {"exit", "Merci d'avoir utilisé le distributeur automatique!"},
                {"invalid", "Option invalide. Réessayez."},
                {"insufficient", "Fonds insuffisants !"}
            }},
              {"Spanish", new Dictionary<string, string>() {
                {"welcome", "Bienvenido al cajero automático"},
                {"menu", "\n1. Consultar saldo\n2. Depositar\n3. Retirar\n4. Salir\nElija una opción: "},
                {"balance", "Su saldo es: "},
                {"deposit", "Ingrese el monto del depósito: "},
                {"withdraw", "Ingrese el monto del retiro: "},
                {"exit", "¡Gracias por usar el cajero automático!"},
                {"invalid", "Opción inválida. Inténtalo de nuevo."},
                {"insufficient", "¡Fondos insuficientes!"}
            }}
        };
    }

    public void Start(string language)
    {
        var msg = messages.ContainsKey(language) ? messages[language] : messages["English"];
        Console.WriteLine(msg["welcome"]);

        

        while (true)
        {
            Console.Write(msg["menu"]);
            string option = Console.ReadLine() ?? "";

            if (option == "1")
            {
                Console.WriteLine($"{msg["balance"]} ${balance}");
            }
            else if (option == "2")
            {
                Console.Write(msg["deposit"]);
                double deposit = Convert.ToDouble(Console.ReadLine());
                balance += deposit;
            }
            else if (option == "3")
            {
                Console.Write(msg["withdraw"]);
                double withdraw = Convert.ToDouble(Console.ReadLine());
                if (withdraw > balance)
                {
                    Console.WriteLine(msg["insufficient"]);
                }
                else
                {
                    balance -= withdraw;
                }
            }
            else if (option == "4")
            {
                Console.WriteLine(msg["exit"]);
                break;
            }
            else
            {
                Console.WriteLine(msg["invalid"]);
            }
        }
    }
}