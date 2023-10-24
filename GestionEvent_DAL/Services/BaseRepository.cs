using GestionEvent_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services
{
    public abstract  class BaseRepository<T> : IBaseRepository<T> 
    {
        protected abstract string _tableName {
            get;
        }
        protected readonly SqlConnection _connection;
            public BaseRepository(SqlConnection sqlconn)
        {
            _connection = sqlconn;
        }

        public virtual bool Delete(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"delete  from {_tableName} where Id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                _connection.Open();
                int row = cmd.ExecuteNonQuery();
                _connection.Close();
                if(row > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public virtual List<T> GetAll()
        {
            List<T> list = new List<T>();
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"select * from {_tableName}";

                _connection.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(mapper(reader));
                    }
                }
                _connection.Close();
            }
            return list;
        }

        public virtual T  GetById(int id)
        {
            T entity = default(T);
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"select * from {_tableName} where Id = @id";
                cmd.Parameters.AddWithValue("id",id);
                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entity = mapper(reader);
                    }
                }
                _connection.Close();
            }
            return entity;
        }

        public abstract T mapper(SqlDataReader reader);
      
    }

 
}
