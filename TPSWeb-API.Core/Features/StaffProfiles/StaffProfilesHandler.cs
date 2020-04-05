using System;
using System.Collections.Generic;
using System.Diagnostics;
using TPSWeb_API.Core.Utilities;

namespace TPSWeb_API.Core.Features.StaffProfiles
{
    public class StaffProfilesHandler
    {
        private StaffProfilesRepository _staffProfileRepo;
        public StaffProfilesHandler(StaffProfilesRepository staffProfileRepo)
        {
            _staffProfileRepo = staffProfileRepo;
        }

        public GetAllStaffProfileResponse GetAll()
        {
            var response = new GetAllStaffProfileResponse();
            try {
                response.data = _staffProfileRepo.GetStaffProfileModels();

            } catch (Exception e)
            {
                Debug.WriteLine($"Failed to get all staff profiles: {e.StackTrace}",e);
                response.IsSuccess = false;
                response.Message = "Failed to retrieve staff profiles";
            }
            response.IsSuccess = true;
            response.Message = $"Successfull retrieved {response.data.Count} staff profiles";
            return response;
        }

        public GetStaffProfileResponse Get(int id)
        {
            var response = new GetStaffProfileResponse();
            try
            {
                response.data = _staffProfileRepo.GetStaffProfileModel(id);

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to retrieve staff profile {id}: {e.StackTrace}", e);
                response.IsSuccess = false;
                response.Message = $"Failed to retrieve staff profile {id}";
            }
            response.IsSuccess = true;
            response.Message = $"Successfull retrieved {id} staff profile";
            return response;
        }

        public StaffProfileResponse Add(StaffProfileModel model)
        {
            var response = new StaffProfileResponse();

            try
            {
                _staffProfileRepo.AddStaffProfileModel(model);
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = "Failed to add Staff Profile";
                return response;
            }
            response.IsSuccess = true;
            response.Message = "Successfully added Staff Profile";
            return response;
        }

        public StaffProfileResponse Update(int id, StaffProfileModel model)
        {
            var response = new StaffProfileResponse();

            try
            {
                _staffProfileRepo.UpdateStaffProfileModel(id, model);
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = "Failed to update Staff Profile";
                return response;
            }
            response.IsSuccess = true;
            response.Message = "Successfully updated Staff Profile";
            return response;
        }
    }

        

    public class GetAllStaffProfileResponse : HandlerResponse
    {
        public List<StaffProfileModel> data = new List<StaffProfileModel>();
    }
    public class GetStaffProfileResponse : HandlerResponse
    {
        public StaffProfileModel data = new StaffProfileModel();
    }
    public class StaffProfileResponse : HandlerResponse { }
}
