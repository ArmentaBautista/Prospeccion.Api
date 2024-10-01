using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prospeccion.Entidades.Negocio;
using Prospeccion.Repositorios.Interfaces;

namespace Prospeccion.Repositorios.Implementaciones
{
    public class RepositorioBase<TEntidad>:IRepositorioBase<TEntidad> 
        where TEntidad:EntBase
    {
        protected readonly DbContext DbContext;

        public RepositorioBase(DbContext context)
        {
            DbContext = context;
        }

        public async Task<ICollection<TEntidad>> ListAsync()
        {
            return await DbContext.Set<TEntidad>()
                .Where(p=>p.Estatus==1)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<TEntidad>> ListAsync(Expression<Func<TEntidad, bool>> predicado)
        {
            return await DbContext.Set<TEntidad>()
                .Where(predicado)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<TInfo>> ListAsync<TInfo>(Expression<Func<TEntidad, bool>> predicado, Expression<Func<TEntidad, TInfo>> selector)
        {
            var resultado = await DbContext.Set<TEntidad>()
                .Where(predicado)
                .AsNoTracking()
                .Select(selector)
                .ToListAsync();

            return resultado;
        }

        public async Task<(ICollection<TInfo> Collection, int TotalRegistros)> ListAsync<TInfo, TKey>(Expression<Func<TEntidad, bool>> predicado, Expression<Func<TEntidad, TInfo>> selector, Expression<Func<TEntidad, TKey>> orderBy, int pagina = 1,
            int filas = 5)
        {
            var resultado = await DbContext.Set<TEntidad>()
                .Where(predicado)
                .AsNoTracking()
                .OrderBy(orderBy)
                .Skip((pagina - 1) * filas)
                .Take(filas)
                .Select(selector)
                .ToListAsync();

            var total = await DbContext.Set<TEntidad>()
                .Where(predicado)
                .CountAsync();
            return (resultado, total);
        }

        public async Task<TEntidad?> FindByIdAsync(int id)
        {
            return await DbContext.Set<TEntidad>().FindAsync(id);
        }

        public async Task<TEntidad> AddAsync(TEntidad entity)
        {
            var resultado = await DbContext.Set<TEntidad>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return resultado.Entity;
        }

    }
}
