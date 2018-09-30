using System;

namespace Domain.General.Queue
{
    [Serializable]
    public class MessageQueue
    {
        public Guid? SagaId { get; set; }
        public string MessageType { get; set; }
    }
}
