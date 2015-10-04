using System.Collections.Generic;

namespace Ticket_Now.Repository.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        bool Delete(string id);
        T FindById(string id);
        T FindByName(string name);
        List<T> GetAll();
        T Update(T updatedEntity);
    }
}