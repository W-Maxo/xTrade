using System;
using System.Windows.Forms;

namespace xTrade
{
    public partial class ClTypeAddForm : Form
    {
        public ClTypeAddForm()
        {
            InitializeComponent();
        }

        private void Button2Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {

            if (textBox1.Text != string.Empty)
            {
                errorProvider1.SetError(textBox1, String.Empty);

                ClientsClass.InsertClType(textBox1.Text);

                if (ActiveForm != null)
                    foreach (Form control in ActiveForm.MdiChildren)
                    {
                        var cf = control as ClientsForm;
                        if (cf != null)
                        {
                            cf.ClientsForm_Load(sender, e);
                        }
                    }

                Close();
            }
            else
            {
                errorProvider1.SetError(textBox1, "Не заполнено.");
            }
            
        }

        private void ClTypeAddFormLoad(object sender, EventArgs e)
        {

        }
    }
}
