using System.Data.SqlClient;

namespace xTrade
{
    class Cost : SQLConnClass
    {
        //private static SqlConnection myConnection;

        public int CostID       { get; set; }
        public int TvID         { get; set; }
        public int CurrencyID   { get; set; }

        public float CostTv     { get; set; }

        //static private string GetConnectionString()
        //{
        //    return Properties.Settings.Default.xTradeConnectionString;
        //}

        //public Cost()
        //{
        //    myConnection = new SqlConnection(GetConnectionString());   
        //}

        //static Cost()
        //{
        //    myConnection = new SqlConnection(GetConnectionString());
        //}

        public void Insert()
        {
            var insertCommand = new SqlCommand("INSERT INTO [dbo].[Cost] (TvID, CurrencyID, CostTv) VALUES (@xTvID, @xCurrencyID, @xCostTv)", MyConnection);

            insertCommand.Parameters.Add(new SqlParameter("@xTvID", typeof(string))).Value = TvID;
            insertCommand.Parameters.Add(new SqlParameter("@xCurrencyID", typeof(string))).Value = CurrencyID;
            insertCommand.Parameters.Add(new SqlParameter("@xCostTv", typeof(string))).Value = CostTv;

            MyConnection.Open();
            insertCommand.ExecuteNonQuery();
            MyConnection.Close();
        }

        public static void ClearTable()
        {
            var clearCommand = new SqlCommand("DELETE FROM [dbo].[Cost]", MyConnection);

            MyConnection.Open();
            clearCommand.ExecuteNonQuery();
            MyConnection.Close();
        }
    }
}
