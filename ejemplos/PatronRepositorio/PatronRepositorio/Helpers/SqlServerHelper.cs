using System.Data.SqlClient;

namespace PatronRepositorio.Helpers
{
    class SqlServerHelper
    {

        public static SqlConnection Connection()
        {
            SqlConnection sqlCnn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MiBaseDeDatos; Integrated Security=true;");
            return sqlCnn;
        }

    }
}
