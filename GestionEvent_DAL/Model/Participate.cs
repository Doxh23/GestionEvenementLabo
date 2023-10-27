using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Model
{
    public class Participate
    {

        public int Id { get; set; }
        public string Nickname { get; set; }
        public int EventId { get; set; }

        public string Date { get; set; }

        public string Presence { get; set; }
    }
}
