using FitHub.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace FitHub.Models
{
    public class Booking
    {
        [Key]
        [Required(ErrorMessage = "Booking Id is Required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Booking Id")]
        public string BookingID { get; set; }

        [ForeignKey("User")]
        [Required(ErrorMessage = "User Id is Required")]
        [Display(Name = "User Id")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Amenity Id is Required")]
        [Display(Name = "Amenity Id")]
        public string AmenityID { get; set; }

        [Required(ErrorMessage = "Booking Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [DateGreaterThanEqualToCurrent(ErrorMessage = "The date must be greater than or equal to the current date.")]
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = "Slot Number is Required")]
        [Display(Name = "Slot Number")]
        public string SlotNumber { get; set; }

        [Required(ErrorMessage = "Number Of People is Required")]
        [Display(Name = "Number Of People")]
        public int NumberOfPeople { get; set; }

        [Required(ErrorMessage = "Amount Paid is Required")]
        [DataType(DataType.Currency)]
        [Display(Name = "Amount Paid")]
        public decimal AmountPaid { get; set; }

        [Required(ErrorMessage = "Purchased Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [DateEqualToCurrent(ErrorMessage = "The date must be equal to the current date.")]
        public DateTime PurchasedDate { get; set; }

        public virtual User User { get; set; }
    }
}

