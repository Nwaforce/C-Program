// using System.Globalization;
// using System.Resources;

// namespace ATMApp;

// public static class Program
// {
//     private static ResourceManager _rm = new ResourceManager("C_.Resources.Strings", typeof(Program).Assembly);

//     public static void Main(string[] args)
//     {
//         Console.OutputEncoding = System.Text.Encoding.UTF8;

//         // Initial language selection (basic, not localized to ensure the prompt can be read)
//         var lang = SelectLanguage();
//         SetCulture(lang);

//         Console.WriteLine(Get("WelcomeBanner"));
//         var atm = SeedATM();

//         while (true)
//         {
//             Console.WriteLine();
//             Console.WriteLine(Get("PromptInsertCard"));
//             Console.Write($"{Get("EnterCardNumber")}: ");
//             var card = Console.ReadLine()?.Trim() ?? string.Empty;
//             Console.Write($"{Get("EnterPin")}: ");
//             var pin = ReadHidden();

//             if (!atm.Authenticate(card, pin))
//             {
//                 Console.WriteLine(Get("AuthFailed"));
//                 continue;
//             }

//             Console.WriteLine(Get("AuthSuccess"));
//             RunSession(atm, card);
//         }
//     }

//     private static string SelectLanguage()
//     {
//         while (true)
//         {
//             Console.WriteLine("Select language / Sélectionnez la langue / Seleccione el idioma:");
//             Console.WriteLine("1) English (en)");
//             Console.WriteLine("2) Français (fr)");
//             Console.WriteLine("3) Español (es)");
//             Console.Write("Choice: ");
//             var choice = Console.ReadLine()?.Trim();
//             switch (choice)
//             {
//                 case "1": return "en";
//                 case "2": return "fr";
//                 case "3": return "es";
//                 default:
//                     Console.WriteLine("Invalid choice. Please try again.");
//                     break;
//             }
//         }
//     }

//     private static void SetCulture(string lang)
//     {
//         var culture = new CultureInfo(lang);
//         CultureInfo.CurrentCulture = culture;
//         CultureInfo.CurrentUICulture = culture;
//     }

//     private static ATM SeedATM()
//     {
//         var atm = new ATM();
//         // Demo accounts
//         atm.AddAccount(new Account("1111222233334444", "1234", ownerName: "Ada Lovelace", openingBalance: 1500.00m));
//         atm.AddAccount(new Account("5555666677778888", "4321", ownerName: "Grace Hopper", openingBalance: 500.00m));
//         return atm;
//     }

//     private static void RunSession(ATM atm, string cardNumber)
//     {
//         while (true)
//         {
//             Console.WriteLine();
//             Console.WriteLine(Get("MainMenuTitle"));
//             Console.WriteLine("1) " + Get("MenuBalance"));
//             Console.WriteLine("2) " + Get("MenuDeposit"));
//             Console.WriteLine("3) " + Get("MenuWithdraw"));
//             Console.WriteLine("4) " + Get("MenuTransfer"));
//             Console.WriteLine("5) " + Get("MenuHistory"));
//             Console.WriteLine("6) " + Get("MenuChangeLang"));
//             Console.WriteLine("7) " + Get("MenuExit"));
//             Console.Write(Get("PromptChoice") + " ");
//             var choice = Console.ReadLine()?.Trim();

//             try
//             {
//                 switch (choice)
//                 {
//                     case "1":
//                         var bal = atm.GetBalance(cardNumber);
//                         Console.WriteLine($"{Get("CurrentBalance")}: {bal.ToString("C", CultureInfo.CurrentCulture)}");
//                         break;

//                     case "2":
//                         Console.Write($"{Get("EnterAmount")}: ");
//                         if (decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.CurrentCulture, out var dep) && dep > 0)
//                         {
//                             atm.Deposit(cardNumber, dep);
//                             Console.WriteLine(Get("DepositSuccess"));
//                         }
//                         else
//                         {
//                             Console.WriteLine(Get("InvalidAmount"));
//                         }
//                         break;

//                     case "3":
//                         Console.Write($"{Get("EnterAmount")}: ");
//                         if (decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.CurrentCulture, out var wd) && wd > 0)
//                         {
//                             if (atm.Withdraw(cardNumber, wd))
//                             {
//                                 Console.WriteLine(Get("WithdrawSuccess"));
//                             }
//                             else
//                             {
//                                 Console.WriteLine(Get("InsufficientFunds"));
//                             }
//                         }
//                         else
//                         {
//                             Console.WriteLine(Get("InvalidAmount"));
//                         }
//                         break;

//                     case "4":
//                         Console.Write($"{Get("EnterTargetCard")}: ");
//                         var target = Console.ReadLine()?.Trim() ?? string.Empty;
//                         Console.Write($"{Get("EnterAmount")}: ");
//                         if (decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.CurrentCulture, out var amt) && amt > 0)
//                         {
//                             if (atm.Transfer(cardNumber, target, amt))
//                             {
//                                 Console.WriteLine(Get("TransferSuccess"));
//                             }
//                             else
//                             {
//                                 Console.WriteLine(Get("TransferFailed"));
//                             }
//                         }
//                         else
//                         {
//                             Console.WriteLine(Get("InvalidAmount"));
//                         }
//                         break;

