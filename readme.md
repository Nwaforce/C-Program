ATM Registration & Multilingual Console App
Overview
This C# console application simulates a simple ATM system with two main features:

User Registration
Users must register by providing their name, email, and password. The registration process validates each input and allows up to 5 attempts. After successful registration, users can choose to register another user or proceed to the ATM.

Multilingual ATM
After registration, users select their preferred language (English, French, or Spanish). The ATM interface—including menus and messages—will be displayed in the chosen language. Users can check their balance, deposit, withdraw, or exit. All prompts and feedback are localized.

Features
Input validation for registration (name, email, password)
Limited attempts for registration and language selection
Multilingual support (English, French, Spanish)
Simple ATM operations: check balance, deposit, withdraw, exit
Error handling for invalid menu and language choices

How to Run
Clone or Download the Repository
Place the files (Program.cs, Registration.cs, Multilingual.cs) in the same directory.

Build and Run
Open a terminal in the project directory and run:

Or, if using Visual Studio Code, press F5 or use the Run menu.

Follow the Prompts

Register with your name, email, and password.
Choose your preferred language (1: English, 2: French, 3: Spanish).
Use the ATM menu to check balance, deposit, withdraw, or exit.

Requirements
.NET SDK (Core or later)
Works on Windows, macOS, and Linux
