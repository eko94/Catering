using Catering.Application.OrdenesTrabajo.EmpaquetarComidas;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Contratos;
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
        private readonly IContratoRepository _contratoRepository;
        private readonly IRecetaRepository _recetaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearOrdenHandler(IOrdenTrabajoRepository ordenTrabajoRepository,
            IOrdenTrabajoFactory ordenTrabajoFactory,
            IUsuarioRepository usuarioRepository,
            IClienteRepository clienteRepository,
            IContratoRepository contratoRepository,
            IRecetaRepository recetaRepository,
            IUnitOfWork unitOfWork)
        {
            _ordenTrabajoRepository = ordenTrabajoRepository;
            _ordenTrabajoFactory = ordenTrabajoFactory;
            _usuarioRepository = usuarioRepository;
            _clienteRepository = clienteRepository;
            _contratoRepository = contratoRepository;
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

            List<OrdenTrabajoCliente> ordenClientes = new List<OrdenTrabajoCliente>();
            foreach(var ordenCliente in request.ordenClientes)
            {
                var cliente = await _clienteRepository.GetByIdAsync(ordenCliente.idCliente);
                if(cliente == null)
                {
                    throw new ArgumentException("Cliente no es válido");
                }

                var contrato = await _contratoRepository.GetByIdAsync(ordenCliente.idContrato);
                if(contrato == null)
                {
                    throw new ArgumentException("Contrato no es válido");
                }
                if(contrato.IdCliente != cliente.Id)
                {
                    throw new ArgumentException($"El contrato {contrato.Id} no pertenece al cliente {cliente.Id}");
                }

                var ordenClienteCreated = _ordenTrabajoFactory.CreateOrdenTrabajoCliente(ordenCliente.idCliente, ordenCliente.idContrato);
                ordenClientes.Add(ordenClienteCreated);
            }

            var orden = _ordenTrabajoFactory.CreateOrdenTrabajo(request.idUsuarioCocinero, request.idReceta, request.cantidad, ordenClientes);

            await _ordenTrabajoRepository.AddAsync(orden);

            await _unitOfWork.CommitAsync(cancellationToken);

            return orden.Id;
        }
    }
}
