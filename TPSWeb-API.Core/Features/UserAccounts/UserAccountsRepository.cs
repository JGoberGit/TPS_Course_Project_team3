using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPSWeb_API.Core.Utilities;

namespace TPSWeb_API.Core.Features.UserAccounts
{
    public class UserAccountsRepository
    {
        public static string connectionString => ConfigurationManager.ConnectionStrings["TPSDBO"].ConnectionString;
        public void AddUserAccount(UserAccountModel userAccountModel)
        {
            using(SqlConnection db = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("TPSDBO.ADDUSER", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pACCOUNTID", userAccountModel.UserId));
                    cmd.Parameters.Add(new SqlParameter("@pPASSWORD", userAccountModel.Password));
                    cmd.Parameters.Add(new SqlParameter("@pACCOUNTTYPE", userAccountModel.AccountType));
                    db.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool VerifyUserAccount(UserAccountModel userAccountModel)
        {
            bool IsVerified = false;
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("TPSDBO.VERIFYUSER", db))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pACCOUNTID", userAccountModel.UserId));
                    cmd.Parameters.Add(new SqlParameter("@pPASSWORD", userAccountModel.Password));
                    cmd.Parameters.Add("@pRESPONSE", SqlDbType.Int);
                    cmd.Parameters["@pRESPONSE"].Direction = ParameterDirection.Output;
                    db.Open();
                    cmd.ExecuteNonQuery();
                    int result = Convert.ToInt32(cmd.Parameters["@pRESPONSE"].Value);
                    if (result == 1)
                    {
                        IsVerified = true;
                    }
                }
            }
            return IsVerified;
        }
    }
    
}
