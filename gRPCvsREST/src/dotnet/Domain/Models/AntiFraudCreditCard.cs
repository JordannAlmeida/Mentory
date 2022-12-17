namespace Domain.Models
{
    public class AntiFraudCreditCard
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
