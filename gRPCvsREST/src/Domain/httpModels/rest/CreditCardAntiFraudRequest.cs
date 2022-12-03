namespace Domain.httpModels.rest
{
    public record CreditCardAntifraudRequest(
        string CreditCardNumber,
        double CreditCardAmoun,
        DateTime Validate,
        string Cvv,
        double Latitude,
        double Longitude,
        string NameOwner,
        string CodeBank,
        DateTime PaymentDate,
        double CreditCardLimit);
}
