namespace Domain.dtos
{
    public class CreditCardDTO
    {
        public string CreditCardNumber { get; set;}
        public double CreditCardAmoun { get; set;}
        public DateTime Validate { get; set;}
        public string Cvv { get; set;}
        public double Latitude { get; set;}
        public double Longitude { get; set; }
        public string NameOwner { get; set;}
        public string CodeBank { get; set;}
        public DateTime PaymentDate { get; set;}
        public double CreditCardLimit { get; set;}
    }
}
