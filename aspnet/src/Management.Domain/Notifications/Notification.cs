using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.Notifications
{
    public class Notification : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string Description  { get; set; }
        public bool Is_seen { get; set; }
        public Guid ID_user { get; set; }
        public Guid ID_repair { get; set; }
        public bool IsDeleted { get; set; }
        private Notification()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal Notification(
               Guid id,
               string description,
               bool is_seen,
               Guid id_user,
               Guid id_repair
           )
           : base(id)
        {
            Description = description;
            Is_seen = is_seen;
            ID_user = id_user;
            ID_repair = id_repair;
        }
    }
}
