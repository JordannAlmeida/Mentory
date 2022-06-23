class CardGood implements TypePaymentGood {
    numberCard: string
    nameOwner: string
    validity: Date
    cv: string

    validate(): void {
        //Do something
    }
    actionPrePayment(): void {
        //Do something
    }
    payment(): void{
        //Do something
    }
    actionPosPayment(): void{
        //Do something
    }
}