// using System;
// using System.Collections.Generic;

// namespace MultilingualATM
// {
//     // ENUM for transaction types
//     public enum TransactionType
//     {
//         CheckBalance = 1,
//         Deposit = 2,
//         Withdraw = 3,
//         Transactions = 4,
//         Exit = 5
//     }

//     // ENUM for language choice
//     public enum Language
//     {
//         English = 1,
//         French = 2,
//         Spanish = 3
//     }

//     public class BankAccount
//     {
//         public string Owner { get; set; }
//         public decimal Balance { get; private set; }
//         public List<string> Transactions { get; private set; }

//         public BankAccount(string owner, decimal initialBalance)
//         {
//             Owner = owner;
//             Balance = initialBalance;
//             Transactions = new List<string>();
//         }

//         public void Deposit(decimal amount)
//         {
//             Balance += amount;
//             Transactions.Add($"Deposited {amount:C}");
//         }

//         public bool Withdraw(decimal amount)
//         {
//             if (amount > Balance)
//                 return false;

//             Balance -= amount;
//             Transactions.Add($"Withdrew {amount:C}");
//             return true;
//         }
//     }

//     public class Program
//     {
//         const decimal WithdrawalLimit = 500m;
//         static readonly string BankName = "Manny's Bank";

//         static Dictionary<Language, Dictionary<string, string>> translations;
//         static Language currentLanguage;

//         static void Main(string[] args)
//         {
//             Console.OutputEncoding = System.Text.Encoding.UTF8;
//             InitTranslations();

//             SelectLanguage();

//             Console.WriteLine($"{T("welcome")} {BankName}!");

//             BankAccount account = new BankAccount("Emmanuel", 1000m);
//             bool running = true;

//             while (running)
//             {
//                 ShowMenu();

//                 try
//                 {
//                     Console.Write(T("enterChoice"));
//                     int choice = int.Parse(Console.ReadLine());

//                     TransactionType transaction = (TransactionType)choice;

//                     switch (transaction)
//                     {
//                         case TransactionType.CheckBalance:
//                             Console.WriteLine($"{T("balance")}: {account.Balance:C}");
//                             break;

//                         case TransactionType.Deposit:
//                             Console.Write(T("depositAmount"));
//                             decimal depositAmount = decimal.Parse(Console.ReadLine());
//                             account.Deposit(depositAmount);
//                             Console.WriteLine($"{T("deposited")} {depositAmount:C}");
//                             break;

//                         case TransactionType.Withdraw:
//                             Console.Write(T("withdrawAmount"));
//                             decimal withdrawAmount = decimal.Parse(Console.ReadLine());

//                             if (withdrawAmount > WithdrawalLimit)
//                             {
//                                 Console.WriteLine($"{T("withdrawLimit")} {WithdrawalLimit:C}");
//                             }
//                             else if (account.Withdraw(withdrawAmount))
//                             {
//                                 Console.WriteLine($"{T("withdrew")} {withdrawAmount:C}");
//                             }
//                             else
//                             {
//                                 Console.WriteLine(T("insufficientFunds"));
//                             }
//                             break;

//                         case TransactionType.Transactions:
//                             Console.WriteLine(T("transactionHistory"));
//                             if (account.Transactions.Count == 0)
//                                 Console.WriteLine(T("noTransactions"));
//                             else
//                                 foreach (var t in account.Transactions)
//                                     Console.WriteLine(t);
//                             break;

//                         case TransactionType.Exit:
//                             Console.WriteLine(T("goodbye"));
//                             running = false;
//                             break;

//                         default:
//                             Console.WriteLine(T("invalidChoice"));
//                             break;
//                     }
//                 }
//                 catch (FormatException)
//                 {
//                     Console.WriteLine(T("invalidNumber"));
//                 }
//             }
//         }

