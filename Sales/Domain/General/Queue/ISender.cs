namespace Domain.General.Queue
{
    public interface ISender
    {
        void Send(MessageQueue queueMessage);
    }
}
