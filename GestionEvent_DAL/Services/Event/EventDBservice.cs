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
    public class EventDBservice : BaseRepository<Model.Event>
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
