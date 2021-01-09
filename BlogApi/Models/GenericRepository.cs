using BlogApi.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private BlogApiContext context;
        private DbSet<T> dbSet;

        public GenericRepository(BlogApiContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await context.Database.
               ExecuteSqlInterpolatedAsync($"DeleteBlogById {id}");
                return true;
            }
            catch
            {
                return false;
            } 
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().
                FromSqlRaw("EXECUTE dbo.GetBlogs").ToListAsync();
        }

        public async Task<List<T>> GetWithBlogsIdAsync(int id)
        {
            return await context.Set<T>().
                FromSqlRaw("EXECUTE dbo.GetBlogsById @Id = {0}", id)
                .ToListAsync(); 
        }
         
    }
}
