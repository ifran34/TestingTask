using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;
using System.Data.OleDb;
using System.Configuration;
using System.Diagnostics;

namespace TestingTask
{

    public class TELReg
    {
        private string _sKeyValue;
        private string _sKeyName;
        private string _sSubKeyName;

        public TELReg(string sRegKeyName, string sRegSubKeyName)
        {
            _sKeyName = sRegKeyName;
            _sSubKeyName = sRegSubKeyName;
            this.GetSetting();
        }

        ~TELReg()
        {
            this.SaveSetting();
        }

        public string KeyValue
        {
            get { return _sKeyValue; }
            set { _sKeyValue = value; }

        }

        public void SaveSetting()
        {
            RegistryKey oKey = Registry.CurrentUser.CreateSubKey(_sKeyName);
            oKey.SetValue(_sSubKeyName, _sKeyValue);
        }

        public void DeleteSetting()
        {
            RegistryKey oKey = Registry.CurrentUser;
            oKey.OpenSubKey(_sKeyName);
            oKey.DeleteSubKey(_sKeyName);
        }

        public void GetSetting()
        {
            RegistryKey oRegKey = Registry.CurrentUser;

            try
            {
                oRegKey = oRegKey.OpenSubKey(_sKeyName);
                object oValue = oRegKey.GetValue(_sSubKeyName);
                _sKeyValue = Convert.ToString(oValue);
            }
            catch { _sKeyValue = ""; }
        }
    }

    public class DBController
    {

        // following two statics are for singleton (not for this class context)
        private static volatile DBController instance = null;
        private static object syncRoot = new Object();
        public static OleDbConnection _conn;
        public static OleDbTransaction _tran;

        public DBController()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DBController Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DBController();
                        }
                    }
                }
                return instance;
            }
        }

        public OleDbConnection getNewConnection()
        {
            string connStr;
            connStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            //Debug.Assert(connStr.Length != 0, "Connection string is zero length");
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = connStr;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return conn;
        }

        /// <summary>
        /// opens a new connection ( not transaction )
        /// </summary>
        public bool OpenNewConnection()
        {
            try
            {

                OleDbConnection conn = getNewConnection();
                _conn = conn;
                return true;
            }
            catch (Exception e)
            {
                throw e;
                //AppLogger.LogFatal("Databse connection close or permisssion problem");
                //return false;
            }
        }

        /// <summary>
        /// close the connection (not a transaction )
        /// </summary>
        /// <param name="connectionID"></param>
        /// <returns>returns false if failes, else returns true</returns>
        public bool CloseConnection()
        {
            if (_conn == null)
            {
                return false;
            }
            _conn.Close();
            return true;

        }  // end of CloseConnection method

        /// <summary>
        /// opens a new connection then starts transaction on that connection
        /// </summary>
        public bool BeginNewTransaction()
        {
            try
            {
                _conn = getNewConnection();
                _tran = _conn.BeginTransaction();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

        }  // end of BeginNewTransaction method

        /// <summary>
        /// commits a transaction
        /// </summary>
        /// <param name="connectionID"></param>
        /// <returns>true if succed, else false</returns>
        public bool CommitTransaction()
        {
            if (_tran == null)
            {
                return false;
            }

            try
            {
                _tran.Commit();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                try
                {
                    _tran.Rollback();

                }
                catch
                {
                    Debug.WriteLine(e.Message);
                }

                return false;
            }
            finally
            {
                _conn.Close();
            }

        }  // end of CommitTransaction method

        /// <summary>
        /// rollback transaction
        /// </summary>
        /// <param name="connectionID"></param>
        /// <returns>true if succeds, else false</returns>
        public bool RollbackTransaction()
        {
            if (_tran == null)
            {
                return false;
            }

            try
            {
                _tran.Rollback();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            finally
            {
                _conn.Close();
            }

        }  // end of RollbackTransaction

        public OleDbCommand GetCommand()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = _conn;
            cmd.Transaction = _tran;
            return cmd;
        }


        public bool CommitTran()
        {
            if (_tran == null)
            {
                return false;
            }

            try
            {
                _tran.Commit();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                try
                {
                    _tran.Rollback();

                }
                catch
                {
                    Debug.WriteLine(e.Message);
                }

                return false;
            }

        }
    }

    public class Utility
    {
        private static int _nUserId;

        private static string _sUsername;
        private static string _sUserFullname;
        private static int _nEmployeeID;

        public static int UserId
        {
            get { return _nUserId; }
            set { _nUserId = value; }
        }

        public static string Username
        {
            get { return _sUsername; }
            set { _sUsername = value; }
        }

        public static string UserFullname
        {
            get { return _sUserFullname; }
            set { _sUserFullname = value; }
        }
        public static int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }
    }
}
