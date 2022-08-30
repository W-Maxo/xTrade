using System;
using System.Linq;
using System.Windows.Forms;
using xTrade.Properties;

namespace xTrade
{
    public partial class MainFormMdi : Form
    {
        public int CurrUssID;
        public UsersClass CUss;

        public NotifiClass Nc;

        public void LoginOn(int ussId)
        {
            menuStrip.Visible = true;
            toolStrip.Visible = true;
            statusStrip.Visible = true;

            CurrUssID = ussId;

            CUss = UsersClass.GetUserByUserID(ussId);

            foreach (Control ctl in Controls)
            {
                try
                {
                    var ctlMDI = (MdiClient)ctl;

                    ctlMDI.Invalidate();
                }
                catch (InvalidCastException)
                {
                  
                }
            }

            if (CUss.AllowAddreq)
            {
                toolStripButtonAdd.Enabled = true;
                ToolStripMenuItemAddReq.Enabled = true;
            }
            else
            {
                toolStripButtonAdd.Enabled = false;
                ToolStripMenuItemAddReq.Enabled = false;
            }

            toolStripButtonMngUss.Enabled = CUss.AllowUseMnqm;

            Nc   = new NotifiClass();
            Nc.SampleEvent +=NcSampleEvent;
        }

        private void NcSampleEvent(object sender, SampleEventArgs e)
        {
            foreach (Form frm in MdiChildren)
            {
                try
                {
                    if (frm as ReqForm != null)
                    {
                        var rf = (ReqForm) frm;


                        if (InvokeRequired)
                        {
                            Invoke(new DelegateUpdReqW(UpdReqW), rf);
                        }
                        else UpdReqW(rf);
                        
                    }
                }
                catch (InvalidCastException)
                {

                }
            }
        }

        private delegate void DelegateUpdReqW(ReqForm value);
        private void UpdReqW(ReqForm value)
        {
            value.LoadList();
        }

        private int _childFormNumber;

        public MainFormMdi()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            var childForm = new Form {MdiParent = this, Text = "Window " + _childFormNumber++};
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void CutToolStripMenuItemClick(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItemClick(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItemClick(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItemClick(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItemClick(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItemClick(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItemClick(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItemClick(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItemClick(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItemClick(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            //CatalogsForm childForm = new CatalogsForm();
            //childForm.MdiParent = this;
            //childForm.Text = "Catalog Window " + childFormNumber++;
            //childForm.Show();
        }

        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            var childForm = new ManageData {MdiParent = this, Text = "Catalog Window " + _childFormNumber++};
            childForm.Show();
        }

        private void MainFormMDILoad(object sender, EventArgs e)
        {
            menuStrip.Visible = false;
            toolStrip.Visible = false;
            statusStrip.Visible = false;

            foreach (Control ctl in Controls)
            {
                try
                {
                    var ctlMDI = (MdiClient)ctl;

                    ctlMDI.BackColor = System.Drawing.Color.FromArgb(8, 3, 0);

                    ctlMDI.BackgroundImage = Resources.splash00;
                    ctlMDI.BackgroundImageLayout = ImageLayout.Zoom;

                    ctlMDI.Invalidate();
                }
                catch (InvalidCastException)
                {

                }
            }

            var lf = new LoginForm {MdiParent = this, StartPosition = FormStartPosition.CenterScreen};
            lf.Show();
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            var aboutForm = new AboutBox1();

            aboutForm.ShowDialog();
        }

        private void ToolStripStatusLabelClick(object sender, EventArgs e)
        {

        }

        private void MainFormMDIClientSizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in Controls)
            {
                try
                {
                    var ctlMDI = (MdiClient)ctl;

                    ctlMDI.Invalidate();
                }
                catch (InvalidCastException)
                {

                }
            }
        }

        private void ТоварыToolStripMenuItemClick(object sender, EventArgs e)
        {
            var childForm = new FormProd {MdiParent = this};
            childForm.Show();
        }

        private void ToolStripButton4Click(object sender, EventArgs e)
        {
            bool addFVis = ActiveForm != null && ActiveForm.MdiChildren.OfType<AddReqForm>().Any();

            if (!addFVis)
            {
                var childForm = new AddReqForm {MdiParent = this};
                childForm.Show();
            }
            else
            {
                MessageBox.Show(Resources.Adding_a_window_is_already_open_orders, Resources.Info, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
         }

        private void ЗаToolStripMenuItemClick(object sender, EventArgs e)
        {
            var childForm = new ReqForm {MdiParent = this};
            childForm.Show();
        }

        private void ToolStripButton6Click(object sender, EventArgs e)
        {
            var uf = new UsersForm {MdiParent = this};
            uf.Show();    
        }

        private void MainFormMDIFormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(Resources.Finish_the_job, Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void ToolStripButton8Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripButton4Click1(object sender, EventArgs e)
        {
            var cf = new ClientsForm {MdiParent = this};
            cf.Show();
        }
    }
}
