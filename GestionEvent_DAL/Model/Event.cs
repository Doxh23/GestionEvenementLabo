using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Model
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string location { get; set; }
         public string Adress { get; set; }

        public Status status { get; set; }  

        

    }
}
