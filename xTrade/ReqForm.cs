using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using xTrade.Properties;

namespace xTrade
{
    public partial class ReqForm : Form
    {
        private double reqsum;
        private double paysum;

        public ReqForm()
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

        public void ReqFormLoad(object sender, EventArgs e)
        {
            var pf = (MainFormMdi)ActiveForm;

            if (pf != null)
            {
                toolStripButtonAdd.Enabled = pf.CUss.AllowAddreq;

                toolStripButtonRem.Enabled = pf.CUss.AllowDelAndEditreq;
            }

            FillCB(InfoClass.GetReqStatusList(), comboBoxReqStatus);
            FillCB(InfoClass.GetReqPriorityList(), comboBoxReqPriority);
            FillCB(InfoClass.GetCurrencyList(), comboBoxCurrency);
            FillCB(InfoClass.GetWarehouseList(), comboBoxWarehouse);
            FillCB(InfoClass.GetTypePaymentList(), comboBoxTypePay);
            FillCB(InfoClass.GetClientsList(), comboBoxClients);

            LoadList();
        }

        public void LoadList()
        {
            string selindx = string.Empty;

            if (listView2.SelectedItems.Count != 0)
            {
                var item = (ReqClass)listView2.SelectedItems[0].Tag;

                selindx = item.UnqStr;
            }

            listView2.BeginUpdate();
            try
            {
                listView2.Items.Clear();

                int indx = 1;

                foreach (ReqClass item in ReqClass.GetAllReq())
                {
                    var col = new[]
                                       {
                                           indx++.ToString(CultureInfo.InvariantCulture), item.DateCreation.ToString("d.MM.yyyy"), item.Name
                                       };

                    var d = new ListViewItem(col, 1) { Tag = item };

                    ListViewItem lvi = listView2.Items.Add(d);
                    lvi.ImageIndex = item.ReqStatusID - 1;
                }
            }
            finally
            {
                listView2.EndUpdate();

                if (string.Empty != selindx)
                {
                    for (int i = 0; i < listView2.Items.Count - 1; i++)
                    {
                        var item = (ReqClass) listView2.Items[i].Tag;

                        if (0 == String.CompareOrdinal(item.UnqStr, selindx))
                        {
                            listView2.Items[i].Selected = true;
                            listView2.Items[i].Focused = true;

                            listView2.EnsureVisible(i);

                            break;
                        }
                    }
                }
            }
        }

        private int GetIDFromCb(ComboBox cb)
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

        private void SelCB(ComboBox cb, int id)
        {
            for (int i = 0; i < cb.Items.Count; i++ )
            {
                var nom = cb.Items[i] as NameObjectMap;

                if (nom == null)
                    throw new InvalidOperationException();

                if ((int)nom.Xobject == id)
                {
                    cb.SelectedIndex = i;
                    return;
                }
            }
        }

