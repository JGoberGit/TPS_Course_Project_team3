using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPSWeb_API.Core.Utilities;

namespace TPSWeb_API.Core.Features.StaffRequests
{
    public class StaffRequestsHandler
    {
        private StaffRequestsRespository _staffRequestRepo;
        public StaffRequestsHandler(StaffRequestsRespository staffRequestRepo)
        {
            _staffRequestRepo = staffRequestRepo;
        }

        public GetAllStaffRequestsResponse GetAll()
        {
            var response = new GetAllStaffRequestsResponse();
            try
            {
                response.data = _staffRequestRepo.GetStaffRequestModels();

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to get all staff requests: {e.StackTrace}", e);
                response.IsSuccess = false;
                response.Message = "Failed to retrieve staff requests";
            }
            response.IsSuccess = true;
            response.Message = $"Successfull retrieved {response.data.Count} staff requests";
            return response;
        }

        public GetStaffRequestResponse Get(int id)
        {
            var response = new GetStaffRequestResponse();
            try
            {
                response.data = _staffRequestRepo.GetStaffRequestModel(id);

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to retrieve staff request {id}: {e.StackTrace}", e);
                response.IsSuccess = false;
                response.Message = $"Failed to retrieve staff request {id}";
            }
            response.IsSuccess = true;
            response.Message = $"Successfull retrieved {id} staff request";
            return response;
        }

        public StaffRequestResponse Add(StaffRequestModel model)
        {
            var response = new StaffRequestResponse();

            try
            {
                _staffRequestRepo.AddStaffRequestModel(model);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to add staff request: {e.StackTrace}", e);
                response.IsSuccess = false;
                response.Message = "Failed to add staff request";
                return response;
            }
            response.IsSuccess = true;
            response.Message = "Successfully added staff request";
            return response;
        }

        public StaffRequestResponse Update(int id, StaffRequestModel model)
        {
            var response = new StaffRequestResponse();

            try
            {
                _staffRequestRepo.UpdateStaffRequestModel(id, model);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to update staff request {id}: {e.StackTrace}", e);
                response.IsSuccess = false;
                response.Message = "Failed to update staff request";
                return response;
            }
            response.IsSuccess = true;
            response.Message = "Successfully updated staff request";
            return response;
        }
    }

    public class GetAllStaffRequestsResponse : HandlerResponse
    {
        public List<StaffRequestModel> data = new List<StaffRequestModel>();
    }
    public class GetStaffRequestResponse : HandlerResponse
    {
        public StaffRequestModel data = new StaffRequestModel();
    }
    public class StaffRequestResponse : HandlerResponse { }
}
