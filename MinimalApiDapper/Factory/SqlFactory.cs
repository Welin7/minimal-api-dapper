using System.Data;
using System.Data.SqlClient;

namespace MinimalApiDapper.Factory
{
    public class SqlFactory
    {
        public IDbConnection GetSqlConnection()
        {
            return new SqlConnection("Server=WELIN\\SQL2019,1433;Database=DbProduct;User Id=sa;Password=medsys;");
        }
    }
}
