namespace SimpleApp.Database.Configuration.BaseEntity
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
