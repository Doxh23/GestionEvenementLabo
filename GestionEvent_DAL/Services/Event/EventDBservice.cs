using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using GestionEvent_DAL.Services.Status;
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

        protected override string _tableName
        {
            get
            {
                return "Events";
            }
        }

        public bool AddEvent(Model.Event e)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"insert into {_tableName} values(@name,@startDate,@endDate,@location,@adress,@statusId)";
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
                int row = cmd.ExecuteNonQuery();
                _connection.Close();

                if (row > 0)
                {
                    return true;
                }
                return false;


            }
        }

        //TODO FINIR DE RAJOUTER LES FONCTIONNALITE
        public override List<Model.Event> GetAll()
        {

            List<Model.Event> list = new List<Model.Event>();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"select e.* , s.Id as IdStatus , s.Name as NameStatus from Events as e join [Status] as s on e.StatusId = s.Id";

                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
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

        public override Model.Event GetById(int id){
            Model.Event ev = null;
            using( SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"select e.* , s.Id as IdStatus , s.Name as NameStatus from Events as e join [Status] as s on e.StatusId = s.Id where e.Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ev = mapper(reader);
                    }
                }
                _connection.Close();
            }
            return ev;
        
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
