using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static string currentLang = "en";

    // Translations stored in dictionaries
    static Dictionary<string, Dictionary<string, string>> translations = new()
    {
        ["en"] = new()
        {
            ["welcome"] = "Welcome to the ATM!",
            ["chooseLang"] = "Select language:",
            ["option1"] = "1) English",
            ["option2"] = "2) Français",
            ["option3"] = "3) Español",
            ["enterPin"] = "Enter your PIN:",
            ["wrongPin"] = "Incorrect PIN. Try again.",
            ["menu"] = "ATM Menu:",
            ["balance"] = "1) Check Balance",
            ["deposit"] = "2) Deposit",
            ["withdraw"] = "3) Withdraw",
            ["exit"] = "4) Exit",
            ["currentBalance"] = "Your current balance is: {0:C}",
            ["enterAmount"] = "Enter amount:",
            ["depositSuccess"] = "Deposit successful!",
            ["withdrawSuccess"] = "Withdrawal successful!",
            ["insufficientFunds"] = "Insufficient funds!",
            ["goodbye"] = "Thank you for using our ATM!"
        },
        ["fr"] = new()
        {
            ["welcome"] = "Bienvenue au distributeur automatique!",
            ["chooseLang"] = "Sélectionnez la langue:",
            ["option1"] = "1) Anglais",
            ["option2"] = "2) Français",
            ["option3"] = "3) Espagnol",
            ["enterPin"] = "Entrez votre code PIN:",
            ["wrongPin"] = "PIN incorrect. Réessayez.",
            ["menu"] = "Menu du distributeur:",
            ["balance"] = "1) Vérifier le solde",
            ["deposit"] = "2) Dépôt",
            ["withdraw"] = "3) Retrait",
            ["exit"] = "4) Quitter",
            ["currentBalance"] = "Votre solde actuel est: {0:C}",
            ["enterAmount"] = "Entrez le montant:",
            ["depositSuccess"] = "Dépôt réussi!",
            ["withdrawSuccess"] = "Retrait réussi!",
            ["insufficientFunds"] = "Fonds insuffisants!",
            ["goodbye"] = "Merci d'avoir utilisé notre distributeur!"
        },
        ["es"] = new()
        {
            ["welcome"] = "¡Bienvenido al cajero automático!",
            ["chooseLang"] = "Seleccione el idioma:",
            ["option1"] = "1) Inglés",
            ["option2"] = "2) Francés",
            ["option3"] = "3) Español",
            ["enterPin"] = "Ingrese su PIN:",
            ["wrongPin"] = "PIN incorrecto. Inténtelo de nuevo.",
            ["menu"] = "Menú del cajero:",
            ["balance"] = "1) Consultar saldo",
            ["deposit"] = "2) Depositar",
            ["withdraw"] = "3) Retirar",
            ["exit"] = "4) Salir",
            ["currentBalance"] = "Su saldo actual es: {0:C}",
            ["enterAmount"] = "Ingrese la cantidad:",
            ["depositSuccess"] = "¡Depósito exitoso!",
            ["withdrawSuccess"] = "¡Retiro exitoso!",
            ["insufficientFunds"] = "Fondos insuficientes!",
            ["goodbye"] = "¡Gracias por usar nuestro cajero!"
        }
    };

    static string T(string key) => translations[currentLang][key];

    static void Main(string[] args)
    {
        SelectLanguage();
        Console.WriteLine(T("welcome"));

        const string correctPin = "1234";
        int attempts = 0;
        while (attempts < 3)
        {
            Console.Write(T("enterPin") + " ");
            if (Console.ReadLine() == correctPin) break;
            Console.WriteLine(T("wrongPin"));
            attempts++;
        }
        if (attempts == 3) return;

        decimal balance = 1000m;
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n" + T("menu"));
            Console.WriteLine(T("balance"));
            Console.WriteLine(T("deposit"));
            Console.WriteLine(T("withdraw"));
            Console.WriteLine(T("exit"));
            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine(string.Format(CultureInfo.CurrentCulture, T("currentBalance"), balance));
                    break;
                case "2":
                    Console.Write(T("enterAmount") + " ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal deposit))
                    {
                        balance += deposit;
                        Console.WriteLine(T("depositSuccess"));
                    }
                    break;
                case "3":
                    Console.Write(T("enterAmount") + " ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal withdraw))
                    {
                        if (withdraw <= balance)
                        {
                            balance -= withdraw;
                            Console.WriteLine(T("withdrawSuccess"));
                        }
                        else
                        {
                            Console.WriteLine(T("insufficientFunds"));
                        }
                    }
                    break;
                case "4":
                    Console.WriteLine(T("goodbye"));
                    running = false;
                    break;
                default:
                    break;
            }
        }
    }

    static void SelectLanguage()
    {
        Console.WriteLine("Select language / Sélectionnez la langue / Seleccione el idioma:");
        Console.WriteLine(translations["en"]["option1"] + "  " + translations["en"]["option2"] + "  " + translations["en"]["option3"]);
        Console.Write("> ");
        string choice = Console.ReadLine();
        currentLang = choice switch
        {
            "1" => "en",
            "2" => "fr",
            "3" => "es",
            _ => "en"
        };
    }
}
