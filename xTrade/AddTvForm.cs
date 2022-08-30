using System;
using System.Windows.Forms;

namespace xTrade
{
    public partial class AddTvForm : Form
    {
        public int Id;
        public int CurrencyID;
        public string TvFName;
        public double Cost1;

        public AddTvForm()
        {
            InitializeComponent();
        }

        private void Button4Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button3Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                foreach (Form control in ActiveForm.MdiChildren)
                {
                    var af = control as AddReqForm;
                    if (af != null)
                    {
                        af.AddTovarToList(Id, (int)numericUpDown1.Value, CurrencyID, TvFName, Cost1);

                        Close();
                    }
                }
        }
    }
}
