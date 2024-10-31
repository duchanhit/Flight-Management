using DAL;
using DAL.DataAccess;
using DTO.Entities;
using System.Collections.Generic;

namespace BUS.Service
{
    public class AccountBUS
    {
        private readonly AccountDAL _accountDAL;

        // Constructor
        public AccountBUS()
        {
            _accountDAL = new AccountDAL();
        }

        // Method to get all accounts
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accountDAL.GetAll();
        }

        // Method to get an account by ID
        public Account GetAccountById(int id)
        {
            return _accountDAL.GetById(id);
        }

        // Method to add a new account
        public void AddAccount(Account account)
        {
            _accountDAL.Add(account);
        }

        // Method to update an existing account
        public void UpdateAccount(Account account)
        {
            _accountDAL.Update(account);
        }

        // Method to delete an account
        public void DeleteAccount(int id)
        {
            _accountDAL.Delete(id);
        }

        // Method to check login credentials
        public bool Login(string username, string password)
        {
            return _accountDAL.CheckLogin(username, password);
        }
    }
}
