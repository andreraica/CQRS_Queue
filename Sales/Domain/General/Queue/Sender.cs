using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.General.Queue
{
    public class Sender : ISender
    {
        public Sender()
        {

        }

        public void Send(MessageQueue queueMessage)
        {
            throw new NotImplementedException();
        }

        //private readonly IBus _bus;

        //public Sender(IBus bus)
        //{
        //    _bus = bus;
        //}

        //public void Send(MessageQueue queueMessage)
        //{
        //    _bus.DeclareQueueSend();

        //    var serializedData = JsonConvert.SerializeObject(queueMessage);
        //    var messageTransfer = new MessageTransfer(serializedData, queueMessage.SagaId, queueMessage.MessageType);

        //    _bus.SendMessage(messageTransfer);

        //    _bus.BindQueueSend();

        //}

    }
}
