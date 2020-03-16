using System;
using System.Linq;
using System.Linq.Expressions;
using VemDeZap.Domain.Entities.Base;

namespace VemDeZap.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntidade, TId>
        where TEntidade : EntityBase
        where TId : struct
    {
        IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, bool>>[] include);
        IQueryable<TEntidade>ListarEOrdernadosPor<TKey>(Expression<Func<TEntidade, bool>> where);
        TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, bool>>[] include);
        bool Existe(Func<TEntidade, bool> where);
        IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, bool>>[] includePropeties);
        IQueryable<TEntidade> ListarOrdenadosPor<Tkey>(Expression<Func<TEntidade, Tkey>> ordem, bool ascendent);
        TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, bool>>[] includePropeties);
        TEntidade Adicionar(TEntidade entidade);
        TEntidade Editar(TEntidade entidade);
        void Remover(TEntidade entidade);
        void Remover(IEquatable<TEntidade> entidades);
        void AdicionarLista(IEquatable<TEntidade> entidades);
    }
}
