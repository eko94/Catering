using Catering.Application.Contratos.GetContratosRealizarDelDia;
using Catering.Domain.Contratos;
using Catering.Infrastructure.StoredModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Queries.Contrato
{
    public class GetContratosRealizarDelDiaQueryHandler : IRequestHandler<GetContratosRealizarDelDiaQuery, IEnumerable<GetContratosRealizarDelDiaDto>>
    {
        private readonly StoredDbContext _dbContext;

        public GetContratosRealizarDelDiaQueryHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GetContratosRealizarDelDiaDto>> Handle(GetContratosRealizarDelDiaQuery request, CancellationToken cancellationToken)
        {
            return await
                (from con in _dbContext.Contrato
                 join cli in _dbContext.Cliente on con.IdCliente equals cli.Id
                 join pla in _dbContext.PlanAlimentario on con.IdPlanAlimentario equals pla.Id
                 join par in _dbContext.PlanAlimentarioReceta on pla.Id equals par.IdPlanAlimentario
                 join rec in _dbContext.Receta on par.IdReceta equals rec.Id
                 where con.Estado != nameof(ContratoStatus.Finalizado) // Se filtra los contratos finalizados
                 && con.DiasRealizados < con.DiasContratados // Se filtra los contratos que se han realizado menos días de los contratados
                 && con.FechaInicio <= DateTime.Now // La fecha de inicio del contrato debe ser mayor al actual
                 && (!con.FechaUltimoRealizado.HasValue || con.FechaUltimoRealizado.Value.Date < DateTime.Today) // Se verifica que no se haya realizado en la fecha
                 && par.Dia == (con.DiasRealizados + 1) // Para preparar la receta del día
                 select new GetContratosRealizarDelDiaDto
                 {
                     IdContrato = con.Id,
                     IdCliente = cli.Id,
                     IdReceta = rec.Id
                 })
                 .ToListAsync(cancellationToken);

            //SELECT
            //  CON.IdContrato
            // ,CLI.Nombre
            // ,REC.Nombre
            //FROM
            //  Contrato CON
            //  INNER JOIN Cliente CLI ON CON.IdCliente = CLI.IdCliente
            //  INNER JOIN PlanAlimentario PLA ON CON.IdPlanAlimentario = PLA.IdPlanAlimentario
            //  INNER JOIN PlanAlimentarioReceta PAR ON PLA.IdPlanAlimentario = PAR.IdPlanAlimentario
            //  INNER JOIN Receta REC ON PAR.IdReceta = REC.IdReceta
            //WHERE
            //  CON.Estado != 'Finalizado'
            //  AND CON.DiasRealizados < CON.DiasContratados--Se filtra los contratos finalizados
            //  AND CON.FechaInicio <= GETDATE()--La fecha de inicio del contrato debe ser mayor al actual
            //  AND(CON.FechaUltimoRealizado IS NULL OR CON.FechaUltimoRealizado < GETDATE())--Se verifica que no se haya realizado en la fecha
            //  AND PAR.Dia = (CON.DiasRealizados + 1)--Para preparar la receta del día
        }
    }
}
