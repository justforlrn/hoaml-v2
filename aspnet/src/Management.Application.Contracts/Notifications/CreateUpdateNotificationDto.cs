using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.Notifications
{
    public class CreateUpdateNotificationDto
    {
        public string Description { get; set; }
        public bool Is_seen { get; set; }
        public Guid ID_user { get; set; }
        public Guid ID_repair { get; set; }
        public bool IsDeleted { get; set; }
    }
}
