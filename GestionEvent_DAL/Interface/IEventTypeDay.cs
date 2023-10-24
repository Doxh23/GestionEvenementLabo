﻿using GestionEvent_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Interface
{
    public interface IEventTypeDay : IBaseRepository<EventTypeDay>
    {
        bool AddDay(EventTypeDay day);
    }
}
