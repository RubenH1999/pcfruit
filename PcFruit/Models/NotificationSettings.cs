using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class NotificationSettings
    {
        public int NotificationSettingsID { get; set; }
        public int NotificationID { get; set; }
        public int ModuleID { get; set; }
        public int MinTemp { get; set; }
        public int MinRH { get; set; }
        public int MaxTemp { get; set;}
        public int MaxRH { get; set; }
        public Module module { get; set; }
        public int UserID { get; set; }
        // user that should be notified for this notification
        public User user { get; set; }

        public bool IsActive { get; set; }
    }
}
