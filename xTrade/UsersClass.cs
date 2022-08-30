using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace xTrade
{
    public class UsersClass : SQLConnClass
    {
        #region Fields
        public int UserID               { get; set; }
        public string LastName         { get; set; }
        public string Name              { get; set; }   
        public string MiddleName       { get; set; }
        public string Telephone         { get; set; }
        public string Address           { get; set; }
        public string EMail             { get; set; }
        public int TypeUserID           { get; set; }
        public string PassHash          { get; set; }
        public string LoginName         { get; set; }
        public int Status               { get; set; }
        public MemoryStream MStream     { get; set; }
        public string StatusStr         { get; set; }
        public string TypeStr           { get; set; }
        public bool AllowAddreq         { get; set; }
        public bool AllowDelAndEditreq  { get; set; }
        public bool AllowUseMnqm        { get; set; }
        public bool AllowModifyPerm     { get; set; }
        #endregion

        public string ImagePath = string.Empty;

        public static IEnumerable<UsersClass> GetUserList() 
        {
            #region SLQ Init

                SqlDataReader drd = null;
                SqlCommand getUsers = MyConnection.CreateCommand();
                getUsers.CommandText = "GetUsers";
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
                            int xUserID                 = drd.GetInt32(0);
                            string xlastName           = drd.GetString(1);
                            string xName                = drd.GetString(2);
                            string xMiddleName         = drd.GetString(3);
                            var xTelephone              = drd.GetSqlString(4);
                            var xAddress                = drd.GetSqlString(5);
                            var xEMail                  = drd.GetSqlString(6);
                            int xTypeUserID             = drd.GetInt32(7);
                            string xPassHash            = drd.GetString(8);
                            string xLoginName           = drd.GetString(9);
                            int xStatus                 = drd.GetInt32(10);
                            string xStatusStr           = drd.GetString(11);
                            string xTypeStr             = drd.GetString(12);
                            bool xAllowAddreq           = drd.GetBoolean(13);
                            bool xAllowDelAndEditreq    = drd.GetBoolean(14);
                            bool xAllowUseMnqm          = drd.GetBoolean(15);
                            bool xAllowModifyPerm       = drd.GetBoolean(16);

                            MemoryStream xmStream = null;

                            var ph = drd.GetSqlBytes(17);

                            if (ph.IsNull != true)
                            {
                                var bLength = (int) drd.GetBytes(17, 0, null, 0, int.MaxValue);

                                var bBuffer = new byte[bLength];

                                drd.GetBytes(17, 0, bBuffer, 0, bLength);
                                //myConnection.Dispose();

                                xmStream = new MemoryStream(bBuffer);
                            }

                            var mc = new UsersClass
                                         {
                                                    UserID              = xUserID,
                                                    LastName           = xlastName,
                                                    Name                = xName,
                                                    MiddleName         = xMiddleName,
                                                    Telephone           = xTelephone.IsNull ? string.Empty : xTelephone.Value,
                                                    Address             = xAddress.IsNull ? string.Empty : xAddress.Value,
                                                    EMail               = xEMail.IsNull ? string.Empty : xEMail.Value,
                                                    TypeUserID          = xTypeUserID,
                                                    PassHash            = xPassHash,
                                                    LoginName           = xLoginName,
                                                    Status              = xStatus,
                                                    MStream             = xmStream,
                                                    StatusStr           = xStatusStr,
                                                    TypeStr             = xTypeStr,
                                                    AllowAddreq         = xAllowAddreq,
                                                    AllowDelAndEditreq  = xAllowDelAndEditreq,
                                                    AllowUseMnqm        = xAllowUseMnqm,
                                                    AllowModifyPerm     = xAllowModifyPerm
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

        public static UsersClass GetUserByUserID(int userID)
        {
            #region SLQ Init
                SqlDataReader drd = null;
                SqlCommand sqlCmdGetUserByUserID = MyConnection.CreateCommand();
                sqlCmdGetUserByUserID.CommandText = "GetUserByUserID";
                sqlCmdGetUserByUserID.CommandType    = CommandType.StoredProcedure;
 
                sqlCmdGetUserByUserID.Parameters.Add("@xUserID", SqlDbType.Int, 4);
                sqlCmdGetUserByUserID.Parameters["@xUserID"].Value = userID;
                #endregion
 
            #region

            UsersClass mc = null;

            try
                {
                MyConnection.Open();
                drd = sqlCmdGetUserByUserID.ExecuteReader();

                if (drd.HasRows)
                    {
                        while (drd.Read())
                        {
                            int xUserID                 = drd.GetInt32(0);
                                string xlastName           = drd.GetString(1);
                                string xName                = drd.GetString(2);
                                string xMiddleName         = drd.GetString(3);
                                var xTelephone              = drd.GetSqlString(4);
                                var xAddress                = drd.GetSqlString(5);
                                var xEMail                  = drd.GetSqlString(6);
                                int xTypeUserID             = drd.GetInt32(7);
                                string xPassHash            = drd.GetString(8);
                                string xLoginName           = drd.GetString(9);
                                int xStatus                 = drd.GetInt32(10);
                                string xStatusStr           = drd.GetString(11);
                                string xTypeStr             = drd.GetString(12);
                                bool xAllowAddreq           = drd.GetBoolean(13);
                                bool xAllowDelAndEditreq    = drd.GetBoolean(14);
                                bool xAllowUseMnqm          = drd.GetBoolean(15);
                                bool xAllowModifyPerm       = drd.GetBoolean(16);

                                mc = new UsersClass
                                         {
                                                        UserID              = xUserID,
                                                        LastName           = xlastName,
                                                        Name                = xName,
                                                        MiddleName         = xMiddleName,
                                                        Telephone           = xTelephone.IsNull ? string.Empty : xTelephone.Value,
                                                        Address             = xAddress.IsNull ? string.Empty : xAddress.Value,
                                                        EMail               = xEMail.IsNull ? string.Empty : xEMail.Value,
                                                        TypeUserID          = xTypeUserID,
                                                        PassHash            = xPassHash,
                                                        LoginName           = xLoginName,
                                                        Status              = xStatus,
                                                        StatusStr           = xStatusStr,
                                                        TypeStr             = xTypeStr,
                                                        AllowAddreq         = xAllowAddreq,
                                                        AllowDelAndEditreq  = xAllowDelAndEditreq,
                                                        AllowUseMnqm        = xAllowUseMnqm,
                                                        AllowModifyPerm     = xAllowModifyPerm
                                                    };

                                return mc;
                        }
                    }
                }
            catch(Exception)
                {
                    return mc;
                }
            finally
                {
                    if (drd != null)
                        drd.Close();
                    MyConnection.Close();
                }

            return null;

            #endregion
        }


        public static IEnumerable<IntStr> GetTypeUser()
        {
            const string queryString = "SELECT * FROM [dbo].[TypeUser];";

            var command = new SqlCommand(queryString, MyConnection);

            MyConnection.Open();

            SqlDataReader myReader = command.ExecuteReader();

            while (myReader.Read())
            {
                int typeUserID = myReader.GetInt32(0);
                string type = myReader.GetString(1);


                var mc = new IntStr
                {
                    ID = typeUserID,
                    ItemContent = type,
                };

                yield return mc;
            }

            myReader.Close();
            MyConnection.Close();
        }

        public static IEnumerable<IntStr> GetStatusUser()
        {
            const string queryString = "SELECT * FROM [dbo].[UserStatus];";

            var command = new SqlCommand(queryString, MyConnection);

            MyConnection.Open();

            SqlDataReader myReader = command.ExecuteReader();

            while (myReader.Read())
            {
                int ussStID = myReader.GetInt32(0);
                string st = myReader.GetString(1);


                var mc = new IntStr
                {
                    ID = ussStID,
                    ItemContent = st,
                };

                yield return mc;
            }

            myReader.Close();
            MyConnection.Close();
        }

        public void Insert()
        {
            #region InsertCommand
             var insertCommand = new SqlCommand("INSERT INTO [dbo].[Users] (" +
                                                       "last_name, " +
                                                       "Name, " +  
                                                       "Middle_name, " +
                                                       "Telephone, " +
                                                       "Address, " +
                                                       "EMail, " +
                                                       "TypeUserID, " +
                                                       "PassHash, " +
                                                       "LoginName, " +
                                                       "Status " +
                                                       (ImagePath != string.Empty ? ", Photo" : "") +
                                                       ") VALUES (" +
                                                       "@xlast_name, " +
                                                       "@xName, " +  
                                                       "@xMiddle_name, " +
                                                       "@xTelephone, " +
                                                       "@xAddress, " +
                                                       "@xEMail, " +
                                                       "@xTypeUserID, " +
                                                       "@xPassHash, " +
                                                       "@xLoginName, " +
                                                       "@xStatus " +
                                                       (ImagePath != string.Empty?", @xPhoto":"") +
                                                       ")", MyConnection);
            #endregion

            #region Add Parameters
            insertCommand.Parameters.Add(new SqlParameter("@xlast_name", typeof(string))).Value = LastName;
            insertCommand.Parameters.Add(new SqlParameter("@xName", typeof(string))).Value = Name;
            insertCommand.Parameters.Add(new SqlParameter("@xMiddle_name", typeof(string))).Value = MiddleName;
            insertCommand.Parameters.Add(new SqlParameter("@xTelephone", typeof(string))).Value = Telephone;
            insertCommand.Parameters.Add(new SqlParameter("@xAddress", typeof(string))).Value = Address;
            insertCommand.Parameters.Add(new SqlParameter("@xEMail", typeof(string))).Value = EMail;
            insertCommand.Parameters.Add(new SqlParameter("@xTypeUserID", typeof(int))).Value = TypeUserID;
            insertCommand.Parameters.Add(new SqlParameter("@xPassHash", typeof(string))).Value = PassHash;
            insertCommand.Parameters.Add(new SqlParameter("@xLoginName", typeof(string))).Value = LoginName;
            insertCommand.Parameters.Add(new SqlParameter("@xStatus", typeof(int))).Value = Status;
            #endregion

            if (ImagePath != string.Empty)
            {
                var fStream = new FileStream(ImagePath, FileMode.Open, FileAccess.Read);

                var imageBytes = new byte[fStream.Length];
                fStream.Read(imageBytes, 0, imageBytes.Length);

                insertCommand.Parameters.Add(new SqlParameter("@xPhoto", SqlDbType.Image)).Value = imageBytes;
            }

            MyConnection.Open();
            insertCommand.ExecuteNonQuery();
            MyConnection.Close();
        }

        public static void Delete(int id)
        {
            #region SLQ Init
                SqlDataReader drd = null;
                SqlCommand sqlCmdDeleteUserByUserID = MyConnection.CreateCommand();
                sqlCmdDeleteUserByUserID.CommandText = "DeleteUserByUserID";
                sqlCmdDeleteUserByUserID.CommandType    = CommandType.StoredProcedure;
 
               sqlCmdDeleteUserByUserID.Parameters.Add("@xUserID", SqlDbType.Int, 4);
               sqlCmdDeleteUserByUserID.Parameters["@xUserID"].Value = id;
             #endregion
 
            #region
 
            try
            {
                MyConnection.Open();
                drd = sqlCmdDeleteUserByUserID.ExecuteReader();
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
