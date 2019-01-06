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
        private StudentService objStudentService = new StudentService();
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

            #region 封装new Student

            Student objstudent = new Student()
            {
                FirstName = this.txtFName.Text.Trim(),
                LastName = this.txtLName.Text.Trim(),
                Gender = rdoMale.Checked ? "Male" : "Female",
                Birthday = Convert.ToDateTime(this.dateTimePicker1.Text),
                Age =Convert.ToInt32( DateTime.Now.Year - Convert.ToDateTime(this.dateTimePicker1.Text).Year),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                Address = this.txtAddress.Text.Trim(),
                ClassId = Convert.ToInt32(this.cboClassName.SelectedValue)
              

            };



            #endregion

            #region Call the backend code the add the student object

            try
            {
                if(objStudentService.AddStudent(objstudent) == 1)
                {
                    DialogResult result = MessageBox.Show("Suceessfull add  the new Student,want to add other student?","Suceess",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        this.cboClassName.SelectedIndex = -1;
                        this.rdoFemale.Checked = false;
                        this.rdoMale.Checked = false;
                        this.dateTimePicker1.Value = DateTime.Today;

                        foreach (Control item in this.Controls)
                        {
                             if(item is TextBox)
                            {
                                item.Text = "";
                            }
                            this.txtFName.Focus();
                        }
                    }
                    else
                    {
                        this.Close();
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
            #endregion
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}