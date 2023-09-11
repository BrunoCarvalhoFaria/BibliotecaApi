using Drogaria.Domain.Core.Models;
using Drogaria.Domain.DTO;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using Drogaria.Infra.Data;
using Drogaria.Domain.Interfaces;
using System;

namespace DrPay.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        protected readonly DbContextOptions<DrogariaDbContext> _optionsBuilder;
        protected readonly string stringConnection;
        private bool disposedValue;


        protected Repository(DrogariaDbContext context)
        {
            _optionsBuilder = new DbContextOptions<DrogariaDbContext>();
        }

        public long Id { get; protected set; }
        public virtual bool Excluido { get; set; }

        public void Excluir()
        {
            Excluido = true;
        }

        public async Task Add(TEntity Objeto)
        {
            using (var data = new DrogariaDbContext(_optionsBuilder))
            {
                await data.Set<TEntity>().AddAsync(Objeto);
                await data.SaveChangesAsync();

            }
        }

        public async Task Delete(TEntity Objeto)
        {
            using (var data = new DrogariaDbContext(_optionsBuilder))
            {
                 data.Set<TEntity>().Remove(Objeto);
                await data.SaveChangesAsync();

            }
        }
    

        public async Task<List<TEntity>> GetAll()
        {
            using (var data = new DrogariaDbContext(_optionsBuilder))
            {
                return await data.Set<TEntity>().ToListAsync();

            }
        }

        public async Task<TEntity> GetById(long Id)
        {
            using (var data = new DrogariaDbContext(_optionsBuilder))
            {
                return await data.Set<TEntity>().FindAsync(Id);

            }

        }

        public async Task Update(TEntity Objeto)
        {
            using (var data = new DrogariaDbContext(_optionsBuilder))
            {
                data.Set<TEntity>().Update(Objeto);
                await data.SaveChangesAsync();

            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }
             
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }


};