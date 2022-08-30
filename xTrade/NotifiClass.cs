using System;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Windows.Forms;
using xTrade.Properties;

namespace xTrade
{
    public class SampleEventArgs
    {
        public SampleEventArgs(string s) { Text = s; }
        public String Text { get; private set; } 
    }

    public class NotifiClass
    {
        public static SqlConnection MyConnection;

        public delegate void SampleEventHandler(object sender, SampleEventArgs e);

        public event SampleEventHandler SampleEvent;

        protected virtual void RaiseSampleEvent()
        {
            if (SampleEvent != null)
                SampleEvent(this, new SampleEventArgs("Change"));
        }

        static private string GetConnectionString()
        {
            return Settings.Default.xTradeConnectionString;
        }

        private bool CheckUserPermissions()
        {
            try
            {
                var permissions = new SqlClientPermission(PermissionState.Unrestricted);

                permissions.Demand();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public NotifiClass()
        {
            if (!CheckUserPermissions())
            {
                MessageBox.Show(Resources.An_error_has_occurred_when_checking_permissions);
                return;
            }

            Initialization();
            SomeMethod();
        }

        ~NotifiClass()
        {
            Termination();
        }

        void Initialization()
        {
            MyConnection = new SqlConnection(GetConnectionString());
            MyConnection.Open();
            SqlDependency.Start(GetConnectionString());
        }

        void SomeMethod()
        {
            using (var command = new SqlCommand(
                "SELECT RecTvID, ReqStatusID FROM dbo.Requests",
                MyConnection))
            {
                var dependency = new SqlDependency(command);

                dependency.OnChange += OnDependencyChange;

                using (SqlDataReader reader = command.ExecuteReader()) {}
            }
        }

        void OnDependencyChange(object sender,
           SqlNotificationEventArgs e)
        {
            SomeMethod();
            RaiseSampleEvent();
        }

        void Termination()
        {
            SqlDependency.Stop(GetConnectionString());
        }
    }
}
