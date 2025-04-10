// BaseRepository.cs

namespace RecipeNest.Repository;

public interface IBaseRepository<T>
{
    bool Save(T obj);

    bool Update(T obj);

    T GetById(int id);

    List<T> GetAll();

    bool DeleteById(int id);
}