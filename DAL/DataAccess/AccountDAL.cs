using DAL.IAccess;
using DTO.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class AccountDAL : IRepository<Account>
    {
        // Lấy tất cả các tài khoản từ cơ sở dữ liệu
        public IEnumerable<Account> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Accounts.ToList();
            }
        }

        // Lấy thông tin tài khoản theo ID
        public Account GetById(int accountId)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Accounts.SingleOrDefault(a => a.AccountId == accountId.ToString());
            }
        }

        // Thêm tài khoản vào cơ sở dữ liệu
        public void Add(Account account)
        {
            using (FlightModel context = new FlightModel())
            {
                context.Accounts.Add(account);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin tài khoản
        public void Update(Account account)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingAccount = context.Accounts.SingleOrDefault(a => a.AccountId == account.AccountId.ToString());
                if (existingAccount != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingAccount.AccountUser = account.AccountUser;
                    existingAccount.AccountPass = account.AccountPass;
                    context.SaveChanges();
                }
            }
        }

        // Xóa tài khoản khỏi cơ sở dữ liệu
        public void Delete(int accountId)
        {
            using (FlightModel context = new FlightModel())
            {
                var accountToDelete = context.Accounts.SingleOrDefault(a => a.AccountId == accountId.ToString());
                if (accountToDelete != null)
                {
                    context.Accounts.Remove(accountToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}
