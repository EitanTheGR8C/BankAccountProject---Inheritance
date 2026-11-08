using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    //For part 2 - all duplicanted things were marked out - including the inherited fields, get methods, Deposit method and changed ToSting and constructors methods to match inheritance.
    // same changes done in SavingAccount
    internal class CheckingAccount : BasicAccount
    {
        /* --- For part 2 - deleted because it it is now inhereted from BasicAccount
        private int bank_number;
        private int location_number;
        private int account_number;
        private string owner_ID;
        private double account_balance;
        */

        private double permitted_overdraft_amount;//doesn't need to change because it doesn't change in the BusinessAccount so can stay private.
        private const double deafult_permitted_overdraft_amount = 1000.0;

        //--- For part 2 - constractors methods changed to match inheritance rules.
        public CheckingAccount(int bank_number, int location_number, int account_number, string owner_ID):
            base(bank_number, location_number, account_number, owner_ID) // Constructor with default permitted overdraft amount(part 1 remark)
        {
            this.permitted_overdraft_amount = deafult_permitted_overdraft_amount;
        }
        public CheckingAccount(int bank_number, int location_number, int account_number, string owner_ID, double permitted_overdraft_amount):
            base(bank_number, location_number, account_number, owner_ID) //regular constructor with permitted overdraft amount(part 1 remark)  
        {          
            this.permitted_overdraft_amount = permitted_overdraft_amount;
        }


        /* --- For part 2 - deleted because it it is now inhereted from BasicAccount
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

        public double GetPermittedOverdraftAmount()
        { return this.permitted_overdraft_amount; }
        public void SetPermittedOverdraftAmount(double permitted_overdraft_amount)
        {
            if(permitted_overdraft_amount >= 0)
            {
                this.permitted_overdraft_amount = permitted_overdraft_amount;
            }
        }

        //--- For part 2 - ToString method changed to match inheritance rules.
        public override string ToString()
        {
            return base.ToString() +
                $", Permitted Overdraft Amount: {this.permitted_overdraft_amount}";
        }

        /* --- For part 2 - deleted because it it is now inhereted from BasicAccount
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

        public bool Withdraw(double amount)
        {
            if (amount > 0 && this.account_balance - amount >= -this.permitted_overdraft_amount)
            {
                this.account_balance -= amount;
                return true;
            }
            return false;
        }
    }
}
