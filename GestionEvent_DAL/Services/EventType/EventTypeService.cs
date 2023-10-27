using GestionEvent_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.EventType
{
    public class EventTypeService : IEventType
    {
        private readonly EventTypeDBService _dbService;
        public EventTypeService(SqlConnection conn)
        {
            _dbService = new EventTypeDBService(conn);
        }
        public bool Delete(int id)
        {
            return _dbService.Delete(id);
        }

        public List<Model.EventType> GetAll()
        {
            return _dbService.GetAll();
        }

        public Model.EventType GetById(int id)
        {
           return _dbService.GetById(id);
        }
    }
}
