using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TPSWeb_API.Core.Utilities;

namespace TPSWeb_API.Core.Features.StaffRequests
{
    public class StaffRequestsRespository
    {
        private StaffRequestModelContext db = new StaffRequestModelContext();

        public List<StaffRequestModel> GetStaffRequestModels()
        {
            return db.StaffRequestModel.ToList();
        }

        public StaffRequestModel GetStaffRequestModel(int id)
        {
            return db.StaffRequestModel.FirstOrDefault((a) => a.RequestId == id);
        }

        public void AddStaffRequestModel(StaffRequestModel staffRequestModel)
        {
            db.StaffRequestModel.Add(staffRequestModel);
            db.SaveChanges();
        }

        public void UpdateStaffRequestModel(int id, StaffRequestModel staffRequestModel)
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
            StaffRequestModel tstaffRequestModel = db.StaffRequestModel.FirstOrDefault((a) => a.RequestId == id);
            staffRequestModel.RequestId = tstaffRequestModel.RequestId;
            db.Entry(tstaffRequestModel).CurrentValues.SetValues(staffRequestModel);
            db.SaveChanges();
        }
    }

    public class StaffRequestModelContext : SQLServerDBContext
    {
        public DbSet<StaffRequestModel> StaffRequestModel { get; set; }
    }
}
