using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestingTask
{
    public partial class frmTask : Form
    {
        public frmTask()
        {
            InitializeComponent();
            cmbTaskStatus.Items.Add("Working");
            cmbTaskStatus.Items.Add("Done");
        }

        private void frmTask_Load(object sender, EventArgs e)
        {

        }

        public void ShowDialog(Task oTask)
        {
            txtTaskCode.Text = oTask.TaskCode;
            txtTaskDescription.Text = oTask.TaskDescription;
            dtpTaskDate.Value = oTask.TaskDate;
            cmbTaskStatus.Text = oTask.TaskStatus;
            txtRemarks.Text = oTask.Remarks;


            this.Tag = oTask;
            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                      
            Task oTask;
            if (this.Tag == null)
            {
                oTask = new Task();
                oTask.TaskCode = txtTaskCode.Text;
                oTask.TaskDescription = txtTaskDescription.Text;
                oTask.TaskDate = dtpTaskDate.Value;
                oTask.TaskStatus = cmbTaskStatus.Text;
                oTask.Remarks = txtRemarks.Text;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oTask.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Task : " + oTask.TaskCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                oTask = (Task)this.Tag;
                oTask.TaskCode = txtTaskCode.Text;
                oTask.TaskDescription = txtTaskDescription.Text;
                oTask.TaskDate = dtpTaskDate.Value;
                oTask.TaskStatus = cmbTaskStatus.Text;
                oTask.Remarks = txtRemarks.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oTask.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update the Task: " + oTask.TaskCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

            this.Close();
        }
    }
}
