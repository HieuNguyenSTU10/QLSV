using System;
using System.Windows.Forms;

namespace Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();

            if (frmLogin.user.Id != "")
            {
                mnuLogin.Visible = false;
                mnuLogout.Visible = true;
            }
            if (frmLogin.user.Role == "Admin")
            {
                mnuManageStu.Enabled = true;
                mnuManagerUser.Enabled = true;
            }
            else
            {
                mnuManageStu.Enabled = false;
            }
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            mnuLogin.Visible = true;
            mnuLogout.Visible = false;
            //FrmLogin frmLogin = new FrmLogin();
            //frmLogin.user = new User("", "", "", "");
            MessageBox.Show("Đăng xuất thành công", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void mnuManagerUser_Click(object sender, EventArgs e)
        {
            frmUser fu = new frmUser();
            fu.ShowDialog();
        }
    }
}
