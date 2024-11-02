using DAL.DataAccess;
using DAL.IAccess;
using DTO.Entities;
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

        public AccountBUS()
        {
            _accountRepository = new AccountDAL();
        }

        // Method to get all accounts
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accountRepository.GetAll();
        }

        // Method to get account by ID
        public Account GetAccountById(string id)
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
        public void DeleteAccount(string id)
        {
            _accountRepository.Delete(id);
        }


        public bool Login(string username, string password)
        {
            AccountDAL accountDAL = new AccountDAL(); 
            return accountDAL.CheckLogin(username, password); 
        }


        public bool InsertAccount(string userId, string username, string password, int permissionId, string gmail)
        {
            AccountDAL accountDAL = new AccountDAL();
            return accountDAL.InsertAccount(userId, username, password, permissionId, gmail);
        }
        public string GetPasswordByEmail(string email)
        {
            AccountDAL accountDAL = new AccountDAL();
            var account = accountDAL.GetAll().SingleOrDefault(a => a.Gmail == email);

            if (account != null)
            {
                return account.AccountPass; // Trả về mật khẩu nếu tài khoản tồn tại
            }

            return null; // Trả về null nếu tài khoản không tồn tại
        }
    }
}
