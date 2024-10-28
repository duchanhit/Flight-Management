using DAL.IAccess;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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



        public bool CheckLogin(string username, string password)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Accounts.Any(a => a.AccountUser == username && a.AccountPass == password);
            }
        }




        public bool InsertAccount(string userId, string username, string password, int permissionId, string gmail)
        {
            // SQL query to insert data into the Account table
            string queryAccount = "INSERT INTO Account (AccountId, AccountUser, AccountPass, Gmail) VALUES (@userId, @username, @password, @gmail)";

            // SQL query to insert data into Per_Acc table to link permissions
            string queryPermission = "INSERT INTO Per_Acc (AccId, PerID) VALUES (@userId, @permissionId)";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FlightModel"].ConnectionString))
            {
                conn.Open();

                // Use transaction to ensure both operations either succeed or fail together
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert new account into the Account table
                        using (SqlCommand cmdAccount = new SqlCommand(queryAccount, conn, transaction))
                        {
                            cmdAccount.Parameters.AddWithValue("@userId", userId);
                            cmdAccount.Parameters.AddWithValue("@username", username);
                            cmdAccount.Parameters.AddWithValue("@password", password);
                            cmdAccount.Parameters.AddWithValue("@gmail", gmail);
                            cmdAccount.ExecuteNonQuery();
                        }

                        // Add record in Per_Acc table to link access permission
                        using (SqlCommand cmdPermission = new SqlCommand(queryPermission, conn, transaction))
                        {
                            cmdPermission.Parameters.AddWithValue("@userId", userId);
                            cmdPermission.Parameters.AddWithValue("@permissionId", permissionId);
                            cmdPermission.ExecuteNonQuery();
                        }

                        // Commit transaction if both operations succeed
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        // Rollback transaction if an error occurs
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

    }
}
