using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace xTrade
{
    class PaymentClass : SQLConnClass
    {
        public int      ID              { get; set; }
        public int      IDClient        { get; set; }
        public DateTime DatePay         { get; set; }
        public double   Summ            { get; set; }
        public int      VarPayID        { get; set; }
        public int      ReqTvID         { get; set; }
        public string   Note            { get; set; }

        public string   Discr           { get; set; }
        public double   PayPercent      { get; set; }

        public static IEnumerable<PaymentClass> GetPaymentReqByRecTvID(int recTvID)
        {
            #region SLQ Init

            SqlDataReader drd = null;
            SqlCommand sqlCmdGetDateReqByRecTvID = MyConnection.CreateCommand();
            sqlCmdGetDateReqByRecTvID.CommandText = "GetPaymentReqByRecTvID";
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
                        int xID = drd.GetInt32(0);
                        int xIDClient = drd.GetInt32(1);
                        DateTime xDatePay = drd.GetDateTime(2);
                        double xSumm = drd.GetDouble(3);
                        int xVarPayID = drd.GetInt32(4);
                        int xReqTvID = drd.GetInt32(5);
                        string xNote = drd.GetString(6);
                        string xDiscr = drd.GetString(7);
                        double xPayPercent = drd.GetDouble(8);

                        var rb = new PaymentClass
                        {
                            ID = xID,
                            IDClient = xIDClient,
                            DatePay = xDatePay,
                            Summ = xSumm,
                            VarPayID = xVarPayID,
                            ReqTvID = xReqTvID,
                            Note = xNote,
                            Discr = xDiscr,
                            PayPercent = xPayPercent
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

        //public static int GetLastItem()
        //{
        //    var selectCommand = new SqlCommand("SELECT DISTINCT TOP 1 RecTvID FROM dbo.Requests ORDER BY RecTvID DESC", MyConnection);

        //    MyConnection.Open();

        //    SqlDataReader myReader = selectCommand.ExecuteReader();

        //    int xTypeID = 0;

        //    while (myReader.Read())
        //    {
        //        xTypeID = myReader.GetInt32(0);
        //    }

        //    myReader.Close();
        //    MyConnection.Close();
        //    return xTypeID;
        //}

        //public static IEnumerable<ReqClass> GetAllReq()
        //{
        //    #region SLQ Init
        //        SqlDataReader drd = null;
        //        SqlCommand getAllReq = MyConnection.CreateCommand();
        //        getAllReq.CommandText = "GetAllReq";
        //        getAllReq.CommandType = CommandType.StoredProcedure;
        //    #endregion
 
        //    #region
        //        try
        //        {
        //            MyConnection.Open();
        //            drd = getAllReq.ExecuteReader();

        //            if (drd.HasRows)
        //            {
        //                while (drd.Read())
        //                {
        //                    int xReqTvID            = drd.GetInt32(0);
        //                    int xIDClient           = drd.GetInt32(1);
        //                    DateTime xDateCreation  = drd.GetDateTime(2);
        //                    DateTime xDateDelivery  = drd.GetDateTime(3);
        //                    var xUserID             = drd.GetSqlInt32(4);
        //                    double xDiscount        = drd.GetDouble(5);
        //                    var xIDClientPoint      = drd.GetSqlInt32(6);
        //                    int xTPaymentID         = drd.GetInt32(7);
        //                    int xPriorityID         = drd.GetInt32(8);
        //                    int xReqStatusID        = drd.GetInt32(9);
        //                    string xNumber          = drd.GetString(10);
        //                    int xCurrencyID         = drd.GetInt32(11);
        //                    string xNote            = drd.GetString(12);
        //                    int xWarehouseID        = drd.GetInt32(13);
        //                    string xName            = drd.GetString(15);

        //                    var mc = new ReqClass
        //                                      {
        //                                          ReqTvID       = xReqTvID,
        //                                          IDClient      = xIDClient,
        //                                          DateCreation  = xDateCreation,
        //                                          DateDelivery  = xDateDelivery,
        //                                          UserID        = xUserID.IsNull ? -1 : xUserID.Value,
        //                                          Discount      = xDiscount,
        //                                          IDClientPoint = xIDClientPoint.IsNull ? -1 : xIDClientPoint.Value,
        //                                          PaymentID    = xTPaymentID,
        //                                          PriorityID    = xPriorityID,
        //                                          ReqStatusID   = xReqStatusID,
        //                                          Number        = xNumber,
        //                                          CurrencyID    = xCurrencyID,
        //                                          Note          = xNote,
        //                                          WarehouseID   = xWarehouseID,
        //                                          Name          = xName
        //                                      };

        //                    yield return mc;
        //                }
        //            }
        //        }
        //        finally
        //        {
        //            if (drd != null)
        //                drd.Close();
        //            MyConnection.Close();
        //        }
        //    #endregion 
        //}

        public void Insert()
        {
            #region Insert
            var insertCommand = new SqlCommand("INSERT INTO [dbo].[Payment] (" +
                                                      "IDClient, " +
                                                      "DatePay, " +
                                                      "Summ, " +
                                                      "VarPayID, " +
                                                      "ReqTvID, " +
                                                      "Note) VALUES" +
                                                      "(" +
                                                      "@IDClient, " +
                                                      "@DatePay, " +
                                                      "@Summ, " +
                                                      "@VarPayID, " +
                                                      "@ReqTvID, " +
                                                      "@Note)", MyConnection);
            #endregion

            #region Add Parameters

            insertCommand.Parameters.Add(new SqlParameter("@IDClient", typeof(int))).Value = IDClient;
            insertCommand.Parameters.Add(new SqlParameter("@DatePay", typeof(DateTime))).Value = DatePay;
            insertCommand.Parameters.Add(new SqlParameter("@Summ", typeof(float))).Value = Summ;
            insertCommand.Parameters.Add(new SqlParameter("@VarPayID", typeof(int))).Value = VarPayID;
            insertCommand.Parameters.Add(new SqlParameter("@ReqTvID", typeof(int))).Value = ReqTvID;
            insertCommand.Parameters.Add(new SqlParameter("@Note", typeof(string))).Value = Note;

            #endregion

            MyConnection.Open();
            insertCommand.ExecuteNonQuery();
            MyConnection.Close();
        }

        //public static void ClearTable()
        //{
        //    var clearCommand = new SqlCommand("DELETE FROM [dbo].[Requests]", MyConnection);

        //    MyConnection.Open();
        //    clearCommand.ExecuteNonQuery();
        //    MyConnection.Close();
        //}

        //public static void DeleteRecByRecTvID(int recTvID)
        //{
        //   #region SLQ Init
        //    SqlDataReader drd = null;
        //    SqlCommand sqlCmdDeleteRecByRecTvID = MyConnection.CreateCommand();
        //    sqlCmdDeleteRecByRecTvID.CommandText = "DeleteRecByRecTvID";
        //    sqlCmdDeleteRecByRecTvID.CommandType    = CommandType.StoredProcedure;
 
        //    sqlCmdDeleteRecByRecTvID.Parameters.Add("@xRecTvID", SqlDbType.Int, 4);
        //    sqlCmdDeleteRecByRecTvID.Parameters["@xRecTvID"].Value = recTvID;
        //    #endregion
 
        //   #region

        //    try
        //    {
        //        MyConnection.Open();
        //        drd = sqlCmdDeleteRecByRecTvID.ExecuteReader();
        //    }
        //    finally
        //    {
        //        if (drd != null)
        //            drd.Close();
        //        MyConnection.Close();
        //    }
        //#endregion 
        //}
    
    }
}
