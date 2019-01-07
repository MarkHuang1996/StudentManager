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
using DAL;

namespace StudentManager
{
    public partial class FrmEditStudent : Form
    {
        private StudentCourseService objStudentCourseService = new StudentCourseService();
        private StudentService objStudentService = new StudentService();

        public FrmEditStudent()
        {
            InitializeComponent();
            this.comboBox1.DataSource = objStudentCourseService.GetAllCourse();
            this.comboBox1.DisplayMember = "ClassName";
            this.comboBox1.ValueMember = "ClassId";

        }
        public FrmEditStudent(StudentExt ObjStudentExt) : this()
        {
            this.txtStudentId.Text = ObjStudentExt.StudentId.ToString();
            this.txtFName.Text = ObjStudentExt.FirstName;
            this.txtLName.Text = ObjStudentExt.LastName;
            this.comboBox1.Text = ObjStudentExt.ClassName;
            this.dtpBirthday.Text = ObjStudentExt.Birthday.ToShortDateString();
            if (ObjStudentExt.Gender == "Male") this.rdoMale.Checked = true;
            else this.rdoFemale.Checked = true;
            this.txtNumber.Text = ObjStudentExt.PhoneNumber;
            this.txtAddress.Text = ObjStudentExt.Address;
        }

        private void FrmEditStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            #region validate
            #endregion

            #region 封装学生对象
            Student objstudent = new Student()
            {
                StudentId = Convert.ToInt32(this.txtStudentId.Text.Trim()),
                FirstName = this.txtFName.Text.Trim(),
                LastName = this.txtLName.Text.Trim(),
                Gender = rdoMale.Checked ? "Male" : "Female",
                Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
                Age = Convert.ToInt32(DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year),
                PhoneNumber = this.txtNumber.Text.Trim(),
                Address = this.txtAddress.Text.Trim(),
                ClassId = Convert.ToInt32(this.comboBox1.SelectedValue)
            };
            #endregion

            #region Submit
            try
            {
                if (objStudentService.ModifyStudent(objstudent) == 1)
                {
                    MessageBox.Show("Edited suceessful!");
                    this.Close();
                    this.DialogResult = DialogResult.OK;// return ok
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            #endregion


        }
    }
}
