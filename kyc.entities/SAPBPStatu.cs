namespace kyc.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SAPBPStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SAPBPStatu()
        {
            CustomerSAPDetails = new HashSet<CustomerSAPDetail>();
        }

        [StringLength(4)]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerSAPDetail> CustomerSAPDetails { get; set; }
    }
}
