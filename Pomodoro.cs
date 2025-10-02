using System;
using System.Threading;

class PomodoroTimer
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Pomodoro Timer ===");

        // Ask user for custom times
        Console.Write("Enter work time in minutes: ");
        int workMinutes = int.Parse(Console.ReadLine()!);

        Console.Write("Enter short break time in minutes: ");
        int shortBreakMinutes = int.Parse(Console.ReadLine()!);

        Console.Write("Enter long break time in minutes: ");
        int longBreakMinutes = int.Parse(Console.ReadLine()!);

        Console.Write("How many Pomodoros before a long break? ");
        int pomodorosBeforeLongBreak = int.Parse(Console.ReadLine()!);

        int pomodoroCount = 0;

        while (true)
        {
            Console.WriteLine($"\nPomodoro {pomodoroCount + 1}: Work for {workMinutes} minutes!");
            RunTimer(workMinutes);

            pomodoroCount++;

            // Break logic
            if (pomodoroCount % pomodorosBeforeLongBreak == 0)
            {
                Console.WriteLine($"\nTime for a long break! ({longBreakMinutes} minutes)");
                RunTimer(longBreakMinutes);
            }
            else
            {
                Console.WriteLine($"\nTake a short break! ({shortBreakMinutes} minutes)");
                RunTimer(shortBreakMinutes);
            }
        }
    }

    static void RunTimer(int minutes)
    {
        int totalSeconds = minutes * 60;

        for (int i = totalSeconds; i > 0; i--)
        {
            Console.Write($"\rTime left: {i / 60:D2}:{i % 60:D2}");
            Thread.Sleep(1000);
        }

        Console.WriteLine("\n⏰ Time's up!");
        Console.Beep();
    }
}
