using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class FrmMain : Form
    {


        public static FrmAddStudent objFrmAddStudent = null;



        public FrmMain()
        {
            InitializeComponent();

            this.lblCurrentUser.Text = Program.objCurrentAdmin.AdminName + "]";

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void tsbAddStudent_Click(object sender, EventArgs e)
        {
            if (objFrmAddStudent == null)
            {
                objFrmAddStudent = new FrmAddStudent();
                objFrmAddStudent.Show();//show this windows
                
            }
            else
            {
                objFrmAddStudent.Activate();
                objFrmAddStudent.WindowState = FormWindowState.Normal;
            }


        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("You wanna exit the system?","Exit",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result != DialogResult.OK)
            {
                // cancel the formClosing function;
                e.Cancel = true;
            }
        }
    }
}
