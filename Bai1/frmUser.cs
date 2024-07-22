using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bai1
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
            displayUser();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool kt = false;
            if (txtID.Text.Trim() == "" || txtUser.Text.Trim() == "" || txtPass.Text.Trim() == "")
            {
                MessageBox.Show("(*) là bắt buộc. Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sqlCnn.Open();
            foreach (ListViewItem item in lsvUser.Items)
            {
                if (item.SubItems[0].Text == txtID.Text)
                {
                    kt = true;
                    //MessageBox.Show("Mã số đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (txtID.Enabled == true && kt == false)
            {
                sqlCmd.CommandText = "INSERT INTO Users VALUES" +
                    "('" + txtID.Text + "','" + txtUser.Text + "','" +
                    txtPass.Text + "','" + cbRole.Text + "','" + txtFullName.Text + "')";

            }
            else
            {
                sqlCmd.CommandText = "UPDATE Users SET username = '" + txtUser.Text + "', password = '" + txtPass.Text + "', fullname = '" +
                    txtFullName.Text + "', role = '" + cbRole.Text + "' WHERE id = '" + txtID.Text + "'";
                txtID.Enabled = true;
            }
            txtID.Text = "";
            txtUser.Text = "";
            txtPass.Text = "";
            txtFullName.Text = "";
            cbRole.Text = "User";
            sqlCmd.ExecuteNonQuery();
            sqlCnn.Close();
            displayUser();
        }

        private void lsvUser_DoubleClick(object sender, EventArgs e)
        {
            if (lsvUser.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("please select an user to modify");
                return;
            }

            int i = lsvUser.SelectedIndices[0];
            ListViewItem lvl = lsvUser.Items[i];
            txtID.Text = lvl.SubItems[0].Text;
            txtUser.Text = lvl.SubItems[1].Text;
            txtPass.Text = lvl.SubItems[2].Text;
            txtFullName.Text = lvl.SubItems[3].Text;
            cbRole.Text = lvl.SubItems[4].Text;
            txtID.Enabled = false;
        }

        private void displayUser(string name = "")
        {
            lsvUser.Items.Clear();
            sqlCnn.Open();
            sqlCmd.CommandText = "SELECT * FROM Users";
            if (name != "")
            {
                sqlCmd.CommandText = "SELECT * FROM Users WHERE username LIKE '%" + name + "%'";
            }
            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                ListViewItem lvl = new ListViewItem(sqlDataReader["Id"].ToString());
                lvl.SubItems.Add(sqlDataReader["Username"].ToString());
                lvl.SubItems.Add(sqlDataReader["Password"].ToString());
                lvl.SubItems.Add(sqlDataReader["Fullname"].ToString());
                lvl.SubItems.Add(sqlDataReader["Role"].ToString());
                lsvUser.Items.Add(lvl);
            }
            sqlCnn.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string idxoa = lsvUser.SelectedItems[0].Text;
            //MessageBox.Show(idxoa);
            sqlCnn.Open();
            sqlCmd.CommandText = "DELETE FROM Users WHERE id = '" + idxoa + "'";
            sqlCmd.ExecuteNonQuery();
            sqlCnn.Close();
            displayUser();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            displayUser(txtSearch.Text.Trim());
        }
    }
}
