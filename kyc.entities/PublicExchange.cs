namespace kyc.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    // using System.Data.Entity.Spatial;

    [Table("PublicExchange")]
    public partial class PublicExchange
    {
        public PublicExchange()
        {
            FIs = new HashSet<FinancialInstitution>();
        }

        public int Id { get; set; }

        [Required]
        public string Exchange { get; set; }

        public virtual ICollection<FinancialInstitution> FIs { get; set; }
    }
}
