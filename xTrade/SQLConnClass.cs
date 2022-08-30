using System.Data.SqlClient;

namespace xTrade
{
    public class SQLConnClass
    {
        public static SqlConnection MyConnection;

        static private string GetConnectionString()
        {
            return Properties.Settings.Default.xTradeConnectionString;
        }

        public SQLConnClass()
        {
            MyConnection = new SqlConnection(GetConnectionString());   
        }

        static SQLConnClass()
        {
            MyConnection = new SqlConnection(GetConnectionString());
        }
    }
}
