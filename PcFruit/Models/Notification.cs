﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public int ModuleID { get; set; }
        public string PhoneNumber { get; set; }
        public int MinTemp { get; set; }
        public int MinRH { get; set; }
        public int MaxTemp { get; set;}
        public int MaxRH { get; set; }

        public Module module { get; set; }
    }
}