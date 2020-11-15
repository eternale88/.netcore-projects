using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutureValueCalculator.Models
{
    public class FutureValueModel
    {
        [Required(ErrorMessage = "Please enter a monthly investment")]
        [Range(1, 500, ErrorMessage = "Monthly investment must be between 1 and 500")]
        [Display(Name = "Monthly Investment:")]
        public decimal? MonthlyInvestment { get; set; }

        [Range(0.1, 10.0, ErrorMessage = "Monthly investment must be between 0.1 and 10.0")]
        [Required(ErrorMessage = "Please enter a yearly interest rate")]
        [Display(Name = "Yearly Interest Rate:")]
        public decimal? YearlyInterestRate { get; set; }

        [Range(1, 50, ErrorMessage = "Number of Years must be between 1 and 50 years")]
        [Required(ErrorMessage = "Please enter number of years")]
        [Display(Name = "Number of Years:")]
        public int? Years { get; set; }

        public decimal Calculate()
        {
            int months = Years.Value * 12;
            decimal monthlyInterestRate = YearlyInterestRate.Value / 12 / 100;

            decimal futureValue = 0;

          for(int i = 0; i < months; i++)
            {
                futureValue = (futureValue + MonthlyInvestment.Value) * (1 + monthlyInterestRate);
            }

            return futureValue;
        }
    }
}
