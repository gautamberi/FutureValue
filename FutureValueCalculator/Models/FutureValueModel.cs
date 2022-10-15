using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FutureValueCalculator.Models
{
    public class FutureValueModel
    {
        [Required]
        [Display(Name ="Monthly Investment:")]
        [Range(100, 5000)]
        public decimal Investment { get; set; }
        
        [Required]
        [Range(0.01, 10.00)]
        [Display(Name = "Monthly Rate:")]
        public decimal Rate { get; set; }
        
        [Required]
        [Display(Name = "Years:")]
        [Range(1, 30)]
        public int Years { get; set; }

        [Display(Name = "Email Address:")]
        [EmailAddress(ErrorMessage ="Error! - Email Address is not in correct format")]
        public string SomeText { get; set; }
        public FutureValueModel()
        {
        }

        //public decimal FutureValue
        //{
        //    get
        //    {
        //        decimal futureValue = 0;
        //        int months = Years * 12;
        //        decimal monthlyRate = Rate / 12 / 100;

        //        for (int i = 0; i < months; i++)
        //        {
        //            futureValue = (futureValue + Investment) * (1 + monthlyRate);
        //        }

        //        return futureValue;
        //    }
        //}
        public decimal CalculateFV()
        {
            decimal futureValue = 0;
            //if (!IsWithInRange(100, 5000, Investment) && !IsWithInRange(.01m, 10.00m, Rate))
            //{
            //    throw new Exception("Invalid Data");
            //}
            //if (Investment<100 || Investment>5000)
            //{
            //    throw new Exception("Invalid Data");
            //}
            int months = Years * 12;
            decimal monthlyRate = Rate / 12 / 100;

            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + Investment) * (1 + monthlyRate);
            }

            return Decimal.Round(futureValue,2);
        }

        public bool IsWithInRange(decimal min, decimal max, decimal value)
        {
            bool returnVal = false;
            if (value > min && value < max)
            {
                return true;
            }
            return returnVal;
        }
    }
}