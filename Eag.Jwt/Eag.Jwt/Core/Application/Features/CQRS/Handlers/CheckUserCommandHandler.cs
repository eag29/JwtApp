using Eag.Jwt.Core.Application.Dto;
using Eag.Jwt.Core.Application.Enums;
using Eag.Jwt.Core.Application.Features.CQRS.Commands;
using Eag.Jwt.Core.Application.Features.CQRS.Queries;
using Eag.Jwt.Core.Application.Interfaces;
using Eag.Jwt.Core.Domain;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserCommandHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;

        public CheckUserCommandHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();

            var user = await _appUserRepository.GetByFilterAsync(x => x.Username == request.Username & x.Password == request.Password);

            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.Id = user.Id;
                dto.Username = user.Username;
                dto.IsExist = true;
                var role = await _appRoleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role?.Definition;
            }
            return dto;
        }
    }
}
