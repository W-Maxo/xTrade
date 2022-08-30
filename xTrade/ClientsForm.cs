using System;
using System.Windows.Forms;

namespace xTrade
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
        }

        public void ClientsForm_Load(object sender, EventArgs e)
        {
            listView2.BeginUpdate();
            listView2.Items.Clear();

            int indx = 1;

            foreach (IntStr item in ClientsClass.GetClTypes())
            {
                string[] col = new string[] 
                {
                    indx++.ToString(), item.ItemContent
                };

                ListViewItem d = new ListViewItem(col, 1);
                d.Tag = item.ID;

                listView2.Items.Add(d);
            }

            listView2.EndUpdate();
        }

        public void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indx = 1;

            if (listView2.SelectedItems.Count == 0) return;

            int ItemIndx = (int)listView2.SelectedItems[0].Tag;

            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (ClientsClass item in ClientsClass.GetClByTypesID(ItemIndx))
            {
                string[] col = new string[] 
                {
                    indx++.ToString(),
                    item.ClientName,
                    item.Balance.ToString(),
                };

                ListViewItem d = new ListViewItem(col, 1);
                d.Tag = item;

                listView1.Items.Add(d);
            }

            listView1.EndUpdate();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ClientViewForm


        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            bool AddFVis = false;

            foreach (Form control in MainFormMdi.ActiveForm.MdiChildren)
            {
                if (control is ClientViewForm)
                {
                    AddFVis = true;
                    break;
                }
            }

            if (!AddFVis)
            {
                int indx = 1;

                if (listView1.SelectedItems.Count == 0) return;

                ClientViewForm cvf = new ClientViewForm();


                cvf.Inf = (ClientsClass)listView1.SelectedItems[0].Tag;


                cvf.MdiParent = MainFormMdi.ActiveForm;
                cvf.Show();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bool AddFVis = false;

            foreach (Form control in MainFormMdi.ActiveForm.MdiChildren)
            {
                if (control is ClientViewForm)
                {
                    AddFVis = true;
                    break;
                }
            }

            if (!AddFVis)
            {
                int indx = 1;


                if (listView2.SelectedItems.Count == 0) return;

                int ItemIndx = (int)listView2.SelectedItems[0].Tag;

                ClientViewForm cvf = new ClientViewForm();


                cvf.XClTypeIDType = ItemIndx;

                cvf.MdiParent = MainFormMdi.ActiveForm;
                cvf.Show();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            bool AddFVis = false;

            foreach (Form control in MainFormMdi.ActiveForm.MdiChildren)
            {
                if (control is ClTypeAddForm)
                {
                    AddFVis = true;
                    break;
                }
            }

            if (!AddFVis)
            {
                int indx = 1;

                ClTypeAddForm cvf = new ClTypeAddForm();

                cvf.MdiParent = MainFormMdi.ActiveForm;
                cvf.Show();
            }
        }
    }
}
