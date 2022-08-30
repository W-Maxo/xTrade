using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using xTrade.Properties;

namespace xTrade
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        public void UsersFormLoad(object sender, EventArgs e)
        {
            listView2.BeginUpdate();
            try
            {
                listView2.Items.Clear();

                int indx = 1;

                foreach (UsersClass item in UsersClass.GetUserList())
                {
                    var col = new[]
                                       {
                                           indx++.ToString(CultureInfo.InvariantCulture),
                                           item.Name,
                                           item.LastName,
                                           item.MiddleName,
                                           item.LoginName,
                                           item.TypeStr,
                                           item.StatusStr
                                       };

                    var d = new ListViewItem(col, 1) {Tag = item};

                    try
                    {
                        listView2.Items.Add(d);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            finally
            {
                listView2.EndUpdate();
            }
        }

        private void ListView2SelectedIndexChanged(object sender, EventArgs e)
        {
            if (0 == listView2.SelectedItems.Count) return;

            var item = (UsersClass)listView2.SelectedItems[0].Tag;

            textBox1.Text = item.Telephone;
            textBox2.Text = item.EMail;
            textBox3.Text = item.Address;

            pictureBox1.BackgroundImage = item.MStream != null ? Image.FromStream(item.MStream) : Resources.user_2_avatar1;

            var pf = (MainFormMdi)ActiveForm;
            if (pf != null && (pf.CurrUssID != item.UserID && pf.CUss.AllowUseMnqm)) toolStripButtonRemove.Enabled = true;
            else toolStripButtonRemove.Enabled = false;

        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            bool addFVis = false;

            if (ActiveForm != null)
            {
                if (ActiveForm.MdiChildren.OfType<AddUserForm>().Any())
                {
                    addFVis = true;
                }

                if (!addFVis)
                {
                    var childForm = new AddUserForm {MdiParent = ActiveForm};
                    childForm.Show();
                }
                else
                {
                    MessageBox.Show(Resources.Adding_a_window_is_already_open_orders, Resources.Info, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
        }

        private void ToolStripButtonRemoveClick(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0) return;

            var item = (UsersClass)listView2.SelectedItems[0].Tag;

            if (MessageBox.Show(string.Format("{0}  {1} ({2})?", Resources.Delete_User + item.Name, item.LastName, item.LoginName), Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UsersClass.Delete(item.UserID);

                if (ActiveForm != null)
                    foreach (Form control in ActiveForm.MdiChildren)
                    {
                        var uf = control as UsersForm;
                        if (uf != null)
                        {
                            uf.UsersFormLoad(sender, e);
                        }
                    }
            }
        }

        private void PictureBox1Click(object sender, EventArgs e)
        {

        }
    }
}
