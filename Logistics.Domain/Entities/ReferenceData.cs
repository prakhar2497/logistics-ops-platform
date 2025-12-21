using System.ComponentModel.DataAnnotations;

namespace Logistics.Domain.Entities
{
    public class ReferenceData
    {
        [Key]
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public short SortOrder { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
