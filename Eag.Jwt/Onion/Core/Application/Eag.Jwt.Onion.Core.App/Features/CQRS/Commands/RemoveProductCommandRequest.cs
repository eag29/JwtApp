using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eag.Jwt.Onion.Core.App.Features.CQRS.Commands
{
    public class RemoveProductCommandRequest: IRequest
    {
        public int Id { get; set; }

        public RemoveProductCommandRequest(int ıd)
        {
            Id = ıd;
        }
    }
}
