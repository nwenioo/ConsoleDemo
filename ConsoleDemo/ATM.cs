using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    public class cardHolder
    {
        string cardNumber;
        int pin;
        double balance;
        string firstName;
        string lastName;

        public cardHolder(string cardNumber,int pin,double balance,string firstName,string lastName)
        {
            this.cardNumber = cardNumber;
            this.pin = pin;
            this.balance = balance;
            this.firstName= firstName;
            this.lastName= lastName;
        }
        public string getNum() {  return cardNumber; }      
        public int getPin() { return pin; }
        public double getBalance() { return balance; }
        public string getFirstName() { return firstName; }
        public string getLastName() { return lastName; }

        public void setNum(string newCardNum) {  cardNumber = newCardNum; }
        public void setPin(int newPin) { pin = newPin; }
        public void setBalance(double newBalance) {  balance = newBalance; }
        public void setFirstName(string newFirstName) {  firstName = newFirstName; }
        public void setLastName(string newLastName) { lastName = newLastName; }

        public static void Main(string[] args)
        {
            void printOptions()
            {
                Console.WriteLine("Please choose from one of the following options ...");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdrawal");
                Console.WriteLine("3. Inquiry");
                Console.WriteLine("4. Exit");
            }

            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("Please input your deposit amount :");
                double deposit = double.Parse(Console.ReadLine());
                currentUser.setBalance(currentUser.getBalance()+ deposit);
                Console.WriteLine("Thank you for banking with us ! Your new balance is : "+ currentUser.getBalance());
            }

            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("Please select your withdrawal amount :");
                double withdraw=double.Parse(Console.ReadLine());
                //check if the user have enough money 
                if (currentUser.getBalance() <  withdraw)
                {
                    Console.WriteLine("Insufficient Balance !");
                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance()-withdraw);
                    Console.WriteLine("Withdraw Success ! You current balance is : "+currentUser.getBalance());
                }
            }

            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Current Balance is : "+ currentUser.getBalance());
            }

            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("4052640311821187",123456,2000,"Jor","Dan"));
            cardHolders.Add(new cardHolder("4052640104366762", 123456, 2000, "Na", "Na"));
            cardHolders.Add(new cardHolder("4052640117237695", 123456, 2000, "Ni", "Ni"));
            cardHolders.Add(new cardHolder("4052640311694014", 123456, 2000, "Dee", "Dee"));
            cardHolders.Add(new cardHolder("4055180213377415", 123456, 2000, "Bi", "Li"));

            //prompt user to start the program 
            Console.WriteLine("Welcome from simple ATM services !");
            Console.WriteLine("Please insert your debit card !");
            string debitCardNumber="";
            cardHolder currentUser;

            //user validation loop 
            while (true)
            {
                try
                {
                    debitCardNumber = Console.ReadLine();
                    //Check cardNum against our DB list 
                    currentUser = cardHolders.FirstOrDefault(a=>a.cardNumber==debitCardNumber);
                    if (currentUser !=null) { break; }
                    else{
                        Console.WriteLine("Invalid Card Number ! Please Try Again !");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid Card Number ! Please Try Again !");
                };
            }

            Console.WriteLine("Please insert your pin : ");
            int userPin = 0;
            //user validation loop 
            while (true)
            {
                try
                {
                    userPin =int.Parse( Console.ReadLine());
                    //Check against our DB list 
                    if (currentUser.getPin() == userPin) { break; }
                    else
                    {
                        Console.WriteLine("Incorrect Pin Number ! Please Try Again !");
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect Pin Number ! Please Try Again !");
                };
            }
            Console.WriteLine("Welcome "+currentUser.getFirstName() +" :) ");

            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option= int.Parse( Console.ReadLine());
                }
                catch { }
                if (option == 1) { deposit(currentUser); }
                else if (option==2) { withdraw(currentUser); }
                else if (option==3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);
            Console.WriteLine("Thanks you ! Have a nice day :) ");
        }
    }
}
