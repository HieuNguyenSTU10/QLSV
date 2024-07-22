using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bai1
{
    public partial class FrmLogin : Form
    {
        public User user = new User("", "", "", "", "");
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            sqlCnn.Open();
            sqlCmd.CommandText = "SELECT *  FROM Users Where username = '" + txUser.Text + "' and password= '" + txPass.Text + "'";
            SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
            if (sqlDataReader.Read())
            {
                user.Id = sqlDataReader["Id"].ToString();
                user.Username = sqlDataReader["Username"].ToString();
                user.Pasword = sqlDataReader["Password"].ToString();
                user.Role = sqlDataReader["Role"].ToString();
                user.Fullname = sqlDataReader["Fullname"].ToString();
                MessageBox.Show("Đăng nhập thành công" + user.Role);

            }
            else
            {
                MessageBox.Show("Tài khoản mật khầu không chính xác");
            }
            sqlCnn.Close();
        }
    }
}
