using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Government
{
    public class GovControls
    {
        [Key]
        public string Id { get; }

        // Budgetary
        public decimal UBIBudgetPercent { get; }

        // Tax Rates
        public decimal SalesTaxRate { get; }
        public decimal CorporateTaxRate { get; }
        public decimal PayrollTaxRate { get; }
        public decimal CapitalGainsTaxRate { get; }
        public decimal InactivityTaxRate { get; }

        // Tax revenues
        public decimal SalesTaxRevenue { get; }
        public decimal CorporateTaxRevenue { get; }
        public decimal PayrollTaxRevenue { get; }
        public decimal CapitalGainsTaxRevenue { get; }
        public decimal InactivityTaxRevenue { get; }

        // General Revenues
        public decimal SalesRevenue { get; }

        // UBI "pot"
        public decimal UBIAccount { get; }

        // Rank payment percentages
        public decimal SpleenPayPercent { get; }
        public decimal CrabPayPercent { get; }
        public decimal GatyPayPercent { get; }
        public decimal CorgiPayPercent { get; }
        public decimal OofPayPercent { get; }
        public decimal UnrankedPayPercent { get; }
    }
}
