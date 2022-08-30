using System.Collections.Generic;
using System.Data.SqlClient;

namespace xTrade
{
    public class ClientsClass : SQLConnClass
    {
        public int IDClient             { get; set; }
        public string ClientName        { get; set; }
        public string Address           { get; set; }
        public double Balance           { get; set; }
        public string FullName          { get; set; }
        public string Director          { get; set; }
        public string Okpo              { get; set; }
        public string Buh               { get; set; }
        public string Telephone         { get; set; }
        public string SettlementAccount { get; set; }
        public string Bank              { get; set; }
        public string BankAddress       { get; set; }
        public string Unn               { get; set; }
        public string Mfo               { get; set; }
        public string BankFax           { get; set; }
        public string Note              { get; set; }
        public int ClTypeID             { get; set; }
        public string MailAddress       { get; set; }

        public static IEnumerable<IntStr> GetClTypes()
        {
            const string queryString = "SELECT * FROM [dbo].[ClTypes];";

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

        public static IEnumerable<ClientsClass> GetClByTypesID(int tid)
        {
            const string queryString = "SELECT * FROM [dbo].[Clients] WHERE [dbo].[Clients].[ClTypeID] = @TID;";

            var command = new SqlCommand(queryString, MyConnection);

            command.Parameters.Add(new SqlParameter("@TID", typeof(int))).Value = tid;

            MyConnection.Open();

            SqlDataReader myReader = command.ExecuteReader();

            while (myReader.Read())
            {
                int xIDClient = myReader.GetInt32(0);
                string xClientName  = myReader.GetString(1);
                string xAddress = myReader.GetString(2);
                double xBalance = myReader.GetDouble(3);
                var xFullName = myReader.GetSqlString(4);
                string xDirector = myReader.GetString(5);
                string xOkpo = myReader.GetString(6);
                string xBuh = myReader.GetString(7);
                var xTelephone = myReader.GetSqlString(8);
                string xSettlementAccount = myReader.GetString(9);
                var xBank = myReader.GetSqlString(10);
                var xBankAddress = myReader.GetSqlString(11);
                string xUnn = myReader.GetString(12);
                var xMfo = myReader.GetSqlString(13);
                var xBankFax = myReader.GetSqlString(14);
                var xNote = myReader.GetSqlString(15);
                int xClTypeID = myReader.GetInt32(16);
                var xMailAddress = myReader.GetSqlString(17);
             
                var mc = new ClientsClass
                {
                    IDClient = xIDClient,
                    ClientName = xClientName,
                    Address = xAddress,
                    Balance = xBalance,
                    FullName = xFullName.IsNull ? string.Empty : xFullName.Value,
                    Director = xDirector,
                    Okpo = xOkpo,
                    Buh = xBuh,
                    Telephone = xTelephone.IsNull ? string.Empty : xTelephone.Value,
                    SettlementAccount = xSettlementAccount,
                    Bank = xBank.IsNull ? string.Empty : xBank.Value,
                    BankAddress = xBankAddress.IsNull ? string.Empty : xBankAddress.Value,
                    Unn = xUnn,
                    Mfo = xMfo.IsNull ? string.Empty : xMfo.Value,
                    BankFax = xBankFax.IsNull ? string.Empty : xBankFax.Value,
                    Note = xNote.IsNull ? string.Empty : xNote.Value,
                    ClTypeID = xClTypeID,
                    MailAddress = xMailAddress.IsNull ? string.Empty : xMailAddress.Value,
                };

                yield return mc;
            }

            myReader.Close();
            MyConnection.Close();
        }

        public void Insert()
        {
            #region Insert
            var insertCommand = new SqlCommand("INSERT INTO [dbo].[Clients] (" +
                                                      "ClientName, " +
                                                      "Address, " +
                                                      "Balance, " +
                                                      "FullName, " +
                                                      "Director, " +
                                                      "OKPO, " +
                                                      "Buh, " +
                                                      "Telephone, " +
                                                      "SettlementAccount, " +
                                                      "Bank, " +
                                                      "BankAddress, " +
                                                      "UNN, " +
                                                      "MFO, " +
                                                      "BankFax, " +
                                                      "Note, " +
                                                      "ClTypeID, " +
                                                      "MailAddress) VALUES" +
                                                      "(" +
                                                      "@xClientName, " +
                                                      "@xAddress, " +
                                                      "@xBalance, " +
                                                      "@xFullName, " +
                                                      "@xDirector, " +
                                                      "@xOKPO, " +
                                                      "@xBuh, " +
                                                      "@xTelephone, " +
                                                      "@xSettlementAccount, " +
                                                      "@xBank, " +
                                                      "@xBankAddress, " +
                                                      "@xUNN, " +
                                                      "@xMFO, " +
                                                      "@xBankFax, " +
                                                      "@xNote, " +
                                                      "@xClTypeID, " +
                                                      "@xMailAddress)", MyConnection);
            #endregion

            #region Add Parameters

            insertCommand.Parameters.Add(new SqlParameter("@xClientName", typeof(string))).Value = ClientName;
            insertCommand.Parameters.Add(new SqlParameter("@xAddress", typeof(string))).Value = Address;
            insertCommand.Parameters.Add(new SqlParameter("@xBalance", typeof(double))).Value = Balance;
            insertCommand.Parameters.Add(new SqlParameter("@xFullName", typeof(string))).Value = FullName;
            insertCommand.Parameters.Add(new SqlParameter("@xDirector", typeof(string))).Value = Director;
            insertCommand.Parameters.Add(new SqlParameter("@xOKPO", typeof(string))).Value = Okpo;
            insertCommand.Parameters.Add(new SqlParameter("@xBuh", typeof(string))).Value = Buh;
            insertCommand.Parameters.Add(new SqlParameter("@xTelephone", typeof(string))).Value = Telephone;
            insertCommand.Parameters.Add(new SqlParameter("@xSettlementAccount", typeof(string))).Value = SettlementAccount;
            insertCommand.Parameters.Add(new SqlParameter("@xBank", typeof(string))).Value = Bank;
            insertCommand.Parameters.Add(new SqlParameter("@xBankAddress", typeof(string))).Value = BankAddress;
            insertCommand.Parameters.Add(new SqlParameter("@xUNN", typeof(string))).Value = Unn;
            insertCommand.Parameters.Add(new SqlParameter("@xMFO", typeof(string))).Value = Mfo;
            insertCommand.Parameters.Add(new SqlParameter("@xBankFax", typeof(string))).Value = BankFax;
            insertCommand.Parameters.Add(new SqlParameter("@xNote", typeof(string))).Value = Note;
            insertCommand.Parameters.Add(new SqlParameter("@xMailAddress", typeof(string))).Value = MailAddress;
            insertCommand.Parameters.Add(new SqlParameter("@xClTypeID", typeof(int))).Value = ClTypeID;
            
            #endregion

            MyConnection.Open();
            insertCommand.ExecuteNonQuery();
            MyConnection.Close();
        }

        public static void InsertClType(string xClType)
        {
            #region Insert
            var insertCommand = new SqlCommand("INSERT INTO [dbo].[ClTypes] (" +
                                                      "ClType) VALUES" +
                                                      "(" +
                                                      "@xClType)", MyConnection);
            #endregion

            #region Add Parameters

            insertCommand.Parameters.Add(new SqlParameter("@xClType", typeof(string))).Value = xClType;

            #endregion

            MyConnection.Open();
            insertCommand.ExecuteNonQuery();
            MyConnection.Close();
        }
    }
}
