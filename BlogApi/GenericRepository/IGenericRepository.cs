using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetWithBlogsIdAsync(int id);
        Task<bool> Delete(int id);
        //T GetById(object id);
        //void Insert(T obj);
        //void Update(T obj);
        //void Delete(object id);
        //void Save();
    }
}
