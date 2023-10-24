using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace GestionEvent_DAL.Services
{
    public class EventTypeDayService : IEventTypeDay
    {
        //TODO a reverifier
        private readonly EventTypeDayDBService _EventTypeDayDBService;
        public EventTypeDayService(SqlConnection conn){
            _EventTypeDayDBService = new EventTypeDayDBService(conn);
        }
        public bool AddDay(EventTypeDay day)
        {
           return _EventTypeDayDBService.AddDay(day);
        }

        public bool Delete(int id)
        {
            return _EventTypeDayDBService.Delete(id);
        }

      

        public List<EventTypeDay> GetAll()
        {
            return _EventTypeDayDBService.GetAll();
        }
        public EventTypeDay GetById(int id)
        {
            return _EventTypeDayDBService.GetById(id);
        }
        public List<EventTypeDay> GetByEvent(int id)
        {


            return _EventTypeDayDBService.getByEvent(id);
        }

    }
}
