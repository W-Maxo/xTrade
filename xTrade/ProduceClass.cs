using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace xTrade
{
    class ProduceClass : SQLConnClass
    {
        //private static SqlConnection myConnection;

        public int      TvID    { get; set; }
        public int      CodeTv  { get; set; }
        public int      TypeID  { get; set; }
        public string   Name    { get; set; }
        public int      NimP    { get; set; }
        public double   Cost1   { get; set; }
        public bool     Status  { get; set; }
        public int      Remains { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6}",
                TvID, CodeTv, TypeID, Name, NimP, Cost1, Status);
        }

        //static private string GetConnectionString()
        //{
        //    return Properties.Settings.Default.xTradeConnectionString;
        //}

        //public ProduceClass()
        //{
        //    myConnection = new SqlConnection(GetConnectionString());   
        //}

        //static ProduceClass()
        //{
        //    myConnection = new SqlConnection(GetConnectionString());
        //}

        public static IEnumerable<ProduceClass> GetAllTovars(int currencyID)
        {
            const string queryString = "SELECT * FROM [dbo].[Produce];";

            var command = new SqlCommand(queryString, MyConnection);

            MyConnection.Open();

            SqlDataReader myReader = command.ExecuteReader();

            while (myReader.Read())
            {
                int     xTvID       = myReader.GetInt32(0);
                int     xCodeTv     = myReader.GetInt32(1);
                int     xTypeID     = myReader.GetInt32(2);
                string  xName       = myReader.GetString(3);
                int     xNimP       = myReader.GetInt32(4);
                bool    xStatus     = myReader.GetBoolean(7);
                int     xRemains    = myReader.GetInt32(8);

                var mc = new ProduceClass
                {
                    TvID    = xTvID,
                    CodeTv  = xCodeTv,
                    TypeID  = xTypeID,
                    Name    = xName,
                    NimP    = xNimP,
                    Status  = xStatus,
                    Remains = xRemains
                };

                yield return mc;
            }
    
            myReader.Close();
            MyConnection.Close();
        }

        public static int GetLastItem()
        {
            var selectCommand = new SqlCommand("SELECT DISTINCT TOP 1 TvID FROM dbo.Produce ORDER BY TvID DESC", MyConnection);

            MyConnection.Open();

            SqlDataReader myReader = selectCommand.ExecuteReader();

            int xID = 0;

            while (myReader.Read())
            {
                xID = myReader.GetInt32(0);
            }


            myReader.Close();
            MyConnection.Close();
            return xID;
        }

        public static IEnumerable<ProduceClass> GetTovarsByTypeEx(int type, int currencyID)
        {
            #region SLQ Init

                SqlDataReader drd = null;
                SqlCommand sqlCmdGetTovarsByType = MyConnection.CreateCommand();
                sqlCmdGetTovarsByType.CommandText = "GetTovarsByType";
                sqlCmdGetTovarsByType.CommandType = CommandType.StoredProcedure;

                sqlCmdGetTovarsByType.Parameters.Add("@xTypeID", SqlDbType.Int, 4);
                sqlCmdGetTovarsByType.Parameters["@xTypeID"].Value =type;

                sqlCmdGetTovarsByType.Parameters.Add("@xCurrencyID", SqlDbType.Int, 4);
                sqlCmdGetTovarsByType.Parameters["@xCurrencyID"].Value = currencyID;

            #endregion

            #region

            try
            {
                MyConnection.Open();
                drd = sqlCmdGetTovarsByType.ExecuteReader();

                if (drd.HasRows)
                {
                    while (drd.Read())
                    {
                        int xTvID       = drd.GetInt32(0);
                        int xCodeTv     = drd.GetInt32(1);
                        int xTypeID     = drd.GetInt32(2);
                        string xName    = drd.GetString(3);
                        int xNimP       = drd.GetInt32(4);
                        double xCost1    =drd.GetDouble(5);  
                        bool xStatus    = drd.GetBoolean(6);
                        int xRemains    = drd.GetInt32(7);

                        var mc = new ProduceClass
                        {
                            TvID = xTvID,
                            CodeTv = xCodeTv,
                            TypeID = xTypeID,
                            Name = xName,
                            NimP = xNimP,
                            Cost1 = xCost1,
                            Status = xStatus,
                            Remains = xRemains
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


        public static IEnumerable<ProduceClass> GetTovarsByType(int type)
        {
            const string queryString = "SELECT * FROM [dbo].[Produce] WHERE TypeID = @xTypeID;";

            var command = new SqlCommand(queryString, MyConnection);

            command.Parameters.Add(new SqlParameter("@xTypeID", typeof(int))).Value = type;

            MyConnection.Open();

            SqlDataReader myReader = command.ExecuteReader();

            while (myReader.Read())
            {
                int xTvID = myReader.GetInt32(0);
                int xCodeTv = myReader.GetInt32(1);
                int xTypeID = myReader.GetInt32(2);
                string xName = myReader.GetString(3);
                int xNimP = myReader.GetInt32(4);
                bool xStatus = myReader.GetBoolean(5);
                int xRemains = myReader.GetInt32(6);

                var mc = new ProduceClass
                {
                    TvID = xTvID,
                    CodeTv = xCodeTv,
                    TypeID = xTypeID,
                    Name = xName,
                    NimP = xNimP,
                    Status = xStatus,
                    Remains = xRemains
                };

                yield return mc;
            }

            myReader.Close();
            MyConnection.Close();
        }

        public static ProduceClass GetTovarById(int id)
        {
            return GetAllTovars(1).FirstOrDefault(item => item.TvID == id);
        }

        public void Insert()
        {

            var insertCommand = new SqlCommand("INSERT INTO [dbo].[Produce] (CodeTv, TypeID, Name, NumberInPacking, Status, Remains) VALUES" +
                                           "(@xCodeTv, @xTypeID, @xName, @NimP, @xStatus, @xRemains)", MyConnection);

            insertCommand.Parameters.Add(new SqlParameter("@xCodeTv",    typeof(int)))       .Value = CodeTv;
            insertCommand.Parameters.Add(new SqlParameter("@xTypeID",    typeof(int)))       .Value = TypeID;
            insertCommand.Parameters.Add(new SqlParameter("@xName",      typeof(string)))    .Value = Name;
            insertCommand.Parameters.Add(new SqlParameter("@NimP",       typeof(int)))       .Value = NimP;
            insertCommand.Parameters.Add(new SqlParameter("@xStatus",    typeof(bool)))      .Value = Status;
            insertCommand.Parameters.Add(new SqlParameter("@xRemains",   typeof(int)))       .Value = Remains;

            MyConnection.Open();
            insertCommand.ExecuteNonQuery();
            MyConnection.Close();   
        }

        public static void Delete(int id)
        {
            var deleteCommand = new SqlCommand("DELETE FROM [dbo].[Produce] WHERE ([dbo].[Produce].[TvID] = @id)", MyConnection);
            deleteCommand.Parameters.Add(new SqlParameter("@id", typeof (int))).Value = id;

            MyConnection.Open();
            deleteCommand.ExecuteNonQuery();
            MyConnection.Close();
        }

        public void Update(int id)
        {
            var updateCommand = new SqlCommand("UPDATE [dbo].[Produce] SET [CodeTv] = @xCodeTv, [TypeID] = @xTypeID, [Name]= @xName," +
                                                      " [NumberInPacking] = @NimP, [Status] = @xStatus, [Remains] =@xRemains" +
                                                      " WHERE (TvID = @id)", MyConnection);

            
            updateCommand.Parameters.Add(new SqlParameter("@id", typeof(int))).Value = id;

            updateCommand.Parameters.Add(new SqlParameter("@xCodeTv", typeof(int))).Value = CodeTv;
            updateCommand.Parameters.Add(new SqlParameter("@xTypeID", typeof(int))).Value = TypeID;
            updateCommand.Parameters.Add(new SqlParameter("@xName", typeof(string))).Value = Name;
            updateCommand.Parameters.Add(new SqlParameter("@NimP", typeof(int))).Value = NimP;
            updateCommand.Parameters.Add(new SqlParameter("@xStatus", typeof(bool))).Value = Status;
            updateCommand.Parameters.Add(new SqlParameter("@xRemains", typeof(int))).Value = Remains;

            MyConnection.Open();
            updateCommand.ExecuteNonQuery();
            MyConnection.Close();
        }

        public static void ClearTable()
        {
            var clearCommand = new SqlCommand("DELETE FROM [dbo].[Produce]", MyConnection);

            MyConnection.Open();
            clearCommand.ExecuteNonQuery();
            MyConnection.Close();
        }
    }
}
