using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSWeb_API.Core.Features.StaffProfiles
{
    [Table("STAFF")]
    public class StaffProfileModel
    {
        [Key]
        [Column("STAFFID")]
        public Int32 StaffId { get; set; }

        [Column("FIRSTNAME")]
        public String FirstName { get; set; }

        [Column("LASTNAME")]
        public String LastName { get; set; }

        [Column("CITY")]
        public String City { get; set; }

        [Column("STATE")]
        public String State { get; set; }

        [Column("RESUME")]
        public byte[] Resume { get; set; }

        [Column("PROFILEIMAGE")]
        public byte[] ProfileImage { get; set; }
        
        [Column("SALARY")]
        public Double Salary { get; set; }

        [Column("EDUCATION")]
        public String Education { get; set; }

        [Column("YEARSEXPERIENCE")]
        public Int32 YearsExperience { get; set; }
       
    }
}
