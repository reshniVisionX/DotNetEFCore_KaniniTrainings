using PatentWebApiProject.Models;

namespace PatentWebApiProject.Interface
{
        public interface ICrud<T> where T : class
        {
            Task<T> CreateAsync(T entity);
            Task<T?> GetByIdAsync(int id);
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> UpdateAsync(T entity,int id);
            Task<bool> DeleteAsync(int id);
    }
    

}
