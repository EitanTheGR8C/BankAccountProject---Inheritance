using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class BusinessAccount : CheckingAccount//hole class is apart of part 2
    {//I have chosen to inherit from the CheckingAccount beacuse the BusinessAccount needs all the exact methods and fields that exist in the CheckingAccount class
        private string business_name;


        public BusinessAccount(int bank_number, int location_number, int account_number, string owner_ID, string business_name) :
            base( bank_number, location_number, account_number, owner_ID)//Constructor with default permitted overdraft amount

        {
            this.business_name = business_name;
        }

        public BusinessAccount(int bank_number, int location_number, int account_number, string owner_ID, double permitted_overdraft_amount, string business_name) :
            base(bank_number, location_number, account_number, owner_ID, permitted_overdraft_amount)//Regular constructor with permitted overdraft amount

        {
            this.business_name = business_name;
        }

        //All gets (except for business_name's one) are inherited from CheckingAccount - so no need for them here.
        public string GetBusinessName()
        {
            return this.business_name;
        }


        public void SetBuisnessName(string new_business_name)
        {
            this.business_name = new_business_name;
        }

        //SetPermittedOverdraftAmount already exists in CheckingAccount so its inherited to here

        public override string ToString()
        {
            return base.ToString() +
                $", Business Name: {this.business_name}";
        }

        //Deposit method is inherited from CheckingAccount which inherites the method from BasicAccount.

        //Withdraw method is inherited from CheckingAccount

        // חשבון עובר ושב באנגלית נקרא: checking account
        public bool paycheck_for_checking_account(double payment_amount, CheckingAccount account_to_pay)
        {
            if( payment_amount < 0)
                return false ;
            bool IsWithdrawn = this.Withdraw(payment_amount);
            if( !IsWithdrawn )
                return false ;
            account_to_pay.Deposit(payment_amount);
            return true ;
        }
    }
}
