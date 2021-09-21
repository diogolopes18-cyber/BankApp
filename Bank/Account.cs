using System;
using System.Collections.Generic;

namespace Bank
{
    public class Account
    {

        public void HelloCustomer()
        {
            Console.WriteLine("This is a method to illustrate class inheritance\n");
        }
        public static string Details()
        {
            string username;
            Console.WriteLine("Welcome to the bank, please enter your username: \n");
            username = Console.ReadLine();

            //Create new account with username data
            OpenAccount newAccount = new OpenAccount();
            newAccount.BankAccountDetails(username, 300);

            return username;
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


            //Notice that it wasn't necessary to create a new instance of the class Account in order to
            //make a call to the method, since OpenAccount inherites all methods of Account

            HelloCustomer();
            Console.WriteLine("Hello {0}, here' your balance: {1}\n", username, Balance);
            MenuChoice();
        }

        public void MenuChoice()
        {

            Console.Write("Choose your menu:\n1 - Deposit\n2 - Withdraw\n3 - Deposit History\n4 - Write name to file\n5 - Open a loan\n");
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

                case 4:
                    FileWrite();
                    break;

                case 5:
                    GetLoan();
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

        public void FileWrite()
        {
            FileHandling write = new FileHandling();
            write.SaveHistoryToFile(this.username);
        }


        public void GetLoan()
        {
            Console.WriteLine("What would be the opening amount for your loan?\n");
            double amount = Convert.ToDouble(Console.ReadLine());
            

            Console.WriteLine("What should be your loan tax?\n");
            double tax = Convert.ToDouble(Console.ReadLine());

            if (tax < 1)
                Console.Error.WriteLine("The loan tax should be greater than 1.0%\n");
            else
            {
                //Open new loan
                Loan myLoan = new Loan(amount, tax);
                double finalLoanResult = myLoan.AssertLoanAmount();
                Console.WriteLine("Here's the bank loan value {0}\n", finalLoanResult);
            }
        }
    }

    public class Loan
    {
        private double LoanAmmount { get; set; }
        private double LoanTax { get; set; }

        //Class constructor
        public Loan(double loan, double tax)
        {
            this.LoanAmmount = loan;
            this.LoanTax = tax;
        }

        public double AssertLoanAmount()
        {
            double formulaResult = this.LoanAmmount * this.LoanTax - (0.20 * this.LoanAmmount);
            return formulaResult;
        }
    }
}
