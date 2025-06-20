﻿using Catering.Application.OrdenesTrabajo.GetOrdenesTrabajo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.OrdenesTrabajo.GetOrdenTrabajoById
{
    public record GetUsuariosQuery() : IRequest<List<GetUsuariosDto>?>;
}
