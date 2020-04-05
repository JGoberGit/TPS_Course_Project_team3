using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TPSWeb_API.Core.Features.StaffRequests
{
    [Table("REQUEST")]
    public class StaffRequestModel
    {
        [Key]
        [Column("REQUESTID")]
        public Int32 RequestId { get; set; }

        [Column("CLIENTID")]
        public Int32 ClientId { get; set; }

        [Column("TYPEOFWORK")]
        public String TypeOfWork { get; set; }

        [Column("SALARY")]
        public Double Salary { get; set; }

        [Column("CITY")]
        public String City { get; set; }

        [Column("STATE")]
        public String State { get; set; }

        [Column("REQSTATUS")]
        public String RequestStatus { get; set; }
    }
}


