class Purchase {

    _notification: NotificationHelper

    makePurchase(clientid: number) {
        //Do somethings...
        this._notification.sendNotification(clientid); //But in future I wold like to send a sms
    }
}