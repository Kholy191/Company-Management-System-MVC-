namespace Kholy.IKEA.DAL.Common.Entites
{
    public class BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public TKey ID { get; set; }

        /*Audit Fields*/
    }
}
