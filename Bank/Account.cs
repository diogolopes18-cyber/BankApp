using System;

namespace Bank
{
    public class Account
    {
        public static void Main()
        {
            string username = null;
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
        private double balance { get; set; }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public void BankAccountDetails(string username, double balance)
        {
            this.balance = Balance;
            this.username = username;

            Console.WriteLine("Hello {0}, here' your balance: {1}", username, balance);
            MenuChoice();
        }

        public static int MenuChoice()
        {
            return 0;
        }


    }
}
