using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace xTrade
{
    public partial class FormProd : Form
    {
        public int CCurr;

        public FormProd()
        {
            InitializeComponent();
        }

        private void FillCBST(IEnumerable<IntStr> istr, ToolStripComboBox cb)
        {
            cb.Items.Clear();

            foreach (IntStr rs in istr)
            {
                cb.Items.Add(new NameObjectMap(rs.ItemContent, rs.ID));
            }
        }

        private int GetIDFromCBST(ToolStripComboBox cb)
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

        private void FormProdLoad(object sender, EventArgs e)
        {

            listView2.BeginUpdate();
            listView2.Items.Clear();
            
            int indx = 1;

            foreach (TypePr item in TypePr.GetAllType())
            {
                var col = new[] 
                {
                    indx++.ToString(CultureInfo.InvariantCulture), item.Name
                };

                var d = new ListViewItem(col, 1) {Tag = item.TypeID};

                listView2.Items.Add(d);
            }

            listView2.EndUpdate();

            FillCBST(InfoClass.GetCurrencyList(), comboBoxCurrencyPf);

            if (comboBoxCurrencyPf.Items.Count != 0) comboBoxCurrencyPf.SelectedIndex = CCurr;
        }

        private void ListView2SelectedIndexChanged(object sender, EventArgs e)
        {
            int indx = 1;

            if (listView2.SelectedItems.Count == 0) return;

            var itemIndx = (int)listView2.SelectedItems[0].Tag;

            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (ProduceClass item in ProduceClass.GetTovarsByTypeEx(itemIndx, GetIDFromCBST(comboBoxCurrencyPf)))
            {
                var col = new[] 
                {
                    indx++.ToString(CultureInfo.InvariantCulture),
                    item.Name,
                    item.Remains.ToString(CultureInfo.InvariantCulture),
                    item.NimP.ToString(CultureInfo.InvariantCulture),
                    item.Cost1.ToString(CultureInfo.InvariantCulture)
                };

                var d = new ListViewItem(col, 1) {Tag = item.TvID};

                listView1.Items.Add(d);
            }

            listView1.EndUpdate();
        }

        private void ListView1SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void ListView1DoubleClick(object sender, EventArgs e)
        {
            bool addFVis = false;

            if (ActiveForm != null)
            {
                if (ActiveForm.MdiChildren.OfType<AddReqForm>().Any())
                {
                    addFVis = true;
                }

                if (addFVis)
                {
                    if (listView1.SelectedItems.Count == 0) return;

                    var tvF = new AddTvForm
                                  {
                                      textBox1 =
                                          {
                                              Text =
                                                  listView1.SelectedItems[0].SubItems[1].Text.ToString(
                                                      CultureInfo.InvariantCulture)
                                          },
                                      Id = (int) listView1.SelectedItems[0].Tag,
                                      TvFName =
                                          listView1.SelectedItems[0].SubItems[1].Text.ToString(CultureInfo.InvariantCulture),
                                      Cost1 =
                                          double.Parse(
                                              listView1.SelectedItems[0].SubItems[4].Text.ToString(
                                                  CultureInfo.InvariantCulture)),
                                      CurrencyID = GetIDFromCBST(comboBoxCurrencyPf),
                                      MdiParent = ActiveForm
                                  };



                    tvF.Show();
                }
            }
        }

        private void ComboBoxCurrencyPfTextChanged(object sender, EventArgs e)
        {
            if (comboBoxCurrencyPf.SelectedIndex != -1)
                ListView2SelectedIndexChanged(sender, e);
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

                    childForm.comboBoxCurrency.SelectedIndex = comboBoxCurrencyPf.SelectedIndex;
                    childForm.comboBoxCurrency.Enabled = false;
                    comboBoxCurrencyPf.Enabled = false;
                }
            }

            ListView1DoubleClick(sender, e);
        }
    }
}
