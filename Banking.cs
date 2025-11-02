using System;

class BankingSystem
{
    static void Main()
    {
        const string correctCardNumber = "1234 5678 9012 3456";
        const string correctCVV = "012";
        const string correctPasscode = "1234";
        decimal balance = 1000.00m;

        Console.WriteLine("=== Welcome to Secure Bank ===");

        // Card number check
        while (true)
        {
            Console.Write("Enter your card number (format: 1234 5678 9012 3456): ");
            string cardInput = Console.ReadLine();
            if (cardInput == correctCardNumber)
                break;
            Console.WriteLine("Invalid card number. Try again.\n");
        }

        // CVV check
        while (true)
        {
            Console.Write("Enter your CVV (3 digits): ");
            string cvvInput = Console.ReadLine();
            if (cvvInput == correctCVV)
                break;
            Console.WriteLine("Invalid CVV. Try again.\n");
        }

        // Passcode check
        while (true)
        {
            Console.Write("Enter your passcode: ");
            string passcodeInput = Console.ReadLine();
            if (passcodeInput == correctPasscode)
                break;
            Console.WriteLine("Incorrect passcode. Try again.\n");
        }

        // Authenticated menu
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Access Granted!");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Charge Card (Withdraw)");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option (1-3): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine($"\nYour current balance is: ${balance:F2}");
                    break;

                case "2":
                    Console.Write("\nEnter amount to charge: $");
                    if (decimal.TryParse(Console.ReadLine(), out decimal charge))
                    {
                        if (charge > 0 && charge <= balance)
                        {
                            balance -= charge;
                            Console.WriteLine($"Charged ${charge:F2} successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient funds or invalid amount.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case "3":
                    Console.WriteLine("\n Thank you for using Secure Bank. Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select 1-3.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
