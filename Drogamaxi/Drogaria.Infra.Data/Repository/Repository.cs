using Drogaria.Domain.Core.Models;
using Drogaria.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Drogaria.Infra.Data.Repository
{
    public abstract class Repository<TEntity>: IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected readonly DrogariaDbContext Db;
        protected readonly string stringConnection;
        protected Repository(DrogariaDbContext context) {
            this.Db = context;
            this.stringConnection = Configuracoes.Configuration.GetConnectionString("DefaultConnection");
        }

        public virtual void Adicionar(TEntity Objeto)
        {
            Db.Set<TEntity>().Add(Objeto);
            Db.Entry(Objeto).State = EntityState.Added;
            Save();
        }

        public virtual void Atualizar(TEntity Objeto)
        {
            try
            {
                this.DetachEntity(Objeto, Objeto.Id);
                Save();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public virtual void Remover(long id)
        {
            var obj = Db.Set<TEntity>().Find(id);
            Db.Entry(obj).State = EntityState.Deleted;
            Save();
        }

        public virtual TEntity ObterPorId(long id)
        {
            try
            {
                return Db.Set<TEntity>().AsNoTracking().FirstOrDefault(t => t.Excluido == false && t.Id == id);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return Db.Set<TEntity>().AsQueryable();
        }
       
        private void Save()
        {
            try
            {
                Db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Erro> detalhe:{e?.InnerException?.InnerException?.Message}");

                foreach (var eve in e.Entries)
                {
                    sb.AppendLine($"Objeto [{eve.Entity.GetType().Name}] no estado [{eve.State}] não pode ser atualizado");
                }
                throw;
            }
        }

        public void DetachEntity(TEntity t, long entryId)
        {
            var attachedEntity = Db.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(entryId));
            if(attachedEntity != null)
                Db.Entry(attachedEntity).State = EntityState.Detached;
            Db.Entry(t).State = EntityState.Modified;
        }


        bool disposed = false;

        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

       
    }
}
