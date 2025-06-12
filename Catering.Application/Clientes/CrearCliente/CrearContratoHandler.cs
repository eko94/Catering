using Catering.Application.Clientes.CrearCliente;
using Catering.Application.OrdenesTrabajo.CrearOrden;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Contratos;
using Catering.Domain.PlanAlimentario;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Contratos.CrearContrato
{
    public class CrearClienteHandler : IRequestHandler<CrearClienteCommand, Guid>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteFactory _clienteFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearClienteHandler(IClienteRepository clienteRepository,
            IClienteFactory clienteFactory,
            IUnitOfWork unitOfWork) {
            _clienteRepository = clienteRepository;
            _clienteFactory = clienteFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearClienteCommand request, CancellationToken cancellationToken) {
            var cliente = await _clienteRepository.GetByIdAsync(request.idCliente);
            if (cliente != null)
            {
                throw new ArgumentException("Cliente ya existe");
            }

            if (string.IsNullOrEmpty(request.nombre))
            {
                throw new ArgumentException("Nombre del cliente no puede ser nulo o vacío");
            }

            var clienteCreado = _clienteFactory.CreateCliente(request.idCliente, request.nombre);

            await _clienteRepository.AddAsync(clienteCreado);

            await _unitOfWork.CommitAsync(cancellationToken);

            return clienteCreado.Id;
        }
    }
}