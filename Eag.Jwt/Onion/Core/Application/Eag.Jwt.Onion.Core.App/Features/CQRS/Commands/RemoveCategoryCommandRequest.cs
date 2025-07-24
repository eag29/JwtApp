using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eag.Jwt.Onion.Core.App.Features.CQRS.Commands
{
    public class RemoveCategoryCommandRequest: IRequest
    {
        public int Id { get; set; }

        public RemoveCategoryCommandRequest(int ıd)
        {
            Id = ıd;
        }
    }
}
