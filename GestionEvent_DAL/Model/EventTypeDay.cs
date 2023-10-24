using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Model
{
    public class EventTypeDay
    {

        public int Id { get; set; }
        public EventType Type { get; set; }
        public int EventId { get; set; }

        public string date { get; set; }
    }
}
