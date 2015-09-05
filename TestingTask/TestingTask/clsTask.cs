using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;

using System.Collections;

using System.Data.OleDb;

namespace TestingTask
{
    /// <summary>
    /// Summary description for Task
    /// </summary>
    public class Task
    {
        public Task()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    
        private int _nTaskID;
        private string _sTaskCode;
        private string _sTaskDescription;
        private DateTime _dTaskDate;
        private string _sTaskStatus;
        private string _sRemarks;
        //private DateTime _dAdmissionDate;
        public int TaskID
        {
            get { return _nTaskID; }
            set { _nTaskID = value; }
        }

        public string TaskCode
        {
            get { return _sTaskCode; }
            set { _sTaskCode = value; }
        }

        public string TaskDescription
        {
            get { return _sTaskDescription; }
            set { _sTaskDescription = value; }
        }

        public DateTime TaskDate
        {
            get { return _dTaskDate; }
            set { _dTaskDate = value; }
        }


        public string TaskStatus
        {
            get { return _sTaskStatus; }
            set { _sTaskStatus = value; }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }


        public void Add()
        {
            int nMaxTaskID = 0;
            OleDbCommand myCmd = DBController.Instance.GetCommand();

            try
            {
                //myConnection.Open();
                string sSql = "";

                if (_nTaskID == 0)
                {

                    sSql = "SELECT MAX([TaskID]) FROM t_Task";
                    myCmd.CommandText = sSql;
                    object maxID = myCmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxTaskID = 1;
                    }
                    else
                    {
                        nMaxTaskID = Convert.ToInt32(maxID) + 1;
                    }
                    _nTaskID = nMaxTaskID;
                }

                sSql = "INSERT INTO t_Task VALUES(?,?,?,?,?,?)";
                myCmd.CommandText = sSql;
                myCmd.CommandType = CommandType.Text;
                myCmd.Parameters.AddWithValue("TaskID", _nTaskID);
                myCmd.Parameters.AddWithValue("TaskCode", _sTaskCode);
                myCmd.Parameters.AddWithValue("TaskDescription", _sTaskDescription);
                myCmd.Parameters.AddWithValue("TaskDate", _dTaskDate);
                myCmd.Parameters.AddWithValue("TaskStatus", _sTaskStatus);
                myCmd.Parameters.AddWithValue("Remarks", _sRemarks);
               
                myCmd.ExecuteNonQuery();
                myCmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Edit()
        {

            OleDbCommand myCmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                //myConnection.Open();

                sSql = "UPDATE t_Task SET TaskCode=?, TaskDescription=?, TaskDate=?, TaskStatus=?, Remarks=?"
                    + " WHERE TaskID=?";
                myCmd.CommandText = sSql;
                myCmd.CommandType = CommandType.Text;
                myCmd.Parameters.AddWithValue("TaskCode", _sTaskCode);
                myCmd.Parameters.AddWithValue("TaskDescription", _sTaskDescription);
                myCmd.Parameters.AddWithValue("TaskDate", _dTaskDate);
                myCmd.Parameters.AddWithValue("TaskStatus", _sTaskStatus);
                myCmd.Parameters.AddWithValue("Remarks", _sRemarks);
                myCmd.Parameters.AddWithValue("TaskID", _nTaskID);

                myCmd.ExecuteNonQuery();

                //int i =Convert.ToInt32(sSql);
                myCmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_Task WHERE [TaskID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TaskID", _nTaskID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }

        public class Tasks : CollectionBase
        {
            public Task this[int i]
            {
                get { return (Task)InnerList[i]; }
                set { InnerList[i] = value; }
            }

            public int GetIndex(int nTaskID)
            {
                int i;
                for (i = 0; i < this.Count; i++)
                {
                    if (this[i].TaskID == nTaskID)
                    {
                        return i;
                    }
                }
                return -1;
            }



            public void Refresh()
            {
                InnerList.Clear();
                OleDbCommand myCmd = DBController.Instance.GetCommand();
                string sSql = "";


                try
                {
                    sSql = "SELECT * FROM t_Task";
                    myCmd.CommandText = sSql;
                    myCmd.CommandType = CommandType.Text;
                    IDataReader reader = myCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Task oTask = new Task();

                        oTask.TaskID = (int)reader["TaskID"];
                        oTask.TaskCode = (string)reader["TaskCode"];
                        oTask.TaskDescription = (string)reader["TaskDescription"];
                        oTask.TaskDate = (DateTime)reader["TaskDate"];
                        oTask.TaskStatus = (string)reader["TaskStatus"];
                        oTask.Remarks = (string)reader["Remarks"];

                        InnerList.Add(oTask);
                    }
                    reader.Close();
                    InnerList.TrimToSize();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
        }
}
