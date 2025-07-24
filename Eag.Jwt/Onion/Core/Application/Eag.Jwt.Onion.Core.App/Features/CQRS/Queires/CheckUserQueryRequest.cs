using Eag.Jwt.Onion.Core.App.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eag.Jwt.Onion.Core.App.Features.CQRS.Queires
{
    public class CheckUserQueryRequest: IRequest<CheckUserResponseDto>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
