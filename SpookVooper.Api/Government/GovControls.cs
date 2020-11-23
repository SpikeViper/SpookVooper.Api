using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SpookVooper.Api.Government
{
    public class GovControls
    {
        [Key]
        public string Id { get; set; }

        // Budgetary
        public decimal UBIBudgetPercent { get; set; }

        // Tax Rates
        public decimal SalesTaxRate { get; set; }
        public decimal CorporateTaxRate { get; set; }
        public decimal PayrollTaxRate { get; set; }
        public decimal CapitalGainsTaxRate { get; set; }
        public decimal InactivityTaxRate { get; set; }

        // Tax revenues
        public decimal SalesTaxRevenue { get; set; }
        public decimal CorporateTaxRevenue { get; set; }
        public decimal PayrollTaxRevenue { get; set; }
        public decimal CapitalGainsTaxRevenue { get; set; }
        public decimal InactivityTaxRevenue { get; set; }

        // General Revenues
        public decimal SalesRevenue { get; set; }

        // UBI "pot"
        public decimal UBIAccount { get; set; }

        // Rank payment percentages
        public decimal SpleenPayPercent { get; set; }
        public decimal CrabPayPercent { get; set; }
        public decimal GatyPayPercent { get; set; }
        public decimal CorgiPayPercent { get; set; }
        public decimal OofPayPercent { get; set; }
        public decimal UnrankedPayPercent { get; set; }
    }
}
