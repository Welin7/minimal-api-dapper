using Dapper;
using MinimalApiDapper.Factory;
using MinimalApiDapper.Models;
using System.Data;

namespace MinimalApiDapper.ComandQuery
{
    public class DapperDbConnection
    {
        private readonly IDbConnection _dbConnection;
        private int result;
        private IEnumerable<Product> listProduct;

        public DapperDbConnection()
        {
            _dbConnection = new SqlFactory().GetSqlConnection();
            result = 0;
        }

        public bool ComandAdd(Product product)
        {
            var query = "INSERT INTO [DbProduct].[dbo].[Product] VALUES(@Name,@Quantity,@Price)";
            var parameters = new { Name = product.Name, Quantity = product.Quantity, Price = product.Price };

            using (_dbConnection)
            {
                result = _dbConnection.Execute(query, parameters);
            }

            return (result != 0 ? true : false);
        }

        public  bool DeleteComand(int id)
        {
            var query = "DELETE [DbProduct].[dbo].[Product] WHERE [Id] = @productid";
            var parameters = new { productid = id };

            using (_dbConnection)
            {
                result = _dbConnection.Execute(query, parameters);
            }

            return (result != 0 ? true : false);
        }

        public  IEnumerable<Product> ComandGetListProducts()
        {
            var query = "SELECT * FROM [DbProduct].[dbo].[Product]";

            using (_dbConnection)
            {
                listProduct = _dbConnection.Query<Product>(query).ToList();
            }

            return listProduct;
        }

        public  Product ComandGetById(int id)
        {
            var parameters = new { productid = id };

            using (_dbConnection)
            {
                var result = _dbConnection.QueryFirstOrDefault<Product>("SELECT * FROM [DbProduct].[dbo].[Product] WHERE [Id] = @productid", parameters);
                return result;
            }
        }

        public bool ComandUpdate(string name, int id)
        {
            var query = "UPDATE [DbProduct].[dbo].[Product] SET [Name] = @productName WHERE [Id] = @productid";
            var parameters = new { productName = name, productid = id };

            using (_dbConnection)
            {
                result = _dbConnection.Execute(query, parameters);
            }

            return (result != 0 ? true : false);
        }
    }
}
