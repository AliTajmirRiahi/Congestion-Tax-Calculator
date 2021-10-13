using Anshan.Framework.Domain;

namespace Anshan.Framework.EF
{
    public class Audit : Entity<long>
    {
        public string AggregateRootName { get; set; }

        public string Values { get; set; }
    }
}