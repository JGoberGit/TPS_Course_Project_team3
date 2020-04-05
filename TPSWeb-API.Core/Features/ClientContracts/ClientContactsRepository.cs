using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPSWeb_API.Core.Utilities;

namespace TPSWeb_API.Core.Features.ClientContracts
{
    public class ClientContractsRepository
    {
        private ClientContractModelContext db = new ClientContractModelContext();

        public List<ClientContractModel> GetClientContractModels()
        {
            return db.ClientContractModel.ToList();
        }

        public ClientContractModel GetClientContractModel(int id)
        {
            return db.ClientContractModel.FirstOrDefault((a) => a.ClientId == id);
        }

        public void AddClientContractModel(ClientContractModel clientContractModel)
        {
            db.ClientContractModel.Add(clientContractModel);
            db.SaveChanges();
        }

        public void UpdateClientContractModel(int id, ClientContractModel clientContractModel)
        {
            /*
             *Currently overriding ALL fields with incoming data, even if empty. Could potentially add check for each field
             * on if empty or different
            Example: 
            if (!ttaffProfileModel.FIRSTNAME != null || !ttaffProfileModel.FIRSTNAME.Equals(staffProfileModel.FIRSTNAME, StringComparison.Ordinal))
             {
                 ttaffProfileModel.FIRSTNAME = staffProfileModel.FIRSTNAME;
                 db.Entry(ttaffProfileModel).Property("FIRSTNAME").IsModified = true;
             }
             db.SaveChanges();
              */
            ClientContractModel tclientContractModel = db.ClientContractModel.FirstOrDefault((a) => a.ClientId == id);
            clientContractModel.ClientId = tclientContractModel.ClientId;
            db.Entry(tclientContractModel).CurrentValues.SetValues(clientContractModel);
            db.SaveChanges();
        }
    }

    public class ClientContractModelContext : SQLServerDBContext
    {
        public DbSet<ClientContractModel> ClientContractModel { get; set; }
    }
}
