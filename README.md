# Bank Account Project - Inheritance

A C# console project about **bank accounts**, built to practice class inheritance. A shared base class holds the common account data, and each account type inherits from it and adds its own behavior.

## Project Structure

```
BankAccountProject/
├── BasicAccount.cs      # Base class - common account data and behavior
├── CheckingAccount.cs   # Checking account with a permitted overdraft
├── SavingAccount.cs     # Saving account locked until an end date
├── BusinessAccount.cs   # Business account (inherits from CheckingAccount)
├── BankServices.cs      # A bank that holds and queries all the accounts
└── Program.cs           # Main + tests
```

## Class Hierarchy

```
BasicAccount
└── CheckingAccount
    └── BusinessAccount

BasicAccount
└── SavingAccount
```

## The Classes

### `BasicAccount` (base class)
Holds what every account shares: bank number, location number, account number, owner ID and balance. Only the balance is `protected` - the subclasses never modify the rest directly, so private keeps them safe from accidental misuse.

| Member | Description |
| --- | --- |
| `BasicAccount(bank, location, account, ownerID)` | Creates an account |
| `GetBankNumber()` / `GetLocationNumber()` / `GetAccountNumber()` / `GetOwnerID()` / `GetAccountBalance()` | Read the account data |
| `Deposit(amount)` | Adds money - shared by all account types |
| `ToString()` | Prints the account details |

`Withdraw` is not here on purpose - each account type withdraws differently.

### `CheckingAccount : BasicAccount`
Adds a permitted overdraft: withdrawals are allowed as long as the balance stays above the overdraft limit. Comes with a default-overdraft constructor and one that takes a custom limit.

### `SavingAccount : BasicAccount`
Adds a saving end date. `Withdraw(withdrawDate)` releases the whole balance only on or after the end date.

### `BusinessAccount : CheckingAccount`
Adds a business name, and `paycheck_for_checking_account(payment_amount, account_to_pay)` which pays a salary from the business account into another checking account.

### `BankServices`
The "bank" itself - holds an array of accounts and answers questions about them:

- **Manage:** `Add`, `GetAccounts`, `GetAccountDetails(accountNumber)`, `GetAccountCount(accountNumber)`
- **Queries:** `GetAccountsWithID(id)` (all accounts of one owner), `GetIDRichest()` (owner with the most money)
- **Reports:** `ZeroSavings()` (saving accounts with zero balance), `LoanSuggestion()` (who should be offered a loan)

## Running the Project

Open in **Visual Studio** (.NET Framework console app) and run. `Main` calls `TestBankServices()`, which tests every class - each check prints `OK` when it passes. All methods handle null input and never crash.

## Author

Eitan
