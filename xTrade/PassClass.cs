using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace xTrade
{
    class PassClass : SQLConnClass
    {
        public struct UssStr
        {
            public string UssName;
            public string UssPHash;
            public int UssID;
            public bool AllowLogin;
        }

        internal class NameObjectMapSPass
        {
            public object Xobject;
            public string Xname;

            public NameObjectMapSPass(string name, object obj)
            {
                Xobject = obj;
                Xname = name;
            }

            public override string ToString()
            {
                return Xname;
            }
        }

        //private static SqlConnection myConnection;

        //static private string GetConnectionString()
        //{
        //    return Properties.Settings.Default.xTradeConnectionString;
        //}

        //static PassClass()
        //{
        //    myConnection = new SqlConnection(GetConnectionString());
        //}

        public static IEnumerable<UssStr> GetUserList()
        {
            #region SLQ Init

                SqlDataReader drd = null;
                SqlCommand getUsers = MyConnection.CreateCommand();
                getUsers.CommandText = "GetUssPass";
                getUsers.CommandType = CommandType.StoredProcedure;

            #endregion

            #region GetUserList Dr

                try
                {
                    MyConnection.Open();
                    drd = getUsers.ExecuteReader();

                    if (drd.HasRows)
                    {
                        while (drd.Read())
                        {
                            string xUssName = drd.GetString(0);
                            string xUsspHash = drd.GetString(1);
                            int xUsspID = drd.GetInt32(2);
                            bool xAllowLogin = drd.GetBoolean(3);

                            var mc = new UssStr
                                            {
                                                UssName = xUssName,
                                                UssPHash = xUsspHash,
                                                UssID = xUsspID,
                                                AllowLogin = xAllowLogin
                                            };

                            yield return mc;
                        }

                    }
                }
                finally
                {
                    if (drd != null)
                        drd.Close();
                    MyConnection.Close();
                }

            #endregion 
        }
    }
}
