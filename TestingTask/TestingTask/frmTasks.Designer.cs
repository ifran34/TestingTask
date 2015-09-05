namespace TestingTask
{
    partial class frmTasks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvwTasks = new System.Windows.Forms.ListView();
            this.colTaskCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTaskDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTaskDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTaskStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwTasks
            // 
            this.lvwTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTaskCode,
            this.colTaskDescription,
            this.colTaskDate,
            this.colTaskStatus,
            this.colRemarks});
            this.lvwTasks.FullRowSelect = true;
            this.lvwTasks.GridLines = true;
            this.lvwTasks.Location = new System.Drawing.Point(12, 12);
            this.lvwTasks.Name = "lvwTasks";
            this.lvwTasks.Size = new System.Drawing.Size(605, 287);
            this.lvwTasks.TabIndex = 0;
            this.lvwTasks.UseCompatibleStateImageBehavior = false;
            this.lvwTasks.View = System.Windows.Forms.View.Details;
            // 
            // colTaskCode
            // 
            this.colTaskCode.Text = "Task Code";
            this.colTaskCode.Width = 120;
            // 
            // colTaskDescription
            // 
            this.colTaskDescription.Text = "Task Description";
            this.colTaskDescription.Width = 120;
            // 
            // colTaskDate
            // 
            this.colTaskDate.Text = "Task Date";
            this.colTaskDate.Width = 120;
            // 
            // colTaskStatus
            // 
            this.colTaskStatus.Text = "Task Status";
            this.colTaskStatus.Width = 120;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 120;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(623, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(623, 41);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(623, 70);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 315);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwTasks);
            this.Name = "frmTasks";
            this.Text = "Tasks";
            this.Load += new System.EventHandler(this.frmTasks_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwTasks;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColumnHeader colTaskCode;
        private System.Windows.Forms.ColumnHeader colTaskDescription;
        private System.Windows.Forms.ColumnHeader colTaskDate;
        private System.Windows.Forms.ColumnHeader colTaskStatus;
        private System.Windows.Forms.ColumnHeader colRemarks;
    }
}