        private void ListView2SelectedIndexChanged(object sender, EventArgs e)
        {
            reqsum = 0;
            paysum = 0;

            int indx = 1;

            toolStripButton1.Enabled = false;
            toolStripButtonAddVarPay.Enabled = false;

            if (listView2.SelectedItems.Count == 0) return;

            var item = (ReqClass)listView2.SelectedItems[0].Tag;

            listView1.BeginUpdate();
            try
            {
                listView1.Items.Clear();

                foreach (DateReqByRecTvID xitem in DataReq.GetDateReqByRecTvID(item.ReqTvID))
                {
                    double sm = xitem.Count*xitem.CostTv;
                    reqsum += sm;

                    var col = new[]
                                       {
                                           indx++.ToString(CultureInfo.InvariantCulture),
                                           xitem.CodeTv.ToString(CultureInfo.InvariantCulture),
                                           xitem.Name,
                                           xitem.Count.ToString(CultureInfo.InvariantCulture),
                                           xitem.CostTv.ToString(CultureInfo.InvariantCulture),
                                           sm.ToString(CultureInfo.InvariantCulture)
                                       };

                    var d = new ListViewItem(col, 1) {Tag = xitem};

                    listView1.Items.Add(d);
                }

                label14.Text = reqsum.ToString(CultureInfo.InvariantCulture);

                indx = 1;

                listView3.Items.Clear();

                foreach (PaymentClass xitem in PaymentClass.GetPaymentReqByRecTvID(item.ReqTvID))
                {
                    paysum += xitem.Summ;

                    var col = new[]
                                       {
                                           indx++.ToString(CultureInfo.InvariantCulture),
                                           xitem.DatePay.ToString(CultureInfo.InvariantCulture),
                                           xitem.Discr,
                                           xitem.Note,
                                           xitem.PayPercent.ToString(CultureInfo.InvariantCulture),
                                           xitem.Summ.ToString(CultureInfo.InvariantCulture)
                                       };

                    var d = new ListViewItem(col, 1) {Tag = xitem};

                    listView3.Items.Add(d);
                }

                label15.Text = paysum.ToString(CultureInfo.InvariantCulture);

                if (item.ReqStatusID != 5)
                {
                    toolStripButtonAddVarPay.Enabled = true;

                    if ((reqsum + paysum) > 0 && (reqsum <= paysum))
                    {
                        toolStripButton1.Enabled = true;
                    }
                }

                textBoxNumReq.Text = item.ReqTvID.ToString(CultureInfo.InvariantCulture);
                dateTimePickerCr.Value = item.DateCreation;
                SelCB(comboBoxClients, item.IDClient);
                SelCB(comboBoxReqStatus, item.ReqStatusID);
                SelCB(comboBoxReqPriority, item.PriorityID);
                SelCB(comboBoxCurrency, item.CurrencyID);
                dateTimePickerDel.Value = item.DateDelivery;
                SelCB(comboBoxWarehouse, item.WarehouseID);
                SelCB(comboBoxTypePay, item.PaymentID);
                textBoxDisc.Text = item.Discount.ToString(CultureInfo.InvariantCulture);
                textBoxNote.Text = item.Note;
                SelCB(comboBoxPoints, item.IDClientPoint);
            }
            finally
            {
                listView1.EndUpdate();
            }
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
            }
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            bool addFVis = false;

            if (ActiveForm != null)
            {
                if (ActiveForm.MdiChildren.OfType<AddReqForm>().Any())
                {
                    addFVis = true;
                }

                if (!addFVis)
                {
                    var childForm = new AddReqForm {MdiParent = ActiveForm};
                    childForm.Show();
                }
                else
                {
                    MessageBox.Show(Resources.Adding_a_window_is_already_open_orders, Resources.Info, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
        }

        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0) return;

            var item = (ReqClass)listView2.SelectedItems[0].Tag;

            if (MessageBox.Show("Удалить заявку: " + item.DateCreation.ToString("d.MM.yyyy") + " " + item.Name + "?", Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ReqClass.DeleteRecByRecTvID(item.ReqTvID);
                if (ActiveForm != null)
                    foreach (Form control in ActiveForm.MdiChildren)
                    {
                        var uf = control as ReqForm;
                        if (uf != null)
                        {
                            uf.ReqFormLoad(sender, e);
                        }
                    }
            }
        }

        public void AddPay(string Note, DateTime Date, int vpay, double summ)
        {
            var item = (ReqClass)listView2.SelectedItems[0].Tag;

            var pc = new PaymentClass
                         {
                             DatePay = Date,
                             Note = Note,
                             VarPayID = vpay,
                             Summ = summ,
                             IDClient = item.IDClient,
                             ReqTvID = item.ReqTvID
                         };

            pc.Insert();
        }

        private void ToolStripButtonAddVarPayClick(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0) return;

            var addpf = new AddPayForm { MdiParent = ActiveForm, ToPay = reqsum - paysum};
            addpf.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var item = (ReqClass)listView2.SelectedItems[0].Tag;

            item.ReqStatusID = 5;

            item.UpdateStatus();

            LoadList();
        }

     
    }
}
