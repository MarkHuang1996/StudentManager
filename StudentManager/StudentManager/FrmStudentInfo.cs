using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace StudentManager
{
    public partial class FrmStudentInfo : Form
    {
        public FrmStudentInfo()
        {
            InitializeComponent();
        }
        public FrmStudentInfo(StudentExt objStudentExt):this()
        {
            this.txtFName.Text = objStudentExt.FirstName;
            this.txtLName.Text = objStudentExt.LastName;
            this.txtCourse.Text = objStudentExt.ClassName;
            this.txtDOB.Text = objStudentExt.Birthday.ToShortDateString();
            this.txtGender.Text = objStudentExt.Gender;
            this.txtNumber.Text = objStudentExt.PhoneNumber;
            this.txtAddress.Text = objStudentExt.Address;

        }
        private void FrmStudentInfo_Load(object sender, EventArgs e)
        {

        }

        private void FrmStudentInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.objFrmStudentManage = null;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
