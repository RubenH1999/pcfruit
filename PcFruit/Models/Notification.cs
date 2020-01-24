using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public int NotificationSettingsID { get; set; }
        public NotificationSettings NotificationSettings { get; set; }
        public int Temp { get; set; }
        public int RH { get; set; }
    }
}
