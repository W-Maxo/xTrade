using System;
using System.Collections.Generic;
using System.Windows.Forms;
using xTrade.Properties;

namespace xTrade
{

    public partial class LoginForm : Form
    {
        private void FillCB(IEnumerable<PassClass.UssStr> istr, ComboBox cb)
        {
            cb.SuspendLayout();
            try
            {
                cb.Items.Clear();

                foreach (PassClass.UssStr rs in istr)
                {
                    cb.Items.Add(new PassClass.NameObjectMapSPass(rs.UssName, rs));
                }
            }
            finally
            {
                cb.ResumeLayout();
            }
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginFormLoad(object sender, EventArgs e)
        {
            FillCB(PassClass.GetUserList(), comboBoxUserName);
        }

        private void Button1Click(object sender, EventArgs e)
        {
            var nom = comboBoxUserName.SelectedItem as PassClass.NameObjectMapSPass;

            if (nom == null)
            {
                MessageBox.Show(Resources.Wrong_username, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
               

            var ussr = (PassClass.UssStr)nom.Xobject;

            if (Md5HashClass.VerifyMd5Hash(maskedTextBoxPass.Text, ussr.UssPHash))
            {
                if (ussr.AllowLogin)
                {
                    var pf = (MainFormMdi) ActiveForm;
                    if (pf != null) pf.LoginOn(ussr.UssID);

                    Close();
                }
                else
                {
                    MessageBox.Show(Resources.Account_locked, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Resources.Incorrect_password, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MaskedTextBoxPassKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1Click(sender, new EventArgs());
            }
        }

        private void ComboBoxUserNameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1Click(sender, new EventArgs());
            }
        }
    }
}
