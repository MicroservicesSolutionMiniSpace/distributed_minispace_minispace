﻿using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using MiniSpace.Services.Friends.Application.Dto;
using MiniSpace.Services.Friends.Application.Exceptions;
using MiniSpace.Services.Friends.Application.Queries;
using MiniSpace.Services.Friends.Core.Entities;
using MiniSpace.Services.Friends.Infrastructure.Mongo.Documents;

namespace MiniSpace.Services.Friends.Infrastructure.Mongo.Queries.Handlers
{
    public class GetStudentEventsHandler : IQueryHandler<GetStudentEvents, StudentEventsDto>
    {
        private readonly IMongoRepository<StudentDocument, Guid> _studentRepository;

        public GetStudentEventsHandler(IMongoRepository<StudentDocument, Guid> repository)
            => _studentRepository = repository;

        public async Task<StudentEventsDto> HandleAsync(GetStudentEvents query, CancellationToken cancellationToken)
        {
            var document = await _studentRepository.GetAsync(p => p.Id == query.StudentId);
            if(document is null)
            {
                throw new StudentNotFoundException(query.StudentId);
            }
            
            var studentEvents = new StudentEventsDto()
            {
                StudentId = document.Id,
                InterestedInEvents = document.InterestedInEvents,
                SignedUpEvents = document.SignedUpEvents
            };

            return studentEvents;
        }
    }
}