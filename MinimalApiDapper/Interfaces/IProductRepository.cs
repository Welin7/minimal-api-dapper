using MinimalApiDapper.Models;

namespace MinimalApiDapper.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetById(int id);
        bool Add(Product product);
        bool Update(string name, int id);
        bool Delete(int id);            
    }
}
