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
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : Entity<TEntity>
    {
        protected readonly DrogariaDbContext data;
        protected readonly string stringConnection;
        private bool disposedValue;


        protected Repository(DrogariaDbContext context)
        {
            data = context;
            stringConnection = Configuracoes.Configuration.GetConnectionString("ConnectionMysql")!;

        }

        public long Id { get; protected set; }
        public virtual bool Excluido { get; set; }

        public void Excluir()
        {
            Excluido = true;
        }

        public async Task Add(TEntity Objeto)
        {

            await data.Set<TEntity>().AddAsync(Objeto);
            await data.SaveChangesAsync();

        }

        public async Task Delete(TEntity Objeto)
        {
            data.Set<TEntity>().Remove(Objeto);
            await data.SaveChangesAsync();

        }


        public List<TEntity> GetAll()
        {
            return  data.Set<TEntity>().Where(t => t.Excluido == false).ToList();

        }

        public TEntity? GetById(long Id)
        {
            return data.Set<TEntity>().Where(t => t.Excluido == false && t.Id == Id).FirstOrDefault();


        }

        public async Task Update(TEntity Objeto)
        {
            data.Set<TEntity>().Update(Objeto);
            await data.SaveChangesAsync();

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