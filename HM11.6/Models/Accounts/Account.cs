using HM11._6.Models.Clients;
using HM11._6.Models.Infastructure;
using System;

namespace HM11._6.Models.Accounts
{
    public class Account
    {
        private int id;
        public int Id
        { 
            get => id;
            set => id = value;
        }
        public Client Client { get; set; }

        private string _balanceAccount;
        public string BalanceAccount
        {
            get => _balanceAccount;
            set => _balanceAccount = value;
        }

        private string _bankAccount;
        public string BankAccount 
        { 
            get => _bankAccount;
            set => _bankAccount = value;
        }

        private TypeAccount _typeAccount;
        public TypeAccount TypeAccountBank
        { 
            get => _typeAccount;
            set => _typeAccount = value;
        }
        public Account() { }

        public Account(Client client,string bankAccount,string balanceAccount)
        {
            this.Client = client;
            _balanceAccount = balanceAccount;
            _bankAccount = bankAccount;
        }

        private const int LENGTHACCOUNT = 20;
        public static string SetAccountBank()
        {
            Random random = RandomProvider.GetThreadRandom();
            string bankAccountRes = "";
            for (int i = 0; i < LENGTHACCOUNT; i++)
            {
                bankAccountRes += $"{random.Next(0, 9)}";
            }
            return bankAccountRes;
        }
    }
}
