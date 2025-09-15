# ATM Registration & Multilingual Console App

## Overview

This C# console application simulates a simple ATM system with two main features:

1. **User Registration**:
   Users must register by providing their name, email, and password. The registration process validates each input and allows up to 5 attempts. After successful registration, users can choose to register another user or proceed to the ATM.

2. **Multilingual ATM**:
   After registration, users select their preferred language (English, French, or Spanish). The ATM interface—including menus and messages—will be displayed in the chosen language. Users can check their balance, deposit, withdraw, or exit. All prompts and feedback are localized.

---

## Features

* **User Registration**:
  Input validation for name, email, and password.
  Limited attempts for registration (up to 5 attempts).

* **Language Selection**:
  Choose between English, French, and Spanish.
  Up to 3 attempts for selecting a valid language.

* **ATM Operations**:

  * Check balance
  * Deposit money
  * Withdraw money
  * Exit the ATM

* **Multilingual Support**:
  After selecting a language, all ATM menus, prompts, and feedback will be displayed in the chosen language.

* **Error Handling**:

  * Invalid input for registration
  * Invalid language selection
  * Invalid ATM menu choices

---

## How to Run

### Prerequisites

* **.NET SDK (Core or later)**:
  Make sure you have the .NET SDK installed on your machine. You can download it from [here](https://dotnet.microsoft.com/download).

### Steps to Run

1. **Clone or Download the Repository**:
   Clone the repository or download the files to your local machine.

   ```bash
   git clone https://github.com/Nwaforce/C-Program
   ```

2. **Build and Run**:
   Open a terminal in the project directory and run the following command to build and run the project:

   ```bash
   dotnet run
   ```

   Alternatively, if using **Visual Studio Code**, press `F5` or use the "Run" menu to start the application.

3. **Follow the Prompts**:

   * Register with your name, email, and password.
   * Choose your preferred language (1: English, 2: French, 3: Spanish).
   * Use the ATM menu to check balance, deposit, withdraw, or exit.

---

## Sample Interaction

Here is a sample run of the application:

```
Enter your name: John Doe
Enter your email: johndoe@example.com
Enter your password: ********

Registration successful!

Choose language:
1. English
2. French
3. Spanish
Enter option (1-3): 1

ATM Started in English Language.
ATM Menu:
1. Check Balance
2. Deposit
3. Withdraw
4. Exit
Enter your choice: 1
Your balance is: $0

Enter your choice: 2
Enter deposit amount: 500
Deposit successful. New balance: $500
```

---

## Requirements

* **.NET SDK 9 (Core or later)**
  Works on Windows, macOS, and Linux.

---

## Directory Structure

The project consists of the following files:

```
ATM-Registration-Multilingual/
│
├── Program.cs         # Main program entry
├── Registration.cs    # Registration logic
├── Multilingual.cs    # ATM and language selection logic
└── README.md          # This readme file
```

---

## Future Improvements

* **Persistent User Data**:
  Save user data (name, email, password) in a database or file for future sessions.

* **Advanced ATM Operations**:
  Add features such as transferring money, viewing transaction history, or setting account limits.

---

## Contributing

Feel free to fork this repository, submit issues, or make pull requests. Contributions are welcome!

---