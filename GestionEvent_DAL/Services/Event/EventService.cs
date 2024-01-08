using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.Event
{
    public class EventService : IEvent
    {

        private readonly EventsDBservice _eventDBservice;
        public EventService(SqlConnection sqlconn)
        {
            _eventDBservice = new EventsDBservice(sqlconn);
        }
        public bool Delete(int id)
        {
            return _eventDBservice.Delete(id);
        }

        public List<Model.Event> GetAll()
        {
            return _eventDBservice.GetAll().Where(x => DateTime.Parse( x.EndDate) > DateTime.Now).ToList();
        }

        public Model.Event GetById(int id)
        {
            return _eventDBservice.GetById(id);
        }

        public int AddEvent(Model.Event e)
        {
            return _eventDBservice.AddEvent(e);
        }

  

 
    }
}
