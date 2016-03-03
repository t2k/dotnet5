namespace KYC.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Location
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Location Type")]
        public LocationType? LocationType { get; set; }
        [Display(Name = "Location")]
        [Required, DataType(DataType.MultilineText)]
        public string FullAddress { get; set; }
        public Customer Customer { get; set; }
    }
}
