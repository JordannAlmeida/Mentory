namespace Domain.httpModels.rest
{
    public record struct PaymentCreditCardResponse
        (bool Aproved,
         string MessageNotification);
}
