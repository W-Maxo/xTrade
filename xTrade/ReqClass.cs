using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace xTrade
{
    class ReqClass : SQLConnClass
    {
        public int      ReqTvID         { get; set; }
        public int      IDClient        { get; set; }
        public DateTime DateCreation    { get; set; }
        public DateTime DateDelivery    { get; set; }
        public int      UserID          { get; set; }
        public double   Discount        { get; set; }
        public int      IDClientPoint   { get; set; }
        public int      PaymentID       { get; set; }
        public int      PriorityID      { get; set; }
        public int      ReqStatusID     { get; set; }
        public string   Number          { get; set; }
        public int      CurrencyID      { get; set; }
        public string   Note            { get; set; }
        public int      WarehouseID     { get; set; }
        public string   Name            { get; set; }
        public string   UnqStr          { get; set; }

        public static int GetLastItem()
        {
            var selectCommand = new SqlCommand("SELECT DISTINCT TOP 1 RecTvID FROM dbo.Requests ORDER BY RecTvID DESC", MyConnection);

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

        public void UpdateStatus()
        {
            var updateCommand = new SqlCommand("UPDATE dbo.Requests SET ReqStatusID = @xReqStatusID WHERE (RecTvID = @xReqTvID)", MyConnection);

            updateCommand.Parameters.Add(new SqlParameter("@xReqStatusID", typeof(int))).Value = ReqStatusID;
            updateCommand.Parameters.Add(new SqlParameter("@xReqTvID", typeof(int))).Value = ReqTvID;

            MyConnection.Open();

            updateCommand.ExecuteNonQuery();

            MyConnection.Close();
        }

        public static IEnumerable<ReqClass> GetAllReq()
        {
            #region SLQ Init
                SqlDataReader drd = null;
                SqlCommand getAllReq = MyConnection.CreateCommand();
                getAllReq.CommandText = "GetAllReq";
                getAllReq.CommandType = CommandType.StoredProcedure;
            #endregion
 
            #region
                try
                {
                    MyConnection.Open();
                    drd = getAllReq.ExecuteReader();

                    if (drd.HasRows)
                    {
                        while (drd.Read())
                        {
                            int xReqTvID            = drd.GetInt32(0);
                            int xIDClient           = drd.GetInt32(1);
                            DateTime xDateCreation  = drd.GetDateTime(2);
                            DateTime xDateDelivery  = drd.GetDateTime(3);
                            var xUserID             = drd.GetSqlInt32(4);
                            double xDiscount        = drd.GetDouble(5);
                            var xIDClientPoint      = drd.GetSqlInt32(6);
                            int xTPaymentID         = drd.GetInt32(7);
                            int xPriorityID         = drd.GetInt32(8);
                            int xReqStatusID        = drd.GetInt32(9);
                            string xNumber          = drd.GetString(10);
                            int xCurrencyID         = drd.GetInt32(11);
                            string xNote            = drd.GetString(12);
                            int xWarehouseID        = drd.GetInt32(13);
                            string xUnqStr          = drd.GetString(14);
                            string xName            = drd.GetString(15);    

                            var mc = new ReqClass
                                              {
                                                  ReqTvID       = xReqTvID,
                                                  IDClient      = xIDClient,
                                                  DateCreation  = xDateCreation,
                                                  DateDelivery  = xDateDelivery,
                                                  UserID        = xUserID.IsNull ? -1 : xUserID.Value,
                                                  Discount      = xDiscount,
                                                  IDClientPoint = xIDClientPoint.IsNull ? -1 : xIDClientPoint.Value,
                                                  PaymentID    = xTPaymentID,
                                                  PriorityID    = xPriorityID,
                                                  ReqStatusID   = xReqStatusID,
                                                  Number        = xNumber,
                                                  CurrencyID    = xCurrencyID,
                                                  Note          = xNote,
                                                  WarehouseID   = xWarehouseID,
                                                  Name          = xName,
                                                  UnqStr        = xUnqStr
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
        
        public void Insert()
        {
            #region Insert
                var insertCommand = new SqlCommand("INSERT INTO [dbo].[Requests] (" +
                                                          "IDClient, " +
                                                          "DateCreation, " +
                                                          "DateDelivery, " +
                                                          "UserID, " +
                                                          "Discount, " +
                                                          (IDClientPoint != 0 ? "IDClientPoint, " : string.Empty) +
                                                          "TPaymentID, " +
                                                          "PriorityID, " +
                                                          "ReqStatusID, " +
                                                          "Number, " +
                                                          "CurrencyID, " +
                                                          "Note, " +
                                                          "WarehouseID," +
                                                          "UnqStr) VALUES" +
                                                          "(" +
                                                          "@IDClient, " +
                                                          "@DateCreation, " +
                                                          "@DateDelivery, " +
                                                          "@UserID, " +
                                                          "@Discount, " +
                                                          (IDClientPoint != 0 ? "@IDClientPoint, " : string.Empty) +
                                                          "@TPaymentID, " +
                                                          "@PriorityID, " +
                                                          "@ReqStatusID, " +
                                                          "@Number, " +
                                                          "@CurrencyID, " +
                                                          "@Note, " +
                                                          "@WarehouseID," +
                                                          "@UnqStr)", MyConnection);
            #endregion

            #region Add Parameters
                insertCommand.Parameters.Add(new SqlParameter("@IDClient",      typeof(int)))       .Value = IDClient;
                insertCommand.Parameters.Add(new SqlParameter("@DateCreation",  typeof(DateTime)))  .Value = DateCreation;
                insertCommand.Parameters.Add(new SqlParameter("@DateDelivery",  typeof(DateTime)))  .Value = DateDelivery;
                insertCommand.Parameters.Add(new SqlParameter("@UserID",        typeof(int)))       .Value = UserID;
                insertCommand.Parameters.Add(new SqlParameter("@Discount",      typeof(float)))     .Value = Discount;

                if (IDClientPoint != 0)
                insertCommand.Parameters.Add(new SqlParameter("@IDClientPoint", typeof(int)))       .Value = IDClientPoint;

                insertCommand.Parameters.Add(new SqlParameter("@TPaymentID",    typeof(int)))       .Value = PaymentID;
                insertCommand.Parameters.Add(new SqlParameter("@PriorityID",    typeof(int)))       .Value = PriorityID;
                insertCommand.Parameters.Add(new SqlParameter("@ReqStatusID",   typeof(int)))       .Value = ReqStatusID;
                insertCommand.Parameters.Add(new SqlParameter("@Number",        typeof(string)))    .Value = Number;
                insertCommand.Parameters.Add(new SqlParameter("@CurrencyID",    typeof(int)))       .Value = CurrencyID;
                insertCommand.Parameters.Add(new SqlParameter("@Note",          typeof(string)))    .Value = Note;
                insertCommand.Parameters.Add(new SqlParameter("@WarehouseID",   typeof(int)))       .Value = WarehouseID;
                insertCommand.Parameters.Add(new SqlParameter("@UnqStr",        typeof(string)))    .Value = UnqStr;
            #endregion

            MyConnection.Open();
            insertCommand.ExecuteNonQuery();
            MyConnection.Close();
        }

        public static void ClearTable()
        {
            var clearCommand = new SqlCommand("DELETE FROM [dbo].[Requests]", MyConnection);

            MyConnection.Open();
            clearCommand.ExecuteNonQuery();
            MyConnection.Close();
        }

        public static void DeleteRecByRecTvID(int recTvID)
        {
           #region SLQ Init
            SqlDataReader drd = null;
            SqlCommand sqlCmdDeleteRecByRecTvID = MyConnection.CreateCommand();
            sqlCmdDeleteRecByRecTvID.CommandText = "DeleteRecByRecTvID";
            sqlCmdDeleteRecByRecTvID.CommandType    = CommandType.StoredProcedure;
 
            sqlCmdDeleteRecByRecTvID.Parameters.Add("@xRecTvID", SqlDbType.Int, 4);
            sqlCmdDeleteRecByRecTvID.Parameters["@xRecTvID"].Value = recTvID;
            #endregion
 
           #region

            try
            {
                MyConnection.Open();
                drd = sqlCmdDeleteRecByRecTvID.ExecuteReader();
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
