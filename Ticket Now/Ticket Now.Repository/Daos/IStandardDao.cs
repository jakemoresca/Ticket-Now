using System;
using System.Collections.Generic;

namespace Ticket_Now.Repository.Daos
{
    public interface IStandardDao<TEntity>
    {
        TEntity Update(TEntity entity);
        int Delete(Guid id);
        TEntity Save(TEntity entity);
        IList<TEntity> LoadAll();
    }
}
