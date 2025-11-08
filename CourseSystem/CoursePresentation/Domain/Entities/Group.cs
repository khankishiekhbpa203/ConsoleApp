

using Domain.Common;

namespace Domain.Models
{
    public class Group:BaseEntity
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int Room { get; set; }
    }
}
