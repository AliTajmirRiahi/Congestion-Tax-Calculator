using System;

namespace Anshan.Framework.Domain
{
    public abstract class Entity<TKey> : TrackEntity
    {
        public TKey Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;
            var otherEntity = obj as Entity<TKey>;
            return Id.Equals(otherEntity.Id);
        }

        public void SetId(TKey id)
        {
            Id = id;
        }

        public void Delete()
        {
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}