//         static void InitTranslations()
//         {
//             translations = new Dictionary<Language, Dictionary<string, string>>
//             {
//                 [Language.English] = new Dictionary<string, string>
//                 {
//                     ["welcome"] = "Welcome to",
//                     ["enterChoice"] = "Enter choice: ",
//                     ["balance"] = "Your balance is",
//                     ["depositAmount"] = "Enter amount to deposit: ",
//                     ["withdrawAmount"] = "Enter amount to withdraw: ",
//                     ["deposited"] = "Deposited",
//                     ["withdrew"] = "Withdrew",
//                     ["withdrawLimit"] = "Cannot withdraw more than",
//                     ["insufficientFunds"] = "Insufficient funds.",
//                     ["transactionHistory"] = "Transaction History:",
//                     ["noTransactions"] = "No transactions yet.",
//                     ["goodbye"] = "Thank you for using our ATM!",
//                     ["invalidChoice"] = "Invalid choice.",
//                     ["invalidNumber"] = "Please enter a valid number."
//                 },
//                 [Language.French] = new Dictionary<string, string>
//                 {
//                     ["welcome"] = "Bienvenue à",
//                     ["enterChoice"] = "Entrez votre choix : ",
//                     ["balance"] = "Votre solde est",
//                     ["depositAmount"] = "Entrez le montant à déposer : ",
//                     ["withdrawAmount"] = "Entrez le montant à retirer : ",
//                     ["deposited"] = "Déposé",
//                     ["withdrew"] = "Retiré",
//                     ["withdrawLimit"] = "Impossible de retirer plus de",
//                     ["insufficientFunds"] = "Fonds insuffisants.",
//                     ["transactionHistory"] = "Historique des transactions :",
//                     ["noTransactions"] = "Aucune transaction pour le moment.",
//                     ["goodbye"] = "Merci d'avoir utilisé notre distributeur automatique !",
//                     ["invalidChoice"] = "Choix invalide.",
//                     ["invalidNumber"] = "Veuillez entrer un nombre valide."
//                 },
//                 [Language.Spanish] = new Dictionary<string, string>
//                 {
//                     ["welcome"] = "Bienvenido a",
//                     ["enterChoice"] = "Ingrese una opción: ",
//                     ["balance"] = "Su saldo es",
//                     ["depositAmount"] = "Ingrese la cantidad a depositar: ",
//                     ["withdrawAmount"] = "Ingrese la cantidad a retirar: ",
//                     ["deposited"] = "Depositado",
//                     ["withdrew"] = "Retirado",
//                     ["withdrawLimit"] = "No se puede retirar más de",
//                     ["insufficientFunds"] = "Fondos insuficientes.",
//                     ["transactionHistory"] = "Historial de transacciones:",
//                     ["noTransactions"] = "Aún no hay transacciones.",
//                     ["goodbye"] = "¡Gracias por usar nuestro cajero automático!",
//                     ["invalidChoice"] = "Opción inválida.",
//                     ["invalidNumber"] = "Por favor ingrese un número válido."
//                 }
//             };
//         }

//         static void SelectLanguage()
//         {
//             Console.WriteLine("Select Language / Sélectionnez la langue / Seleccione el idioma:");
//             foreach (var lang in Enum.GetValues(typeof(Language)))
//             {
//                 Console.WriteLine($"{(int)lang}. {lang}");
//             }

//             Console.Write("Choice: ");
//             int langChoice = int.Parse(Console.ReadLine());
//             currentLanguage = (Language)langChoice;
//         }

//         static string T(string key)
//         {
//             if (translations[currentLanguage].ContainsKey(key))
//                 return translations[currentLanguage][key];
//             return key; // fallback
//         }

//         static void ShowMenu()
//         {
//             string[] menuOptions =
//             {
//                 T("balance"),
//                 T("deposited"),
//                 T("withdrew"),
//                 T("transactionHistory"),
//                 T("goodbye")
//             };

//             Console.WriteLine("\n=== ATM MENU ===");
//             for (int i = 0; i < menuOptions.Length; i++)
//             {
//                 Console.WriteLine($"{i + 1}. {menuOptions[i]}");
//             }
//         }
//     }
// }
