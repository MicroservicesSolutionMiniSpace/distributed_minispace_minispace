﻿using System;
using Convey.CQRS.Events;

namespace MiniSpace.Services.Events.Application.Events
{
    public class StudentSignedUpToEvent: IEvent
    {
        public Guid EventId { get; }
        public Guid StudentId { get; }
        
        public StudentSignedUpToEvent(Guid eventId, Guid studentId)
        {
            EventId = eventId;
            StudentId = studentId;
        }
    }
}