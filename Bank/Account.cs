using System;
using System.Collections.Generic;

namespace Bank
{
    public class Account
    {
        public static void Details()
        {
            string username = "";
            Console.WriteLine("Welcome to the bank, please enter your username: ");
            username = Console.ReadLine();

            //Create new account with username data
            OpenAccount newAccount = new OpenAccount();
            newAccount.BankAccountDetails(username, 300);
        }
    }

    public class OpenAccount:Account
    {
        //
        public string username { get; set; }
        public double Balance { get; set; }
        //List to store bank transactions history
        List<double> depositHistory = new List<double>();

        public void BankAccountDetails(string username, double Balance)
        {
            this.Balance = Balance;
            this.username = username;

            Console.WriteLine("Hello {0}, here' your balance: {1}", username, Balance);
            MenuChoice();
        }

        public void MenuChoice()
        {

            Console.Write("Choose your menu:\n1 - Deposit\n2 - Withdraw\n3 - Deposit History\n");
            string menuChoice = Console.ReadLine();
            int choice = Convert.ToInt32(menuChoice);

            switch(choice)
            {
                case 1:
                    Deposit();
                    break;

                case 2:
                    Withdraw();
                    break;

                case 3:
                    History();
                    break;
            }
        }

        public void Deposit()
        {
            double balance = this.Balance;
            Console.WriteLine("Please insert the amount to deposit: \n");
            string depositAmount = Console.ReadLine();
            double amount = Convert.ToInt32(depositAmount);

            depositHistory.Add(amount);

            if(amount > 0)
            {
                balance += amount;
            }

            Console.Write("Current balance: {0}", balance);
            MenuChoice();
        }

        public void Withdraw()
        {
            double balance = this.Balance;
            Console.WriteLine("Please insert the amount to withdraw: \n");
            string depositAmount = Console.ReadLine();
            double amount = Convert.ToInt32(depositAmount);

            depositHistory.Add(-amount);

            if (amount > 0)
            {
                balance -= amount;
            }

            Console.Write("Current balance: {0}", balance);
            MenuChoice();
        }

        public void History()
        {
            Console.WriteLine("Here's your deposit history:");
            foreach(double mov in depositHistory)
            {
                if (mov > 0)
                    Console.WriteLine("Deposit: " + mov);
                else
                    Console.WriteLine("Withdraw: " + mov);
            }

            MenuChoice();
        }

    }


}
