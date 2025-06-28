using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Usuarios.GetUsuarios
{
    public record GetUsuariosQuery() : IRequest<List<GetUsuariosDto>?>;
}
