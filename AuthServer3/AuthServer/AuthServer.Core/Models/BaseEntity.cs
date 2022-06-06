using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Models
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public int CLIENTID { get; set; }
        public bool PENDING_DELETION { get; set; }
        public string DELETED_BY { get; set; }
        public DateTime? DELETED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime? UPDATED_ON { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
    }
}
