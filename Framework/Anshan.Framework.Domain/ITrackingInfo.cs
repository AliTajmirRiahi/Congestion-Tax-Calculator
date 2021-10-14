using System;

namespace Anshan.Framework.Domain
{
    public class TrackEntity
    {
        public TrackEntity()
        {
            CreatedAt = ModifiedAt = DeletedAt = DateTime.Now;
            IsDeleted = false;
        }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}