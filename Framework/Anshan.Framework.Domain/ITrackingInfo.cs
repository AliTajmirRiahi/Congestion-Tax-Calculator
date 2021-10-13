using System;

namespace Anshan.Framework.Domain
{
    public class TrackEntity
    {
        public TrackEntity()
        {
            CreatedAt = DateTime.Now.ToShortDateString();
            CreatedDateTimeAt = ModifiedAt = DeletedAt = DateTime.Now;
            IsDeleted = false;
        }
        public string CreatedAt { get; set; }
        public DateTime CreatedDateTimeAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}