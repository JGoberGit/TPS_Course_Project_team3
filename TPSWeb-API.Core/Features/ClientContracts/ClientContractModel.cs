using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TPSWeb_API.Core.Features.ClientContracts
{
    [Table("CLIENT")]
    public class ClientContractModel
    {
        [Key]
        [Column("CLIENTID")]
        public Int32 ClientId { get; set; }

        [Column("NAME")]
        public String Name { get; set; }

        [Column("DESCRIPTION")]
        public String Description { get; set; }
    }
}
