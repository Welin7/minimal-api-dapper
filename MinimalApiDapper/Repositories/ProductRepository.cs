using MinimalApiDapper.ComandQuery;
using MinimalApiDapper.Interfaces;
using MinimalApiDapper.Models;

namespace MinimalApiDapper.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {
        }

        public bool Add(Product product)
        {
            var dbConnect = new DapperDbConnection(); 
            bool result = dbConnect.ComandAdd(product);
            return result;
        }

        public bool Delete(int id)
        {
            var dbConnect = new DapperDbConnection();
            bool result = dbConnect.DeleteComand(id);
            return result;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>();
            var dbConnect = new DapperDbConnection();
            products = (List<Product>)dbConnect.ComandGetListProducts();
            return products;
        }

        public Product GetById(int id)
        {
            var dbConnect = new DapperDbConnection();
            var result = dbConnect.ComandGetById(id);  
            return (Product)result;
        }

        public bool Update(string name, int id)
        {
            var dbConnect = new DapperDbConnection();
            bool result = dbConnect.ComandUpdate(name, id); 
            return result;
        }
    }
}
