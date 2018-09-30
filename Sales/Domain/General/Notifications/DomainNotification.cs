using Domain.General.Events;
using System;

namespace Domain.General.Notifications
{
    public class DomainNotification : Event
    {
        public DomainNotification(string key, string value, int version = 1)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = version;
            Key = key;
            Value = value;
        }

        public Guid DomainNotificationId { get; }
        public string Key { get; }
        public string Value { get; }
        public int Version { get; }
    }
}
