class ProcessPaymentGood {

    process(typePayment: TypePaymentGood): void {
        typePayment.validate();
        typePayment.actionPrePayment();
        typePayment.payment();
        typePayment.actionPosPayment();
    }
}