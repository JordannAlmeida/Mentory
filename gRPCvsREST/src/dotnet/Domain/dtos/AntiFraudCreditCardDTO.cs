namespace Domain.dtos
{
    public class AntiFraudCreditCardDTO
    {
        public string? Message { get; set; }
        public bool Aproved { get; set; }
        public float PercentageOfRiskGatewayA { get; set; }
        public float PercentageOfRiskGatewayB { get; set; }
        public float PercentageOfRiskGatewayC { get; set; }
        public float PercentageOfRiskGatewayD { get; set; }
        public float PercentageOfRiskGatewayE { get; set; }
    }
}
