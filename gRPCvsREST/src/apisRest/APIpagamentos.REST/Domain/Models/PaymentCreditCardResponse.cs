namespace Domain.Models
{
    public record struct PaymentCreditCardResponse
        (bool Aproved,
         string MessageNotification);
}
