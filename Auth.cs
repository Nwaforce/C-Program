// using System;
// using System.Collections.Generic;

// namespace AuthSystem
// {
//     enum MenuOption
//     {
//         Register = 1,
//         Login = 2,
//         Exit = 3
//     }

//     class User
//     {
//         public string Name { get; set; }
//         public string Email { get; set; }
//         public string Password { get; set; }

//         public User(string name, string email, string password)
//         {
//             Name = name;
//             Email = email;
//             Password = password;
//         }
//     }

//     class Program
//     {
//         static List<User> users = new List<User>();

//         static void Main(string[] args)
//         {
//             bool running = true;

//             while (running)
//             {
//                 Console.Clear();
//                 Console.WriteLine("=== Authentication System ===");
//                 Console.WriteLine("1) Register");
//                 Console.WriteLine("2) Login");
//                 Console.WriteLine("3) Exit");
//                 Console.Write("Choose an option: ");

//                 if (!int.TryParse(Console.ReadLine(), out int choice))
//                 {
//                     Console.WriteLine("Invalid input. Press any key to try again...");
//                     Console.ReadKey();
//                     continue;
//                 }

//                 switch ((MenuOption)choice)
//                 {
//                     case MenuOption.Register:
//                         Register();
//                         break;
//                     case MenuOption.Login:
//                         Login();
//                         break;
//                     case MenuOption.Exit:
//                         running = false;
//                         break;
//                     default:
//                         Console.WriteLine("Invalid choice. Press any key to try again...");
//                         Console.ReadKey();
//                         break;
//                 }
//             }
//         }

//         static void Register()
//         {
//             Console.Clear();
//             Console.WriteLine("=== Register ===");

//             Console.Write("Enter Name: ");
//             string name = Console.ReadLine() ?? "";

//             Console.Write("Enter Email: ");
//             string email = Console.ReadLine() ?? "";

//             Console.Write("Enter Password: ");
//             string password = Console.ReadLine() ?? "";

//             if (string.IsNullOrWhiteSpace(name) ||
//                 string.IsNullOrWhiteSpace(email) ||
//                 string.IsNullOrWhiteSpace(password))
//             {
//                 Console.WriteLine("All fields are required. Press any key to return...");
//                 Console.ReadKey();
//                 return;
//             }

//             // Check if email already exists
//             foreach (var user in users)
//             {
//                 if (user.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
//                 {
//                     Console.WriteLine("Email already registered. Press any key to return...");
//                     Console.ReadKey();
//                     return;
//                 }
//             }

//             users.Add(new User(name, email, password));
//             Console.WriteLine("Registration successful! Press any key to continue...");
//             Console.ReadKey();
//         }

//         static void Login()
//         {
//             Console.Clear();
//             Console.WriteLine("=== Login ===");

//             int attempts = 0;

//             while (attempts < 3)
//             {
//                 Console.Write("Enter Email: ");
//                 string email = Console.ReadLine() ?? "";

//                 Console.Write("Enter Password: ");
//                 string password = Console.ReadLine() ?? "";

//                 foreach (var user in users)
//                 {
//                     if (user.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && user.Password == password)
//                     {
//                         Console.WriteLine($"Welcome back, {user.Name}! Press any key to continue...");
//                         Console.ReadKey();
//                         return;
//                     }
//                 }

//                 attempts++;
//                 Console.WriteLine($"Invalid email or password. Attempts left: {3 - attempts}");

//                 if (attempts < 3)
//                     Console.WriteLine("Please try again...");
//             }

//             // After 3 failed attempts
//             Console.WriteLine("Invalid login details.");
//             Console.WriteLine("Redirecting to registration...");
//             Console.ReadKey();
//             Register();
//         }
//     }
// }
