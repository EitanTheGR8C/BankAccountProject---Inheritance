using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /*
     *  --- The project includes 3 parts ---
     * 
     * Part 1 of project: 
     *  (Basic class creation code)
     *  Stages 1, 2, and 3.
     *  Next to each remark from this part will have "(part 1)" writen at the end of it,
     *  or will have a remark stating this fact.
     *  Includes BasicAccount, SavingAccount, CheckingAccount and checks in Program classes.
     * 
     * Part 2 of the project:
     * (Inheritance code)
     * Stages 4 and 5.
     * If needed will include remark saying "(part 2)" same as part 1, but only if necessary.
     * Includes Updated BasicAccount, SavingAccount, and CheckingAccount, new class BusinessAccount, and more checks in Program class.
     * 
     * Almost all is the same between the parts so if something is kept the same no remark for which stage it came from.
     * 
     * Part 3 of the project:
     * 
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n1. Testing Checking Accounts:\n");
            TestCheckingAccount();

            Console.WriteLine("\n2. Testing Saving Accounts:\n");
            TestSavingAccount();

            Console.WriteLine("\n3. Testing Basic Accounts:\n");
            TestBasicAccount();

            Console.WriteLine("\n4. Testing Business Accounts:\n");
            TestBusinessAccount();
        }



        static void TestCheckingAccount()//from part 1
        {
            CheckingAccount account1 = new CheckingAccount(123, 456, 789, "owner1");
            CheckingAccount account2 = new CheckingAccount(987, 654, 321, "owner2", 2000.0);
            Console.WriteLine("Account 1:");
            Console.WriteLine($"Bank Number: {account1.GetBankNumber()}");
            Console.WriteLine($"Location Number: {account1.GetLocationNumber()}");
            Console.WriteLine($"Account Number: {account1.GetAccountNumber()}");
            Console.WriteLine($"Owner ID: {account1.GetOwnerID()}");
            Console.WriteLine($"Account Balance: {account1.GetAccountBalance()}");
            Console.WriteLine($"Permitted Overdraft Amount: {account1.GetPermittedOverdraftAmount()}");
            Console.WriteLine("\nAccount 2:");
            Console.WriteLine($"Bank Number: {account2.GetBankNumber()}");
            Console.WriteLine($"Location Number: {account2.GetLocationNumber()}");
            Console.WriteLine($"Account Number: {account2.GetAccountNumber()}");
            Console.WriteLine($"Owner ID: {account2.GetOwnerID()}");
            Console.WriteLine($"Account Balance: {account2.GetAccountBalance()}");
            Console.WriteLine($"Permitted Overdraft Amount: {account2.GetPermittedOverdraftAmount()}");


            Console.WriteLine("\nTesting Deposit and Withdraw on Account 1:");
            Console.WriteLine($"Deposit(500) returns: {account1.Deposit(500)} (expected True)");
            Console.WriteLine($"Balance after deposit: {account1.GetAccountBalance()} (expected 500)");
            Console.WriteLine($"Deposit(-50) returns: {account1.Deposit(-50)} (expected False)");
            Console.WriteLine($"Balance unchanged: {account1.GetAccountBalance()} (expected 500)");

            Console.WriteLine($"Withdraw(1400) returns: {account1.Withdraw(1400)} (expected True, within default overdraft of 1000)");
            Console.WriteLine($"Balance after withdraw: {account1.GetAccountBalance()} (expected -900)");
            Console.WriteLine($"Withdraw(200) returns: {account1.Withdraw(200)} (expected False, exceeds overdraft)");
            Console.WriteLine($"Balance unchanged: {account1.GetAccountBalance()} (expected -900)");

            Console.WriteLine("\nTesting SetPermittedOverdraftAmount on Account 2:");
            account2.SetPermittedOverdraftAmount(500.0);
            Console.WriteLine($"After SetPermittedOverdraftAmount(500): {account2.GetPermittedOverdraftAmount()} (expected 500)");
            account2.SetPermittedOverdraftAmount(-50.0);
            Console.WriteLine($"After SetPermittedOverdraftAmount(-50), rejected: {account2.GetPermittedOverdraftAmount()} (expected 500)");

            Console.WriteLine("\nToString:");
            Console.WriteLine(account1.ToString());
            Console.WriteLine(account2.ToString());
        }

        static void TestSavingAccount()//from part 1
        {
            SavingAccount account1 = new SavingAccount(123, 456, 789, "owner1", new DateTime(2025, 12, 31));
            SavingAccount account2 = new SavingAccount(987, 654, 321, "owner2", new DateTime(2024, 6, 30));
            Console.WriteLine("Account 1:");
            Console.WriteLine($"Bank Number: {account1.GetBankNumber()}");
            Console.WriteLine($"Location Number: {account1.GetLocationNumber()}");
            Console.WriteLine($"Account Number: {account1.GetAccountNumber()}");
            Console.WriteLine($"Owner ID: {account1.GetOwnerID()}");
            Console.WriteLine($"Account Balance: {account1.GetAccountBalance()}");
            Console.WriteLine($"Saving End Date: {account1.GetSavingEndDate()}");
            Console.WriteLine("\nAccount 2:");
            Console.WriteLine($"Bank Number: {account2.GetBankNumber()}");
            Console.WriteLine($"Location Number: {account2.GetLocationNumber()}");
            Console.WriteLine($"Account Number: {account2.GetAccountNumber()}");
            Console.WriteLine($"Owner ID: {account2.GetOwnerID()}");
            Console.WriteLine($"Account Balance: {account2.GetAccountBalance()}");
            Console.WriteLine($"Saving End Date: {account2.GetSavingEndDate()}");

            Console.WriteLine("\nTesting Deposit and Withdraw on Account 1:");
            Console.WriteLine($"Deposit(1000) returns: {account1.Deposit(1000)} (expected True)");
            Console.WriteLine($"Balance after deposit: {account1.GetAccountBalance()} (expected 1000)");

            DateTime beforeEnd = new DateTime(2025, 6, 1);
            Console.WriteLine($"Withdraw({beforeEnd:d}) returns: {account1.Withdraw(beforeEnd)} (expected False, before end date)");
            Console.WriteLine($"Balance unchanged: {account1.GetAccountBalance()} (expected 1000)");

            DateTime onOrAfterEnd = new DateTime(2026, 1, 1);
            Console.WriteLine($"Withdraw({onOrAfterEnd:d}) returns: {account1.Withdraw(onOrAfterEnd)} (expected True, on/after end date)");
            Console.WriteLine($"Balance after withdraw: {account1.GetAccountBalance()} (expected 0)");

            Console.WriteLine("\nTesting SetSavingEndDate on Account 2:");
            account2.SetSavingEndDate(new DateTime(2027, 1, 1));
            Console.WriteLine($"New saving end date: {account2.GetSavingEndDate()} (expected 01/01/2027)");

            Console.WriteLine("\nToString:");
            Console.WriteLine(account1.ToString());
            Console.WriteLine(account2.ToString());
        }

        static void TestBasicAccount()//from part 1
        {
            BasicAccount account1 = new BasicAccount(123, 456, 789, "owner1");
            BasicAccount account2 = new BasicAccount(987, 654, 321, "owner2");
            Console.WriteLine("Account 1:");
            Console.WriteLine($"Bank Number: {account1.GetBankNumber()}");
            Console.WriteLine($"Location Number: {account1.GetLocationNumber()}");
            Console.WriteLine($"Account Number: {account1.GetAccountNumber()}");
            Console.WriteLine($"Owner ID: {account1.GetOwnerID()}");
            Console.WriteLine($"Account Balance: {account1.GetAccountBalance()}");
            Console.WriteLine("\nAccount 2:");
            Console.WriteLine($"Bank Number: {account2.GetBankNumber()}");
            Console.WriteLine($"Location Number: {account2.GetLocationNumber()}");
            Console.WriteLine($"Account Number: {account2.GetAccountNumber()}");
            Console.WriteLine($"Owner ID: {account2.GetOwnerID()}");
            Console.WriteLine($"Account Balance: {account2.GetAccountBalance()}");
        }


        static void TestBusinessAccount()
        {
            BusinessAccount account1 = new BusinessAccount(111, 222, 333, "bizOwner1", "Business1");
            BusinessAccount account2 = new BusinessAccount(444, 555, 666, "bizOwner2", 3000.0, "Business2");

            Console.WriteLine("Account 1:");
            Console.WriteLine($"Permitted Overdraft Amount: {account1.GetPermittedOverdraftAmount()} (expected 1000, default)");
            Console.WriteLine($"Business Name: {account1.GetBusinessName()}");

            Console.WriteLine("\nAccount 2:");
            Console.WriteLine($"Permitted Overdraft Amount: {account2.GetPermittedOverdraftAmount()} (expected 3000)");
            Console.WriteLine($"Business Name: {account2.GetBusinessName()}");

            Console.WriteLine("\nTesting SetBuisnessName on Account 1:");
            account1.SetBuisnessName("Business1 Renamed");
            Console.WriteLine($"New business name: {account1.GetBusinessName()} (expected 'Business1 Renamed')");

            Console.WriteLine("\nTesting inherited Deposit/Withdraw on Account 1:");
            Console.WriteLine($"Deposit(2000) returns: {account1.Deposit(2000)} (expected True)");
            Console.WriteLine($"Balance after deposit: {account1.GetAccountBalance()} (expected 2000)");
            Console.WriteLine($"Withdraw(2500) returns: {account1.Withdraw(2500)} (expected True, within default overdraft)");
            Console.WriteLine($"Balance after withdraw: {account1.GetAccountBalance()} (expected -500)");

            Console.WriteLine("\nTesting paycheck_for_checking_account:");
            CheckingAccount employee = new CheckingAccount(777, 888, 999, "employee1");
            Console.WriteLine($"Employee balance before: {employee.GetAccountBalance()} (expected 0)");

            Console.WriteLine($"Pay(-100) returns: {account1.paycheck_for_checking_account(-100, employee)} (expected False, negative amount)");
            Console.WriteLine($"Pay(2000) returns: {account1.paycheck_for_checking_account(2000, employee)} (expected False, exceeds overdraft)");
            Console.WriteLine($"Business balance unchanged: {account1.GetAccountBalance()} (expected -500)");
            Console.WriteLine($"Employee balance unchanged: {employee.GetAccountBalance()} (expected 0)");

            Console.WriteLine($"Pay(300) returns: {account1.paycheck_for_checking_account(300, employee)} (expected True)");
            Console.WriteLine($"Business balance after payment: {account1.GetAccountBalance()} (expected -800)");
            Console.WriteLine($"Employee balance after payment: {employee.GetAccountBalance()} (expected 300)");

            Console.WriteLine("\nToString:");
            Console.WriteLine(account1.ToString());
            Console.WriteLine(account2.ToString());
        }
    }
}
