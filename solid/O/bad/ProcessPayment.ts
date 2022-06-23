class ProcessPaymentsOld {

    process(card: Card): void {
        //... check properties card (numberCard, nameOwner, validity, cv)
        //... call anti fraud
        //... cash in
    }
}

class ProcessPaymentsNow {

    process(typePayment: TypePayment): void {
        if(typePayment instanceof Card) {
            //... check properties card (numberCard, nameOwner, validity, cv)
            //... call anti fraud
            //... cash in
        }
        else if(typePayment instanceof BankSlip) {
            //... check properties bankslip (codeBar, dueDate)
            //... cash in
        }
    }
}