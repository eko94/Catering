using Catering.Application.OrdenesTrabajo.EmpaquetarComidas;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.OrdenesTrabajo.CrearOrden
{
    public class CrearOrdenHandler : IRequestHandler<CrearOrdenCommand, Guid>
    {
        private readonly IOrdenTrabajoRepository _ordenTrabajoRepository;
        private readonly IOrdenTrabajoFactory _ordenTrabajoFactory;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IRecetaRepository _recetaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearOrdenHandler(IOrdenTrabajoRepository ordenTrabajoRepository,
            IOrdenTrabajoFactory ordenTrabajoFactory,
            IUsuarioRepository usuarioRepository,
            IClienteRepository clienteRepository,
            IRecetaRepository recetaRepository,
            IUnitOfWork unitOfWork)
        {
            _ordenTrabajoRepository = ordenTrabajoRepository;
            _ordenTrabajoFactory = ordenTrabajoFactory;
            _usuarioRepository = usuarioRepository;
            _clienteRepository = clienteRepository;
            _recetaRepository = recetaRepository;
            _unitOfWork = unitOfWork;            
        }

        public async Task<Guid> Handle(CrearOrdenCommand request, CancellationToken cancellationToken)
        {
            var usuarioCocinero = await _usuarioRepository.GetByIdAsync(request.idUsuarioCocinero);
            if(usuarioCocinero == null)
            {
                throw new ArgumentException("Usuario cocinero no es válido");
            }

            var receta = await _recetaRepository.GetByIdAsync(request.idReceta);
            if(receta == null)
            {
                throw new ArgumentException("Receta no es válida");
            }

            List<Guid> clientes = new List<Guid>();
            foreach(var idCliente in request.clientes)
            {
                var cliente = await _clienteRepository.GetByIdAsync(idCliente);
                if(cliente == null)
                {
                    throw new ArgumentException("Cliente no es válido");
                }
                clientes.Add(cliente.Id);
            }

            var orden = _ordenTrabajoFactory.CreateOrdenTrabajo(request.idUsuarioCocinero, request.idReceta, request.cantidad, clientes);

            await _ordenTrabajoRepository.AddAsync(orden);

            await _unitOfWork.CommitAsync(cancellationToken);

            return orden.Id;
        }
    }
}
