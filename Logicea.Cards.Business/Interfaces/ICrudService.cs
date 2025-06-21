namespace Logicea.Cards.Business.Interfaces;

public interface ICrudService<T>
{
    Task<bool> AddAsync(T item);
    Task<bool> AddRangeAsync(IEnumerable<T> items);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(T item);
}
