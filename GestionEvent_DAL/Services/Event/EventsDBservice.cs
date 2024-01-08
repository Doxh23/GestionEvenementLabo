using GestionEvent_DAL.Interface;
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
    public class EventsDBservice : BaseRepository<Model.Event>, IEvent
    {
        private readonly statusDBService _statusDBService;
        public EventsDBservice(SqlConnection sqlconn) : base(sqlconn)
        {
            _statusDBService = new statusDBService(sqlconn);
        }



        public int AddEvent(Model.Event e)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"insert into {_tableName} output Inserted.Id values(@name,@startDate,@endDate,@location,@adress,@statusId)";
                SqlParameter[] parameters = new SqlParameter[]
                               {
                    new SqlParameter("@name",e.Name),
                    new SqlParameter("@startDate",e.StartDate),
                    new SqlParameter("@endDate",e.EndDate),
                    new SqlParameter("@location",e.location),
                    new SqlParameter("@adress",e.Adress),
                    new SqlParameter("@statusId",e.status.Id)


                               };
                cmd.Parameters.AddRange(parameters);
                _connection.Open();
                int id = (int)cmd.ExecuteScalar();
                _connection.Close();
                return id;


            }




        }

        //TODO FINIR DE RAJOUTER LES FONCTIONNALITE
        public override List<Model.Event> GetAll()
        {


            return SQLFonction.getList(_connection, $"select e.* , s.Id as IdStatus , s.Name as NameStatus from Events as e join [Status] as s on e.StatusId = s.Id", mapper).Cast<Model.Event>().ToList();



        }

        public override Model.Event GetById(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
                 {
                    new SqlParameter("@id",id),
                 };

            return SQLFonction.getOne(_connection, $"select e.* , s.Id as IdStatus , s.Name as NameStatus from Events as e join [Status] as s on e.StatusId = s.Id where e.Id = @id", mapper, parameters);

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
