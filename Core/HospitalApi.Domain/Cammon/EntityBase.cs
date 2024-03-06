using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Cammon
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int CreaterUserId { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public int? LastUserId { get; set; }
        public bool IsActive { get; set; } =true;
        public bool IsDeleted { get; set; }
    }
}
