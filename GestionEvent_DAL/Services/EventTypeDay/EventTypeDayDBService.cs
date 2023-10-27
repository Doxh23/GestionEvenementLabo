using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
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

        protected override string _tableName
        {
            get
            {
                return "EventTypeDay";
            }
        }

        public bool AddDay(Model.EventTypeDay eventDay)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {

                cmd.CommandText = "insert into EventTypeDay values(@TypeId,@EventId,@dateDay)";
                cmd.Parameters.AddWithValue("TypeId", eventDay.Type.Id);
                cmd.Parameters.AddWithValue("dateDay", eventDay.date);
                cmd.Parameters.AddWithValue("EventId", eventDay.EventId); //TODO A MODIFIER (INSERER DES CLASS POUR LES IDS)
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

        public override List<Model.EventTypeDay> GetAll()
        {
            List<Model.EventTypeDay> list = new List<Model.EventTypeDay>();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select e.* , et.Name as Name  from EventTypeDay as e join EventType as et on e.TypeId = et.Id ";
                _connection.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(mapper(r));
                    }
                }
                _connection.Close();
                return list;
            }
        }
        public List<Model.EventTypeDay> getByEvent(int id)
        {
            List<Model.EventTypeDay> list = new List<Model.EventTypeDay>();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"select e.* , et.Name as Name  from EventTypeDay as e join EventType as et on e.TypeId = et.Id where EventId=@id";
                cmd.Parameters.AddWithValue("id", id);
                _connection.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(mapper(r));
                    }
                }
                _connection.Close();
                return list;
            }
        }

        public override Model.EventTypeDay GetById(int id)
        {
            Model.EventTypeDay comments = default(Model.EventTypeDay);
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"select e.* , et.Name as Name  from EventTypeDay as e join EventType as et on e.TypeId = et.Id where Id=@id";
                cmd.Parameters.AddWithValue("id", id);
                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comments = mapper(reader);
                    }
                }
                _connection.Close();
            }
            return comments;
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
