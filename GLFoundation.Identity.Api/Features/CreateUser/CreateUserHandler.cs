﻿using AutoMapper;
using GLFoundation.Identity.Api.Domain;
using MediatR;

namespace GLFoundation.Identity.Api.Features.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public CreateUserHandler(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<User>(request);
            entity = await userService.Create(entity, cancellationToken);
            return mapper.Map<CreateUserResponse>(entity);
        }
    }
}