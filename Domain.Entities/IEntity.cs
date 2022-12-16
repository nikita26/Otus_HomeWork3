namespace Domain.Entities
{
    public interface IEntity<T>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        T Id { get; set; }
    }
}