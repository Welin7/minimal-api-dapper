using Dapper;
using MinimalApiDapper.Factory;
using MinimalApiDapper.Interfaces;
using MinimalApiDapper.Models;
using System.Data;

namespace MinimalApiDapper.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository()
        {
            _dbConnection = new SqlFactory().GetSqlConnection();
        }

        public bool Add(Product product)
        {
            var query = "INSERT INTO [DbProduct].[dbo].[Product] VALUES(@Name,@Quantity,@Price)";
            var parametres = new {Name = product.Name, Quantity = product.Quantity, Price = product.Price};

            int result = 0;
            using(_dbConnection)
            {
                result = _dbConnection.Execute(query, parametres);
            }

            return (result != 0 ? true : false);
        }

        public bool Delete(int id)
        {
            var query = "DELETE [DbProduct].[dbo].[Product] WHERE [Id] = @productid";
            var parameters = new { productid = id };

            int result = 0;
            using(_dbConnection)
            {
                result = _dbConnection.Execute(query, parameters);
            }

            return (result != 0 ? true:false);
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>();
            var query = "SELECT * FROM [DbProduct].[dbo].[Product]";

            using (_dbConnection)
            {
                products = _dbConnection.Query<Product>(query).ToList();
            }

            return products;
        }

        public Product GetById(int id)
        {
            var parameters = new { productid = id };

            using (_dbConnection)
            {
                var result = _dbConnection.QueryFirstOrDefault<Product>("SELECT * FROM [DbProduct].[dbo].[Product] WHERE [Id] = @productid", parameters);
                return result;
            }
        }

        public bool Update(string name, int id)
        {
            var query = "UPDATE [DbProduct].[dbo].[Product] SET [Name] = @productName WHERE [Id] = @productid";
            var parameters = new { productName = name, productid = id };

            int result = 0;
            using (_dbConnection)
            {
                result = _dbConnection.Execute(query, parameters);
            }

            return (result != 0 ? true : false);
        }
    }
}
