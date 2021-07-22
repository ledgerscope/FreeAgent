using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class CreditNote : SalesTransactionModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        [JsonProperty("refunded_value")]
        public decimal RefundedValue { get; set; }
        [JsonProperty("refunded_on")]
        public DateTime RefundedOn { get; set; }
        [JsonProperty("credit_note_items")]
        public List<CreditNoteItem> CreditNoteItems { get; set; }
    }

    public class CreditNoteItem : SalesTransactionItemModel { }

    public static class CreditNoteStatus
    {
        public static string Draft = "Draft";
        public static string Open = "Open";
        public static string Overdue = "Overdue";
        public static string Refunded = "Refunded";
        public static string WrittenOff = "Written-off";
    }

    public static class CreditNoteECStatus
    {
        public static string UKNonEc = "UK/Non-EC";
        public static string ECGoods = "EC Goods";
        public static string ECServices = "EC Services";
        public static string ECVatMoss = "EC VAT MOSS";
    }

    public static class CreditNoteItemType
    {
        public static string Hours = "Hours";
        public static string Days = "Days";
        public static string Weeks = "Weeks";
        public static string Months = "Months";
        public static string Years = "Years";
        public static string Products = "Products";
        public static string Services = "Services";
        public static string Training = "Training";
        public static string Expenses = "Expenses";
        public static string Comment = "Comment";
        public static string Bills = "Bills";
        public static string Discount = "Discount";
        public static string Credit = "Credit";
        public static string VAT = "VAT";
        public static string NoUnit = "No Unit";
    }

    public static class CreditNoteViewFilter
    {
        public static string RecentOpenOrOverdue = "recent_open_or_overdue";
        public static string Open = "open";
        public static string Overdue = "overdue";
        public static string OpenOrOverdue = "open_or_overdue";
        public static string Draft = "draft";
        public static string Refunded = "refunded";
        private static string lastNMonths = "last_{0}_months";

        public static string LastNMonths(int months = 1)
        {
            return string.Format(lastNMonths, months);
        }
    }

    public class CreditNoteWrapper
    {
        public CreditNoteWrapper()
        {
            creditNote = null;
        }

        public CreditNote creditNote { get; set; }
    }

    public class CreditNotesWrapper
    {
        public CreditNotesWrapper()
        {
            creditNotes = new List<CreditNote>();
        }

        public List<CreditNote> creditNotes { get; set; }
    }

    public class CreditNoteEmailWrapper
    {
        public CreditNoteEmailWrapper()
        {
            creditNote = new CreditNoteEmail();
        }

        public CreditNoteEmail creditNote { get; set; }
    }

    public class CreditNoteEmail
    {
        public CreditNoteEmail()
        {
            email = new CreditNoteEmailDetail();
        }

        public CreditNoteEmailDetail email { get; set; }
    }

    public class CreditNoteEmailDetail
    {
        public string to { get; set; }

        public string @from { get; set; }

        public string subject { get; set; }

        public string body { get; set; }
    }
}




