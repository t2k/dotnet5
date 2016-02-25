namespace kyc.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   //using System.Data.Entity.Spatial;

    [Table("CustomerEmployeeRole")]
    public partial class CustomerEmployeeRole
    {
        public int Id { get; set; }

        public int CustomerID { get; set; }

        public int EmployeeId { get; set; }

        public int RoleId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Role Role { get; set; }
    }
}
