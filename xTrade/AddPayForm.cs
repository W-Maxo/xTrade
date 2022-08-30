using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace xTrade
{
    public partial class AddPayForm : Form
    {
        public double ToPay;

        public AddPayForm()
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

        private void Button2Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddPayFormLoad(object sender, EventArgs e)
        {
            FillCB(InfoClass.GetReqVarPaymentList(), comboBoxVarPay);

            textBoxSumm.Text  =ToPay.ToString(CultureInfo.InvariantCulture);
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

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                foreach (Form control in MdiParent.MdiChildren)
                {
                    var rf = control as ReqForm;
                    if (rf != null)
                    {
                        rf.AddPay(textBoxNote.Text, dateTimePickerPay.Value, GetIDFromCB(comboBoxVarPay), double.Parse(textBoxSumm.Text));

                        rf.LoadList();

                        Close();
                    }
                }
        }
    }
}
