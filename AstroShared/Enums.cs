using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AstroShared
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum KundaliDatesRadio
    {
        Kp,
        RedBook
    }

    public enum Period
    {
        Maha,
        Antar,
        Pryan
    }

    public enum Dasha
    {
        Dasha,
        NakSwami,
        Both
    }

    public enum AddressType
    {
        Home,
        Billing,
        Office,
    }
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer,
        Stripe,
        CashOnDelivery
    }

    //[JsonConverter(typeof(StringEnumConverter))]
    public enum ShippingMethod
    {
        Standard,
        Express,
    }

    //[JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatus
    {
        PendingPayment,
        Processing,
        Shipped,
        Delivered,
        Cancelled,
        Returned
    }

    //[JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentStatus
    {
        Pending,
        Processing,
        Completed,
        Failed,
        Refunded
    }

    //[JsonConverter(typeof(StringEnumConverter))]
    public enum ProductStatus
    {
        Draft,
        //PendingApproval,
        //Approved,
        //Rejected,
        Published,
        //Discontinued,
        //OnSale,
        Archived,

        //[Display(Name = "Out of Stock")]
        //OutOfStock,

        //[Display(Name = "In Stock")]
        //InStock,
    }

    //[JsonConverter(typeof(StringEnumConverter))]
    public enum CategoryStatus
    {
        Draft,
        PendingApproval,
        Approved,
        Rejected,
        Active,
        Inactive,
        Archived
    }

    public enum FileType
    {
        Text,
        Image,
        Audio,
        Video,
        PDF,
        Spreadsheet,
        Presentation,
        Archive,
        Other
    }

}
