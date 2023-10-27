﻿using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using GestionEvent_DAL.Services.Status;
using GestionEvent_DAL.tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.Event
{
    public class EventDBservice : BaseRepository<Model.Event>, IEvent
    {
        private readonly statusDBService _statusDBService;
        public EventDBservice(SqlConnection sqlconn) : base(sqlconn)
        {
            _statusDBService = new statusDBService(sqlconn);
        }

 

        public bool AddEvent(Model.Event e)
        {


                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@name",e.Name),
                    new SqlParameter("@startDate",e.StartDate),
                    new SqlParameter("@endDate",e.EndDate),
                    new SqlParameter("@location",e.location),
                    new SqlParameter("@adress",e.Adress),
                    new SqlParameter("@statusId",e.status.Id)


                };
          

            return SQLFonction.AlterTable(_connection, $"insert into {_tableName} values(@name,@startDate,@endDate,@location,@adress,@statusId)", parameters);
        }

        //TODO FINIR DE RAJOUTER LES FONCTIONNALITE
        public override List<Model.Event> GetAll()
        {

           
           return  SQLFonction.getList(_connection, $"select e.* , s.Id as IdStatus , s.Name as NameStatus from Events as e join [Status] as s on e.StatusId = s.Id", mapper).Cast<Model.Event>().ToList();


           
        }

        public override Model.Event GetById(int id){
            SqlParameter[] parameters = new SqlParameter[]
                 {
                    new SqlParameter("@id",id),   
                 };
    
            return SQLFonction.getOne(_connection,  $"select e.* , s.Id as IdStatus , s.Name as NameStatus from Events as e join [Status] as s on e.StatusId = s.Id where e.Id = @id", mapper, parameters);
      
            }


        public override Model.Event mapper(SqlDataReader reader)
        {
            return new Model.Event()
            {
                Id = (int)reader["Id"],
                Adress = (string)reader["Adress"],
                Name = (string)reader["Name"],
                StartDate = ((DateTime)reader["StartDate"]).ToString("d"),
                EndDate = ((DateTime)reader["EndDate"]).ToString("d"),
                location = (string)reader["Location"],
                status = new Model.Status() { Id = (int)reader["IdStatus"], Name = (string)reader["NameStatus"] }

            };

        }
    }
}
