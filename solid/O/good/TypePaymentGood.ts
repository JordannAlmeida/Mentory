interface TypePaymentGood {
    validate(): void
    actionPrePayment(): void
    payment(): void
    actionPosPayment(): void
}