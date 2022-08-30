using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using xTrade.Properties;

namespace xTrade
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void TextBox1Validated(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;

            errorProvider1.SetError(tb, tb.Text != string.Empty ? String.Empty : "Не заполнено.");
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

        private void AddUserFormLoad(object sender, EventArgs e)
        {
            FillCB(UsersClass.GetTypeUser(), comboBoxPol);
            FillCB(UsersClass.GetStatusUser(), comboBoxSt);

            openFileDialog1.FileName = string.Empty;
        }

        private void ComboBox1Validated(object sender, EventArgs e)
        {
            var cb = (ComboBox)sender;

            if ((cb.SelectedIndex > -1) || !cb.Enabled)
            {
                errorProvider1.SetError(cb, String.Empty);
            }
            else
            {
                errorProvider1.SetError(cb, "Не заполнено.");
            }
        }

        private void Button4Click(object sender, EventArgs e)
        {
            Close();
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

            foreach (Control control in groupBox1.Controls)
            {
                if (!(control is TextBox)) continue;

                var tb = (TextBox)control;

                if ((tb.Tag.ToString() == "1"))
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

            if ((String.CompareOrdinal(textBoxPass.Text, textBoxPassR.Text) != 0))
            {
                vilidated = false;
                errorProvider1.SetError(textBoxPass, "Пароли не совпадают");
                errorProvider1.SetError(textBoxPassR, "Пароли не совпадают");
            }
            else
            {
                if ((textBoxPass.Text != string.Empty) && (textBoxPassR.Text != string.Empty))
                {
                    errorProvider1.SetError(textBoxPass, String.Empty);
                    errorProvider1.SetError(textBoxPassR, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBoxPass, "Не заполнено.");
                    errorProvider1.SetError(textBoxPassR, "Не заполнено.");
                }
            }

            if (!vilidated) return;

            var uc = new UsersClass
                         {
                             EMail = textBoxEMail.Text,
                             Telephone = textBoxTel.Text,
                             Name = textBoxName.Text,
                             LastName = textBoxLName.Text,
                             MiddleName = textBoxMName.Text,
                             LoginName = textBoxLogin.Text,
                             Address = textBoxAddress.Text,
                             PassHash = Md5HashClass.GetMd5Hash(textBoxPass.Text),
                             TypeUserID = GetIDFromCB(comboBoxPol),
                             Status = GetIDFromCB(comboBoxSt),
                             ImagePath = openFileDialog1.FileName
                         };


            uc.Insert();

            if (ActiveForm != null)
                foreach (Form control in ActiveForm.MdiChildren)
                {
                    var uf = control as UsersForm;
                    if (uf != null)
                    {
                        uf.UsersFormLoad(sender, e);
                    }
                }

            Close();
        }

        private void Button1Click(object sender, EventArgs e)
        {


            openFileDialog1.Title = Resources.AddUserForm_ButtonOpenImage_OpenImage;
            openFileDialog1.Filter = Resources.AddUserForm_Button1OpenImageType;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackgroundImage = new Bitmap(openFileDialog1.OpenFile());
            }

            openFileDialog1.Dispose();
        }
    }
}
