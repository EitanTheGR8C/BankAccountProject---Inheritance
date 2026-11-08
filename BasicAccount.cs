using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    //For part 2 only changes account_balance to protected instead of private
    internal class BasicAccount
    {
        // The bank_number, location_number, account_number, and owner_ID are common properties between CheckingAccount and SavingAccount. (part 1)

        // (Part 2): changing account_balance to protected. the rest stay the same because the subclasses only read them (via inheriting Get methods)-
        // and never need to modify them directly so private already gives them everything they need,-
        // and loosening it further would only expose fields to accidental misuse for no benefit. therefore only account_number is changed.
        private int bank_number;
        private int location_number;
        private int account_number;
        private string owner_ID;
        protected double account_balance;

        // Getters for the common properties
        public int GetBankNumber()
        { return this.bank_number; }
        public int GetLocationNumber()
        { return this.location_number; }
        public int GetAccountNumber()
        { return this.account_number; }
        public string GetOwnerID()
        { return this.owner_ID; }
        public double GetAccountBalance()
        { return this.account_balance; }


        // The Constructor isn't Identical between ChekingAccount and SavingAccount,
        // but it's part of the building blocks of the class. So I'll make a basic one which includes the common properties.
        // I know that the instructions say that only what is identical should be in the base class,
        // but I think this is a reasonable exception because the constructor is a fundamental part of object initialization. (part 1)
        public BasicAccount(int bank_number, int location_number, int account_number, string owner_ID)
        {
            this.bank_number = bank_number;
            this.location_number = location_number;
            this.account_number = account_number;
            this.owner_ID = owner_ID;
            this.account_balance = 0.0;
        }

        // For the same reason, I'll also make a ToString() method for this class. (part 1)

        // (part 2): I could change override to virtual but no need, can be done without changing so let's keep it the way it is.
        public override string ToString()
        {
            return $"Bank Number: {this.bank_number}, " +
                $"Location Number: {this.location_number}, " +
                $"Account Number: {this.account_number}, " +
                $"Owner ID: {this.owner_ID}, Account Balance: {this.account_balance}";
        }

        // Deposit method is common between CheckingAccount and SavingAccount. (part 1)
        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                this.account_balance += amount;
                return true;
            }
            return false;
        }

        // The Withdraw method is different between CheckingAccount and SavingAccount, so I won't include it here. (part 1)

    }
}
