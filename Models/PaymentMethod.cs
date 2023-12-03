﻿using FitHub.Validations;
using System.ComponentModel.DataAnnotations;

namespace FitHub.Models
{
    public class PaymentMethod
    {
        [Required(ErrorMessage = "Card Type is Required")]
        public string CardType { get; set; }

        [Required(ErrorMessage = "Name on Card is Required")]
        [MaxLength(50, ErrorMessage = "Maximum Length is 50 characters")]
        public string NameOnCard { get; set; }

        [Required(ErrorMessage = "Card Number is Required")]
        [CreditCard(ErrorMessage = "Invalid Credit Card Number")]
        [CardValidation(ErrorMessage = "Invalid Credit Card Number")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Expiry Date is Required")]
        [ExpiryValidation]
        public string ExpiryDate { get; set; }

        [Required(ErrorMessage = "CVV is Required")]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Invalid CVV")]
        public string CVV { get; set; }   
    }
}