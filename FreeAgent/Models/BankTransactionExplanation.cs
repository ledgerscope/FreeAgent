﻿using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class BankTransactionExplanation : UpdatableModel, IAttachmentModel, IRemoveUrlOnSerialization
    {
        [JsonProperty("bank_account")]
        public Uri BankAccount { get; set; }
        [JsonProperty("bank_transaction")]
        public Uri BankTransaction { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("ec_status")]
        public string EcStatus { get; set; }
        [JsonProperty("place_of_supply")]
        public string PlaceOfSupply { get; set; }
        [JsonProperty("dated_on")]
        public DateTime DatedOn { get; set; }
        [JsonProperty("gross_value")]
        public decimal GrossValue { get; set; }
        [JsonProperty("sales_tax_rate")]
        public decimal SalesTaxRate { get; set; }
        [JsonProperty("second_sales_tax_rate")]
        public decimal SecondSalesTaxRate { get; set; }
        [JsonProperty("sales_tax_value")]
        public decimal SalesTaxValue { get; set; }
        [JsonProperty("second_sales_tax_value")]
        public decimal SecondSalesTaxValue { get; set; }
        [JsonProperty("sales_tax_status")]
        public string SalesTaxStatus { get; set; }
        [JsonProperty("second_sales_tax_status")]
        public string SecondSalesTaxStatus { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("category")]
        public Uri Category { get; set; }
        [JsonProperty("cheque_number")]
        public string ChequeNumber { get; set; }
        [JsonProperty("attachment")]
        public Attachment Attachment { get; set; }
        [JsonProperty("marked_for_review")]
        public bool MarkedForReview { get; set; }
        [JsonProperty("is_money_in")]
        public bool IsMoneyIn { get; set; }
        [JsonProperty("is_money_out")]
        public bool IsMoneyOut { get; set; }
        [JsonProperty("is_money_paid_to_user")]
        public bool IsMoneyPaidToUser { get; set; }
        [JsonProperty("is_locked")]
        public bool IsLocked { get; set; }
        [JsonProperty("locked_attributes")]
        public List<string> LockedAttributes { get; set; }
        [JsonProperty("locked_reason")]
        public string LockedReason { get; set; }

        // Additional properties for Payment/Refund
        [JsonProperty("project")]
        public Uri Project { get; set; }
        [JsonProperty("rebill_type")]
        public string RebillType { get; set; }
        [JsonProperty("rebill_factor")]
        public decimal RebillFactor { get; set; }
        [JsonProperty("receipt_reference")]
        public string ReceiptReference { get; set; }

        // Additional properties for Invoice Receipt/CreditNote Refund
        [JsonProperty("paid_invoice")]
        public Uri PaidInvoice { get; set; }
        [JsonProperty("foreign_currency_value")]
        public decimal ForeignCurrencyValue { get; set; }

        // Additional properties for Bill Payment/Bill Refund
        [JsonProperty("paid_bill")]
        public Uri PaidBill { get; set; }

        // Additional properties for Money Paid to User/Money Received from User
        [JsonProperty("paid_user")]
        public Uri PaidUser { get; set; }

        // Additional properties for Transfer to Another Account/Transfer from Another Account
        [JsonProperty("transfer_bank_account")]
        public Uri TransferBankAccount { get; set; }

        // Additional properties for Purchase of Stock/Sale of Stock
        [JsonProperty("stock_item")]
        public Uri StockItem { get; set; }
        [JsonProperty("stock_altering_quantity")]
        public decimal StockAlteringQuantity { get; set; }

        // Additional properties for Purchase of Capital Asset/Disposal of Capital Asset
        [JsonProperty("capital_asset")]
        public Uri CapitalAsset { get; set; }
        /// <summary>
        /// Even though FA API docs say this should be an int, some companies are having this value set to string (for example: "3 Years")
        /// </summary>
        [JsonProperty("asset_life_years")]
        public string AssetLifeYears { get; set; }
        [JsonProperty("disposed_asset")]
        public Uri DisposedAsset { get; set; }

        public static class BankTransactionExplanationType
        {
            // Money Out
            public static string SalesRefund = "Sales Refund";
            public static string Payment = "Payment";
            public static string BillPayment = "Bill Payment";
            public static string TransferToAnotherAccount = "Transfer to Another Account";
            public static string MoneyPaidToUser = "Money Paid to User";
            public static string PurchaseOfCapitalAsset = "Purchase of Capital Asset";
            public static string PurchaseOfStock = "Purchase of Stock";
            public static string CreditNoteRefund = "Credit Note Refund";
            public static string PaymentOfHPAgreement = "Payment of HP Agreement";
            public static string OtherMoneyOut = "Other Money Out";

            // Money In
            public static string InvoiceReceipt = "Invoice Receipt";
            public static string Sales = "Sales";
            public static string TransferFromAnotherAccount = "Transfer from Another Account";
            public static string Refund = "Refund";
            public static string BillRefund = "Bill Refund";
            public static string MoneyReceivedFromUser = "Money Received from User";
            public static string DisposalOfCapitalAsset = "Disposal of Capital Asset";
            public static string SaleOfStock = "Sale of Stock";
        }
    }

    public static class BankTransactionExplanationECStatus
    {
        public static string UKNonEc = "UK/Non-EC";
        public static string ECGoods = "EC Goods";
        public static string ECServices = "EC Services";
        public static string ECVatMoss = "EC VAT MOSS";
    }

    public class BankTransactionExplanationWrapper
    {
        public BankTransactionExplanationWrapper()
        {
            bank_transaction_explanation = null;
        }

        public BankTransactionExplanation bank_transaction_explanation { get; set; }
    }

    public class BankTransactionExplanationsWrapper
    {
        public BankTransactionExplanationsWrapper()
        {
            bank_transaction_explanations = new List<BankTransactionExplanation>();
        }

        public List<BankTransactionExplanation> bank_transaction_explanations { get; set; }
    }
}



