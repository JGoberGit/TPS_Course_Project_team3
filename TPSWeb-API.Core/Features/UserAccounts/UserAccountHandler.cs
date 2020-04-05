using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPSWeb_API.Core.Utilities;

namespace TPSWeb_API.Core.Features.UserAccounts
{
    public class UserAccountHandler
    {

        private UserAccountsRepository _userAccountsRepo;
        public UserAccountHandler(UserAccountsRepository userAccountsRepo)
        {
            _userAccountsRepo = userAccountsRepo;
        }

        public AddUserAccountResponse Add(UserAccountModel model)
        {
            var response = new AddUserAccountResponse();

            try
            {
                _userAccountsRepo.AddUserAccount(model);
            }
            catch (Exception e)
            {
                
                response.IsSuccess = false;
                response.Message = "Failed to add user account";
                return response;
            }
            response.IsSuccess = true;
            response.Message = "Successfully added user account";
            return response;
        }

        public AddUserAccountResponse Verify(UserAccountModel model)
        {
            var response = new AddUserAccountResponse();
            bool IsVerified = false;
            try
            {
                IsVerified = _userAccountsRepo.VerifyUserAccount(model);
            }
            catch (Exception e)
            {

                response.IsSuccess = false;
                response.Message = "Unable to authentication user";
                Debug.WriteLine(response.Message, e.StackTrace);
                return response;
            }
            if (IsVerified)
            {
                response.IsSuccess = true;
                response.Message = "Successful authentication";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Userid or password is incorrect";
            }
            return response;
        }

    }

    public class AddUserAccountResponse : HandlerResponse { }
}
