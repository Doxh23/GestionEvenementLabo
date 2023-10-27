

using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.participate
{
    public class ParticipateService : IParticipate
    {
        private readonly ParticipateDBService _participateDBService;

        public ParticipateService(SqlConnection conn)
        {
            _participateDBService = new ParticipateDBService(conn);
        }
        public bool addParticipate(Participate participate)
        {
            return _participateDBService.addParticipate(participate);
        }

        public bool Delete(int id)
        {
            return _participateDBService.Delete(id);
        }

        public List<Participate> GetAll()
        {
            return _participateDBService.GetAll();
        }

        public List<Participate> GetByEvent(int id)
        {
            return _participateDBService.GetByEvent(id);
        }

        public Participate GetById(int id)
        {
           return _participateDBService.GetById(id);
        }
    }
}
