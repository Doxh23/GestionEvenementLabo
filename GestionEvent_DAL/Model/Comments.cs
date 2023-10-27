using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Model
{
    public class Comments
    {

        public int Id { get; set; }
        public string content { get; set; }
        public int UserId { get; set; }
        public string PostDate { get; set; }

        public int EventId { get; set; }
    }
}
