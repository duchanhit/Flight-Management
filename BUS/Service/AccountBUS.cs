using DAL.IAccess;
using DTO.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class AccountBUS
    {
        private readonly IRepository<Account> _accountRepository;

        // Constructor Injection
        public AccountBUS(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // Method to get all accounts
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accountRepository.GetAll();
        }

        // Method to get account by ID
        public Account GetAccountById(int id)
        {
            return _accountRepository.GetById(id);
        }

        // Method to add a new account
        public void AddAccount(Account account)
        {
            _accountRepository.Add(account);
        }

        // Method to update an existing account
        public void UpdateAccount(Account account)
        {
            _accountRepository.Update(account);
        }

        // Method to delete an account
        public void DeleteAccount(int id)
        {
            _accountRepository.Delete(id);
        }
    }
}
