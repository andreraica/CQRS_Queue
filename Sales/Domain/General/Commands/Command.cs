using Domain.General.Events;
using FluentValidation.Results;
using System;

namespace Domain.General.Commands
{
    public abstract class Command : Message
    {
        public DateTime CreatedOn { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {

        }

        public abstract bool IsValid();

        internal void setCreatedOn(DateTime timeStamp)
        {
            CreatedOn = timeStamp;
        }
    }
}
