using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
