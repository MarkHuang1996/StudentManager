using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Models;

namespace StudentManager
{
    public partial class FrmUserLogin : Form
    {

        private sysAdminService objSysAdminService = new sysAdminService();


        public FrmUserLogin()
        {
            InitializeComponent();
          
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            ///1 验证不为空
            if (this.txtLoginId.Text.Trim().Length == 0)
            {
                MessageBox.Show("xxxxxxxxxx");
                this.txtLoginId.Focus();
                return;
            }
            if (this.txtLoginPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please entry the Password");
                this.txtLoginPwd.Focus();
                return;
            }

            //2 封装
            sysAdmin objAdmin = new sysAdmin()
            {
                LoginId = Convert.ToInt32(this.txtLoginId.Text.Trim()),
                LoginPwd = this.txtLoginPwd.Text.Trim()

            };

            try
            {
                objSysAdminService.AdminLogin(objAdmin);
                if (objAdmin != null)
                {
                    //save Admin info
                    Program.objCurrentAdmin = objAdmin;
                    //
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("sql connection error!!!");



            }
          


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
