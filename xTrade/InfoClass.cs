using System.Collections.Generic;
using System.Data.SqlClient;

namespace xTrade
{
    public struct IntStr
    {
        public int ID;
        public string ItemContent;
    }

    internal class NameObjectMap
    {
        public object Xobject;
        public string Xname;

        public NameObjectMap(string name, object obj)
        {
            Xobject = obj;
            Xname = name;
        }

        public override string ToString()
        {
            return Xname;
        }
    }

    class InfoClass : SQLConnClass
    {
        //private static SqlConnection myConnection;

        //static private string GetConnectionString()
        //{
        //    return Properties.Settings.Default.xTradeConnectionString;
        //}

        //static InfoClass()
        //{
        //    myConnection = new SqlConnection(GetConnectionString());
        //}

        private static IEnumerable<IntStr> ExecQuery(string queryString)
        {
            var command = new SqlCommand(queryString, MyConnection);

            MyConnection.Open();

            SqlDataReader myReader = command.ExecuteReader();

            while (myReader.Read())
            {
                int xID = myReader.GetInt32(0);
                string xName = myReader.GetString(1);


                var mc = new IntStr
                {
                    ID = xID,
                    ItemContent = xName,
                };

                yield return mc;
            }

            myReader.Close();
            MyConnection.Close();    
        }

        public static IEnumerable<IntStr> GetReqVarPaymentList()
        {
            const string queryString = "SELECT * FROM [dbo].[VariantsPayment];";

            return ExecQuery(queryString);
        }

        public static IEnumerable<IntStr> GetReqStatusList()
        {
            const string queryString = "SELECT * FROM [dbo].[ReqStatus];";

            return ExecQuery(queryString);
        }

        public static IEnumerable<IntStr> GetReqStatusNewList()
        {
            const string queryString = "SELECT * FROM [dbo].[ReqStatus] WHERE [dbo].[ReqStatus].[ShCr] = 1;";

            return ExecQuery(queryString);
        }

        public static IEnumerable<IntStr> GetReqPriorityList()
        {
            const string queryString = "SELECT * FROM [dbo].[ReqPriority];";

            return ExecQuery(queryString);
        }

        public static IEnumerable<IntStr> GetCurrencyList()
        {
            const string queryString = "SELECT * FROM [dbo].[Currency];";

            return ExecQuery(queryString);
        }

        public static IEnumerable<IntStr> GetWarehouseList()
        {
            const string queryString = "SELECT [WarehouseID], [Name] FROM [dbo].[Warehouse];";

            return ExecQuery(queryString);
        }

        public static IEnumerable<IntStr> GetTypePaymentList()
        {
            const string queryString = "SELECT [TPaymentID], [Type] FROM [dbo].[TypePayment];";

            return ExecQuery(queryString);
        }

        public static IEnumerable<IntStr> GetClientsList()
        {
            const string queryString = "SELECT [IDClient], [ClientName] FROM [dbo].[Clients];";

            return ExecQuery(queryString);
        }

        public static IEnumerable<IntStr> GetClientsPointsList(int xIDClient)
        {
            const string queryString = "SELECT [IDClientPoint], [Name] FROM [dbo].[ClientsPoint] WHERE IDClient = @xIDClient;";

            var command = new SqlCommand(queryString, MyConnection);

            command.Parameters.Add(new SqlParameter("@xIDClient", sizeof (int))).Value = xIDClient;

            MyConnection.Open();

            SqlDataReader myReader = command.ExecuteReader();

            while (myReader.Read())
            {
                int xID = myReader.GetInt32(0);
                string xName = myReader.GetString(1);


                var mc = new IntStr
                {
                    ID = xID,
                    ItemContent = xName,
                };

                yield return mc;
            }

            myReader.Close();
            MyConnection.Close();  
        }
    }
}