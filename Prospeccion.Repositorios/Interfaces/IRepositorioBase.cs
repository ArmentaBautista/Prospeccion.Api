using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prospeccion.Entidades.Negocio;
using System.Linq.Expressions;

namespace Prospeccion.Repositorios.Interfaces
{
    public interface IRepositorioBase<TEntity> where TEntity : EntBase
    {
        /// <summary>
        /// Listado completo
        /// </summary>
        /// <returns></returns>
        Task<ICollection<TEntity>> ListAsync();
        
        /// <summary>
        /// Listado filtrado
        /// </summary>
        /// <param name="predicado"></param>
        /// <returns></returns>
        Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicado);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInfo"></typeparam>
        /// <param name="predicado"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        Task<ICollection<TInfo>> ListAsync<TInfo>(
            Expression<Func<TEntity, bool>> predicado,
            Expression<Func<TEntity, TInfo>> selector);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInfo"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicado"></param>
        /// <param name="selector"></param>
        /// <param name="orderBy"></param>
        /// <param name="pagina"></param>
        /// <param name="filas"></param>
        /// <returns></returns>
        Task<(ICollection<TInfo> Collection, int TotalRegistros)> ListAsync<TInfo, TKey>(
            Expression<Func<TEntity, bool>> predicado,
            Expression<Func<TEntity, TInfo>> selector,
            Expression<Func<TEntity, TKey>> orderBy,
            int pagina = 1, int filas = 5);

        /// <summary>
        /// Buscar por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity?> FindByIdAsync(int id);

        /// <summary>
        /// Agregar Entidad a la BD
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity);

    }
}
