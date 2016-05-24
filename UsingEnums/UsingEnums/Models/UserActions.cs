using System.ComponentModel;

namespace UsingEnums.Models
{
    public enum UserActions
    {
        [Description("Product Registration Started")]
        ProductRegistrationStarted = 1,
        [Description("Saving Product")]
        SavingProduct = 2,
        [Description("Viewing Product")]
        ViewingProduct = 3,
        [Description("Order Creation Started")]
        OrderCreationStarted = 4,
        [Description("Viewing Order")]
        ViewingOrder = 5,
        [Description("Saving Order")]
        SavingOrder = 6
    }
}