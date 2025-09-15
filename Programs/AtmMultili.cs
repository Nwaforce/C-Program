// using System;
// using System.Collections.Generic;
// using System.Globalization;

// class Program
// {
//     static string currentLang = "en";

//     // Translations stored in dictionaries
//     static Dictionary<string, Dictionary<string, string>> translations = new()
//     {
//         ["en"] = new()
//         {
//             ["welcome"] = "Welcome to the ATM!",
//             ["chooseLang"] = "Select language:",
//             ["option1"] = "1) English",
//             ["option2"] = "2) Français",
//             ["option3"] = "3) Español",
//             ["enterPin"] = "Enter your PIN:",
//             ["wrongPin"] = "Incorrect PIN. Try again.",
//             ["menu"] = "ATM Menu:",
//             ["balance"] = "1) Check Balance",
//             ["deposit"] = "2) Deposit",
//             ["withdraw"] = "3) Withdraw",
//             ["exit"] = "4) Exit",
//             ["currentBalance"] = "Your current balance is: {0:C}",
//             ["enterAmount"] = "Enter amount:",
//             ["depositSuccess"] = "Deposit successful!",
//             ["withdrawSuccess"] = "Withdrawal successful!",
//             ["insufficientFunds"] = "Insufficient funds!",
//             ["goodbye"] = "Thank you for using our ATM!"
//         },
//         ["fr"] = new()
//         {
//             ["welcome"] = "Bienvenue au distributeur automatique!",
//             ["chooseLang"] = "Sélectionnez la langue:",
//             ["option1"] = "1) Anglais",
//             ["option2"] = "2) Français",
//             ["option3"] = "3) Espagnol",
//             ["enterPin"] = "Entrez votre code PIN:",
//             ["wrongPin"] = "PIN incorrect. Réessayez.",
//             ["menu"] = "Menu du distributeur:",
//             ["balance"] = "1) Vérifier le solde",
//             ["deposit"] = "2) Dépôt",
//             ["withdraw"] = "3) Retrait",
//             ["exit"] = "4) Quitter",
//             ["currentBalance"] = "Votre solde actuel est: {0:C}",
//             ["enterAmount"] = "Entrez le montant:",
//             ["depositSuccess"] = "Dépôt réussi!",
//             ["withdrawSuccess"] = "Retrait réussi!",
//             ["insufficientFunds"] = "Fonds insuffisants!",
//             ["goodbye"] = "Merci d'avoir utilisé notre distributeur!"
//         },
//         ["es"] = new()
//         {
//             ["welcome"] = "¡Bienvenido al cajero automático!",
//             ["chooseLang"] = "Seleccione el idioma:",
//             ["option1"] = "1) Inglés",
//             ["option2"] = "2) Francés",
//             ["option3"] = "3) Español",
//             ["enterPin"] = "Ingrese su PIN:",
//             ["wrongPin"] = "PIN incorrecto. Inténtelo de nuevo.",
//             ["menu"] = "Menú del cajero:",
//             ["balance"] = "1) Consultar saldo",
//             ["deposit"] = "2) Depositar",
//             ["withdraw"] = "3) Retirar",
//             ["exit"] = "4) Salir",
//             ["currentBalance"] = "Su saldo actual es: {0:C}",
//             ["enterAmount"] = "Ingrese la cantidad:",
//             ["depositSuccess"] = "¡Depósito exitoso!",
//             ["withdrawSuccess"] = "¡Retiro exitoso!",
//             ["insufficientFunds"] = "Fondos insuficientes!",
//             ["goodbye"] = "¡Gracias por usar nuestro cajero!"
//         }
//     };

//     static string T(string key) => translations[currentLang][key];

//     static void Main(string[] args)
//     {
//         SelectLanguage();
//         Console.WriteLine(T("welcome"));

//         const string correctPin = "1234";
//         int attempts = 0;
//         while (attempts < 3)
//         {
//             Console.Write(T("enterPin") + " ");
//             if (Console.ReadLine() == correctPin) break;
//             Console.WriteLine(T("wrongPin"));
//             attempts++;
//         }
//         if (attempts == 3) return;

