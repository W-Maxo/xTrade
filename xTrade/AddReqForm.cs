using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace xTrade
{
    public partial class AddReqForm : Form
    {
        private int _numReq;

        struct StToReqTv
        {
            public int TvId;
            public int Count;
            public int CurrencyID;
        }

        public void AddTovarToList(int id, int count, int currencyID, string tvName, double cost1)
        {
            var strt = new StToReqTv {Count = count, CurrencyID = currencyID, TvId = id};

            var col = new[] 
                {
                    (listViewTv.Items.Count + 1).ToString(CultureInfo.InvariantCulture),
                    id.ToString(CultureInfo.InvariantCulture),
                    tvName,
                    count.ToString(CultureInfo.InvariantCulture),
                    cost1.ToString(CultureInfo.InvariantCulture),
                    (cost1 * count).ToString(CultureInfo.InvariantCulture)
                };

            var d = new ListViewItem(col, 1) {Tag = strt};

            listViewTv.Items.Add(d);

            comboBoxCurrency.Enabled = false;

        }

        public AddReqForm()
        {
            InitializeComponent();
        }

        private void FillCB(IEnumerable<IntStr> istr, ComboBox cb)
        {
            cb.SuspendLayout();
            try
            {
                cb.Items.Clear();

                foreach (IntStr rs in istr)
                {
                    cb.Items.Add(new NameObjectMap(rs.ItemContent, rs.ID));
                }
            }
            finally
            {
                cb.ResumeLayout();
            }
        }

        private void AddReqFormLoad(object sender, EventArgs e)
        {
            FillCB(InfoClass.GetReqStatusNewList(), comboBoxReqStatus);
            FillCB(InfoClass.GetReqPriorityList(), comboBoxReqPriority);
            FillCB(InfoClass.GetCurrencyList(), comboBoxCurrency);
            FillCB(InfoClass.GetWarehouseList(), comboBoxWarehouse);
            FillCB(InfoClass.GetTypePaymentList(), comboBoxTypePay);
            FillCB(InfoClass.GetClientsList(), comboBoxClients);
        }

        private int GetIDFromCB(ComboBox cb)
        {
            if (cb.SelectedIndex > -1)
            {
                var nom = cb.SelectedItem as NameObjectMap;

                if (nom == null)
                    throw new InvalidOperationException();

                return (int)nom.Xobject;
            }
            return 0;
        }

        private void ComboBoxClientsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClients.SelectedIndex > -1)
            {
                comboBoxPoints.Text = String.Empty;

                var nom = comboBoxClients.SelectedItem as NameObjectMap;

                if (nom == null)
                    throw new InvalidOperationException();

                var inv = (int)nom.Xobject;

                FillCB(InfoClass.GetClientsPointsList(inv), comboBoxPoints);

                comboBoxPoints.Enabled = comboBoxPoints.Items.Count != 0;
            }
        }

        private void Button3Click(object sender, EventArgs e)
        {
            bool vilidated = true;

            foreach (Control control in groupBox1.Controls)
             { 
                if (!(control is ComboBox)) continue;

                var cb = (ComboBox)control;

                if ((cb.SelectedIndex > -1) || !cb.Enabled)
                {
                    errorProvider1.SetError(cb, String.Empty);
                }
                else
                {
                    vilidated = false;
                    errorProvider1.SetError(cb, "Не заполнено.");
                }
            }

            try
            {
                if (Single.Parse(textBoxDisc.Text) > 100) vilidated = false;
                errorProvider1.SetError(textBoxDisc, String.Empty);
            }
            catch (Exception)
            {
                errorProvider1.SetError(textBoxDisc, "Не заполнено.");
                vilidated = false;
            }

            if (!vilidated) return;

            var pf = (MainFormMdi)ActiveForm;

            var dateCreation = DateTime.Now;

            if (pf != null)
            {
                string tomd5HashStr = string.Format("{0} {1} {2}",
                    dateCreation.ToString(CultureInfo.InvariantCulture),
                    pf.CUss.LoginName,
                    RandomString.NextString(new Random(), 25));

                var mc = new ReqClass
                             {
                                      CurrencyID      = GetIDFromCB(comboBoxCurrency),
                                      DateDelivery    = dateTimePickerDel.Value,
                                      DateCreation    = dateTimePickerCr.Value,
                                      Discount        = Single.Parse(textBoxDisc.Text),
                                      IDClient        = GetIDFromCB(comboBoxClients),
                                      IDClientPoint   = GetIDFromCB(comboBoxPoints),
                                      Note            = textBoxNote.Text,
                                      Number          = _numReq.ToString(CultureInfo.InvariantCulture),
                                      PriorityID      = GetIDFromCB(comboBoxReqPriority),
                                      ReqStatusID     = GetIDFromCB(comboBoxReqStatus),
                                      PaymentID      = GetIDFromCB(comboBoxTypePay),
                                      WarehouseID     = GetIDFromCB(comboBoxWarehouse),
                                      UserID          = pf.CurrUssID,
                                      UnqStr          = Md5HashClass.GetMd5Hash(tomd5HashStr).ToLower() 
                                  };

                mc.Insert();
            }

            _numReq = ReqClass.GetLastItem();

            for (int i = 0; i < listViewTv.Items.Count; i++)
            {
                var tm = (StToReqTv) listViewTv.Items[i].Tag;

                var dr = new DataReq
                             {
                                     Count = tm.Count,
                                     CurrencyID = tm.CurrencyID,
                                     RecTvID = _numReq,
                                     TvID = tm.TvId
                                 };
                dr.Insert();
            }

            if (ActiveForm != null)
                foreach (Form control in ActiveForm.MdiChildren)
                {
                    var uf = control as ReqForm;
                    if (uf != null)
                    {
                        uf.ReqFormLoad(sender, e);
                    }
                }

            Close();
        }

        private void Button4Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBoxClientsValidated(object sender, EventArgs e)
        {
            var cb = (ComboBox) sender;

            if ((cb.SelectedIndex > -1) || !cb.Enabled)
            {
                errorProvider1.SetError(cb, String.Empty);
            }
            else
            {
                errorProvider1.SetError(cb, "Не заполнено.");
            }
        }

        private void TextBoxDiscValidated(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.SetError(textBoxDisc,
                                        Single.Parse(textBoxDisc.Text) > 100 ? "Неверное значение." : String.Empty);
            }
            catch (Exception)
            {
                errorProvider1.SetError(textBoxDisc, "Неверное значение.");
            }
        }

        private void TextBoxDiscKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (textBoxDisc.Text.IndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]) != -1) &&
                        (e.KeyChar == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);

            if (!e.Handled)
                e.Handled = !Char.IsNumber(e.KeyChar) &&
                        (e.KeyChar != 8) &&
                        (e.KeyChar != CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);    
        }

        private void Button1Click(object sender, EventArgs e)
        {
            if (comboBoxCurrency.SelectedIndex > -1)
            {
                errorProvider1.SetError(comboBoxCurrency, String.Empty);

                var childForm = new FormProd
                                    {
                                        MdiParent = ActiveForm,
                                        CCurr = comboBoxCurrency.SelectedIndex,
                                        comboBoxCurrencyPf = {Enabled = false}
                                    };

                childForm.Show();   
            }
            else
            {
                errorProvider1.SetError(comboBoxCurrency, "Не заполнено.");
            }
        }

        private void Button2Click(object sender, EventArgs e)
        {
            if (listViewTv.SelectedItems.Count == 0) return;

            var itemIndx = listViewTv.SelectedItems[0].Index;
            
            listViewTv.Items[itemIndx].Remove();
        }
    }
}
