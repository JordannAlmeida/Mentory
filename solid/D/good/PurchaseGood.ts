class PurchaseGood {
    _notification: INotificationHelper

    constructor(notification: INotificationHelper) {
        this._notification = notification;
    }

    makePurchase(clientid: number) {
        //Do somethings...
        this._notification.sendNotification(clientid); //in constructor I received a NotificationSms
    }
}