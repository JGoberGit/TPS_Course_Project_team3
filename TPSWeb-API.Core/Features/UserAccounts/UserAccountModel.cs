using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSWeb_API.Core.Features.UserAccounts
{
    [Table("USERACCOUNTS")]
    public class UserAccountModel
    {
        [Key]
        [Column("USERID")]
        public String UserId { get; set; }

        [Column("PASSWORD")]
        public String Password { get; set; }
        [Column("ACCOUNTTYPE")]
        public String AccountType { get; set; }
    }
}
