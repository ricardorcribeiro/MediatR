using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using VemDeZap.Domain.Entities.Base;
using VemDeZap.Domain.Interfaces.Repositories.Base;

namespace VemDeZap.Infra.Repositories.Base
{
    public class RepositoryBase<TEntidade, TId> : IRepositoryBase<TEntidade, TId>
        where TEntidade : EntityBase
        where TId : struct
    {

        protected readonly VemDeZapContext _db;
        public RepositoryBase(VemDeZapContext context)
        {
            _db = context;
        }
        public TEntidade Adicionar(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public void AdicionarLista(IEquatable<TEntidade> entidades)
        {
            throw new NotImplementedException();
        }

        public TEntidade Editar(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Func<TEntidade, bool> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, bool>>[] includePropeties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntidade> ListarEOrdernadosPor<TKey>(Expression<Func<TEntidade, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntidade> ListarOrdenadosPor<Tkey>(Expression<Func<TEntidade, Tkey>> ordem, bool ascendent)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, bool>>[] include)
        {
            throw new NotImplementedException();
        }

        public TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, bool>>[] include)
        {
            throw new NotImplementedException();
        }

        public TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, bool>>[] includePropeties)
        {
            throw new NotImplementedException();
        }

        public void Remover(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(IEquatable<TEntidade> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
