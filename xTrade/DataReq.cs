using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace xTrade
{
    struct DateReqByRecTvID
    {
        public int TvID;
        public int CodeTv;
        public string Name;
        public int Count;
        public double CostTv;
    }

    class DataReq : SQLConnClass
    {
        //private static SqlConnection myConnection;

        public int      ID              { get; set; }
        public int      RecTvID         { get; set; }
        public int      TvID            { get; set; }
        public int      Count           { get; set; }
        public int      CurrencyID      { get; set; }

        //static private string GetConnectionString()
        //{
        //    return Properties.Settings.Default.xTradeConnectionString;
        //}

        //public DataReq()
        //{
        //    myConnection = new SqlConnection(GetConnectionString());   
        //}

        //static DataReq()
        //{
        //    myConnection = new SqlConnection(GetConnectionString());
        //}

        public static int GetLastItem()
        {
            var selectCommand = new SqlCommand("SELECT DISTINCT TOP 1 RecTvID FROM dbo.DataReq ORDER BY ID DESC", MyConnection);

            MyConnection.Open();

            SqlDataReader myReader = selectCommand.ExecuteReader();

            int xTypeID = 0;

            while (myReader.Read())
            {
                xTypeID = myReader.GetInt32(0);
            }

            myReader.Close();
            MyConnection.Close();
            return xTypeID;
        }

        public static IEnumerable<DateReqByRecTvID> GetDateReqByRecTvID(int recTvID)
        {
            #region SLQ Init

                SqlDataReader drd = null;
                SqlCommand sqlCmdGetDateReqByRecTvID = MyConnection.CreateCommand();
                sqlCmdGetDateReqByRecTvID.CommandText = "GetDateReqByRecTvID";
                sqlCmdGetDateReqByRecTvID.CommandType = CommandType.StoredProcedure;

                sqlCmdGetDateReqByRecTvID.Parameters.Add("@xRecTvID", SqlDbType.Int, 4);
                sqlCmdGetDateReqByRecTvID.Parameters["@xRecTvID"].Value = recTvID;

            #endregion

            #region

                try
                {
                    MyConnection.Open();
                    drd = sqlCmdGetDateReqByRecTvID.ExecuteReader();

                    if (drd.HasRows)
                    {
                        while (drd.Read())
                        {

                            var rb = new DateReqByRecTvID
                                         {
                                                         TvID = drd.GetInt32(0),
                                                         CodeTv = drd.GetInt32(1),
                                                         Name = drd.GetString(2),
                                                         Count = drd.GetInt32(3),
                                                         CostTv = drd.GetDouble(4)
                                                      };

                            yield return rb;
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

        public void Insert()
        {
            var insertCommand = new SqlCommand("INSERT INTO [dbo].[DataReq] (" +
                                                      "RecTvID, " +
                                                      "TvID, " +
                                                      "Count, " +
                                                      "CurrencyID) VALUES (" +
                                                      "@xRecTvID, " +
                                                      "@xTvID, " +
                                                      "@xCount, " +
                                                      "@xCurrencyID)", MyConnection);


            insertCommand.Parameters.Add(new SqlParameter("@xRecTvID", typeof(int)))        .Value = RecTvID;
            insertCommand.Parameters.Add(new SqlParameter("@xTvID", typeof(int)))            .Value = TvID;
            insertCommand.Parameters.Add(new SqlParameter("@xCount", typeof(float)))        .Value = Count;
            insertCommand.Parameters.Add(new SqlParameter("@xCurrencyID", typeof(float)))   .Value = CurrencyID;

            MyConnection.Open();
            insertCommand.ExecuteNonQuery();
            MyConnection.Close();
        }

        public static void Delete(int id)
        {
            var deleteCommand = new SqlCommand("DELETE FROM [dbo].[DataReq] WHERE ([dbo].[DataReq].[ID] = @id)", MyConnection);
            deleteCommand.Parameters.Add(new SqlParameter("@id", typeof(int))).Value = id;

            MyConnection.Open();
            deleteCommand.ExecuteNonQuery();
            MyConnection.Close();
        }

        public static void ClearTable()
        {
            var clearCommand = new SqlCommand("DELETE FROM [dbo].[DataReq]", MyConnection);

            MyConnection.Open();
            clearCommand.ExecuteNonQuery();
            MyConnection.Close();
        }
    }
}
