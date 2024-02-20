namespace SimpleApp.Database.Configuration.BaseEntity
{
    public interface IDataEntity<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
