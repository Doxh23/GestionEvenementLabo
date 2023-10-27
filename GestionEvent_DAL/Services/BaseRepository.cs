using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Services.User;
using GestionEvent_DAL.tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services
{
    public abstract  class BaseRepository<T> : IBaseRepository<T>  where T : class , new()
    {
        protected  string _tableName {
            get;set;
        }
        protected readonly SqlConnection _connection;
            public BaseRepository(SqlConnection sqlconn)
        {
            _connection = sqlconn;
            _tableName =  GetType().Name.Split(new string[]{ "DB" }, StringSplitOptions.None)[0];
        }

        public virtual bool Delete(int id)
        {

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            
            return SQLFonction.AlterTable(_connection, $"delete  from {_tableName} where Id = @id", parameter);
        }

        public virtual List<T> GetAll()
        {
         
            return SQLFonction.getList(_connection, $"select * from {_tableName}", mapper).Cast<T>().ToList();

        }

        public virtual T  GetById(int id)
        {
            SqlParameter[] parameter = new SqlParameter[]
          {
                new SqlParameter("id", id)
          };

            return SQLFonction.getOne(_connection, $"select * from {_tableName}", mapper).Cast<T>().ToList();

        }

        public abstract T mapper(SqlDataReader reader);
      
    }

 
}
