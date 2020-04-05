using System;
using System.Collections.Generic;
using System.Diagnostics;
using TPSWeb_API.Core.Utilities;

namespace TPSWeb_API.Core.Features.ClientContracts
{
    public class ClientContractsHandler
    {
        private ClientContractsRepository _clientContractsRepo;

        public ClientContractsHandler(ClientContractsRepository clientContractsRepo)
        {
            _clientContractsRepo = clientContractsRepo;
        }

        public GetAllClientContractsResponse GetAll()
        {
            var response = new GetAllClientContractsResponse();
            try
            {
                response.data = _clientContractsRepo.GetClientContractModels();

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to get all client contracts: {e.StackTrace}", e);
                response.IsSuccess = false;
                response.Message = "Failed to retrieve client contracts";
            }
            response.IsSuccess = true;
            response.Message = $"Successfull retrieved {response.data.Count} client contracts";
            return response;
        }

        public GetClientContractsResponse Get(int id)
        {
            var response = new GetClientContractsResponse();
            try
            {
                response.data = _clientContractsRepo.GetClientContractModel(id);

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to retrieve client contract {id}: {e.StackTrace}", e);
                response.IsSuccess = false;
                response.Message = $"Failed to retrieve client contract {id}";
            }
            response.IsSuccess = true;
            response.Message = $"Successfull retrieved {id} client contract";
            return response;
        }

        public ClientContractsResponse Add(ClientContractModel model)
        {
            var response = new ClientContractsResponse();

            try
            {
                _clientContractsRepo.AddClientContractModel(model);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to add client contract: {e.StackTrace}", e);
                response.IsSuccess = false;
                response.Message = "Failed to add client contract";
                return response;
            }
            response.IsSuccess = true;
            response.Message = "Successfully added client contract";
            return response;
        }

        public ClientContractsResponse Update(int id, ClientContractModel model)
        {
            var response = new ClientContractsResponse();

            try
            {
                _clientContractsRepo.UpdateClientContractModel(id, model);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to update client contract: {e.StackTrace}", e);
                response.IsSuccess = false;
                response.Message = "Failed to update client contract";
                return response;
            }
            response.IsSuccess = true;
            response.Message = "Successfully updated client contract";
            return response;
        }

    }

    public class GetAllClientContractsResponse : HandlerResponse
    {
        public List<ClientContractModel> data = new List<ClientContractModel>();
    }
    public class GetClientContractsResponse : HandlerResponse
    {
        public ClientContractModel data = new ClientContractModel();
    }
    public class ClientContractsResponse : HandlerResponse { }
}





