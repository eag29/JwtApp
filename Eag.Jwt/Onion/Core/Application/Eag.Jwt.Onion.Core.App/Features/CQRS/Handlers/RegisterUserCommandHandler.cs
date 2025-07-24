using AutoMapper;
using Eag.Jwt.Onion.Core.App.Dto;
using Eag.Jwt.Onion.Core.App.Enums;
using Eag.Jwt.Onion.Core.App.Features.CQRS.Commands;
using Eag.Jwt.Onion.Core.App.Interfaces;
using Eag.Jwt.Onion.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eag.Jwt.Onion.Core.App.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, CreatedUserDto?>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatedUserDto?> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.CreateAsync(new AppUser
            {
                Username = request.Username,
                Password = request.Password,
                AppRoleId = (int)RoleByType.Member,
            });

            return _mapper.Map<CreatedUserDto?>(data);
        }
    }
}
