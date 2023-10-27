using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestionEvent_DAL.tools
{
    static public class SQLFonction
    {


        static public List<dynamic> getList(SqlConnection conn,string sql,Func<SqlDataReader, dynamic> fn, SqlParameter[] parameter = default) {
            List<dynamic> list = new List<dynamic>();

            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (parameter != null)
                {
                    cmd.Parameters.AddRange(parameter);

                }

                conn.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while( reader.Read())
                    {
                       list.Add(fn(reader));
                    }
                }

                conn.Close();
            }
            return list;
        
        
        }

        static public dynamic getOne(SqlConnection conn, string sql, Func<SqlDataReader, dynamic> fn, SqlParameter[] parameter = default)
        {
            dynamic element = default;

            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (parameter != null)
                {
                   cmd.Parameters.AddRange(parameter);
                }

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        element = fn(reader); 
                    }
                }

                conn.Close();
            }
            return element;


        }

        static public bool AlterTable(SqlConnection conn, string sql, SqlParameter[] parameter = default)
        {
           

            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (parameter != null)
                {
                    cmd.Parameters.AddRange(parameter);

                }

                try
                {
                    conn.Open();
                    int i =   cmd.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }catch (Exception ex)
                {
                    throw new Exception(ex.Message) ;
                }

              
            }
         


        }


    }
}
