
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class AccountDAL 
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



        public bool CheckLogin(string username, string password)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Accounts.Any(a => a.AccountUser == username && a.AccountPass == password);
            }
        }




        public bool InsertAccount(string userId, string username, string password, int permissionId, string gmail)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FlightModel"].ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("InsertAccountWithPermission", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@gmail", gmail);
                    cmd.Parameters.AddWithValue("@permissionId", permissionId);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }


    }
}
