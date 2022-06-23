class RegistrationGood {

    _notification: INotificationHelper

    constructor(notification: INotificationHelper) {
        this._notification = notification;
    }

    makeRegistration(nameClient: string, ageClient: number, emailClient: string) {
        //Do somethings...
        const clientId = 0; //Imagine that we call a function that return a clientId created
        this._notification.sendNotification(clientId); //in constructor I received a NotificationEmail
    }
}