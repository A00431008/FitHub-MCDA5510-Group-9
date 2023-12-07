﻿using System;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitHub.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitHub.Models
{
    public class Membership
    {
        private decimal _AmountPaid;
        private DateTime _EndDate;
        private string _MembType;


        [Key]
        [HiddenInput(DisplayValue = true)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MembershipID { get; set; }

        [ForeignKey("User")]
        [HiddenInput(DisplayValue = true)]
        public string UserID { get; set; }

        [Required]
        public string MembershipType { get; set; }

        [Required]
        //[RegularExpression(@"^\d{4}-\d{2}-\d{2}$", 
          //  ErrorMessage = "Date must be in the format 'YYYY-MM-DD'.")]
        [DateNotInPastAttribute(ErrorMessage = 
            "The date must be greater than or equal to the current date.")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [HiddenInput(DisplayValue = true)]
        [Display(Name = "End Date"), DataType(DataType.Date)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EndDate { get; set; }
        
        //public DateTime EndDate
        //{
        //    get
        //    {
        //        return EndDate;
        //    }
        //    set
        //    {
        //        if (MD != null)
        //        {
        //            EndDate = StartDate.AddMonths(MD.DurationMonths);
        //        }
        //        //return StartDate; //doubtful
        //    }
        //}
        

        [Required/*(ErrorMessage = "Amount Paid is Required")*/]
        [DataType(DataType.Currency)]
        [Display(Name = "Amount Paid")]
        /*[DatabaseGenerated(DatabaseGeneratedOption.Computed)]*/
        public decimal AmountPaid { get; set; }
        //public decimal AmountPaid
        //{
        //    get
        //    {
        //        return AmountPaid;
        //    }
        //    private set
        //    {
        //        if (MD != null)
        //        {
        //            AmountPaid = MD.Cost;
        //        }
        //    }
        //}

        [ForeignKey("MD")]
        [HiddenInput(DisplayValue = true)]
        public string MembershipTypeID { get; set; }

        public virtual MembershipDetail MD { get; set; }
        public virtual User User { get; set; }
    }
}