//         decimal balance = 1000m;
//         bool running = true;

//         while (running)
//         {
//             Console.WriteLine("\n" + T("menu"));
//             Console.WriteLine(T("balance"));
//             Console.WriteLine(T("deposit"));
//             Console.WriteLine(T("withdraw"));
//             Console.WriteLine(T("exit"));
//             Console.Write("> ");
//             string choice = Console.ReadLine();

//             switch (choice)
//             {
//                 case "1":
//                     Console.WriteLine(string.Format(CultureInfo.CurrentCulture, T("currentBalance"), balance));
//                     break;
//                 case "2":
//                     Console.Write(T("enterAmount") + " ");
//                     if (decimal.TryParse(Console.ReadLine(), out decimal deposit))
//                     {
//                         balance += deposit;
//                         Console.WriteLine(T("depositSuccess"));
//                     }
//                     break;
//                 case "3":
//                     Console.Write(T("enterAmount") + " ");
//                     if (decimal.TryParse(Console.ReadLine(), out decimal withdraw))
//                     {
//                         if (withdraw <= balance)
//                         {
//                             balance -= withdraw;
//                             Console.WriteLine(T("withdrawSuccess"));
//                         }
//                         else
//                         {
//                             Console.WriteLine(T("insufficientFunds"));
//                         }
//                     }
//                     break;
//                 case "4":
//                     Console.WriteLine(T("goodbye"));
//                     running = false;
//                     break;
//                 default:
//                     break;
//             }
//         }
//     }

//     static void SelectLanguage()
//     {
//         Console.WriteLine("Select language / Sélectionnez la langue / Seleccione el idioma:");
//         Console.WriteLine(translations["en"]["option1"] + "  " + translations["en"]["option2"] + "  " + translations["en"]["option3"]);
//         Console.Write("> ");
//         string choice = Console.ReadLine();
//         currentLang = choice switch
//         {
//             "1" => "en",
//             "2" => "fr",
//             "3" => "es",
//             _ => "en"
//         };
//     }
// }



// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello World!");

// using System;
// using System.Security.Principal;

// class Program
// {
//     static void Main(string[] args)
//     {
//         // This for initailizing a variable
//         // string name = "Aba";
//         // int age = 30;
//         // System.Console.WriteLine($"My name is {name} and i'm {age} years old");

//         //This for PasswordChecker and Validation 
//         Console.Write("Enter Password: ");
//         string Password = Console.ReadLine()!;

//         Console.Write("Confirm Password: ");
//         string ConfirmPassword = Console.ReadLine()!;
//         int maxLength = 6;
//         // Console.WriteLine(Password);
//         // Console.WriteLine(ConfirmPassword);

//         if (!Password.Equals(string.Empty) && !ConfirmPassword.Equals(string.Empty))
//         {
//             if (Password.Length >= maxLength && ConfirmPassword.Length >= maxLength)

//                 if (Password.Equals(ConfirmPassword))
//                 {
//                     Console.WriteLine("Password Match");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Password Do not Match");
//                 }

//             else
//             {
//                 Console.WriteLine("Please Enter Atleast 6 Charaters");
//             }
//         }

//         // if (!Password.Equals(string.Empty))
//         // {
//         //     if (!ConfirmPassword.Equals(string.Empty)) {
//         //         if (Password.Length >= 6 && ConfirmPassword.Length >= 6)

//         //             {
//         //                 //i can write the next line using == instead of .Equals
//         //                 if (Password.Equals(ConfirmPassword))
//         //                 {
//         //                     Console.WriteLine("Password Match");
//         //                 }
//         //                 else
//         //                 {
//         //                     Console.WriteLine("Password Do not Match");
//         //                 }
//         //             }
//         //     else
//         //     {
//         //                 Console.WriteLine("Please Enter Atleast 6 Charaters");
//         //     } 
//         //     }

