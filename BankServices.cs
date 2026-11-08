using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class BankServices
    {//From Part 3
        private BasicAccount[] accounts;//6

        public BankServices(int size)//asuming positive or 0
        {
            this.accounts = new BasicAccount[size];
        }

        public BasicAccount[] GetAccounts()
            { return accounts; }
        public void SetAccounts(BasicAccount[] new_accounts)
        { this.accounts = new_accounts; }


        public bool Add(BasicAccount to_add)//7
        {
            for (int i = 0; i < accounts.Length && accounts != null; i++)
            {
                if (accounts[i] == null)
                {
                    accounts[i] = to_add;
                    return true;
                }
            }
            return false;
        }

        public string GetAccountDetails(int accountNumber)//assuming only one exists
        {//Q8
            if(accounts == null)
                return "";
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].GetAccountNumber() == accountNumber)
                {
                    return accounts[i].ToString();
                }
            }
            return "";
        }

        public int GetAccountCount(int accountNumber)//assuming only one exists
        {//Q9
            string id = "";
            int cnt = 0;
            bool found = false;
            for (int i = 0; i < accounts.Length && accounts != null; i++)
            {
                if (!found && accounts[i].GetAccountNumber() == accountNumber)
                {
                    id = accounts[i].GetOwnerID();
                    found = true;
                }
                if (accounts[i].GetOwnerID() == id && found)
                { cnt++; }
            }

            return cnt;
        }

        public BasicAccount[] GetAccountsWithID(string id)//Q10
        {
            if (accounts == null)
                return null;
            BasicAccount[] accountsRet = new BasicAccount[0];

            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i] != null && accounts[i].GetOwnerID() == id)
                {
                    Array.Resize(ref accountsRet, accountsRet.Length + 1);
                    accountsRet[accountsRet.Length -1] = accounts[i];
                }
            }
            if (accountsRet.Length == 0)
                return null;
            return accountsRet;
        }

        public string GetIDRichest()//Q11
        {//only 1 richest
            if (accounts == null)
                return null;
            (string Id, double amount)[] IDAndAmount = new (string, double)[accounts.Length];
            int IDAndAmountCNT = 0;
            double currentMax = double.MinValue;
            int maxIndex = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i] == null)
                    continue;
                for (int j = 0; j < IDAndAmount.Length; j++)
                { 
                    if (IDAndAmount[j] == (null, 0))
                    {
                        IDAndAmountCNT++;
                        IDAndAmount[j] = (accounts[i].GetOwnerID(), accounts[i].GetAccountBalance());
                        if (IDAndAmount[j].amount >= currentMax)
                        {
                            currentMax = IDAndAmount[j].amount;
                            maxIndex = i;
                        }
                        break;
                    }
                    else if (IDAndAmount[j].Id == accounts[i].GetOwnerID())
                    {
                        IDAndAmount[j].amount += accounts[i].GetAccountBalance();
                        if (IDAndAmount[j].amount >= currentMax)
                        {
                            currentMax = IDAndAmount[j].amount;
                            maxIndex = i;
                        }
                        break;
                    }
                }
            }

            if (IDAndAmountCNT == 0)
                return null;
            return accounts[maxIndex].GetOwnerID();
        }

    }
}
