using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace ExaminationCore
{
    public static class DBhelper
    {
        public static string con = ManagerJson.GetSectionValue("sqlcon");
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable get(string sql)
        {
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        /// <summary>
        /// 增、删、改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool ex(string sql)
        {
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand com = new SqlCommand(sql, conn);
            int i = com.ExecuteNonQuery();
            conn.Close();

            return i > 0;
        }
        /// <summary>
        /// 链接查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader Reade(string sql)
        {
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader Read = com.ExecuteReader();
            return Read;

        }
    }
}