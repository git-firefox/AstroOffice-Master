using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AstroOfficeWeb.Shared.Utilities
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

    public enum UserStatus
    {
        Active,
        Inactive,
        Suspended
    }

    public enum UserRole
    {
        Guest,
        Member,
        Astrologer,
        [Description("Product Manager")]
        ProductManager,
        [Description("Order Manager")]
        OrderManager,
        Administrator
    }

    public enum ActionMode
    {
        View,
        Edit,
        Delete,
        Add
    }

    public enum SnackbarPosition
    {
        TopStart,
        TopLeft,
        TopCenter,
        TopRight,
        TopEnd,

        BottomStart,
        BottomLeft,
        BottomCenter,
        BottomRight,
        BottomEnd
    }

    public enum SnackbarType
    {
        Dark,
        Info,
        Success,
        Warning,
        Error
    }
    public enum ProductSorting
    {
        [Description("Default Sorting")]
        Default,

        [Description("Sort by Name (A to Z)")]
        NameAscending,

        [Description("Sort by Name (Z to A)")]
        NameDescending,

        [Description("Sort by Price (Low to High)")]
        PriceAscending,

        [Description("Sort by Price (High to Low)")]
        PriceDescending,

        [Description("Sort by Rating (Low to High)")]
        RatingAscending,

        [Description("Sort by Rating (High to Low)")]
        RatingDescending
    }
}