//         //         else
//         //         {
//         //             Console.WriteLine("Please Enter Password Confirmation: ");
//         //         }
//         // }
//         //  else
//         // {
//         //     Console.WriteLine("Please Enter Password: ");
//         // }

//         //Arrays

//         // int num1 = 5;
//         // int num2 = 10;
//         // int num3 = 15;
//         // int num4 = 30;

//         // int[] numbers = new int[4];

//         // numbers[0] = 5;
//         // numbers[1] = 10;
//         // numbers[2] = 15;

//         // Console.Write("Enter a number: ");
//         // numbers[0] = Convert.ToInt32(Console.ReadLine());
//         //  Console.Write("Enter a number: ");
//         // numbers[1] = Convert.ToInt32(Console.ReadLine());
//         //  Console.Write("Enter a number: ");
//         // numbers[2] = Convert.ToInt32(Console.ReadLine());
//         //  Console.Write("Enter a number: ");
//         // numbers[3] = Convert.ToInt32(Console.ReadLine());

//         // Console.WriteLine($"{num1} {num2} {num3} {num4}");
//         // Console.WriteLine($"{numbers[0]} {numbers[1]} {numbers[2]} {numbers[3]}");

//         //USING FOR LOOP
//         // for (int i = 0; i < numbers.Length; i++)
//         // {
//         //     Console.Write("Enter a number: ");
//         //     numbers[i] = Convert.ToInt32(Console.ReadLine());
//         // }

//         // for (int i = 0; i < numbers.Length; i++)
//         // {
//         //     Console.Write($"{numbers[i]} ");
//         // }
//         // Console.WriteLine();

//         // //USING FOREACH 
//         // foreach (int num in numbers)
//         // {
//         //     Console.Write($"{num} ");
//         // }

//         //SOLVING A PROBLEM WITH ARRAY AND ALSO STORE THE VALUES WE GOT

//         // const int angleCount = 3;
//         // int[] angles = new int[angleCount];

//         // for (int i = 0; i < angles.Length; i++)
//         // {
//         //     Console.Write($"Enter angel {i + 1}: "); // FOR {I + 1} HELPS US INCREASE THE ANGELS NUMBER EACH WE ADD ANOTHER ANGEL 
//         //     angles[i] = Convert.ToInt32(Console.ReadLine());
//         // }

//         // int angleSum = 0;

//         // foreach (int angle in angles)
//         // {
//         //     angleSum += angle;
//         // }

//         // USING THIS IS ALSO LONGER 

//         // Console.Write("Enter angle 1: ");
//         // int angle1 = Convert.ToInt32(Console.ReadLine());

//         // Console.Write("Enter angle 2: ");
//         // int angle2 = Convert.ToInt32(Console.ReadLine());

//         // Console.Write("Enter angle 3: ");
//         // int angle3 = Convert.ToInt32(Console.ReadLine());

//         // int angleSum = angle1 + angle2 + angle3;

//         //USIGN THE IF STATEMENT TO SOLVE

//         // if (angleSum == 180)
//         // {
//         //     Console.WriteLine("Valid");
//         // }
//         // else
//         // {
//         //     Console.WriteLine("Invalid");
//         // }
//         //ANOTHER WAY TO SOLVE AND NOT STORING THE VALUES WE INPUT IS
//         // const int angleCount = 3;
//         // int angleSum = 0;

//         // for (int i = 0; i < angleCount; i++)
//         // {
//         //     Console.Write($"Enter angel {i + 1}: ");
//         //     angleSum += Convert.ToInt32(Console.ReadLine());
//         // }

//         // //USING A SIGNLE LINE TO ALSO SOLVE THE SAME PROBLEM FOR CLEARER CODE 
//         // Console.WriteLine(angleSum == 180 ? "Valid" : "Invalid");

//         Console.ReadLine();
//     }
// }



// Dictionary<string, string> msg = new Dictionary<string, string>();
