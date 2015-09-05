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
    public partial class frmTasks : Form
    {
        public frmTasks()
        {
            InitializeComponent();
        }

        private void DataLoadControl()
        {
            Tasks oTasks = new Tasks();
            lvwTasks.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oTasks.Refresh();
            foreach (Task oTask in oTasks)
            {
                ListViewItem oItem = lvwTasks.Items.Add(oTask.TaskCode);
                oItem.SubItems.Add(oTask.TaskDescription);
                oItem.SubItems.Add(oTask.TaskDate.ToString());
                oItem.SubItems.Add(oTask.TaskStatus);
                oItem.SubItems.Add(oTask.Remarks);

                oItem.Tag = oTask;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Task oTask = (Task)lvwTasks.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Do you want to Delete: " + oTask.TaskCode + "?", "Confirm Task Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    oTask.Delete();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                DataLoadControl();
            }


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Task oTask = (Task)lvwTasks.SelectedItems[0].Tag;
            frmTask oForm = new frmTask();
            oForm.ShowDialog(oTask);
            DataLoadControl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTask oForm = new frmTask();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void frmTasks_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}