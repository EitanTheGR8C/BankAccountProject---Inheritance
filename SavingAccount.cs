using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    //For part 2 - all duplicanted things were marked out - including the inherited fields, get methods, Deposit method and changed ToSting and constructor method to match inheritance.
    internal class SavingAccount : BasicAccount
    {
        /* --- For part 2 - deleted because it it is now inhereted from BasicAccount
        private int bank_number;
        private int location_number;
        private int account_number;
        private string owner_ID;
        private double account_balance;
        */
        private DateTime saving_end_date; //we didn't make anything called Date so I assume meant DateTime (part 1)


        //--- For part 2 - constractor method changed to match inheritance rules.
        public SavingAccount(int bank_number, int location_number, int account_number, string owner_ID, DateTime saving_end_date) :
            base(bank_number, location_number, account_number, owner_ID)
        {
            this.saving_end_date = saving_end_date;
        }

        /* --- For part 2 - deleted because it it is now inhereted from BasicAccount.
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
        */

        public DateTime GetSavingEndDate()
        { return this.saving_end_date; }
        public void SetSavingEndDate(DateTime saving_end_date)
        {
            this.saving_end_date = saving_end_date;
        }

        // --- For part 2 - ToString method changed to match inheritance rules.
        public override string ToString()
        {
            return base.ToString() +
                $", Saving End Date: {this.saving_end_date}";
        }
        /* --- For part 2 - deleted because it it is now inherited from BasicAccount.
        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                this.account_balance += amount;
                return true;
            }
            return false;
        }
        */


        // Withdraws the entire saving balance, but only if withdrawDate is on/after saving_end_date. (part 1)
        public bool Withdraw(DateTime withdrawDate)
        {
            if (withdrawDate >= this.saving_end_date)
            {
                this.account_balance = 0.0;
                return true;
            }
            return false;
        }

    }
}
