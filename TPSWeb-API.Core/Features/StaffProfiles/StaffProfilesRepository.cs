using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using TPSWeb_API.Core.Properties;
using TPSWeb_API.Core.Utilities;

namespace TPSWeb_API.Core.Features.StaffProfiles
{
    public class StaffProfilesRepository
    {
        private StaffProfileModelContext db = new StaffProfileModelContext();
        
        public List<StaffProfileModel> GetStaffProfileModels()
        {
            return db.StaffProfileModel.ToList();
        }

        public StaffProfileModel GetStaffProfileModel(int id)
        {
            return db.StaffProfileModel.FirstOrDefault((a) => a.StaffId == id);
        }

        public void AddStaffProfileModel(StaffProfileModel staffProfileModel)
        {
            db.StaffProfileModel.Add(staffProfileModel);
            db.SaveChanges();
        }

        public void UpdateStaffProfileModel(int id, StaffProfileModel staffProfileModel)
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
            StaffProfileModel tstaffProfileModel = db.StaffProfileModel.FirstOrDefault((a) => a.StaffId == id);
            staffProfileModel.StaffId = tstaffProfileModel.StaffId; 
            db.Entry(tstaffProfileModel).CurrentValues.SetValues(staffProfileModel);
            db.SaveChanges();
        }
    }

    public class StaffProfileModelContext : SQLServerDBContext
    {
        public DbSet<StaffProfileModel> StaffProfileModel { get; set; }
    }
}
