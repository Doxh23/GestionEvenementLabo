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
    public class EventService 
    {

        private readonly EventDBservice _eventDBservice;
        public EventService(SqlConnection sqlconn)
        {
            _eventDBservice = new EventDBservice(sqlconn);
        }
        public bool Delete(int id)
        {
            return _eventDBservice.Delete(id);
        }

        public List<Model.Event> GetAll()
        {
            return _eventDBservice.GetAll();
        }

        public Model.Event GetById(int id)
        {
            return _eventDBservice.GetById(id);
        }

 
    }
}
