using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    /// <summary>
    /// Only available for UK companies (i.e. those which support payroll in FreeAgent)
    /// </summary>
    public class Period : UpdatableModel, IRemoveUrlOnSerialization
    {
        [JsonProperty("period")]
        public int PayrollPeriod { get; set; }
        [JsonProperty("frequency")]
        public string Frequency { get; set; }
        [JsonProperty("dated_on")]
        public DateTime DatedOn { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("employment_allowance_claimed")]
        public bool EmploymentAllowanceClaimed { get; set; }
        [JsonProperty("employment_allowance_amount")]
        public decimal EmploymentAllowanceAmount { get; set; }
        [JsonProperty("construction_industry_scheme_deduction")]
        public decimal ConstructionIndustrySchemeDeduction { get; set; }
        [JsonProperty("payslips")]
        public List<Payslip> Payslips { get; set; }

        public static class PeriodStatus
        {
            public static string Unfiled = "unfiled";
            public static string Pending = "pending";
            public static string Rejected = "rejected";
            public static string PartiallyFiled = "partially_filed";
            public static string Filed = "filed";
        }
    }

    public class Payslip
    {
        [JsonProperty("user")]
        public Uri User { get; set; }
        [JsonProperty("tax_code")]
        public string TaxCode { get; set; }
        [JsonProperty("dated_on")]
        public DateTime DatedOn { get; set; }
        [JsonProperty("basic_pay")]
        public decimal BasicPay { get; set; }
        [JsonProperty("tax_deducted")]
        public decimal TaxDeducted { get; set; }
        [JsonProperty("employee_ni")]
        public decimal EmployeeNI { get; set; }
        [JsonProperty("employer_ni")]
        public decimal EmployerNI { get; set; }
        [JsonProperty("other_deductions")]
        public decimal OtherDeductions { get; set; }
        [JsonProperty("student_loan_deduction")]
        public decimal StudentLoanDeduction { get; set; }
        [JsonProperty("postgrad_loan_deduction")]
        public decimal PostgradLoanDeduction { get; set; }
        [JsonProperty("overtime	")]
        public decimal Overtime { get; set; }
        [JsonProperty("commission")]
        public decimal Commission { get; set; }
        [JsonProperty("bonus")]
        public decimal Bonus { get; set; }
        [JsonProperty("allowance")]
        public decimal Allowance { get; set; }
        [JsonProperty("statutory_sick_pay")]
        public decimal StatutorySickPay { get; set; }
        [JsonProperty("statutory_maternity_pay")]
        public decimal StatutoryMaternityPay { get; set; }
        [JsonProperty("statutory_paternity_pay")]
        public decimal StatutoryPaternityPay { get; set; }
        [JsonProperty("statutory_adoption_pay	")]
        public decimal StatutoryAdoptionPay { get; set; }
        [JsonProperty("statutory_parental_bereavement_pay")]
        public decimal StatutoryParentalBereavementPay { get; set; }
        [JsonProperty("absence_payments")]
        public decimal AbsencePayments { get; set; }
        [JsonProperty("other_payments")]
        public decimal OtherPayments { get; set; }
        [JsonProperty("employee_pension")]
        public decimal EmployeePension { get; set; }
        [JsonProperty("employer_pension")]
        public decimal EmployerPension { get; set; }
        [JsonProperty("attachments")]
        public decimal Attachments { get; set; }
        [JsonProperty("payroll_giving")]
        public decimal PayrollGiving { get; set; }
        [JsonProperty("ni_calc_type")]
        public string NiCalcType { get; set; }
        [JsonProperty("frequency")]
        public string Frequency { get; set; }
        [JsonProperty("additional_statutory_paternity_pay")]
        public decimal AdditionalStatutoryPaternityPay { get; set; }
        [JsonProperty("deductions_subject_to_nic_but_not_paye")]
        public decimal DeductionsSubjectToNicButNotPaye { get; set; }
        [JsonProperty("other_deductions_from_net_pay")]
        public decimal OtherDeductionsFromNetPay { get; set; }
        [JsonProperty("employee_pension_not_under_net_pay")]
        public decimal EmployeePensionNotUnderNetPay { get; set; }
        [JsonProperty("ni_letter")]
        public string NiLetter { get; set; }
        [JsonProperty("deduct_student_loan")]
        public bool DeductStudentLoan { get; set; }
        [JsonProperty("student_loan_deductions_plan")]
        public string StudentLoanDeductionsPlan { get; set; }
        [JsonProperty("deduct_postgrad_loan")]
        public bool DeductPostgradLoan { get; set; }
        [JsonProperty("week_1_month_1_basis")]
        public bool Week1Month1Basis { get; set; }
        [JsonProperty("deduction_free_pay")]
        public decimal DeductionFreePay { get; set; }
        [JsonProperty("hours_worked")]
        public decimal HoursWorked { get; set; }
    }

    public class PeriodWrapper
    {
        public PeriodWrapper()
        {
            period = null;
        }
        public Period period { get; set; }
    }

    public class PeriodsWrapper
    {
        public PeriodsWrapper()
        {
            periods = new List<Period>();
        }

        public List<Period> periods { get; set; }
    }
}

