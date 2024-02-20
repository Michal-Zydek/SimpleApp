namespace SimpleApp.Database.Configuration.BaseEntity
{
    public interface IBaseEntity<TKey> : IDataEntity<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
