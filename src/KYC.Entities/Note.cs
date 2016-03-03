namespace KYC.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Note")]
    public partial class Note
    {
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        public DateTime Timestamp { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
