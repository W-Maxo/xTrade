using System;
using System.Globalization;
using System.Windows.Forms;
using xTrade.Properties;

namespace xTrade
{
    public partial class ClientViewForm : Form
    {
        public ClientsClass Inf;
        public int XClTypeIDType;

        public ClientViewForm()
        {
            InitializeComponent();
        }

        public void ClientViewFormLoad(object sender, EventArgs e)
        {
            if (Inf != null)
            {
                buttonSave.Visible = false;

                foreach (Control control in groupBox1.Controls)
                {
                    if (!(control is TextBox)) continue;

                    var tb = (TextBox)control;

                    tb.ReadOnly = true;
                }

                foreach (Control control in groupBox2.Controls)
                {
                    if (!(control is TextBox)) continue;

                    var tb = (TextBox)control;

                    tb.ReadOnly = true;
                }

                textBoxClientName.Text = Inf.ClientName;
                textBoxFullClientName.Text = Inf.FullName;
                textBoxCode.Text = Inf.IDClient.ToString(CultureInfo.InvariantCulture);

                textBoxDirector.Text = Inf.Director;
                textBoxOKPO.Text = Inf.Okpo;
                textBoxBuh.Text = Inf.Buh;
                textBoxTel.Text = Inf.Telephone;
                textBoxAddress.Text = Inf.Address;
                textBoxMailAddress.Text = Inf.MailAddress;
                textBoxSettlementAccount.Text = Inf.SettlementAccount;
                textBoxUNN.Text = Inf.Unn;
                textBoxBank.Text = Inf.Bank;
                textBoxMFO.Text = Inf.Mfo;
                textBoxBankAddress.Text = Inf.BankAddress;
                textBoxBankFax.Text = Inf.BankFax;
                textBoxNote.Text = Inf.Note;
            }
            else
            {
                Text = Resources.AddClient;
            }
        }

        private void Button2Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            bool vilidated = true;

            foreach (Control control in groupBox1.Controls)
            {
                if (!(control is TextBox)) continue;

                var tb = (TextBox)control;

                if (tb.Tag.ToString() == "1")
                {
                    if (tb.Text != string.Empty)
                    {
                        errorProvider1.SetError(tb, String.Empty);
                    }
                    else
                    {
                        vilidated = false;
                        errorProvider1.SetError(tb, "Не заполнено.");
                    }
                }
            }

            foreach (Control control in groupBox2.Controls)
            {
                if (!(control is TextBox)) continue;

                var tb = (TextBox)control;

                if (tb.Tag.ToString() == "1")
                {
                    if (tb.Text != string.Empty)
                    {
                        errorProvider1.SetError(tb, String.Empty);
                    }
                    else
                    {
                        vilidated = false;
                        errorProvider1.SetError(tb, "Не заполнено.");
                    }
                }
            }

            if (!vilidated) return;

            var cc = new ClientsClass
                         {
                                      Address = textBoxAddress.Text,
                                      Balance = 0,
                                      Bank = textBoxBank.Text,
                                      BankAddress = textBoxBankAddress.Text,
                                      BankFax = textBoxBankFax.Text,
                                      Buh = textBoxBuh.Text,
                                      ClientName = textBoxClientName.Text,
                                      ClTypeID = XClTypeIDType,
                                      Director = textBoxDirector.Text,
                                      FullName = textBoxFullClientName.Text,
                                      Telephone = textBoxTel.Text,
                                      Mfo = textBoxMFO.Text,
                                      MailAddress = textBoxMailAddress.Text,
                                      Okpo = textBoxOKPO.Text,
                                      Unn = textBoxUNN.Text,
                                      SettlementAccount = textBoxSettlementAccount.Text,
                                      Note = textBoxNote.Text
                                  };
            cc.Insert();

            if (ActiveForm != null)
                foreach (Form control in ActiveForm.MdiChildren)
                {
                    var cf = control as ClientsForm;
                    if (cf != null)
                    {
                        cf.listView2_SelectedIndexChanged(sender, e);
                    }
                }

            Close();
        }

        private void TextBoxClientNameValidated(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;

            if (tb.Tag.ToString() == "1")
            {
                errorProvider1.SetError(tb, tb.Text != string.Empty ? String.Empty : "Не заполнено.");
            }
        }

    }
}
