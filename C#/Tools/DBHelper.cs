using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Tools
{
    /// <summary>
    /// 数据库操作的类
    /// </summary>
    public class DBHelper
    {


        private static string DBName = RWAppConfig.ReadAppconfig("DBName");
        private static string DBURL = RWAppConfig.ReadAppconfig("DBURL");
        private static string DBUser = RWAppConfig.ReadAppconfig("DBUser");
        private static string DBPassword = RWAppConfig.ReadAppconfig("DBPassword");

        private static string connstr="Initial Catalog = "+DBName+";Data Source="+DBURL+";User ID="+DBUser+";Password="+DBPassword;

        /// <summary>
        /// 从数据库里获得数据
        /// </summary>
        /// <param name="sqlstr">sql语句</param>
        /// <returns>返回结果DataSet;出错则返回null</returns>
        public static DataSet GetData(string sqlstr, out int returncode,out Exception sql_err)
        {
            DataSet ds = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connstr))
                {

                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sqlstr, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    returncode = ds.Tables[0].Rows.Count;
                    sql_err = null;
                }
            }
            catch (Exception e)
            {
                returncode = -1;
                sql_err = e;
                return null;
            }

            return ds;

        }


        /// <summary>
        /// 执行insert,update类型的sql语句
        /// </summary>
        /// <param name="sqlstr">sql语句</param>
        /// <returns>0-执行正确;-1-出错</returns>
        public static int RunSqlCommand(string sqlstr)
        {
        
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                SqlCommand sc = conn.CreateCommand();
                sc.CommandText = sqlstr;
                conn.Open();
                //建立事务
                SqlTransaction st = conn.BeginTransaction();
                sc.Transaction = st;
                try
                {
                    sc.ExecuteNonQuery();
                    st.Commit();
                    conn.Close();
                }
                catch (Exception)
                {
                    st.Rollback();
                    conn.Close();
                    return -1;
                }

            }

            return 0;
           
        }

        public static string GetMc(string bhbm, string bh, out int returncode)
        {
            string mc = "";
            string sql = "select mc from " + bhbm + " where bh = " + bh;
            returncode = 0;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                SqlCommand sqlcmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    mc = sqlcmd.ExecuteScalar().ToString();
                }
                catch (Exception)
                {
                    returncode = -1;
                    return "";
                }
            }
            returncode = 0;
            return mc;

        }

        public static int GetBh(string bhbm, string mc, out int returncode)
        {
            int bh = 0;
            string sql = "select mc from " + bhbm + " where trim(mc) = '" + mc.Trim() + "'";
            returncode = 0;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                SqlCommand sqlcmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    bh = Convert.ToInt32(sqlcmd.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                    returncode = -1;
                    return 0;
                }
            }
            returncode = 0;
            return bh;

        }


    }
}
