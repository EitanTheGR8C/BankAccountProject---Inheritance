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
     * 
     * Part 2 of the project:
     * (Inheritance code)
     * Stages 4 and 5.
     * 
     * 
     * Part 3 of the project:
     * (Pre-Polymorphism Exercise)
     * Stages 6 to 11 (included)
     * 
     * Part 4 -f the project:
     * (Polymorphism Exercise)
     * Stages 12 and 13
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            #region from last homework
            /*
            Console.WriteLine("\n1. Testing Checking Accounts:\n");
            TestCheckingAccount();

            Console.WriteLine("\n2. Testing Saving Accounts:\n");
            TestSavingAccount();

            Console.WriteLine("\n3. Testing Basic Accounts:\n");
            TestBasicAccount();

            Console.WriteLine("\n4. Testing Business Accounts:\n");
            TestBusinessAccount();
            */
            #endregion from last homework

            #region part 3 & 4
            Console.WriteLine("\n5. Testing Bank Services:\n");
            TestBankServices();
            #endregion part 3 & 4


        }

        public static void TestBankServices()//Part 3 and 4
        {
            SavingAccount sav1 = new SavingAccount(1, 1, 1001, "owner1", new DateTime(2025, 12, 31));
            CheckingAccount chk1 = new CheckingAccount(1, 1, 1002, "owner1");
            BusinessAccount biz1 = new BusinessAccount(2, 2, 2001, "bizOwner1", "Business1");
            SavingAccount sav2 = new SavingAccount(2, 2, 2002, "owner2", new DateTime(2025, 12, 31));
            SavingAccount sav3 = new SavingAccount(3, 3, 3001, "owner3", new DateTime(2025, 12, 31));
            CheckingAccount chk2 = new CheckingAccount(3, 3, 3002, "owner3");

            sav1.Deposit(1000);
            chk1.Deposit(500);
            biz1.Deposit(2000);
            chk2.Withdraw(600);

            BankServices bank = new BankServices(6);

            Console.WriteLine("Testing Add (Q7):");
            Console.WriteLine($"Add sav1 returns: {bank.Add(sav1)} (expected True)");
            Console.WriteLine($"Add chk1 returns: {bank.Add(chk1)} (expected True)");
            Console.WriteLine($"Add biz1 returns: {bank.Add(biz1)} (expected True)");
            Console.WriteLine($"Add sav2 returns: {bank.Add(sav2)} (expected True)");
            Console.WriteLine($"Add sav3 returns: {bank.Add(sav3)} (expected True)");
            Console.WriteLine($"Add chk2 returns: {bank.Add(chk2)} (expected True)");

            CheckingAccount extra = new CheckingAccount(9, 9, 9001, "owner9");
            Console.WriteLine($"Add extra when full returns: {bank.Add(extra)} (expected False)");

            Console.WriteLine("\nTesting GetAccountDetails (Q8):");
            string details = bank.GetAccountDetails(1002);
            Console.WriteLine($"Details for 1002: {details}");
            Console.WriteLine("(expected the details of account 1002)");
            Console.WriteLine($"GetAccountDetails(9999) is empty: {bank.GetAccountDetails(9999) == ""} (expected True)");

            Console.WriteLine("\nTesting GetAccountCount (Q9):");
            Console.WriteLine($"GetAccountCount(1002) returns: {bank.GetAccountCount(1002)} (expected 2)");
            Console.WriteLine($"GetAccountCount(9999) returns: {bank.GetAccountCount(9999)} (expected 0)");

            Console.WriteLine("\nTesting GetAccountsWithID (Q10):");
            BasicAccount[] owner1Accounts = bank.GetAccountsWithID("owner1");
            if (owner1Accounts == null)
            {
                Console.WriteLine("GetAccountsWithID(owner1) returned null (expected 2 accounts)");
            }
            else
            {
                Console.WriteLine($"GetAccountsWithID(owner1) found {owner1Accounts.Length} accounts (expected 2):");
                for (int i = 0; i < owner1Accounts.Length; i++)
                {
                    if (owner1Accounts[i] == null)
                        Console.WriteLine("null account returned (unexpected)");
                    else
                        Console.WriteLine(owner1Accounts[i].GetAccountNumber() + " (expected 1001 and 1002)");
                }
            }

            BasicAccount[] nobodyAccounts = bank.GetAccountsWithID("nobody");
            Console.WriteLine($"GetAccountsWithID(nobody) is null: {nobodyAccounts == null} (expected True)");
            Console.WriteLine("\nTesting GetIDRichest (Q11):");
            Console.WriteLine($"GetIDRichest returns: {bank.GetIDRichest()} (expected bizOwner1)");

            Console.WriteLine("\nTesting ZeroSavings (Q12):");
            SavingAccount[] zeroAccounts = bank.ZeroSavings();
            if (zeroAccounts == null)
            {
                Console.WriteLine("ZeroSavings returned null (expected 2 accounts)");
            }
            else
            {
                Console.WriteLine($"ZeroSavings found {zeroAccounts.Length} accounts (expected 2):");
                for (int i = 0; i < zeroAccounts.Length; i++)
                {
                    if (zeroAccounts[i] == null)
                        Console.WriteLine("null account returned (unexpected)");
                    else
                        Console.WriteLine(zeroAccounts[i].GetAccountNumber() + " (expected 2002 and 3001)");
                }
            }

            Console.WriteLine("\nTesting LoanSuggestion (Q13):");
            string[] loans = bank.LoanSuggestion();
            if (loans == null)
            {
                Console.WriteLine("LoanSuggestion returned null (expected 1 suggestion)");
            }
            else
            {
                Console.WriteLine($"LoanSuggestion found {loans.Length} suggestions (expected 1):");
                for (int i = 0; i < loans.Length; i++)
                {
                    if (loans[i] == null)
                        Console.WriteLine("null suggestion returned (unexpected)");
                    else
                        Console.WriteLine(loans[i] + " (expected Type:Checking, Num:3002, ID:owner3, Balance:600)");
                }
            }

            Console.WriteLine("\nTesting with empty slots:");
            BankServices bankWithEmptySlots = new BankServices(4);
            Console.WriteLine($"Add sav1 returns: {bankWithEmptySlots.Add(sav1)} (expected True)");
            Console.WriteLine($"Add sav2 returns: {bankWithEmptySlots.Add(sav2)} (expected True)");
            Console.WriteLine($"GetAccountDetails(9999) is empty: {bankWithEmptySlots.GetAccountDetails(9999) == ""} (expected True)");
            Console.WriteLine($"GetAccountCount(1001) returns: {bankWithEmptySlots.GetAccountCount(1001)} (expected 1)");
            Console.WriteLine($"GetAccountCount(9999) returns: {bankWithEmptySlots.GetAccountCount(9999)} (expected 0)");
            Console.WriteLine($"GetIDRichest returns: {bankWithEmptySlots.GetIDRichest()} (expected owner1)");

            SavingAccount[] emptySlotZeroAccounts = bankWithEmptySlots.ZeroSavings();
            if (emptySlotZeroAccounts == null)
            {
                Console.WriteLine("ZeroSavings with empty slots returned null (expected account 2002)");
            }
            else
            {
                Console.WriteLine($"ZeroSavings with empty slots found {emptySlotZeroAccounts.Length} accounts (expected 1):");
                for (int i = 0; i < emptySlotZeroAccounts.Length; i++)
                {
                    if (emptySlotZeroAccounts[i] == null)
                        Console.WriteLine("null account returned (unexpected)");
                    else
                        Console.WriteLine(emptySlotZeroAccounts[i].GetAccountNumber() + " (expected 2002)");
                }
            }
            string[] emptySlotLoans = bankWithEmptySlots.LoanSuggestion();
            if (emptySlotLoans == null)
                Console.WriteLine("LoanSuggestion with empty slots returned null (expected 0 suggestions)");
            else
                Console.WriteLine($"LoanSuggestion with empty slots returns {emptySlotLoans.Length} suggestions (expected 0)");

            Console.WriteLine("\nTesting with a null accounts array:");
            BankServices nullArrayBank = new BankServices(3);
            nullArrayBank.SetAccounts(null);
            Console.WriteLine($"Add returns: {nullArrayBank.Add(sav1)} (expected False)");
            Console.WriteLine($"GetAccountDetails(1001) is empty: {nullArrayBank.GetAccountDetails(1001) == ""} (expected True)");
            Console.WriteLine($"GetAccountCount(1001) returns: {nullArrayBank.GetAccountCount(1001)} (expected 0)");
            Console.WriteLine($"GetAccountsWithID(owner1) is null: {nullArrayBank.GetAccountsWithID("owner1") == null} (expected True)");
            Console.WriteLine($"GetIDRichest is null: {nullArrayBank.GetIDRichest() == null} (expected True)");
            Console.WriteLine($"ZeroSavings is null: {nullArrayBank.ZeroSavings() == null} (expected True)");

            string[] nullArrayLoans = nullArrayBank.LoanSuggestion();
            if (nullArrayLoans == null)
                Console.WriteLine("LoanSuggestion with a null array returned null (expected 0 suggestions)");
            else
                Console.WriteLine($"LoanSuggestion with a null array returns {nullArrayLoans.Length} suggestions (expected 0)");
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
        static void TestBusinessAccount()//from part 1,2
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
