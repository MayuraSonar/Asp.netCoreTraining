export interface IMessage
{
    id: number;
    senderId: number;
    senderPhotoUrl: string;
    recipientId: number;
    recipientPhotoUrl: string;
    content: string;
    dateRead?: Date;
    messageSent: Date;
}