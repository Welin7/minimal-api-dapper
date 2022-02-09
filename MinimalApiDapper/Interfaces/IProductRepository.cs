using MinimalApiDapper.Models;

namespace MinimalApiDapper.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        bool Add(Product product);
        bool Update(string name, int id);
        bool Delete(int id);            
    }
}
