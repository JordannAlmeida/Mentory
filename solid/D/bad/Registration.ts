class Registration {

    _notification: NotificationHelper

    makeRegistration(nameClient: string, ageClient: number, emailClient: string) {
        //Do somethings...
        const clientId = 0; //Imagine that we call a function that return a clientId created
        this._notification.sendNotification(clientId);
    }
}