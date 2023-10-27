using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.EventType
{
    public class EventTypeDBService : BaseRepository<Model.EventType> , IEventType
    {
        public EventTypeDBService(SqlConnection sqlconn) : base(sqlconn)
        {
        }

        protected override string _tableName
        {
            get
            {
                return "EventType";
            }
        }

        public override Model.EventType mapper(SqlDataReader reader)
        {
            return new Model.EventType()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"]
            };
        }
    }
}
