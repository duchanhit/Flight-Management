using DAL.IAccess;
using DTO.Entites;
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




        public bool InsertAccount(string userId, string username, string password, int permissionId)
        {
            // Câu truy vấn SQL để chèn dữ liệu vào bảng Account
            string queryAccount = "INSERT INTO Account (AccountId, AccountUser, AccountPass) VALUES (@userId, @username, @password)";

            // Câu truy vấn SQL để chèn dữ liệu vào bảng Per_Acc, tạo liên kết quyền truy cập
            string queryPermission = "INSERT INTO Per_Acc (AccId, PerID) VALUES (@userId, @permissionId)";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FlightModel"].ConnectionString))
            {
                conn.Open();

                // Sử dụng transaction để đảm bảo cả hai thao tác đều thành công hoặc đều thất bại
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Chèn tài khoản mới vào bảng Account
                        using (SqlCommand cmdAccount = new SqlCommand(queryAccount, conn, transaction))
                        {
                            cmdAccount.Parameters.AddWithValue("@userId", userId);
                            cmdAccount.Parameters.AddWithValue("@username", username);
                            cmdAccount.Parameters.AddWithValue("@password", password);
                            cmdAccount.ExecuteNonQuery();
                        }

                        // Thêm bản ghi vào bảng Per_Acc để liên kết quyền truy cập
                        using (SqlCommand cmdPermission = new SqlCommand(queryPermission, conn, transaction))
                        {
                            cmdPermission.Parameters.AddWithValue("@userId", userId);
                            cmdPermission.Parameters.AddWithValue("@permissionId", permissionId);
                            cmdPermission.ExecuteNonQuery();
                        }

                        // Commit transaction nếu cả hai thao tác thành công
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        // Rollback transaction nếu xảy ra lỗi
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}
