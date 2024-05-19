﻿using Convey.CQRS.Queries;
using MiniSpace.Services.Organizations.Application.DTO;

namespace MiniSpace.Services.Organizations.Application.Queries
{
    public class GetChildrenOrganizations: IQuery<IEnumerable<OrganizationDto>>
    {
        public Guid OrganizationId { get; set; }
        public Guid RootId { get; set; }
    }
}