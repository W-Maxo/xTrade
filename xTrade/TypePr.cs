using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace xTrade
{
    class TypePr : SQLConnClass
    {
        //private static SqlConnection myConnection;

        public int      TypeID  { get; set; }
        public string   Name    { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", TypeID, Name);
        }

        //static private string GetConnectionString()
        //{
        //    return Properties.Settings.Default.xTradeConnectionString;
        //}

        //public TypePr()
        //{
        //    myConnection = new SqlConnection(GetConnectionString());   
        //}

        //static TypePr()
        //{
        //    myConnection = new SqlConnection(GetConnectionString());
        //}

        public static IEnumerable<TypePr> GetAllType()
        {
            const string queryString = "SELECT * FROM [dbo].[TypeProduce];";

            var command = new SqlCommand(queryString, MyConnection);

            SqlDataReader myReader;

            MyConnection.Open();

            myReader = command.ExecuteReader();

            while (myReader.Read())
            {
                    int     xTypeID         = myReader.GetInt32(0);
                string  xName           = myReader.GetString(1);

                var mc = new TypePr
                {
                    TypeID  = xTypeID,
                    Name    = xName,
                };

                yield return mc;
            }
    
            myReader.Close();
            MyConnection.Close();
        }

        public static TypePr GetTypeTovarById(int id)
        {
            return GetAllType().FirstOrDefault(item => item.TypeID == id);
        }

        public static int GetLastItem()
        {
            var selectCommand = new SqlCommand("SELECT DISTINCT TOP 1 * FROM dbo.TypeProduce ORDER BY TypeID DESC", MyConnection);

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


        public void Insert()
        {
            var insertCommand = new SqlCommand("INSERT INTO dbo.TypeProduce (Name) VALUES (@xName)", MyConnection);

            insertCommand.Parameters.Add(new SqlParameter("@xName", typeof(string))).Value = Name;

            MyConnection.Open();
            insertCommand.ExecuteNonQuery();
            MyConnection.Close();   
        }

        public static void Delete(int id)
        {
            var deleteCommand = new SqlCommand("DELETE FROM [dbo.TypeProduce] WHERE ([dbo.Produce].[TvID] = @id)", MyConnection);
            deleteCommand.Parameters.Add(new SqlParameter("@id", typeof (int))).Value = id;

            MyConnection.Open();
            deleteCommand.ExecuteNonQuery();
            MyConnection.Close();
        }

        public void Update(int id)
        {
            var updateCommand = new SqlCommand("UPDATE [dbo.TypeProduce] SET Name = @xName WHERE ([dbo.TypeProduce].[TypeID] = @id)", MyConnection);

            
            updateCommand.Parameters.Add(new SqlParameter("@id", typeof(int))).Value = id;
            updateCommand.Parameters.Add(new SqlParameter("@xName", typeof(string))).Value = Name;
           

            MyConnection.Open();
            updateCommand.ExecuteNonQuery();
            MyConnection.Close();
        }

        public static void ClearTable()
        {
            var clearCommand = new SqlCommand("DELETE FROM [dbo].[TypeProduce]", MyConnection);

            MyConnection.Open();
            clearCommand.ExecuteNonQuery();
            MyConnection.Close();
        }
    }
}
