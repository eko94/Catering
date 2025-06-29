using Catering.Domain.Abstractions;
using Catering.Domain.OrdenesTrabajo;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catering.Tests.Contracts.Provider.Repositories
{
    public class OrdenTrabajoTestRepository : IOrdenTrabajoRepository
    {

        private readonly ConcurrentDictionary<Guid, OrdenTrabajo> _ordenes = new();

        public Task AddAsync(OrdenTrabajo entity)
        {
            this._ordenes[entity.Id] = entity;
            return Task.CompletedTask;
        }

        public Task AddRangeAsync(List<OrdenTrabajo> ordenes)
        {
            foreach(var orden in ordenes)
            {
                this._ordenes[orden.Id] = orden;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            this._ordenes.Remove(id, out _);
            return Task.CompletedTask;
        }

        public Task<OrdenTrabajo?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            //OrdenTrabajo? ordenTrabajo = this._ordenes[id];
            OrdenTrabajo ordenTrabajo = new OrdenTrabajo(
                Guid.Parse("5E7D8A8F-807B-42F9-BB46-5617D835B881"),
                Guid.Parse("d19a0e52-cf2a-45cb-a99f-7343afb296b4"), 
                Guid.Parse("f57a6be5-585b-4b28-88df-6ed1cd2b6ef0"), 
                1, 
                OrdenTrabajoType.Comida,
                new List<OrdenTrabajoCliente> { new OrdenTrabajoCliente(
                    Guid.Parse("5E7D8A8F-807B-42F9-BB46-5617D835B881"),
                    Guid.Parse("9b971b55-e539-4939-9240-825a48402329"),
                    Guid.Parse("5faf7842-e7b5-4a3f-96c8-7719d01748b9"))
                });
            return Task.FromResult<OrdenTrabajo?>(ordenTrabajo);
        }

        public Task UpdateAsync(OrdenTrabajo ordenTrabajo)
        {
            this._ordenes[ordenTrabajo.Id] = ordenTrabajo;
            return Task.CompletedTask;
        }
    }
}
