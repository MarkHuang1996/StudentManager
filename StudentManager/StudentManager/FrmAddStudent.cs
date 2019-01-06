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
    public partial class FrmAddStudent : Form
    {
        private StudentCourseService objStudentCourseService = new StudentCourseService();
        public FrmAddStudent()
        {
            InitializeComponent();
            this.cboClassName.DataSource = objStudentCourseService.GetAllCourse();
            this.cboClassName.DisplayMember = "ClassName";//
            this.cboClassName.ValueMember = "ClassId";//
            this.cboClassName.SelectedIndex = -1; ////
        }

        private void FrmAddStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.objFrmAddStudent = null; //when close the windows 
        }

        private void FrmAddStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region Data Validate
            if (this.txtFName.Text.Trim().Length == 0)
            {
                MessageBox.Show("entry Fname!");
                this.txtFName.Focus();
                return;
            }

            if (!this.rdoFemale.Checked && !this.rdoMale.Checked)
            {
                MessageBox.Show("select the gender!!!!!!");
                return;
            }
            if (this.cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("Select the StudentClass !!");
                this.cboClassName.Focus();
                return;
            }

                #endregion
            }
        }
    }