//                     case "5":
//                         var history = atm.GetHistory(cardNumber);
//                         if (history.Count == 0)
//                         {
//                             Console.WriteLine(Get("NoHistory"));
//                         }
//                         else
//                         {
//                             Console.WriteLine(Get("HistoryHeader"));
//                             foreach (var t in history)
//                             {
//                                 Console.WriteLine($"{t.Timestamp.ToString("g", CultureInfo.CurrentCulture)} - {t.Type} - {t.Amount.ToString("C", CultureInfo.CurrentCulture)} {(string.IsNullOrEmpty(t.Note) ? "" : $"({t.Note})")}");
//                             }
//                         }
//                         break;

//                     case "6":
//                         var lang = SelectLanguage();
//                         SetCulture(lang);
//                         Console.WriteLine(Get("LanguageChanged"));
//                         break;

//                     case "7":
//                         Console.WriteLine(Get("Goodbye"));
//                         return;

//                     default:
//                         Console.WriteLine(Get("InvalidChoice"));
//                         break;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"{Get("UnexpectedError")}: {ex.Message}");
//             }
//         }
//     }

//     private static string Get(string key) => _rm.GetString(key, CultureInfo.CurrentUICulture) ?? key;

//     private static string ReadHidden()
//     {
//         var pwd = string.Empty;
//         ConsoleKey key;
//         do
//         {
//             var keyInfo = Console.ReadKey(intercept: true);
//             key = keyInfo.Key;

//             if (key == ConsoleKey.Backspace && pwd.Length > 0)
//             {
//                 pwd = pwd[..^1];
//                 Console.Write("\b \b");
//             }
//             else if (!char.IsControl(keyInfo.KeyChar))
//             {
//                 pwd += keyInfo.KeyChar;
//                 Console.Write("*");
//             }
//         } while (key != ConsoleKey.Enter);
//         Console.WriteLine();
//         return pwd;
//     }
// }

// public record Transaction(DateTime Timestamp, string Type, decimal Amount, string? Note);

// public class Account
// {
//     public string CardNumber { get; }
//     private string Pin { get; set; }
//     public string OwnerName { get; }
//     public decimal Balance { get; private set; }
//     private readonly List<Transaction> _history = new();

//     public Account(string cardNumber, string pin, string ownerName, decimal openingBalance = 0m)
//     {
//         CardNumber = cardNumber;
//         Pin = pin;
//         OwnerName = ownerName;
//         Balance = openingBalance;
//         if (openingBalance > 0)
//         {
//             _history.Add(new Transaction(DateTime.Now, "DEPOSIT", openingBalance, "Opening balance"));
//         }
//     }

//     public bool VerifyPin(string pin) => Pin == pin;

//     public void Deposit(decimal amount)
//     {
//         Balance += amount;
//         _history.Add(new Transaction(DateTime.Now, "DEPOSIT", amount, ""));
//     }

//     public bool Withdraw(decimal amount)
//     {
//         if (amount <= 0 || amount > Balance) return false;
//         Balance -= amount;
//         _history.Add(new Transaction(DateTime.Now, "WITHDRAW", amount, ""));
//         return true;
//     }

//     public bool TransferTo(Account target, decimal amount)
//     {
//         if (!Withdraw(amount)) return false;
//         target.Deposit(amount);
//         _history.Add(new Transaction(DateTime.Now, "TRANSFER", amount, $"->{target.CardNumber[^4..]}"));
//         target._history.Add(new Transaction(DateTime.Now, "TRANSFER", amount, $"<-{CardNumber[^4..]}"));
//         return true;
//     }

//     public IReadOnlyList<Transaction> History => _history.AsReadOnly();
// }

// public class ATM
// {
//     private readonly Dictionary<string, Account> _accounts = new();
//     private readonly HashSet<string> _lockedCards = new();
//     public int MaxAttempts { get; init; } = 3;

//     private readonly Dictionary<string, int> _attempts = new();

//     public void AddAccount(Account acc) => _accounts[acc.CardNumber] = acc;

//     public bool Authenticate(string cardNumber, string pin)
//     {
//         if (_lockedCards.Contains(cardNumber)) return false;
//         if (!_accounts.TryGetValue(cardNumber, out var acc)) return false;

//         if (acc.VerifyPin(pin))
//         {
//             _attempts[cardNumber] = 0;
//             return true;
//         }

//         if (!_attempts.ContainsKey(cardNumber)) _attempts[cardNumber] = 0;
//         _attempts[cardNumber]++;
//         if (_attempts[cardNumber] >= MaxAttempts)
//         {
//             _lockedCards.Add(cardNumber);
//         }
//         return false;
//     }

//     public decimal GetBalance(string cardNumber) => _accounts[cardNumber].Balance;

//     public void Deposit(string cardNumber, decimal amount) => _accounts[cardNumber].Deposit(amount);

//     public bool Withdraw(string cardNumber, decimal amount) => _accounts[cardNumber].Withdraw(amount);

//     public bool Transfer(string sourceCard, string targetCard, decimal amount)
//     {
//         if (!_accounts.ContainsKey(targetCard)) return false;
//         var src = _accounts[sourceCard];
//         var dst = _accounts[targetCard];
//         return src.TransferTo(dst, amount);
//     }

//     public List<Transaction> GetHistory(string cardNumber) => _accounts[cardNumber].History.ToList();
// }


// //Demo cards

// // 1111222233334444 / PIN 1234 (balance 1500)

// // 5555666677778888 / PIN 4321 (balance 500)