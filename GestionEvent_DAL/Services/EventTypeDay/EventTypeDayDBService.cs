using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using GestionEvent_DAL.tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services
{//TODO A REVERIFIER
    public class EventTypeDayDBService : BaseRepository<Model.EventTypeDay>, IEventTypeDay
    {
        public EventTypeDayDBService(SqlConnection sqlconn) : base(sqlconn)
        {
        }


        public bool AddDay(Model.EventTypeDay eventDay)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("TypeId", eventDay.Type.Id) ,
                new SqlParameter("dateDay", eventDay.date),
               new SqlParameter("EventId", eventDay.EventId)
            };


            return SQLFonction.AlterTable(_connection, $"insert into {_tableName} values(@TypeId,@EventId,@dateDay)", parameters);
        }

        public override List<Model.EventTypeDay> GetAll()
        {
           
            return SQLFonction.getList(_connection, $@"select e.* , et.Name as Name  from {_tableName} as e 
                                                    join EventType as et on e.TypeId = et.Id ",
                                                    mapper).Cast<Model.EventTypeDay>().ToList();
        }
        public List<Model.EventTypeDay> getByEvent(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("id", id) ,
               
            };
        
            return SQLFonction.getList(_connection, $@"select e.* , et.Name as Name  from {_tableName} as e
                                                    join EventType as et on e.TypeId =
                                                    et.Id where EventId=@id",
                                                    mapper,parameters).Cast<Model.EventTypeDay>().ToList();
        }

        public override Model.EventTypeDay GetById(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("id", id) ,

            };
          

            return SQLFonction.getOne(_connection, $@"select e.* , et.Name as Name  from {_tableName}
                                                   as e join EventType as et 
                                                   on e.TypeId = et.Id where Id=@id",
                                                   mapper,parameters);
        }

        public override Model.EventTypeDay mapper(SqlDataReader reader)
        {
            return new Model.EventTypeDay()
            {
                Id = (int)reader["Id"],
                EventId = (int)reader["EventId"],
                Type = new Model.EventType()
                {
                    Id = (int)reader["TypeId"],
                    Name = (string)reader["Name"],
                },
                date = ((DateTime)reader["Date"]).ToString("d")

            };
        }


    }
}
