type SignalrConfig = {
    HubUrl: string;
    NotificationMethod : string;
}

export const signalrConfig : SignalrConfig = {
    HubUrl: 'https://localhost:7021/orderNotificationHub',
    NotificationMethod: 'ReceiveNotification',
};